namespace pc_superstore_app
{
    partial class Rekisteroidy_form
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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.EmailTB = new System.Windows.Forms.TextBox();
            this.KayttajatunnusTB = new System.Windows.Forms.TextBox();
            this.SalasanaTB = new System.Windows.Forms.TextBox();
            this.RekisteroidyBT = new System.Windows.Forms.Button();
            this.PeruutaBT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Täytä kentät";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(89, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Käyttäjätunnus";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(90, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Salasana";
            // 
            // EmailTB
            // 
            this.EmailTB.Location = new System.Drawing.Point(92, 120);
            this.EmailTB.Name = "EmailTB";
            this.EmailTB.Size = new System.Drawing.Size(170, 20);
            this.EmailTB.TabIndex = 7;
            // 
            // KayttajatunnusTB
            // 
            this.KayttajatunnusTB.Location = new System.Drawing.Point(92, 198);
            this.KayttajatunnusTB.Name = "KayttajatunnusTB";
            this.KayttajatunnusTB.Size = new System.Drawing.Size(170, 20);
            this.KayttajatunnusTB.TabIndex = 8;
            // 
            // SalasanaTB
            // 
            this.SalasanaTB.Location = new System.Drawing.Point(92, 273);
            this.SalasanaTB.Name = "SalasanaTB";
            this.SalasanaTB.Size = new System.Drawing.Size(170, 20);
            this.SalasanaTB.TabIndex = 9;
            // 
            // RekisteroidyBT
            // 
            this.RekisteroidyBT.Location = new System.Drawing.Point(93, 329);
            this.RekisteroidyBT.Name = "RekisteroidyBT";
            this.RekisteroidyBT.Size = new System.Drawing.Size(75, 23);
            this.RekisteroidyBT.TabIndex = 11;
            this.RekisteroidyBT.Text = "Rekisteröidy";
            this.RekisteroidyBT.UseVisualStyleBackColor = true;
            this.RekisteroidyBT.Click += new System.EventHandler(this.RekisteroidyBT_Click);
            // 
            // PeruutaBT
            // 
            this.PeruutaBT.Location = new System.Drawing.Point(187, 329);
            this.PeruutaBT.Name = "PeruutaBT";
            this.PeruutaBT.Size = new System.Drawing.Size(75, 23);
            this.PeruutaBT.TabIndex = 12;
            this.PeruutaBT.Text = "Peruuta";
            this.PeruutaBT.UseVisualStyleBackColor = true;
            // 
            // Rekisteroidy_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 443);
            this.Controls.Add(this.PeruutaBT);
            this.Controls.Add(this.RekisteroidyBT);
            this.Controls.Add(this.SalasanaTB);
            this.Controls.Add(this.KayttajatunnusTB);
            this.Controls.Add(this.EmailTB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "Rekisteroidy_form";
            this.Text = "Rekisteröidy";
            this.Load += new System.EventHandler(this.Rekisteroidy_form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox EmailTB;
        private System.Windows.Forms.TextBox KayttajatunnusTB;
        private System.Windows.Forms.TextBox SalasanaTB;
        private System.Windows.Forms.Button RekisteroidyBT;
        private System.Windows.Forms.Button PeruutaBT;
    }
}