using System;
using System.Data;
using System.Data.SqlClient;

namespace CBR_Web.Controllers
{
    public class ConexionDB
    {
        public SqlConnection conexion = new SqlConnection();

        public SqlConnection ObtenerConexion()
        {
            conexion = new SqlConnection("Server = tcp:cbrdatabase.database.windows.net,1433; Initial Catalog = SERVICE_DESK; Persist Security Info = False; User ID = Byron; Password = miakhalifa69; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
            //Server=tcp:cbrdatabase.database.windows.net,1433;Initial Catalog=AnalisisDataBase;Persist Security Info=False;User ID=Byron;Password=miakhalifa69;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;

            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        //public Boolean Desconectar()
        //{
        //    Boolean desconectar = false;
        //    try
        //    {

        //        if (conexion.State.Equals(ConnectionState.Open))
        //        {
        //            conexion.Close();
        //            desconectar = true;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        desconectar = false;

        //    }
        //    finally
        //    {
        //        conexion.Close();
        //    }
        //    return desconectar;
        //}


        public DataTable getDatosBD(String strSQL, SqlParameterCollection ListaParametros)
        {
            DataTable dtDatos = new DataTable();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ObtenerConexion();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;
                if (ListaParametros != null)
                {
                    foreach (var item in ListaParametros)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dtDatos);
            }
            catch (Exception ex)
            {


            }
            finally
            {
                conexion.Close();
            }
            return dtDatos;
        }

        public String setDatosBD(String strSQL, SqlParameterCollection ListaParametros)
        {
            String bandera = String.Empty;
            try
            {
                ObtenerConexion();
                SqlCommand cmd = conexion.CreateCommand();
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
                conexion.Close();
            }
            return bandera;
        }


    }
}
