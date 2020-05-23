using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmaticShop.DatabaseLayer
{
    public class DatabaseAccess
    {
        private static SqlConnection Conn;

        public static SqlConnection ConnOpen()
        {
            if (Conn == null)
            {
                Conn = new SqlConnection(@"Data Source=DESKTOP-4DRNDGT\SANISQL2014;Initial Catalog=CosmaticShopDb;Integrated Security=True");
            }
            if (Conn.State != System.Data.ConnectionState.Open)
            {
                Conn.Open();
            }
            return Conn;
        }
        public static bool Insert(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, ConnOpen());
                int noofrecord = cmd.ExecuteNonQuery();
                if (noofrecord > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
        public static bool Update(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, ConnOpen());
                int noofrecord = cmd.ExecuteNonQuery();
                if (noofrecord > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
        public static bool Delete(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, ConnOpen());
                int noofrecord = cmd.ExecuteNonQuery();
                if (noofrecord > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
        public static DataTable Retrive(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(query, ConnOpen());
                da.Fill(dt);

                if(dt.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    return dt;
                }
                
            }
            catch
            {

                return null;
            }
        }

        public static string ImageToBase64(Image  image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                //Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                //Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;

            }
        }
        public static Image Base64ToImage(string base64String)
        {
            try
            {

            
                //Convert Base64 String to byte[]
                if(!string.IsNullOrEmpty(base64String) && !string.IsNullOrWhiteSpace(base64String))
                {
                    byte[] imageBytes = Convert.FromBase64String(base64String);
                    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

                    //Convert byte[] to Image
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    Image image = Image.FromStream(ms, true);
                    return image;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
