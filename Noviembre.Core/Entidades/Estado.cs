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

        public static Estado GetById(int id)
        {
            Estado estado = new Estado();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre FROM Estado WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        estado.Id = int.Parse(dataReader["id"].ToString());
                        estado.Nombre = dataReader["nombre"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return estado;
        }
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
            } catch (Exception ex)
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
            } catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        public static bool Guardar(int id, string nombre)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    if (id == 0)
                    {

                        cmd.CommandText = "INSERT INTO estado (nombre) VALUES (@nombre)";
                        cmd.Parameters.AddWithValue("@nombre", nombre);

                    }
                    else
                    {

                        cmd.CommandText = "UPDATE estado SET nombre = @nombre WHERE id = @id";
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", nombre);

                    }
                    result = cmd.ExecuteNonQuery() == 1;



                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        public static bool Eliminar(int id)
        {
            bool result = false;
            try
            {

                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM estado WHERE id= @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    result = cmd.ExecuteNonQuery() == 1;
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return result;

        }
    
    }
}
