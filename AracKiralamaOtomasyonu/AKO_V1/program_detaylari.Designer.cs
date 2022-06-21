namespace WindowsFormsApplication1
{
    partial class program_detaylari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(program_detaylari));
            this.arkaplan_yesil_ton_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // arkaplan_yesil_ton_label
            // 
            this.arkaplan_yesil_ton_label.AutoSize = true;
            this.arkaplan_yesil_ton_label.Cursor = System.Windows.Forms.Cursors.Default;
            this.arkaplan_yesil_ton_label.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.arkaplan_yesil_ton_label.Location = new System.Drawing.Point(12, 9);
            this.arkaplan_yesil_ton_label.Name = "arkaplan_yesil_ton_label";
            this.arkaplan_yesil_ton_label.Size = new System.Drawing.Size(294, 144);
            this.arkaplan_yesil_ton_label.TabIndex = 41;
            this.arkaplan_yesil_ton_label.Text = resources.GetString("arkaplan_yesil_ton_label.Text");
            // 
            // program_detaylari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(326, 164);
            this.Controls.Add(this.arkaplan_yesil_ton_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "program_detaylari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Program Detayları";
            this.Load += new System.EventHandler(this.program_detaylari_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label arkaplan_yesil_ton_label;
    }
}