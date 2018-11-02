using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using CBR_Web.Controllers;

namespace CBR_Web.Models
{
    public class Usercs
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Lugarestudio { get; set; }
        public DateTime Fechanacimiento { get; set; }
        public string Reingresopassword { get; set; }

        ConexionDB connect = new ConexionDB();

        public void Agregarususarionuevo()
        {
            String consulta = String.Empty;
            try
            {
                consulta = " INSERT INTO USUARIO (                 ";
                consulta += " NOMBRE,                             ";
                consulta += " CORREO,                        ";
                consulta += " LUGARESTUDIO,                       ";
                consulta += " FECHANACIMIENTO,                       ";
                consulta += " FECHANACIMIENTO,                       ";
                consulta += " REINGRESOPASSWORD)                       ";
                consulta += " VALUES(                               ";
                consulta += " '" + Nombre + "',            ";
                consulta += " '" + Correo + "',                 ";
                consulta += " '" + Clave + "',                 ";
                consulta += " '" + Lugarestudio + "',                 ";
                consulta += " '" + Fechanacimiento + "',                 ";
                consulta += " '" + Reingresopassword + "',                 ";
                consulta += " )                                     ";

                connect.setDatosBD(consulta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable CargarUsuarioExistente(String strWhere)
        {
            try
            {
                String Consulta = "SELECT CORREO,CLAVE FROM USUARIO";

                if (!String.Empty.Equals(strWhere))
                {
                    Consulta = Consulta + " WHERE " + strWhere;
                }

                return connect.getDatosBD(Consulta);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
