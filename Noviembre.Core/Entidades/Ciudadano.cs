using MySql.Data.MySqlClient;
using Noviembre.Core.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class Ciudadano
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public string Domicilio { get; set; }
        public string Email { get; set; }
        public static List<Ciudadano> GetAll()
        {
            List<Ciudadano> ciudadanos = new List<Ciudadano>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM noviembredb.ciudadano;";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Ciudadano ciudadano = new Ciudadano();
                        ciudadano.Id = int.Parse(dataReader["id"].ToString());
                        ciudadano.Nombre = dataReader["nombre"].ToString();
                        ciudadano.ApellidoPaterno = dataReader["apellidoPaterno"].ToString();
                        ciudadano.ApellidoMaterno = dataReader["apellidoMaterno"].ToString();
                        ciudadano.Telefono = dataReader["telefono"].ToString();
                        ciudadano.Domicilio = dataReader["domicilio"].ToString();
                        ciudadano.Email = dataReader["email"].ToString();

                        ciudadanos.Add(ciudadano);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ciudadanos;
        }


    }
}
