namespace CapptaDnsHelper
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.googleDnsButton = new System.Windows.Forms.Button();
			this.openDnsButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// googleDnsButton
			// 
			this.googleDnsButton.Location = new System.Drawing.Point(12, 12);
			this.googleDnsButton.Name = "googleDnsButton";
			this.googleDnsButton.Size = new System.Drawing.Size(260, 48);
			this.googleDnsButton.TabIndex = 0;
			this.googleDnsButton.Text = "Configurar para Google\r\n8.8.8.8 e 8.8.4.4";
			this.googleDnsButton.UseVisualStyleBackColor = true;
			this.googleDnsButton.Click += new System.EventHandler(this.googleDnsButton_Click);
			// 
			// openDnsButton
			// 
			this.openDnsButton.Location = new System.Drawing.Point(12, 66);
			this.openDnsButton.Name = "openDnsButton";
			this.openDnsButton.Size = new System.Drawing.Size(260, 48);
			this.openDnsButton.TabIndex = 1;
			this.openDnsButton.Text = "Configurar para OpenDNS\r\n208.67.222.222 e 208.67.220.220";
			this.openDnsButton.UseVisualStyleBackColor = true;
			this.openDnsButton.Click += new System.EventHandler(this.openDnsButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 131);
			this.Controls.Add(this.openDnsButton);
			this.Controls.Add(this.googleDnsButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "MainForm";
			this.Text = "Utilitario de DNS da Cappta";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button googleDnsButton;
		private System.Windows.Forms.Button openDnsButton;
	}
}

