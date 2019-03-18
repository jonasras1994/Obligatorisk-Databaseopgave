using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HotelModel;

namespace HotelRest.DBUtil
{
    public class ManageFacilities
    {
        private static string PW = "";
        private static string connectionString =
            $"Data Source=jonasras1994server.database.windows.net;Initial Catalog=Jonasras1994;User ID=Jonasras1994;Password={PW};Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Facilities> GetAllFacilities()
        {
            List<Facilities> facilitiesList = new List<Facilities>();

            string queryString = "SELECT * FROM DemoFacilities";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Facilities f = new Facilities();
                        f.Hotel_no = reader.GetInt32(0);
                        f.Swimmingpool = reader.GetBoolean(1);
                        f.Tabletennis = reader.GetBoolean(2);
                        f.Pooltable = reader.GetBoolean(3);
                        f.Bar = reader.GetBoolean(4);
                        facilitiesList.Add(f);
                    }
                }
                finally
                {
                    //Always call Close when done reading
                    reader.Close();
                }

                return facilitiesList;
            }
        }

        public Facilities GetFacilitiesFromId(int id)
        {
            string queryString = $"SELECT * FROM DemoFacilities WHERE Hotel_no = {id}";

            Facilities f = new Facilities();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        f.Hotel_no = reader.GetInt32(0);
                        f.Swimmingpool = reader.GetBoolean(1);
                        f.Tabletennis = reader.GetBoolean(2);
                        f.Pooltable = reader.GetBoolean(3);
                        f.Bar = reader.GetBoolean(4);
                    }
                }
                finally
                {
                    //Always call Close when done reading
                    reader.Close();
                }

                return f;
            }
        }

        public bool CreateFacilities(Facilities facilities)
        {
            string queryString = $"INSERT INTO DemoFacilities " +
                                 $"VALUES ({facilities.Hotel_no}, {Convert.ToInt16(facilities.Swimmingpool)}, {Convert.ToInt16(facilities.Tabletennis)}, {Convert.ToInt16(facilities.Pooltable)}, {Convert.ToInt16(facilities.Bar)})";

            using (SqlConnection connection =
                new SqlConnection(connectionString))

            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }

            return true;
        }

        public bool UpdateFacilities(Facilities facilities, int id)
        {
            string queryString = $"UPDATE DemoFacilities " +
                                 $"SET SwimmingPool = {Convert.ToInt16(facilities.Swimmingpool)}, TableTennis = {Convert.ToInt16(facilities.Tabletennis)}, PoolTable = " +
                                 $"{Convert.ToInt16(facilities.Pooltable)}, Bar = {Convert.ToInt16(facilities.Bar)} " +
                                 $"WHERE Hotel_no = {id}";

            using (SqlConnection connection =
                new SqlConnection(connectionString))

            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }

                return true;
            }
        }

        public bool DeleteFacilities(int id)
        {
            string queryString = $"DELETE FROM DemoFacilities WHERE Hotel_No = {id}";

            using (SqlConnection connection = new SqlConnection(connectionString))

            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                }
                finally
                {
                    command.ExecuteNonQuery();
                }

                return true;
            }
        }
    }
}