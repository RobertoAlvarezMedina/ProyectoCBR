using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CBR_Web.Controllers;
using System.Data;
using CBR_Web.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CBR_Web.Utils
{
    public class Utils
    {
        public SqlParameterCollection parameterCollection { get; set; }
        public string CommandText { get; private set; }
        public CommandType CommandType { get; private set; }

        public void LimpiarSqlParameterCollection()
        {
            parameterCollection.Clear();
        }



        ConexionDB connect = new ConexionDB();

        public Boolean InsertarUsuario(User user)
        {
            using (var sqlConnection1 = new SqlConnection("Server = tcp:cbrdatabase.database.windows.net,1433; Initial Catalog = CBR Technologies; Persist Security Info = False; User ID = Byron; Password = miakhalifa69!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;")
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

                    //using (var reader = cmd.ExecuteReader())
                    //{
                    //    if (reader.Read())
                    //    {
                    //        var id = reader[0];
                    //        var whatEver = reader[1];
                    //        // get the rest of the columns you need the same way
                    //    }
                    //}
                }
            }
            return false;
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



        //public int GetUsuarioPorCorreoYContrasena(string correo, string contrasena)
        //{
        //    ConexionDB conexion = new ConexionDB();
        //    int resultado = 0;
        //    try
        //    {
        //        string strSelect = " SELECT  Correo,Contrasena FROM dbo.cbr_Usuarios WHERE Correo = @CORREO AND Contrasena = @Contrasena ";

        //       //LimpiarSqlParameterCollection();
        //       parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@CORREO", correo));
        //       parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@Contrasena", contrasena));

        //        resultado = int.Parse(conexion.getDatosBD(strSelect,parameterCollection).Rows[0][0].ToString());

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }


        //    return resultado;
        //}

    }
}
