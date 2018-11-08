using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CBR_Web.Controllers;



namespace CBR_Web.Models
{
    public class User   
    {
        public string Nombre { get; set; }
        public string apellido { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Lugarestudio { get; set; }
        public DateTime Fechanacimiento { get; set; }
        public string Reingresopassword { get; set; }

        ConexionDB connect = new ConexionDB();

        public Boolean IngresarUsuario(string nombre, string apellido, string correo,string clave, string institucion,string fechanacimiento)
        {

            ConexionDB conexion = new ConexionDB();
            bool resultado = true;
            string strInsert = string.Empty;
            try
            {
                strInsert = "INSERT INTO dbo.cbr_Usuarios (Nombre, Apellido, Correo,Contrasena,FechaNacimiento,Institucion) " +
                            " VALUES (@Nombre, @Apellido, @Correo, @Contrasena,@FechaNacimiento, @Institucion)";

                Utils.Utils utils = new Utils.Utils();
                utils.LimpiarSqlParameterCollection();
                utils.parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@NOMBRE", nombre));
                utils.parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@Apellido", apellido));
                utils.parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@Correo", correo));
                utils.parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@Contrasena", clave));
                utils.parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@FechaNacimiento", fechanacimiento));
                utils.parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@Institucion", institucion));



                conexion.setDatosBD(strInsert, utils.parameterCollection);
            }
            catch (Exception)
            {

                throw;
            }


            return resultado;
        }

        public int GetUsuarioPorCorreoYContrasena(string correo,string contrasena)
        {
            ConexionDB conexion = new ConexionDB();
            int resultado = 0;
            try
            {
                string strSelect = " SELECT  Correo,Contrasena FROM dbo.cbr_Usuarios WHERE Correo = @CORREO AND Contrasena = @Contrasena ";
                Utils.Utils utils = new Utils.Utils();
                utils.LimpiarSqlParameterCollection();
                utils.parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@CORREO", correo));
                utils.parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@Contrasena", contrasena));

                resultado = int.Parse(conexion.getDatosBD(strSelect, utils.parameterCollection).Rows[0][0].ToString());

            }
            catch (Exception)
            {

                throw;
            }


            return resultado;
        }

    }
}
