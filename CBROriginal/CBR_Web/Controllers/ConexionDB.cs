using CBR_Web.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CBR_Web.Controllers
{
    public class ConexionDB
    {
        private const string ConnectionString = "Server = tcp:cbrdatabase.database.windows.net,1433; Initial Catalog = CBRDatabase; Persist Security Info = False; User ID = Byron ; Password = miakhalifa69!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        public Boolean InsertarUsuario(User user)
        {
            try
            {
                using (var sqlConnection1 = new SqlConnection(ConnectionString))
                {
                    using (var cmd = new SqlCommand()
                    {
                        CommandText = "INSERT INTO cbrUsuarios ([Cedula],[Nombre],[Apellido],[Correo],[Contrasena],[ReingresoContrasena],[FechaNacimiento],[Institucion],[TemaInteres])VALUES " +
                                      "(@Cedula,@Nombre,@Apellido,@Correo,@Contrasena,@ReingresoContrasena,@FechaNacimiento, @Institucion, @TemaInteres)",
                        CommandType = CommandType.Text,
                        Connection = sqlConnection1
                    })
                    {
                        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = user.Nombre;
                        cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = user.Correo;
                        cmd.Parameters.Add("@Contrasena", SqlDbType.VarChar).Value = user.Clave;
                        cmd.Parameters.Add("@Institucion", SqlDbType.VarChar).Value = user.Lugarestudio;
                        cmd.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = user.Fechanacimiento;
                        cmd.Parameters.Add("@Cedula", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = string.Empty;
                        cmd.Parameters.Add("@ReingresoContrasena", SqlDbType.VarChar).Value = string.Empty;
                        cmd.Parameters.Add("@TemaInteres", SqlDbType.VarChar).Value = string.Empty;
                        sqlConnection1.Open();

                        var reader = cmd.ExecuteReader();

                        reader.Close();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public User SeleccionarUsuario(string correo, string contrasena)
        {
            try
            {
                User usuarioEncontrado = null;
                using (var sqlConnection1 = new SqlConnection(ConnectionString))
                {
                    using (var cmd = new SqlCommand()
                    {
                        CommandText = "SELECT Nombre, Correo, FechaNacimiento, Institucion FROM cbrUsuarios WHERE Correo = @Correo AND Contrasena = @Contrasena",
                        CommandType = CommandType.Text,
                        Connection = sqlConnection1
                    })
                    {
                        cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = correo;
                        cmd.Parameters.Add("@Contrasena", SqlDbType.VarChar).Value = contrasena;
                        sqlConnection1.Open();

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                usuarioEncontrado = new User()
                                {
                                    Nombre = reader.GetString(0),
                                    Correo = reader.GetString(1),
                                    Fechanacimiento = reader.GetDateTime(2),
                                    Lugarestudio = reader.GetString(3)
                                };
                            }
                        }
                    }
                }
                return usuarioEncontrado;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
