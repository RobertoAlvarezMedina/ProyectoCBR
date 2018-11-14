using CBR_Web.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CBR_Web.Utils
{
    public class Utils
    {
        public SqlParameterCollection parameterCollection { get; set; }

        public void LimpiarSqlParameterCollection()
        {
            parameterCollection.Clear();
        }



        Utils conexion = new Utils();

        public Boolean InsertarUsuario(User user)
        {
            using (var sqlConnection1 = new SqlConnection("Server = tcp:cbrdatabase.database.windows.net,1433; Initial Catalog = CBRDatabase; Persist Security Info = False; User ID = Byron ; Password = miakhalifa69!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;")

            )
            {
                using (var cmd = new SqlCommand()
                {
                    CommandText = "INSERT INTO dbo.cbr_Usuario (Nombre,Correo,Contrasena,Institucion,FechaNacimiento)" +
                                           "Values(@Nombre,@Correo,@Contrasena,@Institucion,@FechaNacimiento)",
                    CommandType = CommandType.Text,
                    Connection = sqlConnection1
                })
                {
                    cmd.Parameters.Add("@Nombre", SqlDbType.Int).Value = user.Nombre;
                    cmd.Parameters.Add("@Correo", SqlDbType.Int).Value = user.Correo;
                    cmd.Parameters.Add("@Contrasena", SqlDbType.Int).Value = user.Clave;
                    cmd.Parameters.Add("@Institucion", SqlDbType.Int).Value = user.Lugarestudio;
                    cmd.Parameters.Add("@FechaNacimiento", SqlDbType.Int).Value = user.Fechanacimiento;
                    sqlConnection1.Open();
                    conexion.setDatosBD(
                        , parameterCollection);
                }
            }
            return false;
        }

        public String setDatosBD(String strSQL,SqlParameterCollection ListaParametros)
        {
            String bandera = String.Empty;
            using (var sqlConnection1 = new SqlConnection("Server = tcp:cbrdatabase.database.windows.net,1433; Initial Catalog = CBRDatabase; Persist Security Info = False; User ID = Byron ; Password = miakhalifa69!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;")

            )
               
                try
                {
                    sqlConnection1.Open();
                    SqlCommand cmd = sqlConnection1.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    if (ListaParametros != null)
                    {
                        foreach (var item in ListaParametros)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }
                    cmd.ExecuteNonQuery();
                    bandera = "Proceso correcto";
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    sqlConnection1.Close();
                }
            return bandera;
        }
    

        public void SeleccionarUsuario(string correo,string contrasena)
        {
            using (var sqlConnection1 = new SqlConnection("Server = tcp:cbrdatabase.database.windows.net,1433; Initial Catalog = SERVICE_DESK; Persist Security Info = False; User ID = Byron; Password = miakhalifa69!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;")
            )
            {
                using (var cmd = new SqlCommand()
                {
                    CommandText = "SELECT Correo,Contrasena FROM dbo.cbr_Usuario WHERE Correo = @Correo AND Contrasena = @Contrasena",
                    CommandType = CommandType.Text,
                    Connection = sqlConnection1
                })
                {
                    cmd.Parameters.Add("@Correo", SqlDbType.Int).Value = correo;
                    cmd.Parameters.Add("@Contrasena", SqlDbType.Int).Value = contrasena;
                    sqlConnection1.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var id = reader[0];
                            var lector = reader[1];

                        }
                    }
                }
            }
    }

       

    }
}
