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
    public class PurchaseStatusDAL : IPurchaseStatusDAL
    {
        private string _connectionString;
        public PurchaseStatusDAL(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public PurchaseStatusDTO CreateStatus(PurchaseStatusDTO purchaseStatus)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into PurchaseStatus (StatusName, PurchaseStatus, Date/Time)  values (@StatusName, @PurchaseStatus, @Date/Time)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@FullName", purchaseStatus.StatusName);
                comm.Parameters.AddWithValue("@Mail", purchaseStatus.PurchaseStatus);
                comm.Parameters.AddWithValue("@Login", purchaseStatus.DateTime);

                conn.Open();

                purchaseStatus.ID = Convert.ToInt32(comm.ExecuteScalar());
                return purchaseStatus;
            }
        }

        public void DeleteStatus(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from PurchaseStatus where ID = @ID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@ID", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        public PurchaseStatusDTO GetStatusById(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                PurchaseStatusDTO purchaseStatus = new PurchaseStatusDTO();

                comm.CommandText = $"select * from Seller where ID={id}";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    purchaseStatus = new PurchaseStatusDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        StatusName = reader["StatusName"].ToString(),
                        PurchaseStatus = Convert.ToBoolean(reader["PurchaseStatus"]),
                        DateTime = Convert.ToDateTime(reader["Date/Time"])

                    };
                }

                return purchaseStatus;
            }
        }

        public PurchaseStatusDTO UpdateStatuse(PurchaseStatusDTO purchaseStatus)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update PurchaseStatus set StatusName= @StatusName,PurchaseStatus=@PurchaseStatus where ID = @ID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@ID", purchaseStatus.ID);
                comm.Parameters.AddWithValue("@StatusName", purchaseStatus.StatusName);
                comm.Parameters.AddWithValue("@PurchaseStatus", purchaseStatus.PurchaseStatus);
                conn.Open();

                purchaseStatus.ID = Convert.ToInt32(comm.ExecuteScalar());


                return purchaseStatus;
            }
        }

        public List<PurchaseStatusDTO> GetStatuses()
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from User";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<PurchaseStatusDTO> purchaseStatus = new List<PurchaseStatusDTO>();
                while (reader.Read())
                {

                    purchaseStatus.Add(new PurchaseStatusDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        StatusName = reader["StatusName"].ToString(),
                        PurchaseStatus = Convert.ToBoolean(reader["PurchaseStatus"]),
                        DateTime = Convert.ToDateTime(reader["Date/Time"])
                    });
                }

                return purchaseStatus;
            }
        }
    }
}
