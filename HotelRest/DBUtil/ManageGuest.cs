using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelModel;
using System.Data.SqlClient;
using System.Runtime.Remoting;

namespace HotelRest.DBUtil
{
    public class ManageGuest
    {
        private string connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"Hotel database\"; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Guest> GetAllGuest()
        {
            List<Guest> guestList = new List<Guest>();
            string queryString = "SELECT * FROM demoguest";

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
                        Guest guest = new Guest();
                        guest.Guest_no = reader.GetInt32(0);
                        guest.Name = reader.GetString(1);
                        guest.Address = reader.GetString(2);
                        guestList.Add(guest);
                    }
                }
                finally
                {
                    //Always call Close when done reading
                    reader.Close();
                }

                return guestList;
            }
        }

        public Guest GetGuestFromId(int guestNO)
        {
            Guest g = new Guest();

            string queryString = "SELECT * FROM demoguest WHERE GUEST_NO LIKE '" + guestNO + "'";

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
                        g.Guest_no = reader.GetInt32(0);
                        g.Name = reader.GetString(1);
                        g.Address = reader.GetString(2);
                    }
                }
                finally
                {
                    //Always call Close when done reading
                    reader.Close();
                }

                return g;
            }
        }

        public bool CreateGuest(Guest guest)
        {
            string queryString = $"INSERT INTO DemoGuest (Guest_no, Name, Address) " +
                                 $"VALUES ({guest.Guest_no}, '{guest.Name}', '{guest.Address}')";

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

        public bool UpdateGuest(Guest guest, int guestNr)

        {
            string queryString = $"UPDATE demoguest " +
                                 $"SET Guest_no = {guest.Guest_no}, Name = '{guest.Name}', Address = '{guest.Address}' " +
                                 $"WHERE Guest_no = {guestNr}";

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

        public Guest DeleteGuest(int guestNr)
        {
            Guest g = GetGuestFromId(guestNr);
            string queryString = "DELETE FROM demoguest WHERE GUEST_NO LIKE '" + guestNr + "'";

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

                return g;
            }
        }
    }
}