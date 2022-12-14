using MySql.Data.MySqlClient;
using Noviembre.Core.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class ComprobanteDomicilio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static List<ComprobanteDomicilio> GetAll()
        {
            List<ComprobanteDomicilio> comprobantes = new List<ComprobanteDomicilio>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM noviembredb.comprobante_domicilio;";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        ComprobanteDomicilio comprobante = new ComprobanteDomicilio();
                        comprobante.Id = int.Parse(dataReader["id"].ToString());
                        comprobante.Nombre = dataReader["nombre"].ToString();

                        comprobantes.Add(comprobante);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return comprobantes;
        }
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


    }
}
