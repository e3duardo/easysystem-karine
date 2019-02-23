using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Library
{
    public class Logons
    {
        public Logons()
        {
        }


        public long Id { get; set; }
        public Library.Funcionario Funcionario { get; set; }
        public DateTime? Data { get; set; }
    }
    public class LogonsBD
    {
        private LogonsBD()
        {
        }

        static public void Save(Library.Logons logons)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO Logons (idFuncionario, data) VALUES (@idFuncionario, @data)"
                +"SELECT CAST(scope_identity() AS bigint)";

                comando.Parameters.AddWithValue("@idFuncionario", logons.Funcionario.Id);
                comando.Parameters.AddWithValue("@data", logons.Data);

                conexao.Open();

                //comando.ExecuteNonQuery();
                logons.Id = (long)comando.ExecuteScalar();

            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex.Message,ex.StackTrace,ex.HelpLink,ex);;
            }
            finally
            {
                conexao.Close();
            }
        }

        static public void Update(Library.Logons logons)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "UPDATE Logons SET idFuncionario = @idFuncionario, data = @data WHERE (id= " + logons.Id + ")";
                comando.Parameters.AddWithValue("@idFuncionario", logons.Funcionario.Id);
                comando.Parameters.AddWithValue("@data", logons.Data);

                conexao.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex.Message,ex.StackTrace,ex.HelpLink,ex);;
            }
            finally
            {
                conexao.Close();
            }
        }

        static public void DeleteById(long idLogons)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM Logons WHERE id='" + idLogons + "'";

                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex.Message,ex.StackTrace,ex.HelpLink,ex);;
            }
            finally
            {
                conexao.Close();
            }
        }

        static public List<Library.Logons> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM Logons AS l ";

                int p = 0;
                string pre = "";
                foreach (Library.Classes.QItem qi in args)
                {
                    if (p == 0)
                        pre = "WHERE ";
                    else
                        pre = "AND ";

                    p++;

                    switch (qi.Campo)
                    {
                        case "l.id":
                            query += pre + "l.id = @id";
                            comando.Parameters.AddWithValue("@id", qi.Objeto);
                            break;
                    }
                }

                comando.CommandText = query;

                comando.Connection = conexao;

                conexao.Open();

                rdr = comando.ExecuteReader();

                List<Library.Logons> logonsList = new List<Library.Logons>();

                while (rdr.Read())
                {
                    Library.Logons logons = new Logons();
                    logons.Id = (long)rdr["id"];
                    logons.Funcionario = Library.FuncionarioBD.FindFuncionarioById((long)rdr["idFuncionario"]);
                    logons.Data = (DateTime)rdr["data"];

                    logonsList.Add(logons);
                }

                return logonsList;
            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex.Message, ex.StackTrace, ex.HelpLink, ex); ;
            }
            finally
            {
                conexao.Close();
                comando.Dispose();
            }
            return null;
        }

        static public Library.Logons FindLogonsById(long idLogons)
        {
            SqlConnection conexao = null;
            SqlDataAdapter dap = null;
            DataSet ds = null;
            Library.Logons logons = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                dap = new SqlDataAdapter("SELECT * FROM Logons WHERE id='" + idLogons + "'", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Logons");

                if (ds.Tables["Logons"].Rows.Count == 1)
                {
                    logons = new Logons();
                    logons.Id = (long)ds.Tables["Logons"].Rows[0]["id"];
                    logons.Funcionario = Library.FuncionarioBD.FindFuncionarioById((long)ds.Tables["Logons"].Rows[0]["idFuncionario"]);
                    logons.Data = (DateTime)ds.Tables["Logons"].Rows[0]["data"];
                }
                return logons;
            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex.Message,ex.StackTrace,ex.HelpLink,ex);;
            }
            finally
            {
                conexao.Close();
                dap.Dispose();
                ds.Dispose();
            }
            return null;
        }

        static public long GetNextId()
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "SELECT IDENT_CURRENT('Logons') AS lastId";

                conexao.Open();
                long lastId = 0;
                long.TryParse(comando.ExecuteScalar().ToString(), out lastId);


                return lastId + 1;
            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex.Message,ex.StackTrace,ex.HelpLink,ex);;
            }
            finally
            {
                conexao.Close();
            }
            return 0;
        }
    }
}
