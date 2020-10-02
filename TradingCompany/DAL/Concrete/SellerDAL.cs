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
    public class SellerDAL : ISellerDAL
    {
        private string _connectionString;
        public SellerDAL(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public SellerDTO CreateSeller(SellerDTO seller)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into Seller (FullName, Mail, Login,Password)  values (@FullName, @Mail, @Login, @Password)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@FullName", seller.FullName);
                comm.Parameters.AddWithValue("@Mail", seller.Mail);
                comm.Parameters.AddWithValue("@Login", seller.Login);
                comm.Parameters.AddWithValue("@Password", seller.Password);

                conn.Open();

                seller.ID = Convert.ToInt32(comm.ExecuteScalar());
                return seller;
            }
        }

        public void DeleteSeller(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Seller where ID = @ID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@ID", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        public List<SellerDTO> GetSellers()
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Seller";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<SellerDTO> seller = new List<SellerDTO>();
                while (reader.Read())
                {

                    seller.Add(new SellerDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        FullName = reader["FullName"].ToString(),
                        Mail = reader["Mail"].ToString(),
                        Login = reader["Login"].ToString(),
                        Password = Convert.ToByte(reader["Password"])
                    });
                }

                return seller;
            }
        }

       
        public SellerDTO GetSellerById(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                SellerDTO seller = new SellerDTO();

                comm.CommandText = $"select * from Seller where ID={id}";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    seller = new SellerDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        FullName = reader["Name"].ToString(),
                        Mail = reader["Mail"].ToString(),
                        Login = reader["Login"].ToString(),
                    };
                }

                return seller;
            }
        }

        public SellerDTO GetSellerByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                SellerDTO items = new SellerDTO();

                comm.CommandText = $"select * fromSeller where FullName={name}";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    items = new SellerDTO
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

        public SellerDTO UpdateSeller(SellerDTO seller)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update Seller set FullName= @FullName, Mail=@Mail where ID = @ID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@ID", seller.ID);
                comm.Parameters.AddWithValue("@FullName", seller.FullName);
                comm.Parameters.AddWithValue("@Mail", seller.Mail);
                conn.Open();

                seller.ID = Convert.ToInt32(comm.ExecuteScalar());


                return seller;
            }
        }
    }
}
