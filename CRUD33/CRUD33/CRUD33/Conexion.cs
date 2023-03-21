using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CRUD33
{
    public class Conexion
    {
        static string serverName = "localhost";  
        static int port = 5432;            
        static string userName = "postgres";    
        static int password = 12345;     
        static string databaseName = "BD_UniversidadP";


        NpgsqlConnection pgsqlConnection = null;
        string connString = null;

        public Conexion()
        {
            connString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                                          serverName, port, userName, password, databaseName);
        }

        //Pega todos os registros
        public DataTable GetRegistros()
        {
            DataTable dt = new DataTable();
            try
            {
                using (pgsqlConnection = new NpgsqlConnection(connString))
                {
                    // abre la conexión con la BD PgSQL
                    pgsqlConnection.Open();
                    string cmdSeleciona = "Select * from tb_persona order by id_usuario";

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }
            return dt;
        }


        
        public DataTable GetRegistroPorId(int id_usuario)
        {
            DataTable dt = new DataTable();
            try
            {
                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(connString))
                {
                   
                    pgsqlConnection.Open();
                    string cmdSeleciona = "Select * from tb_persona Where id_usuario = " + id_usuario;

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }
            return dt;
        }

        //Insertar registros
        public void InsertarRegistros(int id_usuario, string nombre, string email, int edad)
        {
           try
           {
                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(connString))
                {
                    //Abrir la conexión con PgSQL                  
                    pgsqlConnection.Open();

                    string cmdInsertar = String.Format("Insert INTO tb_persona VALUES ({0},{1},{2},{3})", id_usuario, nombre, email, edad);
                    using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(cmdInsertar, pgsqlConnection))
                    {
                        pgsqlcommand.ExecuteNonQuery();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }
        }

        //Actualizar registros
        public void AtualizarRegistro(int id_usuario, string nombre, string email, int edad)
        {
            try
            {
                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(connString))
                {
                    //Abrir la conexión con PgSQL                  
                    pgsqlConnection.Open();

                    string cmdAtualiza = String.Format("Update tb_persona Set nombre='{1}',email='{2}', edad= '{3}' Where id_usuario='{0}'", id_usuario,nombre,email,edad);

                    using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(cmdAtualiza, pgsqlConnection))
                    {
                        pgsqlcommand.ExecuteNonQuery();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }
        }

        //Eliminar registros
        public void BorrarRegistro(int id_usuario)
        {
            try
            {
                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(connString))
                {
                    //abre la conexión             
                    pgsqlConnection.Open();

                    string cmdBorrar = String.Format("Delete From tb_persona Where id_usuario = '{0}'", id_usuario);

                    using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(cmdBorrar, pgsqlConnection))
                    {
                        pgsqlcommand.ExecuteNonQuery();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }
        }
    }
}
