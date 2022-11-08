using MySql.Data.MySqlClient;
using Noviembre.Core.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class DocumentoNacionalidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static List<DocumentoNacionalidad> GetAll()
        {
            List<DocumentoNacionalidad> docs = new List<DocumentoNacionalidad>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM noviembredb.documento_nacionalidad;";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DocumentoNacionalidad doc = new DocumentoNacionalidad();
                        doc.Id = int.Parse(dataReader["id"].ToString());
                        doc.Nombre = dataReader["nombre"].ToString();

                        docs.Add(doc);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return docs;
        }
    }
}
