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
                    string query = "SELECT idestado, nombre FROM estado;";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Estado estado = new Estado();
                        estado.Id = int.Parse(dataReader["idestado"].ToString());
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

        public bool Editar(int id, string nombre)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    cmd.CommandText = "UPDATE estado SET nombre = @nombre WHERE id = @id ";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nombre", nombre);

                    result = cmd.ExecuteNonQuery() == 1;
                    
                    /*MySqlDataAdapter mySqlDataAdapter = ;
                    while ()
                    {

                    }*/

                    
                }
            }catch(Exception ex)
            {
                throw ex;
            }

            return result;
        }
        public static bool Guardar(string nombre)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO estado (nombre) VALUES (@nombre)";
                    
                    cmd.Parameters.AddWithValue("@nombre", nombre);

                    result = cmd.ExecuteNonQuery() == 1;


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
