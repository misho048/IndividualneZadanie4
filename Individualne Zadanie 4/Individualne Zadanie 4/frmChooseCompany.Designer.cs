namespace Individualne_Zadanie_4
{
    partial class frmChooseCompany
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
            this.cmbCompanies = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCreateCompany = new System.Windows.Forms.Button();
            this.btnEditCompany = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbCompanies
            // 
            this.cmbCompanies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompanies.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbCompanies.FormattingEnabled = true;
            this.cmbCompanies.Location = new System.Drawing.Point(23, 290);
            this.cmbCompanies.Name = "cmbCompanies";
            this.cmbCompanies.Size = new System.Drawing.Size(299, 33);
            this.cmbCompanies.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(125, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose Company";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnConfirm.Location = new System.Drawing.Point(23, 338);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(149, 59);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(175, 338);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 59);
            this.button2.TabIndex = 3;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCreateCompany
            // 
            this.btnCreateCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCreateCompany.Location = new System.Drawing.Point(23, 31);
            this.btnCreateCompany.Name = "btnCreateCompany";
            this.btnCreateCompany.Size = new System.Drawing.Size(299, 44);
            this.btnCreateCompany.TabIndex = 4;
            this.btnCreateCompany.Text = "Create Company";
            this.btnCreateCompany.UseVisualStyleBackColor = true;
            this.btnCreateCompany.Click += new System.EventHandler(this.btnCreateCompany_Click);
            // 
            // btnEditCompany
            // 
            this.btnEditCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEditCompany.Location = new System.Drawing.Point(23, 95);
            this.btnEditCompany.Name = "btnEditCompany";
            this.btnEditCompany.Size = new System.Drawing.Size(299, 44);
            this.btnEditCompany.TabIndex = 5;
            this.btnEditCompany.Text = "Edit Company";
            this.btnEditCompany.UseVisualStyleBackColor = true;
            this.btnEditCompany.Click += new System.EventHandler(this.btnEditCompany_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDelete.Location = new System.Drawing.Point(23, 186);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(299, 44);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete Company";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmChooseCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 409);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEditCompany);
            this.Controls.Add(this.btnCreateCompany);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCompanies);
            this.Name = "frmChooseCompany";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmChooseCompany_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCompanies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCreateCompany;
        private System.Windows.Forms.Button btnEditCompany;
        private System.Windows.Forms.Button btnDelete;
    }
}

