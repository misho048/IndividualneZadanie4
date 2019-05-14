namespace Individualne_Zadanie_4
{
    partial class frmEmployeesOverView
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dGVOverview = new System.Windows.Forms.DataGridView();
            this.btnAllEmployees = new System.Windows.Forms.Button();
            this.btnUnsignedEmployees = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVOverview)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDelete.Location = new System.Drawing.Point(598, 319);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(191, 53);
            this.btnDelete.TabIndex = 26;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEdit.Location = new System.Drawing.Point(598, 240);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(191, 53);
            this.btnEdit.TabIndex = 25;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSelect.Location = new System.Drawing.Point(598, 30);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(191, 53);
            this.btnSelect.TabIndex = 24;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBack.Location = new System.Drawing.Point(598, 504);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(191, 53);
            this.btnBack.TabIndex = 23;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // dGVOverview
            // 
            this.dGVOverview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVOverview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVOverview.Location = new System.Drawing.Point(12, 91);
            this.dGVOverview.Name = "dGVOverview";
            this.dGVOverview.ReadOnly = true;
            this.dGVOverview.RowHeadersVisible = false;
            this.dGVOverview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVOverview.Size = new System.Drawing.Size(567, 489);
            this.dGVOverview.TabIndex = 21;
            // 
            // btnAllEmployees
            // 
            this.btnAllEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAllEmployees.Location = new System.Drawing.Point(12, 12);
            this.btnAllEmployees.Name = "btnAllEmployees";
            this.btnAllEmployees.Size = new System.Drawing.Size(191, 53);
            this.btnAllEmployees.TabIndex = 27;
            this.btnAllEmployees.Text = "All Employees";
            this.btnAllEmployees.UseVisualStyleBackColor = true;
            this.btnAllEmployees.Click += new System.EventHandler(this.btnAllEmployees_Click);
            // 
            // btnUnsignedEmployees
            // 
            this.btnUnsignedEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUnsignedEmployees.Location = new System.Drawing.Point(238, 12);
            this.btnUnsignedEmployees.Name = "btnUnsignedEmployees";
            this.btnUnsignedEmployees.Size = new System.Drawing.Size(247, 53);
            this.btnUnsignedEmployees.TabIndex = 28;
            this.btnUnsignedEmployees.Text = "Unsigned Employees";
            this.btnUnsignedEmployees.UseVisualStyleBackColor = true;
            this.btnUnsignedEmployees.Click += new System.EventHandler(this.btnUnsignedEmployees_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCreate.Location = new System.Drawing.Point(598, 159);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(191, 53);
            this.btnCreate.TabIndex = 29;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // frmEmployeesOverView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 610);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnUnsignedEmployees);
            this.Controls.Add(this.btnAllEmployees);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dGVOverview);
            this.Name = "frmEmployeesOverView";
            this.Text = "frmEmployees";
            this.Load += new System.EventHandler(this.frmEmployeesOverView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVOverview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dGVOverview;
        private System.Windows.Forms.Button btnAllEmployees;
        private System.Windows.Forms.Button btnUnsignedEmployees;
        private System.Windows.Forms.Button btnCreate;
    }
}