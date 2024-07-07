using Invent.Model;
using Microsoft.Data.SqlClient;

using System.Collections.Generic;
//using System.Data.SqlClient;

namespace Invent.Data
{
    internal static class BaseDatos
    {
        private static readonly string cadenaConexion = @"data source=sql.bsite.net\MSSQL2016;initial catalog=jnieves_SampleDB;user id=jnieves_SampleDB;password=0Pk9*+_srrXbuUc;Connect Timeout=60;TrustServerCertificate=true";

        internal static string GetCadenaConexion()
        {
            return cadenaConexion;
        }

        public static List<Inventario> GetInventario()
        {
            List<Inventario> listaEmpleados = new List<Inventario>(); //return listaEmpleados;
            string sql = "SELECT [id_prod],[id_mcodbarra],[plu],[descripcion],[boleta],[ubicacion],[monto],[cantidad],[valor],[total],[valor_imp],[total_imp],[id_unico],[fecha],[numeracion] FROM [inventario]";

            using (SqlConnection con = new SqlConnection(GetCadenaConexion()))
            {
                con.Open();

                using (SqlCommand sqlCommand = new SqlCommand(sql, con))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Inventario inventario = new Inventario()
                            {
                                id_prod = reader.GetInt32(0),
                                id_mcodbarra = reader.GetString(1),
                                plu = reader.GetString(2),
                                descripcion = reader["descripcion"]?.ToString(),
                                boleta = reader.GetInt32(4),
                                ubicacion = reader["ubicacion"]?.ToString(),
                                monto = reader.GetDouble(6),
                                cantidad = reader.GetDouble(7),
                                valor = reader.GetDouble(8),
                                total = reader.GetDouble(9),
                                valor_imp = reader.GetDouble(10),
                                total_imp = reader.GetDouble(11),
                                id_unico = reader.GetInt32(12),
                                fecha = reader.GetDateTime(13),
                                numeracion = reader.GetInt16(14)
                            };

                            listaEmpleados.Add(inventario);
                        }
                    }
                }

                con.Close();

                return listaEmpleados;
            }
        }

        public static bool InsertInventario(Inventario inventario)
        {
            bool ret;
            string sql = "INSERT INTO [inventario] " +
                        "([id_prod],[id_mcodbarra],[plu],[descripcion],[boleta],[ubicacion],[monto],[cantidad],[valor],[total],[valor_imp],[total_imp],[fecha],[numeracion]) VALUES " +
                        "(@id_prod,@id_mcodbarra,@plu,@descripcion,@boleta,@ubicacion,@monto,@cantidad,@valor,@total,@valor_imp,@total_imp,@fecha,@numeracion)";
            
            using (SqlConnection con = new SqlConnection(GetCadenaConexion()))
            {
                con.Open();

                using (SqlCommand sqlCommand = new SqlCommand(sql, con))
                {
                    sqlCommand.Parameters.AddWithValue("@id_prod", inventario.id_prod);
                    sqlCommand.Parameters.AddWithValue("@id_mcodbarra", inventario.id_mcodbarra);
                    sqlCommand.Parameters.AddWithValue("@plu", inventario.plu);
                    sqlCommand.Parameters.AddWithValue("@descripcion", inventario.descripcion);
                    sqlCommand.Parameters.AddWithValue("@boleta", inventario.boleta);

                    sqlCommand.Parameters.AddWithValue("@ubicacion", inventario.ubicacion);
                    sqlCommand.Parameters.AddWithValue("@monto", inventario.monto);
                    sqlCommand.Parameters.AddWithValue("@cantidad", inventario.cantidad);
                    sqlCommand.Parameters.AddWithValue("@valor", inventario.valor);
                    sqlCommand.Parameters.AddWithValue("@total", inventario.total);

                    sqlCommand.Parameters.AddWithValue("@valor_imp", inventario.valor_imp);
                    sqlCommand.Parameters.AddWithValue("@total_imp", inventario.total_imp);
                    sqlCommand.Parameters.AddWithValue("@fecha", inventario.fecha);
                    sqlCommand.Parameters.AddWithValue("@numeracion", inventario.numeracion);
                    
                    ret = sqlCommand.ExecuteNonQuery() > 0;
                }

                con.Close();

                return ret;
            }
        }

        public static bool UpdateInventario(Inventario inventario)
        {
            bool ret;
            string sql = "UPDATE [inventario] " + 
                       "SET[id_prod] = @id_prod " + 
                          ",[id_mcodbarra] = @id_mcodbarra " + 
                          ",[plu] = @plu " + 
                          ",[descripcion] = @descripcion " + 
                          ",[boleta] = @boleta " + 
                          ",[ubicacion] = @ubicacion " + 
                          ",[monto] = @monto " + 
                          ",[cantidad] = @cantidad " + 
                          ",[valor] = @valor " + 
                          ",[total] = @total " + 
                          ",[valor_imp] = @valor_imp " + 
                          ",[total_imp] = @total_imp " + 
                          ",[fecha] = @fecha " + 
                          ",[numeracion] = @numeracion " + 
                     "WHERE id_unico = id_unico";

            using (SqlConnection con = new SqlConnection(GetCadenaConexion()))
            {
                con.Open();

                using (SqlCommand sqlCommand = new SqlCommand(sql, con))
                {
                    sqlCommand.Parameters.AddWithValue("@id_prod", inventario.id_prod);
                    sqlCommand.Parameters.AddWithValue("@id_mcodbarra", inventario.id_mcodbarra);
                    sqlCommand.Parameters.AddWithValue("@plu", inventario.plu);
                    sqlCommand.Parameters.AddWithValue("@descripcion", inventario.descripcion);
                    sqlCommand.Parameters.AddWithValue("@boleta", inventario.boleta);

                    sqlCommand.Parameters.AddWithValue("@ubicacion", inventario.ubicacion);
                    sqlCommand.Parameters.AddWithValue("@monto", inventario.monto);
                    sqlCommand.Parameters.AddWithValue("@cantidad", inventario.cantidad);
                    sqlCommand.Parameters.AddWithValue("@valor", inventario.valor);
                    sqlCommand.Parameters.AddWithValue("@total", inventario.total);

                    sqlCommand.Parameters.AddWithValue("@valor_imp", inventario.valor_imp);
                    sqlCommand.Parameters.AddWithValue("@total_imp", inventario.total_imp);
                    sqlCommand.Parameters.AddWithValue("@fecha", inventario.fecha);
                    sqlCommand.Parameters.AddWithValue("@numeracion", inventario.numeracion);
                    sqlCommand.Parameters.AddWithValue("@id_unico", inventario.id_unico);

                    ret = sqlCommand.ExecuteNonQuery() > 0;
                }

                con.Close();

                return ret;
            }
        }

        public static bool DeleteInventario(Inventario inventario)
        {
            bool ret;
            string sql = "DELETE FROM [inventario] " +
                     "WHERE id_unico = id_unico";

            using (SqlConnection con = new SqlConnection(GetCadenaConexion()))
            {
                con.Open();

                using (SqlCommand sqlCommand = new SqlCommand(sql, con))
                {
                    sqlCommand.Parameters.AddWithValue("@id_unico", inventario.id_unico);

                    ret = sqlCommand.ExecuteNonQuery() > 0;
                }

                con.Close();

                return ret;
            }
        }

    }
}
