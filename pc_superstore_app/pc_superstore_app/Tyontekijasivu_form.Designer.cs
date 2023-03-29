namespace pc_superstore_app
{
    partial class Tyontekijasivu_form
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
            this.TyontekijaEtusivuPN = new System.Windows.Forms.Panel();
            this.VarastoBT = new System.Windows.Forms.Button();
            this.TilauksetBT = new System.Windows.Forms.Button();
            this.AsiakkaatBT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.AsiakkaatPN = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.AsiakkaatDG = new System.Windows.Forms.DataGridView();
            this.TilauksetPN = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.VarastoPN = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.AlaPN = new System.Windows.Forms.Panel();
            this.TyontekijaEtusivuPN.SuspendLayout();
            this.AsiakkaatPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AsiakkaatDG)).BeginInit();
            this.TilauksetPN.SuspendLayout();
            this.VarastoPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // TyontekijaEtusivuPN
            // 
            this.TyontekijaEtusivuPN.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TyontekijaEtusivuPN.Controls.Add(this.VarastoBT);
            this.TyontekijaEtusivuPN.Controls.Add(this.TilauksetBT);
            this.TyontekijaEtusivuPN.Controls.Add(this.AsiakkaatBT);
            this.TyontekijaEtusivuPN.Controls.Add(this.label1);
            this.TyontekijaEtusivuPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.TyontekijaEtusivuPN.Location = new System.Drawing.Point(0, 0);
            this.TyontekijaEtusivuPN.Name = "TyontekijaEtusivuPN";
            this.TyontekijaEtusivuPN.Size = new System.Drawing.Size(1133, 100);
            this.TyontekijaEtusivuPN.TabIndex = 0;
            // 
            // VarastoBT
            // 
            this.VarastoBT.Location = new System.Drawing.Point(718, 55);
            this.VarastoBT.Name = "VarastoBT";
            this.VarastoBT.Size = new System.Drawing.Size(92, 32);
            this.VarastoBT.TabIndex = 3;
            this.VarastoBT.Text = "Varasto";
            this.VarastoBT.UseVisualStyleBackColor = true;
            this.VarastoBT.Click += new System.EventHandler(this.VarastoBT_Click);
            // 
            // TilauksetBT
            // 
            this.TilauksetBT.Location = new System.Drawing.Point(513, 55);
            this.TilauksetBT.Name = "TilauksetBT";
            this.TilauksetBT.Size = new System.Drawing.Size(92, 32);
            this.TilauksetBT.TabIndex = 2;
            this.TilauksetBT.Text = "Tilaukset";
            this.TilauksetBT.UseVisualStyleBackColor = true;
            this.TilauksetBT.Click += new System.EventHandler(this.TilauksetBT_Click);
            // 
            // AsiakkaatBT
            // 
            this.AsiakkaatBT.Location = new System.Drawing.Point(306, 55);
            this.AsiakkaatBT.Name = "AsiakkaatBT";
            this.AsiakkaatBT.Size = new System.Drawing.Size(92, 32);
            this.AsiakkaatBT.TabIndex = 1;
            this.AsiakkaatBT.Text = "Asiakkaat";
            this.AsiakkaatBT.UseVisualStyleBackColor = true;
            this.AsiakkaatBT.Click += new System.EventHandler(this.AsiakkaatBT_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 78);
            this.label1.TabIndex = 0;
            this.label1.Text = "     PC\r\nSuperstore";
            // 
            // AsiakkaatPN
            // 
            this.AsiakkaatPN.Controls.Add(this.label3);
            this.AsiakkaatPN.Controls.Add(this.AsiakkaatDG);
            this.AsiakkaatPN.Location = new System.Drawing.Point(0, 106);
            this.AsiakkaatPN.Name = "AsiakkaatPN";
            this.AsiakkaatPN.Size = new System.Drawing.Size(1133, 500);
            this.AsiakkaatPN.TabIndex = 3;
            this.AsiakkaatPN.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Asiakkaat";
            // 
            // AsiakkaatDG
            // 
            this.AsiakkaatDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AsiakkaatDG.Location = new System.Drawing.Point(545, 3);
            this.AsiakkaatDG.Name = "AsiakkaatDG";
            this.AsiakkaatDG.Size = new System.Drawing.Size(576, 500);
            this.AsiakkaatDG.TabIndex = 0;
            // 
            // TilauksetPN
            // 
            this.TilauksetPN.Controls.Add(this.label4);
            this.TilauksetPN.Location = new System.Drawing.Point(0, 106);
            this.TilauksetPN.Name = "TilauksetPN";
            this.TilauksetPN.Size = new System.Drawing.Size(1130, 503);
            this.TilauksetPN.TabIndex = 2;
            this.TilauksetPN.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tilaukset";
            // 
            // VarastoPN
            // 
            this.VarastoPN.Controls.Add(this.label5);
            this.VarastoPN.Location = new System.Drawing.Point(0, 106);
            this.VarastoPN.Name = "VarastoPN";
            this.VarastoPN.Size = new System.Drawing.Size(1130, 503);
            this.VarastoPN.TabIndex = 1;
            this.VarastoPN.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(521, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Varasto";
            // 
            // AlaPN
            // 
            this.AlaPN.BackColor = System.Drawing.SystemColors.ControlText;
            this.AlaPN.Location = new System.Drawing.Point(0, 615);
            this.AlaPN.Name = "AlaPN";
            this.AlaPN.Size = new System.Drawing.Size(1133, 65);
            this.AlaPN.TabIndex = 4;
            // 
            // Tyontekijasivu_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 678);
            this.Controls.Add(this.AlaPN);
            this.Controls.Add(this.TyontekijaEtusivuPN);
            this.Controls.Add(this.VarastoPN);
            this.Controls.Add(this.TilauksetPN);
            this.Controls.Add(this.AsiakkaatPN);
            this.Name = "Tyontekijasivu_form";
            this.Text = "Tyontekijasivu_form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Tyontekijasivu_form_FormClosed);
            this.Load += new System.EventHandler(this.Tyontekijasivu_form_Load);
            this.TyontekijaEtusivuPN.ResumeLayout(false);
            this.TyontekijaEtusivuPN.PerformLayout();
            this.AsiakkaatPN.ResumeLayout(false);
            this.AsiakkaatPN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AsiakkaatDG)).EndInit();
            this.TilauksetPN.ResumeLayout(false);
            this.TilauksetPN.PerformLayout();
            this.VarastoPN.ResumeLayout(false);
            this.VarastoPN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TyontekijaEtusivuPN;
        private System.Windows.Forms.Button VarastoBT;
        private System.Windows.Forms.Button TilauksetBT;
        private System.Windows.Forms.Button AsiakkaatBT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel AsiakkaatPN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView AsiakkaatDG;
        private System.Windows.Forms.Panel TilauksetPN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel VarastoPN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel AlaPN;
    }
}