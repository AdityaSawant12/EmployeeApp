\
        using System;
        using System.Collections.Generic;
        using System.Web.UI;

        public partial class _Default : Page
        {
            EmployeeDAL dal = new EmployeeDAL();
            List<Employee> cacheList;

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    LoadEmployeesIntoDropdown();
                    ViewState["Index"] = -1;
                }
            }

            private void LoadEmployeesIntoDropdown()
            {
                cacheList = dal.GetAllEmployees();
                ViewState["Employees"] = cacheList;
                ddlEmployees.Items.Clear();
                ddlEmployees.Items.Add("-- Select --");
                foreach (var e in cacheList)
                {
                    ddlEmployees.Items.Add(new System.Web.UI.WebControls.ListItem(e.EmployeeName + " (" + e.EmployeeID + ")", e.EmployeeID.ToString()));
                }
            }

            protected void ddlEmployees_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (ddlEmployees.SelectedIndex > 0)
                {
                    int id = int.Parse(ddlEmployees.SelectedValue);
                    var emp = dal.GetEmployeeById(id);
                    if (emp != null) PopulateForm(emp);
                }
            }

            private void PopulateForm(Employee emp)
            {
                txtID.Text = emp.EmployeeID.ToString();
                txtName.Text = emp.EmployeeName;
                txtEmail.Text = emp.Email;
                txtAddress.Text = emp.Address;
                txtPhone.Text = emp.PhoneNumber;
                lblMessage.Text = "";
            }

            protected void btnAdd_Click(object sender, EventArgs e)
            {
                if (!Page.IsValid) return;
                Employee emp = new Employee
                {
                    EmployeeName = txtName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    PhoneNumber = txtPhone.Text.Trim()
                };
                dal.InsertEmployee(emp);
                lblMessage.Text = "Added.";
                LoadEmployeesIntoDropdown();
                ClearForm();
            }

            protected void btnUpdate_Click(object sender, EventArgs e)
            {
                if (!Page.IsValid) return;
                if (string.IsNullOrWhiteSpace(txtID.Text)) { lblMessage.Text = "Select an employee to update."; return; }
                Employee emp = new Employee
                {
                    EmployeeID = int.Parse(txtID.Text),
                    EmployeeName = txtName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    PhoneNumber = txtPhone.Text.Trim()
                };
                dal.UpdateEmployee(emp);
                lblMessage.Text = "Updated.";
                LoadEmployeesIntoDropdown();
            }

            protected void btnDelete_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrWhiteSpace(txtID.Text)) { lblMessage.Text = "Select an employee to delete."; return; }
                dal.DeleteEmployee(int.Parse(txtID.Text));
                lblMessage.Text = "Deleted.";
                LoadEmployeesIntoDropdown();
                ClearForm();
            }

            protected void btnClear_Click(object sender, EventArgs e)
            {
                ClearForm();
            }

            private void ClearForm()
            {
                txtID.Text = "";
                txtName.Text = "";
                txtEmail.Text = "";
                txtAddress.Text = "";
                txtPhone.Text = "";
                ddlEmployees.SelectedIndex = 0;
            }

            // Navigation helpers use ViewState stored list
            private List<Employee> GetCachedList()
            {
                if (ViewState["Employees"] == null) ViewState["Employees"] = dal.GetAllEmployees();
                return (List<Employee>)ViewState["Employees"];
            }

            protected void btnFirst_Click(object sender, EventArgs e)
            {
                var list = GetCachedList();
                if (list.Count == 0) return;
                ViewState["Index"] = 0;
                PopulateForm(list[0]);
            }

            protected void btnPrev_Click(object sender, EventArgs e)
            {
                var list = GetCachedList();
                int idx = (int)(ViewState["Index"] ?? -1);
                if (list.Count == 0) return;
                idx = Math.Max(0, idx - 1);
                ViewState["Index"] = idx;
                PopulateForm(list[idx]);
            }

            protected void btnNext_Click(object sender, EventArgs e)
            {
                var list = GetCachedList();
                int idx = (int)(ViewState["Index"] ?? -1);
                if (list.Count == 0) return;
                idx = Math.Min(list.Count - 1, idx + 1);
                ViewState["Index"] = idx;
                PopulateForm(list[idx]);
            }

            protected void btnLast_Click(object sender, EventArgs e)
            {
                var list = GetCachedList();
                if (list.Count == 0) return;
                ViewState["Index"] = list.Count - 1;
                PopulateForm(list[list.Count - 1]);
            }
        }
