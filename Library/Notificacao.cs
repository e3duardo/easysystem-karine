using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Npgsql;

namespace Library
{
    public class Notificacao
    {
        public Notificacao()
        {
        }

        public long Id { get; set; }
        public Library.TermoCompromisso TermoCompromisso { get; set; }
        public string Texto { get; set; }
        public DateTime Data { get; set; }
        public bool isJudicial { get; set; }
    }
    public class NotificacaoBD
    {
        private NotificacaoBD()
        {
        }

        static public void Save(Library.Notificacao Notificacao)
        {
            NpgsqlConnection conexao = null;
            try
            {
                long id = GetNextId();
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                using (NpgsqlCommand comando = conexao.CreateCommand())
                {

                    comando.CommandText = "INSERT INTO \"Notificacao\" (idTermoCompromisso, texto, data, isJudicial) VALUES (@idTermoCompromisso, @texto, @data, @isJudicial)";

                    comando.Parameters.AddWithValue("@idTermoCompromisso", Notificacao.TermoCompromisso.Id);
                    comando.Parameters.AddWithValue("@texto", Notificacao.Texto);
                    comando.Parameters.AddWithValue("@data", Notificacao.Data);
                    if (Notificacao.isJudicial)
                        comando.Parameters.AddWithValue("@isJudicial", 1);
                    else
                        comando.Parameters.AddWithValue("@isJudicial", 0);

                    conexao.Open();

                    Notificacao.Id = id;

                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex); ;
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        static public void Update(Library.Notificacao Notificacao)
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                using (NpgsqlCommand comando = conexao.CreateCommand())
                {

                    comando.CommandText = "UPDATE \"Notificacao\" SET idTermoCompromisso = @idTermoCompromisso, texto = @texto, data = @data, isJudicial = @isJudicial WHERE (id= " + Notificacao.Id + ")";

                    comando.Parameters.AddWithValue("@idTermoCompromisso", Notificacao.TermoCompromisso.Id);
                    comando.Parameters.AddWithValue("@texto", Notificacao.Texto);
                    comando.Parameters.AddWithValue("@data", Notificacao.Data);
                    if (Notificacao.isJudicial)
                        comando.Parameters.AddWithValue("@isJudicial", 1);
                    else
                        comando.Parameters.AddWithValue("@isJudicial", 0);

                    conexao.Open();

                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex); ;
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
        }

        static public void DeleteById(long idNotificacao)
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());
                NpgsqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM \"Notificacao\" WHERE id='" + idNotificacao + "'";

                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex); ;
            }
            finally
            {
                conexao.Close();
            }
        }

        static public List<Library.Notificacao> FindAdvanced(params Library.Classes.QItem[] args)
        {
            NpgsqlDataReader rdr = null;
            NpgsqlConnection conexao = null;

            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                using (NpgsqlCommand comando = new NpgsqlCommand())
                {
                    string query = "SELECT * FROM \"Notificacao\" AS n " +
                                    "INNER JOIN \"TermoCompromisso\" AS tc ON tc.id = n.idTermoCompromisso ";

                    int p = 0;
                    string pre = "";
                    foreach (Library.Classes.QItem qi in args)
                    {
                        if (p == 0)
                            pre = "WHERE ";
                        else
                            pre = " AND ";

                        p++;

                        switch (qi.Campo)
                        {
                            case "n.id":
                                query += pre + "(n.id = @id)";
                                comando.Parameters.AddWithValue("@id", qi.Objeto);
                                break;
                            case "n.idTermoCompromisso":
                                query += pre + "(n.idTermoCompromisso = @idTC)";
                                comando.Parameters.AddWithValue("@idTC", qi.Objeto);
                                break;
                            case "tc.id":
                                query += pre + "(tc.id = @idtermocompromisso)";
                                comando.Parameters.AddWithValue("@idtermocompromisso", qi.Objeto);
                                break;
                            case "tc.status":
                                query += pre + "(tc.status = @status)";
                                comando.Parameters.AddWithValue("@status", qi.Objeto);
                                break;
                            case "ORDER BY":
                                query += " ORDER BY " + qi.Objeto;
                                break;
                        }
                    }

                    comando.CommandText = query;

                    comando.Connection = conexao;

                    conexao.Open();

                    rdr = comando.ExecuteReader();
                }
                List<Library.Notificacao> notificacoes = new List<Library.Notificacao>();

                while (rdr.Read())
                {
                    DateTime date = DateTime.MinValue;
                    DateTime.TryParse(rdr["data"].ToString(), out date);

                    Library.Notificacao notificacao = new Notificacao();
                    notificacao.Id = (long)rdr["id"];
                    notificacao.TermoCompromisso = Library.TermoCompromissoBD.FindById((long)rdr["idTermoCompromisso"]);
                    notificacao.Texto = rdr["texto"].ToString();
                    notificacao.Data = date;

                    if ((int)rdr["isJudicial"] == 1)
                        notificacao.isJudicial = true;
                    else
                        notificacao.isJudicial = false;

                    notificacoes.Add(notificacao);
                }

                return notificacoes;
            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex); ;
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
            return null;
        }

        static public Library.Notificacao FindById(long idNotificacao)
        {
            NpgsqlConnection conexao = null;
            NpgsqlDataAdapter dap = null;
            DataSet ds = null;
            //Library.Notificacao Notificacao = null;
            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                dap = new NpgsqlDataAdapter("SELECT * FROM \"Notificacao\" WHERE id='" + idNotificacao + "'", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Notificacao");

                if (ds.Tables["Notificacao"].Rows.Count == 1)
                {
                    DateTime date = DateTime.MinValue;
                    DateTime.TryParse(ds.Tables["Notificacao"].Rows[0]["data"].ToString(), out date);

                    Library.Notificacao notificacao = new Notificacao();
                    notificacao.Id = (long)ds.Tables["Notificacao"].Rows[0]["id"];
                    notificacao.TermoCompromisso = Library.TermoCompromissoBD.FindById((long)ds.Tables["Notificacao"].Rows[0]["idTermoCompromisso"]);
                    notificacao.Texto = ds.Tables["Notificacao"].Rows[0]["texto"].ToString();
                    notificacao.Data = date;
                    if ((int)ds.Tables["Notificacao"].Rows[0]["isJudicial"] == 1)
                        notificacao.isJudicial = true;
                    else
                        notificacao.isJudicial = false;

                    return notificacao;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex); ;
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
            NpgsqlConnection conexao = null;
            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());
                NpgsqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "SELECT MAX(id) AS lastId FROM \"Notificacao\" ";

                conexao.Open();

                long lastId = 0;
                long.TryParse(comando.ExecuteScalar().ToString(), out lastId);


                return lastId + 1;
            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex); ;
            }
            finally
            {
                conexao.Close();
            }
            return 0;
        }
    }
}
