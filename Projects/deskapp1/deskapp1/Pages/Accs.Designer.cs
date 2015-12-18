namespace deskapp1.Pages
{
    partial class Accs
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.bckBttn = new System.Windows.Forms.Button();
            this.Label_Status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(178, 234);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // bckBttn
            // 
            this.bckBttn.Location = new System.Drawing.Point(206, 235);
            this.bckBttn.Name = "bckBttn";
            this.bckBttn.Size = new System.Drawing.Size(75, 23);
            this.bckBttn.TabIndex = 1;
            this.bckBttn.Text = "Back";
            this.bckBttn.UseVisualStyleBackColor = true;
            this.bckBttn.Click += new System.EventHandler(this.bckBttn_Click);
            // 
            // Label_Status
            // 
            this.Label_Status.AutoSize = true;
            this.Label_Status.Location = new System.Drawing.Point(203, 9);
            this.Label_Status.Name = "Label_Status";
            this.Label_Status.Size = new System.Drawing.Size(0, 13);
            this.Label_Status.TabIndex = 2;
            // 
            // Accs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Label_Status);
            this.Controls.Add(this.bckBttn);
            this.Controls.Add(this.listView1);
            this.Name = "Accs";
            this.Text = "Accs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button bckBttn;
        private System.Windows.Forms.Label Label_Status;
    }
}