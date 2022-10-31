using MySql.Data.MySqlClient;
using Noviembre.Core.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class Estado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static List<Estado> GetAll()
        {
            List<Estado> estados = new List<Estado>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre FROM estado;";
                    MySqlCommand command = new MySqlCommand(query, conexion.connection);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Estado estado = new Estado();
                        estado.Id = int.Parse(dataReader["id"].ToString());
                        estado.Nombre = dataReader["nombre"].ToString();

                        estados.Add(estado);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            return estados;
        }
    }
}
