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
        public string Direccion { get; set; }
        public string Email { get; set; }

        public static Ciudadano GetById(int id)
        {
            Ciudadano ciudadano = new Ciudadano();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre, apellidoPaterno, apellidoMaterno, telefono, direccion, email  FROM ciudadano WHERE id = @id;";

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        ciudadano.Id = int.Parse(dataReader["id"].ToString());
                        ciudadano.Nombre = dataReader["nombre"].ToString();
                        ciudadano.ApellidoPaterno = dataReader["apellidoPaterno"].ToString();
                        ciudadano.ApellidoMaterno = dataReader["apellidoMaterno"].ToString();
                        ciudadano.Telefono = dataReader["telefono"].ToString();
                        ciudadano.Direccion = dataReader["direccion"].ToString();
                        ciudadano.Email = dataReader["email"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ciudadano;
        }
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
                        ciudadano.Direccion = dataReader["direccion"].ToString();
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
        public bool Editar(int id, string nombre, string apellidoPaterno, string apellidoMaterno, string direccion, string telefono, string email)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    cmd.CommandText = "UPDATE ciudadano SET nombre = @nombre, apellidoPaterno = @apellidoPaterno, apellidoMaterno = @apellidoMaterno , telefono = @telefono, direccion = @direccion, email = @email WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                    cmd.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@email", email);

                    result = cmd.ExecuteNonQuery() == 1;

                    /*MySqlDataAdapter mySqlDataAdapter = ;
                    while ()
                    {

                    }*/


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        public static bool Guardar(int id,string nombre, string apellidoPaterno, string apellidoMaterno, string direccion, string telefono, string email)
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
                        cmd.CommandText = "INSERT INTO ciudadano (nombre, apellidoPaterno, apellidoMaterno, telefono, direccion, email) VALUES ( @nombre, @apellidoPaterno, @apellidoMaterno, @telefono, @direccion, @email);";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                        cmd.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@direccion", direccion);
                        cmd.Parameters.AddWithValue("@email", email);
                    }
                    else
                    {

                        cmd.CommandText = "UPDATE estado SET nombre = @nombre WHERE id = @id";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                        cmd.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@direccion", direccion);
                        cmd.Parameters.AddWithValue("@email", email);

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

    }
}
