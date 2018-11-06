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
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Lugarestudio { get; set; }
        public DateTime Fechanacimiento { get; set; }
        public string Reingresopassword { get; set; }

        ConexionDB connect = new ConexionDB();

        public Boolean IngresarUsuario(string nombre, string correo, string clave, string LugarEstudio,string FechaNacimiento,string ReingresoContraseña)
        {

            ConexionDB conexion = new ConexionDB();
            bool resultado = true;
            string strInsert = string.Empty;
            try
            {
                strInsert = "INSERT INTO PSD_USUARIO (NOMBRE, CORREO, CLAVE, LUGAR_ESTUDIO, FECHA_NACIMIENTO, REINGRESO_CONTRASENA) " +
                            " VALUES (@P_NOMBRE,@P_CORREO,@P_CLAVE,@P_LUGAR_ESTUDIO,@P_FECHA_NACIMIENTO,@P_REINGRESO_CONTRASENA)";

                Utils.Utils utils = new Utils.Utils();
                utils.LimpiarSqlParameterCollection();
                utils.parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@P_NOMBRE", nombre));
                utils.parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@P_CORREO", correo));
                utils.parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@P_CLAVE", clave));
                utils.parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@P_LUGAR_ESTUDIO", LugarEstudio));
                utils.parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@P_FECHA_NACIMIENTO", FechaNacimiento));
                utils.parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@P_REINGRESO_CONTRASENA", ReingresoContraseña));



                conexion.setDatosBD(strInsert, utils.parameterCollection);
            }
            catch (Exception)
            {

                throw;
            }


            return resultado;
        }

        public int GetPsdUsuarioIdPorCorreo(string correo)
        {
            ConexionDB conexion = new ConexionDB();
            int resultado = 0;
            try
            {
                string strSelect = " SELECT PSD_Usuario_ID FROM PSD_Usuario WHERE CORREO = @CORREO ";
                Utils.Utils utils = new Utils.Utils();
                utils.LimpiarSqlParameterCollection();
                utils.parameterCollection.Add(new System.Data.SqlClient.SqlParameter("@CORREO", correo));

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
