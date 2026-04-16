using Bankappvedant.Controllers;
using System;
using System.Windows.Forms;

namespace Bankappvedant
{
    public partial class AccountManagementForm : Form
    {
        private CustomerController controller;
        private Customer selectedCustomer;

        public AccountManagementForm(CustomerController controller, Customer customer)
        {
            InitializeComponent();
            this.controller = controller;
            this.selectedCustomer = customer;
        }

        private void AccountManagementForm_Load(object sender, EventArgs e)
        {
            lblCustomerInfo.Text = $"Customer: {selectedCustomer.CustomerName} | ID: {selectedCustomer.CustomerID} | Staff: {selectedCustomer.IsStaff}";

            cmbAccountType.Items.Clear();
            cmbAccountType.Items.Add("Everyday");
            cmbAccountType.Items.Add("Investment");
            cmbAccountType.Items.Add("Omni");

            RefreshAccountList();
            ClearTransactionInputs();
        }

        private void RefreshAccountList()
        {
            lstAccounts.Items.Clear();

            foreach (Account account in selectedCustomer.Accounts)
            {
                lstAccounts.Items.Add(account);
            }

            cmbFromAccount.Items.Clear();
            cmbToAccount.Items.Clear();

            foreach (Account account in selectedCustomer.Accounts)
            {
                cmbFromAccount.Items.Add(account);
                cmbToAccount.Items.Add(account);
            }
        }

        private void ClearTransactionInputs()
        {
            txtOpeningBalance.Clear();
            txtAmount.Clear();
            cmbAccountType.SelectedIndex = -1;
            cmbFromAccount.SelectedIndex = -1;
            cmbToAccount.SelectedIndex = -1;
            lblResult.Text = "Result:";
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAccountType.SelectedItem == null)
                {
                    MessageBox.Show("Please select an account type.",
                        "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(txtOpeningBalance.Text.Trim(), out double openingBalance))
                {
                    MessageBox.Show("Please enter a valid opening balance.",
                        "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string accountType = cmbAccountType.SelectedItem.ToString();

                controller.AddAccountToCustomer(selectedCustomer.CustomerID, accountType, openingBalance);

                RefreshAccountList();
                txtOpeningBalance.Clear();

                MessageBox.Show("Account added successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding account: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstAccounts.SelectedItem is not Account selectedAccount)
                {
                    MessageBox.Show("Please select an account from the list first.",
                        "No Account Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(txtAmount.Text.Trim(), out double amount))
                {
                    MessageBox.Show("Please enter a valid amount.",
                        "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                controller.DepositToAccount(selectedCustomer.CustomerID, selectedAccount.AccountID, amount);

                RefreshAccountList();
                lblResult.Text = "Result: " + selectedAccount.LastTransaction;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during deposit: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstAccounts.SelectedItem is not Account selectedAccount)
                {
                    MessageBox.Show("Please select an account from the list first.",
                        "No Account Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(txtAmount.Text.Trim(), out double amount))
                {
                    MessageBox.Show("Please enter a valid amount.",
                        "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool success = controller.WithdrawFromAccount(selectedCustomer.CustomerID, selectedAccount.AccountID, amount);

                RefreshAccountList();

                if (success)
                {
                    lblResult.Text = "Result: " + selectedAccount.LastTransaction;
                }
                else
                {
                    lblResult.Text = "Result: Withdrawal failed. " + selectedAccount.LastTransaction;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during withdrawal: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbFromAccount.SelectedItem is not Account fromAccount)
                {
                    MessageBox.Show("Please select a source account.",
                        "Missing Source Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbToAccount.SelectedItem is not Account toAccount)
                {
                    MessageBox.Show("Please select a destination account.",
                        "Missing Destination Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(txtAmount.Text.Trim(), out double amount))
                {
                    MessageBox.Show("Please enter a valid amount.",
                        "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool success = controller.TransferBetweenAccounts(
                    selectedCustomer.CustomerID,
                    fromAccount.AccountID,
                    toAccount.AccountID,
                    amount);

                RefreshAccountList();

                if (success)
                {
                    lblResult.Text = "Result: Transfer successful.";
                }
                else
                {
                    lblResult.Text = "Result: Transfer failed. " + fromAccount.LastTransaction;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during transfer: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCalculateInterest_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstAccounts.SelectedItem is not Account selectedAccount)
                {
                    MessageBox.Show("Please select an account from the list first.",
                        "No Account Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double interest = controller.ApplyInterestToAccount(selectedCustomer.CustomerID, selectedAccount.AccountID);

                RefreshAccountList();
                lblResult.Text = $"Result: Interest applied = ${interest:F2}. {selectedAccount.LastTransaction}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating interest: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAccounts.SelectedItem is Account selectedAccount)
            {
                lblResult.Text = "Result: " + selectedAccount.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}