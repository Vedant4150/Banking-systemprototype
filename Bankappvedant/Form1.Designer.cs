using System.Drawing;
using System.Windows.Forms;

namespace Bankappvedant
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtcustomerid = new TextBox();
            lblCustomerId = new Label();
            lblName = new Label();
            textname = new TextBox();
            txtEmailcustomer = new TextBox();
            lblEmail = new Label();
            chkisstaff = new CheckBox();
            btnAdd = new Button();
            btnupdate = new Button();
            btndelete = new Button();
            dgvcustomers = new DataGridView();
            lblTitle = new Label();
            btnManageAccounts = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvcustomers).BeginInit();
            SuspendLayout();
            // 
            // txtcustomerid
            // 
            txtcustomerid.Location = new Point(60, 95);
            txtcustomerid.Name = "txtcustomerid";
            txtcustomerid.ReadOnly = true;
            txtcustomerid.Size = new Size(180, 39);
            // 
            // lblCustomerId
            // 
            lblCustomerId.AutoSize = true;
            lblCustomerId.Location = new Point(60, 60);
            lblCustomerId.Name = "lblCustomerId";
            lblCustomerId.Size = new Size(137, 32);
            lblCustomerId.Text = "Customer ID";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(280, 60);
            lblName.Name = "lblName";
            lblName.Size = new Size(78, 32);
            lblName.Text = "Name";
            // 
            // textname
            // 
            textname.Location = new Point(280, 95);
            textname.Name = "textname";
            textname.Size = new Size(220, 39);
            // 
            // txtEmailcustomer
            // 
            txtEmailcustomer.Location = new Point(540, 95);
            txtEmailcustomer.Name = "txtEmailcustomer";
            txtEmailcustomer.Size = new Size(260, 39);
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(540, 60);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(71, 32);
            lblEmail.Text = "Email";
            // 
            // chkisstaff
            // 
            chkisstaff.AutoSize = true;
            chkisstaff.Location = new Point(60, 160);
            chkisstaff.Name = "chkisstaff";
            chkisstaff.Size = new Size(119, 36);
            chkisstaff.Text = "Is Staff";
            chkisstaff.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(60, 220);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(170, 50);
            btnAdd.Text = "Add Customer";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnupdate
            // 
            btnupdate.Location = new Point(250, 220);
            btnupdate.Name = "btnupdate";
            btnupdate.Size = new Size(190, 50);
            btnupdate.Text = "Update Customer";
            btnupdate.UseVisualStyleBackColor = true;
            btnupdate.Click += btnupdate_Click;
            // 
            // btndelete
            // 
            btndelete.Location = new Point(460, 220);
            btndelete.Name = "btndelete";
            btndelete.Size = new Size(190, 50);
            btndelete.Text = "Delete Customer";
            btndelete.UseVisualStyleBackColor = true;
            btndelete.Click += btndelete_Click;
            // 
            // dgvcustomers
            // 
            dgvcustomers.AllowUserToAddRows = false;
            dgvcustomers.AllowUserToDeleteRows = false;
            dgvcustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvcustomers.BackgroundColor = SystemColors.ButtonHighlight;
            dgvcustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvcustomers.Location = new Point(60, 310);
            dgvcustomers.MultiSelect = false;
            dgvcustomers.Name = "dgvcustomers";
            dgvcustomers.ReadOnly = true;
            dgvcustomers.RowHeadersWidth = 82;
            dgvcustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvcustomers.Size = new Size(950, 320);
            dgvcustomers.CellClick += dgvcustomers_CellClick;
            dgvcustomers.DataError += dgvcustomers_DataError;
            dgvcustomers.AllowUserToAddRows = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(60, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(345, 59);
            lblTitle.Text = "Customer Management";
            // 
            // btnManageAccounts
            // 
            btnManageAccounts.Location = new Point(670, 220);
            btnManageAccounts.Name = "btnManageAccounts";
            btnManageAccounts.Size = new Size(250, 50);
            btnManageAccounts.Text = "Manage Accounts";
            btnManageAccounts.UseVisualStyleBackColor = true;
            btnManageAccounts.Click += btnManageAccounts_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1100, 700);
            Controls.Add(btnManageAccounts);
            Controls.Add(lblTitle);
            Controls.Add(dgvcustomers);
            Controls.Add(btndelete);
            Controls.Add(btnupdate);
            Controls.Add(btnAdd);
            Controls.Add(chkisstaff);
            Controls.Add(lblEmail);
            Controls.Add(txtEmailcustomer);
            Controls.Add(textname);
            Controls.Add(lblName);
            Controls.Add(lblCustomerId);
            Controls.Add(txtcustomerid);
            Name = "Form1";
            Text = "Bankapp";
            Load += Form1_Load;
            FormClosing += Form1_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvcustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtcustomerid;
        private Label lblCustomerId;
        private Label lblName;
        private TextBox textname;
        private TextBox txtEmailcustomer;
        private Label lblEmail;
        private CheckBox chkisstaff;
        private Button btnAdd;
        private Button btnupdate;
        private Button btndelete;
        private DataGridView dgvcustomers;
        private Label lblTitle;
        private Button btnManageAccounts;
    }
}