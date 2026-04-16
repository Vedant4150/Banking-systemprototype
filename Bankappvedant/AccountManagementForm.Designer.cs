using System.Drawing;
using System.Windows.Forms;

namespace Bankappvedant
{
    partial class AccountManagementForm
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
            lblTitle = new Label();
            lblCustomerInfo = new Label();
            lblAccountType = new Label();
            cmbAccountType = new ComboBox();
            lblOpeningBalance = new Label();
            txtOpeningBalance = new TextBox();
            btnAddAccount = new Button();
            lblAccounts = new Label();
            lstAccounts = new ListBox();
            lblAmount = new Label();
            txtAmount = new TextBox();
            btnDeposit = new Button();
            btnWithdraw = new Button();
            btnCalculateInterest = new Button();
            lblFromAccount = new Label();
            cmbFromAccount = new ComboBox();
            lblToAccount = new Label();
            cmbToAccount = new ComboBox();
            btnTransfer = new Button();
            lblResult = new Label();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(30, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(337, 59);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Account Management";
            // 
            // lblCustomerInfo
            // 
            lblCustomerInfo.AutoSize = true;
            lblCustomerInfo.Location = new Point(30, 70);
            lblCustomerInfo.Name = "lblCustomerInfo";
            lblCustomerInfo.Size = new Size(119, 32);
            lblCustomerInfo.TabIndex = 1;
            lblCustomerInfo.Text = "Customer:";
            // 
            // lblAccountType
            // 
            lblAccountType.AutoSize = true;
            lblAccountType.Location = new Point(30, 120);
            lblAccountType.Name = "lblAccountType";
            lblAccountType.Size = new Size(144, 32);
            lblAccountType.TabIndex = 2;
            lblAccountType.Text = "Account Type";
            // 
            // cmbAccountType
            // 
            cmbAccountType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccountType.FormattingEnabled = true;
            cmbAccountType.Location = new Point(30, 155);
            cmbAccountType.Name = "cmbAccountType";
            cmbAccountType.Size = new Size(180, 40);
            cmbAccountType.TabIndex = 3;
            // 
            // lblOpeningBalance
            // 
            lblOpeningBalance.AutoSize = true;
            lblOpeningBalance.Location = new Point(240, 120);
            lblOpeningBalance.Name = "lblOpeningBalance";
            lblOpeningBalance.Size = new Size(170, 32);
            lblOpeningBalance.TabIndex = 4;
            lblOpeningBalance.Text = "Opening Balance";
            // 
            // txtOpeningBalance
            // 
            txtOpeningBalance.Location = new Point(240, 155);
            txtOpeningBalance.Name = "txtOpeningBalance";
            txtOpeningBalance.Size = new Size(150, 39);
            txtOpeningBalance.TabIndex = 5;
            // 
            // btnAddAccount
            // 
            btnAddAccount.Location = new Point(410, 150);
            btnAddAccount.Name = "btnAddAccount";
            btnAddAccount.Size = new Size(150, 45);
            btnAddAccount.TabIndex = 6;
            btnAddAccount.Text = "Add Account";
            btnAddAccount.UseVisualStyleBackColor = true;
            btnAddAccount.Click += btnAddAccount_Click;
            // 
            // lblAccounts
            // 
            lblAccounts.AutoSize = true;
            lblAccounts.Location = new Point(30, 220);
            lblAccounts.Name = "lblAccounts";
            lblAccounts.Size = new Size(101, 32);
            lblAccounts.TabIndex = 7;
            lblAccounts.Text = "Accounts";
            // 
            // lstAccounts
            // 
            lstAccounts.FormattingEnabled = true;
            lstAccounts.ItemHeight = 32;
            lstAccounts.Location = new Point(30, 255);
            lstAccounts.Name = "lstAccounts";
            lstAccounts.Size = new Size(530, 132);
            lstAccounts.TabIndex = 8;
            lstAccounts.SelectedIndexChanged += lstAccounts_SelectedIndexChanged;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(30, 410);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(96, 32);
            lblAmount.TabIndex = 9;
            lblAmount.Text = "Amount";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(30, 445);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(150, 39);
            txtAmount.TabIndex = 10;
            // 
            // btnDeposit
            // 
            btnDeposit.Location = new Point(200, 440);
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Size = new Size(110, 45);
            btnDeposit.TabIndex = 11;
            btnDeposit.Text = "Deposit";
            btnDeposit.UseVisualStyleBackColor = true;
            btnDeposit.Click += btnDeposit_Click;
            // 
            // btnWithdraw
            // 
            btnWithdraw.Location = new Point(325, 440);
            btnWithdraw.Name = "btnWithdraw";
            btnWithdraw.Size = new Size(125, 45);
            btnWithdraw.TabIndex = 12;
            btnWithdraw.Text = "Withdraw";
            btnWithdraw.UseVisualStyleBackColor = true;
            btnWithdraw.Click += btnWithdraw_Click;
            // 
            // btnCalculateInterest
            // 
            btnCalculateInterest.Location = new Point(465, 440);
            btnCalculateInterest.Name = "btnCalculateInterest";
            btnCalculateInterest.Size = new Size(195, 45);
            btnCalculateInterest.TabIndex = 13;
            btnCalculateInterest.Text = "Calculate Interest";
            btnCalculateInterest.UseVisualStyleBackColor = true;
            btnCalculateInterest.Click += btnCalculateInterest_Click;
            // 
            // lblFromAccount
            // 
            lblFromAccount.AutoSize = true;
            lblFromAccount.Location = new Point(600, 120);
            lblFromAccount.Name = "lblFromAccount";
            lblFromAccount.Size = new Size(148, 32);
            lblFromAccount.TabIndex = 14;
            lblFromAccount.Text = "From Account";
            // 
            // cmbFromAccount
            // 
            cmbFromAccount.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFromAccount.FormattingEnabled = true;
            cmbFromAccount.Location = new Point(600, 155);
            cmbFromAccount.Name = "cmbFromAccount";
            cmbFromAccount.Size = new Size(220, 40);
            cmbFromAccount.TabIndex = 15;
            // 
            // lblToAccount
            // 
            lblToAccount.AutoSize = true;
            lblToAccount.Location = new Point(600, 220);
            lblToAccount.Name = "lblToAccount";
            lblToAccount.Size = new Size(118, 32);
            lblToAccount.TabIndex = 16;
            lblToAccount.Text = "To Account";
            // 
            // cmbToAccount
            // 
            cmbToAccount.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbToAccount.FormattingEnabled = true;
            cmbToAccount.Location = new Point(600, 255);
            cmbToAccount.Name = "cmbToAccount";
            cmbToAccount.Size = new Size(220, 40);
            cmbToAccount.TabIndex = 17;
            // 
            // btnTransfer
            // 
            btnTransfer.Location = new Point(600, 320);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(140, 45);
            btnTransfer.TabIndex = 18;
            btnTransfer.Text = "Transfer";
            btnTransfer.UseVisualStyleBackColor = true;
            btnTransfer.Click += btnTransfer_Click;
            // 
            // lblResult
            // 
            lblResult.BorderStyle = BorderStyle.FixedSingle;
            lblResult.Location = new Point(30, 520);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(790, 80);
            lblResult.TabIndex = 19;
            lblResult.Text = "Result:";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(670, 620);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 45);
            btnClose.TabIndex = 20;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // AccountManagementForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(860, 700);
            Controls.Add(btnClose);
            Controls.Add(lblResult);
            Controls.Add(btnTransfer);
            Controls.Add(cmbToAccount);
            Controls.Add(lblToAccount);
            Controls.Add(cmbFromAccount);
            Controls.Add(lblFromAccount);
            Controls.Add(btnCalculateInterest);
            Controls.Add(btnWithdraw);
            Controls.Add(btnDeposit);
            Controls.Add(txtAmount);
            Controls.Add(lblAmount);
            Controls.Add(lstAccounts);
            Controls.Add(lblAccounts);
            Controls.Add(btnAddAccount);
            Controls.Add(txtOpeningBalance);
            Controls.Add(lblOpeningBalance);
            Controls.Add(cmbAccountType);
            Controls.Add(lblAccountType);
            Controls.Add(lblCustomerInfo);
            Controls.Add(lblTitle);
            Name = "AccountManagementForm";
            Text = "Account Management";
            Load += AccountManagementForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblCustomerInfo;
        private Label lblAccountType;
        private Label lblOpeningBalance;
        private Label lblAccounts;
        private Label lblAmount;
        private Label lblFromAccount;
        private Label lblToAccount;
        private Label lblResult;
        private ComboBox cmbAccountType;
        private ComboBox cmbFromAccount;
        private ComboBox cmbToAccount;
        private TextBox txtOpeningBalance;
        private TextBox txtAmount;
        private ListBox lstAccounts;
        private Button btnAddAccount;
        private Button btnDeposit;
        private Button btnWithdraw;
        private Button btnCalculateInterest;
        private Button btnTransfer;
        private Button btnClose;
    }
}