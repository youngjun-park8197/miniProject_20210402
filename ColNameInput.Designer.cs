
namespace DBManager
{
    partial class ColinputFrm
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
            this.ColName = new System.Windows.Forms.Label();
            this.tbColName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ColName
            // 
            this.ColName.AutoSize = true;
            this.ColName.Location = new System.Drawing.Point(12, 9);
            this.ColName.Name = "ColName";
            this.ColName.Size = new System.Drawing.Size(88, 15);
            this.ColName.TabIndex = 0;
            this.ColName.Text = "Input name :";
            // 
            // tbColName
            // 
            this.tbColName.Location = new System.Drawing.Point(12, 34);
            this.tbColName.Name = "tbColName";
            this.tbColName.Size = new System.Drawing.Size(326, 25);
            this.tbColName.TabIndex = 1;
            this.tbColName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbColName_KeyDown);
            // 
            // ColinputFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 71);
            this.Controls.Add(this.tbColName);
            this.Controls.Add(this.ColName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColinputFrm";
            this.Text = "ColinputFrm";
            this.Load += new System.EventHandler(this.ColinputFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ColName;
        private System.Windows.Forms.TextBox tbColName;
    }
}