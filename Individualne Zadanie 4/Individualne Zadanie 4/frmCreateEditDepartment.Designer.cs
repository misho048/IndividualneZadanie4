namespace Individualne_Zadanie_4
{
    partial class FrmCreateEditDepartment
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
            this.lblChooseName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.txtBoxCode = new System.Windows.Forms.TextBox();
            this.btnCreateBoss = new System.Windows.Forms.Button();
            this.lblBossName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblChooseName
            // 
            this.lblChooseName.AutoSize = true;
            this.lblChooseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblChooseName.Location = new System.Drawing.Point(22, 31);
            this.lblChooseName.Name = "lblChooseName";
            this.lblChooseName.Size = new System.Drawing.Size(166, 25);
            this.lblChooseName.TabIndex = 0;
            this.lblChooseName.Text = "Choose Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(27, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose Code:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnConfirm.Location = new System.Drawing.Point(27, 296);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(165, 53);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBack.Location = new System.Drawing.Point(341, 296);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(220, 53);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(194, 36);
            this.txtBoxName.MaxLength = 49;
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(367, 20);
            this.txtBoxName.TabIndex = 4;
            // 
            // txtBoxCode
            // 
            this.txtBoxCode.Location = new System.Drawing.Point(194, 112);
            this.txtBoxCode.MaxLength = 19;
            this.txtBoxCode.Name = "txtBoxCode";
            this.txtBoxCode.Size = new System.Drawing.Size(367, 20);
            this.txtBoxCode.TabIndex = 5;
            // 
            // btnCreateBoss
            // 
            this.btnCreateBoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCreateBoss.Location = new System.Drawing.Point(27, 226);
            this.btnCreateBoss.Name = "btnCreateBoss";
            this.btnCreateBoss.Size = new System.Drawing.Size(534, 41);
            this.btnCreateBoss.TabIndex = 8;
            this.btnCreateBoss.Text = "Choose Boss";
            this.btnCreateBoss.UseVisualStyleBackColor = true;
            this.btnCreateBoss.Click += new System.EventHandler(this.Button1_Click);
            // 
            // lblBossName
            // 
            this.lblBossName.AutoSize = true;
            this.lblBossName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBossName.Location = new System.Drawing.Point(27, 168);
            this.lblBossName.Name = "lblBossName";
            this.lblBossName.Size = new System.Drawing.Size(0, 25);
            this.lblBossName.TabIndex = 9;
            // 
            // frmCreateDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 378);
            this.Controls.Add(this.lblBossName);
            this.Controls.Add(this.btnCreateBoss);
            this.Controls.Add(this.txtBoxCode);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblChooseName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCreateDepartment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCreateCompany";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChooseName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.TextBox txtBoxCode;
        private System.Windows.Forms.Button btnCreateBoss;
        private System.Windows.Forms.Label lblBossName;
    }
}