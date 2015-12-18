namespace SalesforceREST
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
            this.UIWebBrowser = new System.Windows.Forms.WebBrowser();
            this.UIResults = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UIWebBrowser
            // 
            this.UIWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.UIWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.UIWebBrowser.Name = "UIWebBrowser";
            this.UIWebBrowser.Size = new System.Drawing.Size(462, 542);
            this.UIWebBrowser.TabIndex = 0;
            this.UIWebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.UIwebBrowser_DocumentCompleted);
            // 
            // UIResults
            // 
            this.UIResults.Location = new System.Drawing.Point(468, 12);
            this.UIResults.Multiline = true;
            this.UIResults.Name = "UIResults";
            this.UIResults.Size = new System.Drawing.Size(330, 303);
            this.UIResults.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 541);
            this.Controls.Add(this.UIResults);
            this.Controls.Add(this.UIWebBrowser);
            this.Name = "MainForm";
            this.Text = "Salesforce.com REST Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser UIWebBrowser;
        private System.Windows.Forms.TextBox UIResults;
    }
}

