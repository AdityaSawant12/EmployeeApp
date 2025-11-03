\
        using System;
        using System.Collections.Generic;
        using System.Configuration;
        using System.Data;
        using System.Data.SqlClient;

        public class EmployeeDAL
        {
            private string cs = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

            public void InsertEmployee(Employee emp)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string q = "INSERT INTO Employees (EmployeeName, Email, Address, PhoneNumber) VALUES (@Name, @Email, @Address, @Phone)";
                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", emp.EmployeeName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Email", emp.Email ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Address", emp.Address ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Phone", emp.PhoneNumber ?? (object)DBNull.Value);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public void UpdateEmployee(Employee emp)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string q = "UPDATE Employees SET EmployeeName=@Name, Email=@Email, Address=@Address, PhoneNumber=@Phone WHERE EmployeeID=@ID";
                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", emp.EmployeeID);
                        cmd.Parameters.AddWithValue("@Name", emp.EmployeeName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Email", emp.Email ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Address", emp.Address ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Phone", emp.PhoneNumber ?? (object)DBNull.Value);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public void DeleteEmployee(int id)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string q = "DELETE FROM Employees WHERE EmployeeID=@ID";
                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public List<Employee> GetAllEmployees()
            {
                List<Employee> list = new List<Employee>();
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string q = "SELECT EmployeeID, EmployeeName, Email, Address, PhoneNumber FROM Employees ORDER BY EmployeeID";
                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        con.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                list.Add(new Employee
                                {
                                    EmployeeID = Convert.ToInt32(dr["EmployeeID"]),
                                    EmployeeName = dr["EmployeeName"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    Address = dr["Address"].ToString(),
                                    PhoneNumber = dr["PhoneNumber"].ToString()
                                });
                            }
                        }
                    }
                }
                return list;
            }

            public Employee GetEmployeeById(int id)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string q = "SELECT EmployeeID, EmployeeName, Email, Address, PhoneNumber FROM Employees WHERE EmployeeID=@ID";
                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        con.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                return new Employee
                                {
                                    EmployeeID = Convert.ToInt32(dr["EmployeeID"]),
                                    EmployeeName = dr["EmployeeName"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    Address = dr["Address"].ToString(),
                                    PhoneNumber = dr["PhoneNumber"].ToString()
                                };
                            }
                        }
                    }
                }
                return null;
            }
        }
