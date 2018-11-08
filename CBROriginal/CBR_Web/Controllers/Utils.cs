using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CBR_Web.Controllers;
using CBR_Web.Models;

namespace CBR_Web.Utils
{
    public class Utils
    {
        public SqlParameterCollection parameterCollection { get; set; }

        public void LimpiarSqlParameterCollection()
        {
            parameterCollection.Clear();
        }



        ConexionDB connect = new ConexionDB();

        public Boolean IngresarUsuario(User user)

        {

            ConexionDB conexion = new ConexionDB();
            string strInsert = string.Empty;
            try
            {
                strInsert = "INSERT INTO dbo.cbr_Usuarios (Nombre, Correo,Contrasena,FechaNacimiento,Institucion) " +
                            " VALUES (@Nombre, @Correo, @Contrasena,@FechaNacimiento, @Institucion)";

                //LimpiarSqlParameterCollection();
                parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@Nombre", user.Nombre));
                parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@Correo", user.Correo));
                parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@Contrasena", user.Clave));
                parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@FechaNacimiento", user.Fechanacimiento));
                parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@Institucion",user.Lugarestudio));



                conexion.setDatosBD(strInsert,parameterCollection);
            }
            catch (Exception ex)
            {
                return false;
                
            }


            return true;
        }

        public int GetUsuarioPorCorreoYContrasena(string correo, string contrasena)
        {
            ConexionDB conexion = new ConexionDB();
            int resultado = 0;
            try
            {
                string strSelect = " SELECT  Correo,Contrasena FROM dbo.cbr_Usuarios WHERE Correo = @CORREO AND Contrasena = @Contrasena ";

               //LimpiarSqlParameterCollection();
               parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@CORREO", correo));
               parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@Contrasena", contrasena));

                resultado = int.Parse(conexion.getDatosBD(strSelect,parameterCollection).Rows[0][0].ToString());

            }
            catch (Exception)
            {

                throw;
            }


            return resultado;
        }

    }
}
