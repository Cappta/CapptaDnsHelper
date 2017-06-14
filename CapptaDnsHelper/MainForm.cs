using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Windows.Forms;

namespace CapptaDnsHelper
{
	public partial class MainForm : Form
	{
		private static readonly string[] googleDns = new string[] { "8.8.8.8", "8.8.4.4" };
		private static readonly string[] openDns = new string[] { "208.67.222.222", "208.67.220.220" };

		public MainForm()
		{
			InitializeComponent();
		}

		private IEnumerable<string> SetDns(string[] dns)
		{
			var networkAdapterConfiguration = new ManagementClass("Win32_NetworkAdapterConfiguration");
			var networkAdapterConfigurationInstances = networkAdapterConfiguration.GetInstances();

			foreach (var managementBaseObject in networkAdapterConfigurationInstances)
			{
				var networkAdapter = managementBaseObject as ManagementObject;

				if ((bool)networkAdapter["IPEnabled"] == false) { continue; }

				try
				{
					var newDNS = networkAdapter.GetMethodParameters("SetDNSServerSearchOrder");
					newDNS["DNSServerSearchOrder"] = dns;
					var setDNS = networkAdapter.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
					var result = (uint)setDNS["returnValue"];
					if (result != 0) { continue; }
				}
				catch { continue; }

				yield return (string)networkAdapter["Caption"];
			}
		}

		private void SetDnsAndNotify(string[] dns)
		{
			var updatedAdapters = this.SetDns(dns).ToArray();
			switch (updatedAdapters.Length)
			{
				case 0: MessageBox.Show(this, "Não conseguimos alterar o DNS", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
				case 1: MessageBox.Show(this, $"Alteramos o DNS do adaptador de rede \"{updatedAdapters.First()}\" para {string.Join(" e ", dns)}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
				default: MessageBox.Show(this, $"Alteramos o DNS dos adaptador de rede \"{string.Join("\", \"", updatedAdapters)}\" para {string.Join(" e ", dns)}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
			}
		}

		private void googleDnsButton_Click(object sender, EventArgs e)
		{
			this.SetDnsAndNotify(googleDns);
		}

		private void openDnsButton_Click(object sender, EventArgs e)
		{
			this.SetDnsAndNotify(openDns);
		}
	}
}
