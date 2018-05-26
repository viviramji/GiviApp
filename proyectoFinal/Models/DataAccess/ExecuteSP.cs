using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace proyectoFinal.Models.DataAccess
{
    public class ExecuteSP
    {
        static string ConnStr = "server=204.93.216.11;user=ivanbano_grupo10;database=ivanbano_grupo10;port=3306;password=grupo10;SslMode=none;";
        static MySqlConnection conn = null;
        static public MySqlDataReader executeStoreProcedure(string nombre, List<Parameter> parameters)
        {

            conn = new MySqlConnection(ConnStr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(nombre, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (Parameter p in parameters)
            {
                cmd.Parameters.AddWithValue("@" + p.name, p.value);
            }
            return cmd.ExecuteReader();

        }
        static public MySqlDataReader ExecuteSPWithoutParameters(string name)
        {
            conn = new MySqlConnection(ConnStr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(name, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            return cmd.ExecuteReader();
        }
    }
}