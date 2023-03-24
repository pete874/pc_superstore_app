namespace pc_superstore_app
{
    partial class Sisaankirjautuminen_form
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
            this.KayttajatunnusTB = new System.Windows.Forms.TextBox();
            this.SalasanaTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.KirjauduBT = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.RekisteroidyLB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kirjautumissivu";
            // 
            // KayttajatunnusTB
            // 
            this.KayttajatunnusTB.Location = new System.Drawing.Point(105, 147);
            this.KayttajatunnusTB.Name = "KayttajatunnusTB";
            this.KayttajatunnusTB.Size = new System.Drawing.Size(173, 20);
            this.KayttajatunnusTB.TabIndex = 1;
            // 
            // SalasanaTB
            // 
            this.SalasanaTB.Location = new System.Drawing.Point(105, 217);
            this.SalasanaTB.Name = "SalasanaTB";
            this.SalasanaTB.Size = new System.Drawing.Size(173, 20);
            this.SalasanaTB.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(114, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Syötä Käyttäjätunnus";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(133, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Syötä Salasana";
            // 
            // KirjauduBT
            // 
            this.KirjauduBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KirjauduBT.Location = new System.Drawing.Point(158, 255);
            this.KirjauduBT.Name = "KirjauduBT";
            this.KirjauduBT.Size = new System.Drawing.Size(75, 23);
            this.KirjauduBT.TabIndex = 5;
            this.KirjauduBT.Text = "Kirjaudu";
            this.KirjauduBT.UseVisualStyleBackColor = true;
            this.KirjauduBT.Click += new System.EventHandler(this.KirjauduBT_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 379);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Eikö sinulla ole tunnuksia?";
            // 
            // RekisteroidyLB
            // 
            this.RekisteroidyLB.AutoSize = true;
            this.RekisteroidyLB.ForeColor = System.Drawing.SystemColors.Highlight;
            this.RekisteroidyLB.Location = new System.Drawing.Point(168, 403);
            this.RekisteroidyLB.Name = "RekisteroidyLB";
            this.RekisteroidyLB.Size = new System.Drawing.Size(65, 13);
            this.RekisteroidyLB.TabIndex = 7;
            this.RekisteroidyLB.Text = "Rekisteröidy";
            this.RekisteroidyLB.Click += new System.EventHandler(this.RekisteroidyLB_Click);
            // 
            // Sisaankirjautuminen_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 425);
            this.Controls.Add(this.RekisteroidyLB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.KirjauduBT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SalasanaTB);
            this.Controls.Add(this.KayttajatunnusTB);
            this.Controls.Add(this.label1);
            this.Name = "Sisaankirjautuminen_form";
            this.Text = "Sisäänkirjautuminen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox KayttajatunnusTB;
        private System.Windows.Forms.TextBox SalasanaTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button KirjauduBT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label RekisteroidyLB;
    }
}

