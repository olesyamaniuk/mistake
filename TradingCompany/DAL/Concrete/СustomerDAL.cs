using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class CustomerDAL : ICustomerDAL
    {
        private string _connectionString;
        public CustomerDAL(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public CustomerDTO CreateCustomer(CustomerDTO customer)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into Customer (FullName, Mail, Login,Password)  values (@FullName, @Mail, @Login, @Password)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@FullName", customer.FullName);
                comm.Parameters.AddWithValue("@Mail", customer.Mail);
                comm.Parameters.AddWithValue("@Login", customer.Login);
                comm.Parameters.AddWithValue("@Password", customer.Password);

                conn.Open();

                customer.ID = Convert.ToInt32(comm.ExecuteScalar());
                return customer;
            }
        }

        public void DeleteCustomer(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Customer where ID = @ID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@ID", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        public List<CustomerDTO> GetCustomers()
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Customer";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<CustomerDTO> customer = new List<CustomerDTO>();
                while (reader.Read())
                {

                    customer.Add(new CustomerDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        FullName = reader["FullName"].ToString(),
                        Mail = reader["Mail"].ToString(),
                        Login = reader["Login"].ToString(),
                        Password = Convert.ToByte(reader["Password"])
                    });
                }

                return customer;
            }
        }


        public CustomerDTO GetCustomerById(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                CustomerDTO customer = new CustomerDTO();

                comm.CommandText = $"select * from Customer where ID={id}";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    customer = new CustomerDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        FullName = reader["Name"].ToString(),
                        Mail = reader["Mail"].ToString(),
                        Login = reader["Login"].ToString(),
                    };
                }

                return customer;
            }
        }

        public CustomerDTO GetCustomerByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                CustomerDTO items = new CustomerDTO();

                comm.CommandText = $"select * from Customer where FullName={name}";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    items = new CustomerDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        FullName = reader["Name"].ToString(),
                        Mail = reader["Mail"].ToString(),
                        Login = reader["Login"].ToString(),
                    };
                }

                return items;
            }
        }

        public CustomerDTO UpdateCustomer(CustomerDTO customer)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update Customer set FullName= @FullName, Mail=@Mail where ID = @ID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@ID", customer.ID);
                comm.Parameters.AddWithValue("@FullName", customer.FullName);
                comm.Parameters.AddWithValue("@Mail", customer.Mail);
                conn.Open();

                customer.ID = Convert.ToInt32(comm.ExecuteScalar());


                return customer;
            }
        }
    }
}
