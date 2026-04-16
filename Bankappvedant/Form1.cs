using Bankappvedant.Controllers;
using System;
using System.Windows.Forms;

namespace Bankappvedant
{
    public partial class Form1 : Form
    {
        private CustomerController controller = new CustomerController();
        private readonly string dataFile = "customers.json";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                controller.LoadFromFile(dataFile);

                var list = controller.GetAllCustomers();

                if (list != null && list.Count > 0)
                {
                    BindGrid();
                }

                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading saved data: " + ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                controller.SaveToFile(dataFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message,
                    "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearInputs()
        {
            txtcustomerid.Clear();
            textname.Clear();
            txtEmailcustomer.Clear();
            chkisstaff.Checked = false;
        }

        private void BindGrid()
        {
            var list = controller.GetAllCustomers();

            dgvcustomers.DataSource = null;

            if (list == null || list.Count == 0)
            {
                dgvcustomers.DataSource = null;
                return;
            }

            dgvcustomers.AutoGenerateColumns = true;
            dgvcustomers.DataSource = list;

            if (dgvcustomers.Columns["Accounts"] != null)
                dgvcustomers.Columns["Accounts"].Visible = false;
        }

        private Customer GetSelectedCustomer()
        {
            if (dgvcustomers.CurrentRow == null)
                return null;

            return dgvcustomers.CurrentRow.DataBoundItem as Customer;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textname.Text.Trim();
                string email = txtEmailcustomer.Text.Trim();
                bool isStaff = chkisstaff.Checked;

                controller.NewCustomer(name, email, isStaff);

                BindGrid();
                ClearInputs();

                MessageBox.Show("Customer added successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message,
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                Customer selectedCustomer = GetSelectedCustomer();

                if (selectedCustomer == null)
                {
                    MessageBox.Show("Please select a customer row first.",
                        "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool updated = controller.UpdateCustomer(
                    selectedCustomer.CustomerID,
                    textname.Text.Trim(),
                    txtEmailcustomer.Text.Trim(),
                    chkisstaff.Checked);

                if (updated)
                {
                    BindGrid();
                    ClearInputs();
                    MessageBox.Show("Customer updated successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Customer not found.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message,
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                Customer selectedCustomer = GetSelectedCustomer();

                if (selectedCustomer == null)
                {
                    MessageBox.Show("Please select a customer row first.",
                        "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    "Delete this customer?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

                bool deleted = controller.DeleteCustomer(selectedCustomer.CustomerID);

                if (deleted)
                {
                    BindGrid();
                    ClearInputs();
                    MessageBox.Show("Customer deleted successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Customer not found.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnManageAccounts_Click(object sender, EventArgs e)
        {
            try
            {
                Customer selectedCustomer = GetSelectedCustomer();

                if (selectedCustomer == null)
                {
                    MessageBox.Show("Please select a customer row first.",
                        "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AccountManagementForm accountForm = new AccountManagementForm(controller, selectedCustomer);
                accountForm.ShowDialog();

                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvcustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Customer selectedCustomer = GetSelectedCustomer();
            if (selectedCustomer == null) return;

            txtcustomerid.Text = selectedCustomer.CustomerID.ToString();
            textname.Text = selectedCustomer.CustomerName;
            txtEmailcustomer.Text = selectedCustomer.CustomerEmail;
            chkisstaff.Checked = selectedCustomer.IsStaff;
        }

        private void dgvcustomers_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true;
        }
    }
}