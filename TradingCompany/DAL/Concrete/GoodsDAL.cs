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
    public class GoodsDAL : IGoodsDAL
    {
        private string _connectionString;
        public GoodsDAL(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public GoodsDTO CreateGoods(GoodsDTO goods)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into User (Name, Price, Description, Amount)  values (@GoodsName, @GoodsPrice, @GoodsDescription, @GoodsAmount)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@GoodsName", goods.GoodsName);
                comm.Parameters.AddWithValue("@GoodsPrice", goods.GoodsPrice);
                comm.Parameters.AddWithValue("@GoodsDescription", goods.GoodsDescription);
                comm.Parameters.AddWithValue("@GoodsAmount", goods.GoodsAmount);

                conn.Open();

                goods.GoodsID = Convert.ToInt32(comm.ExecuteScalar());
                return goods;
            }
        }

        public void DeleteGoods(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Goods where ID = @ID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@ID", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        public List<GoodsDTO> GetGoods()
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Goods";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<GoodsDTO> goods = new List<GoodsDTO>();
                while (reader.Read())
                {
                    goods.Add(new GoodsDTO
                    {
                        GoodsID = Convert.ToInt32(reader["GoodsID"]),
                        GoodsName = reader["GoodsName"].ToString(),
                        GoodsPrice = reader["GoodsPrice"].ToString(),
                        GoodsDescription = reader["GoodsDescription"].ToString(),
                        GoodsAmount = reader["GoodsAmount"].ToString()
                    });

                }

                return goods;
            }
        }

        public List<GoodsDTO> SortedGoods(int n)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {

                if (n == 1)
                { 
                    comm.CommandText = "select * from Goods order by ID"; 
                }
                if (n == 2)
                {
                    comm.CommandText = "select * from Goods order by Name";
                }
                if (n == 3)
                {
                    comm.CommandText = "select * from Goods order by Price";
                }
                if (n == 4)
                {
                    comm.CommandText = "select * from Goods order by Description";
                }
                if (n == 5)
                {
                    comm.CommandText = "select * from Goods order by Amount";
                }
                else
                { 
                    comm.CommandText = "select * from Goods"; 
                }



                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<GoodsDTO> goods = new List<GoodsDTO>();
                
                while (reader.Read())
                {

                    goods.Add(new GoodsDTO
                    {
                        GoodsID = Convert.ToInt32(reader["GoodsID"]),
                        GoodsName = reader["GoodsName"].ToString(),
                        GoodsPrice = reader["GoodsPrice"].ToString(),
                        GoodsDescription = reader["GoodsDescription"].ToString(),
                        GoodsAmount = reader["GoodsAmount"].ToString()
                    });
                }
                return goods;
            }
        }

        public GoodsDTO GetGoodsById(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                GoodsDTO goods = new GoodsDTO();

                comm.CommandText = $"select * from User where ID={id}";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    goods = new GoodsDTO
                    {
                        GoodsID = Convert.ToInt32(reader["GoodsID"]),
                        GoodsName = reader["GoodsName"].ToString(),
                        GoodsPrice = reader["GoodsPrice"].ToString(),
                        GoodsDescription = reader["GoodsDescription"].ToString(),
                        GoodsAmount = reader["GoodsAmount"].ToString()
                    };
                }

                return goods;
            }
        }

        public GoodsDTO GetGoodsByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                GoodsDTO goods = new GoodsDTO();

                comm.CommandText = $"select * from User where Name={name}";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    goods = new GoodsDTO
                    {
                        GoodsID = Convert.ToInt32(reader["GoodsID"]),
                        GoodsName = reader["GoodsName"].ToString(),
                        GoodsPrice = reader["GoodsPrice"].ToString(),
                        GoodsDescription = reader["GoodsDescription"].ToString(),
                        GoodsAmount = reader["GoodsAmount"].ToString()
                    };
                }

                return goods;
            }
        }

        public GoodsDTO UpdateGoods(GoodsDTO goods)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update Goods set GoodsName= @GoodsName,GoodsPrice = @GoodsPrice, GoodsDescription=@GoodsDescription, GoodsAmount=@GoodsAmount where ID = @ID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@GoodsID", goods.GoodsID);
                comm.Parameters.AddWithValue("@GoodsName", goods.GoodsName);
                comm.Parameters.AddWithValue("@GoodsPrice", goods.GoodsPrice);
                comm.Parameters.AddWithValue("@GoodsDescription", goods.GoodsDescription);
                comm.Parameters.AddWithValue("@GoodsAmount", goods.GoodsAmount);

                conn.Open();

                goods.GoodsID = Convert.ToInt32(comm.ExecuteScalar());


                return goods;
            }
        }
    }
}
