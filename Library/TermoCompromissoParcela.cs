using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Npgsql;

namespace Library
{
    public class TermoCompromissoParcela
    {
        public TermoCompromissoParcela()
        {
        }

        public long Id { get; set; }
        public Library.TermoCompromisso TermoCompromisso { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public int Pago { get; set; }
    }
    public class TermoCompromissoParcelaBD
    {
        private TermoCompromissoParcelaBD()
        {
        }

        static public void Save(Library.TermoCompromissoParcela TermoCompromissoParcela)
        {
            NpgsqlConnection conexao = null;
            try
            {
                long id = GetNextId();
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                using (NpgsqlCommand comando = conexao.CreateCommand())
                {

                    comando.CommandText = "INSERT INTO \"TermoCompromissoParcela\" (idTermoCompromisso, valor, data, pago) VALUES (@idTermoCompromisso, @valor, @data, @pago)";

                    comando.Parameters.AddWithValue("@idTermoCompromisso", TermoCompromissoParcela.TermoCompromisso.Id);
                    comando.Parameters.AddWithValue("@valor", TermoCompromissoParcela.Valor);
                    comando.Parameters.AddWithValue("@data", TermoCompromissoParcela.Data);
                    comando.Parameters.AddWithValue("@pago", TermoCompromissoParcela.Pago);

                    conexao.Open();

                    TermoCompromissoParcela.Id = id;

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

        static public void Update(Library.TermoCompromissoParcela TermoCompromissoParcela)
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                using (NpgsqlCommand comando = conexao.CreateCommand())
                {

                    comando.CommandText = "UPDATE \"TermoCompromissoParcela\" SET  valor = @valor, data = @data, pago = @pago WHERE (id= " + TermoCompromissoParcela.Id + ")";

                    comando.Parameters.AddWithValue("@idTermoCompromisso", TermoCompromissoParcela.TermoCompromisso.Id);
                    comando.Parameters.AddWithValue("@valor", TermoCompromissoParcela.Valor);
                    comando.Parameters.AddWithValue("@data", TermoCompromissoParcela.Data);
                    comando.Parameters.AddWithValue("@pago", TermoCompromissoParcela.Pago);

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

        static public void DeleteById(long idTermoCompromissoParcela)
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());
                NpgsqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM \"TermoCompromissoParcela\" WHERE id='" + idTermoCompromissoParcela + "'";

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

        static public List<Library.TermoCompromissoParcela> FindAdvanced(params Library.Classes.QItem[] args)
        {
            NpgsqlDataReader rdr = null;
            NpgsqlConnection conexao = null;

            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                using (NpgsqlCommand comando = new NpgsqlCommand())
                {
                    string query = "SELECT * FROM \"TermoCompromissoParcela\" AS tcp "
                                    + "INNER JOIN \"TermoCompromisso\" AS tc ON tc.id = tcp.idTermoCompromisso ";

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
                            case "tcp.id":
                                query += pre + "(tcp.id = @id)";
                                comando.Parameters.AddWithValue("@id", qi.Objeto);
                                break;
                            case "tc.id":
                                query += pre + "(tc.id = @idTermo)";
                                comando.Parameters.AddWithValue("@idTermo", qi.Objeto);
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
                List<Library.TermoCompromissoParcela> TermoCompromissoParcelas = new List<Library.TermoCompromissoParcela>();

                while (rdr.Read())
                {
                    DateTime date = DateTime.MinValue;
                    DateTime.TryParse(rdr["data"].ToString(), out date);

                    Library.TermoCompromissoParcela TermoCompromissoParcela = new TermoCompromissoParcela();
                    TermoCompromissoParcela.Id = (long)rdr["id"];
                    TermoCompromissoParcela.TermoCompromisso = Library.TermoCompromissoBD.FindById((long)rdr["idTermoCompromisso"]);
                    TermoCompromissoParcela.Valor = (double)rdr["valor"];
                    TermoCompromissoParcela.Data = date;
                    TermoCompromissoParcela.Pago = (int)rdr["pago"];

                    TermoCompromissoParcelas.Add(TermoCompromissoParcela);
                }

                return TermoCompromissoParcelas;
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

        static public Library.TermoCompromissoParcela FindById(long idTermoCompromissoParcela)
        {
            NpgsqlConnection conexao = null;
            NpgsqlDataAdapter dap = null;
            DataSet ds = null;
            //Library.TermoCompromissoParcela TermoCompromissoParcela = null;
            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                dap = new NpgsqlDataAdapter("SELECT * FROM \"TermoCompromissoParcela\" WHERE id='" + idTermoCompromissoParcela + "'", conexao);

                ds = new DataSet();

                dap.Fill(ds, "TermoCompromissoParcela");

                if (ds.Tables["TermoCompromissoParcela"].Rows.Count == 1)
                {
                    DateTime date = DateTime.MinValue;
                    DateTime.TryParse(ds.Tables["TermoCompromissoParcela"].Rows[0]["data"].ToString(), out date);

                    Library.TermoCompromissoParcela termoCompromissoParcela = new TermoCompromissoParcela();
                    termoCompromissoParcela.Id = (long)ds.Tables["TermoCompromissoParcela"].Rows[0]["id"];
                    termoCompromissoParcela.TermoCompromisso = Library.TermoCompromissoBD.FindById((long)ds.Tables["TermoCompromissoParcela"].Rows[0]["idTermoCompromisso"]);
                    termoCompromissoParcela.Valor = (double)ds.Tables["TermoCompromissoParcela"].Rows[0]["valor"];
                    termoCompromissoParcela.Data = date;
                    termoCompromissoParcela.Pago = (int)ds.Tables["TermoCompromissoParcela"].Rows[0]["pago"];

                    return termoCompromissoParcela;
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

                comando.CommandText = "SELECT MAX(id) AS lastId FROM \"TermoCompromissoParcela\" ";

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
