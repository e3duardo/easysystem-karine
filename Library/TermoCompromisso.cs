using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Npgsql;

namespace Library
{
    public class TermoCompromisso
    {
        public TermoCompromisso()
        {
        }

        public long Id { get; set; }
        public Library.Cliente Cliente { get; set; }
        public Library.Empresa Empresa { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public int Status { get; set; }
    }
    



    public class TermoCompromissoBD
    {
        private TermoCompromissoBD()
        {
        }

        static public void Save(Library.TermoCompromisso termoCompromisso)
        {
            NpgsqlConnection conexao = null;
            try
            {
                long id = GetNextId();
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                using (NpgsqlCommand comando = conexao.CreateCommand())
                {

                    comando.CommandText = "INSERT INTO \"TermoCompromisso\" (idCliente, idEmpresa, valor, data, status) VALUES (@idCliente, @idEmpresa, @valor, @data, @status)";

                    comando.Parameters.AddWithValue("@idCliente", termoCompromisso.Cliente.Id);
                    comando.Parameters.AddWithValue("@idEmpresa", termoCompromisso.Empresa.Id);
                    comando.Parameters.AddWithValue("@valor", termoCompromisso.Valor);
                    comando.Parameters.AddWithValue("@data", termoCompromisso.Data);
                    comando.Parameters.AddWithValue("@status", termoCompromisso.Status);

                    conexao.Open();

                    termoCompromisso.Id = id;

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

        static public void Update(Library.TermoCompromisso termoCompromisso)
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                using (NpgsqlCommand comando = conexao.CreateCommand())
                {

                    comando.CommandText = "UPDATE \"TermoCompromisso\" SET  idCliente = @idCliente, idEmpresa = @idEmpresa, valor = @valor, data = @data, status = @status WHERE (id= " + termoCompromisso.Id + ")";

                    comando.Parameters.AddWithValue("@idCliente", termoCompromisso.Cliente.Id);
                    comando.Parameters.AddWithValue("@idEmpresa", termoCompromisso.Empresa.Id);
                    comando.Parameters.AddWithValue("@valor", termoCompromisso.Valor);
                    comando.Parameters.AddWithValue("@data", termoCompromisso.Data);
                    comando.Parameters.AddWithValue("@status", termoCompromisso.Status);

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

        static public void DeleteById(long idTermoCompromisso)
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());
                NpgsqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM \"TermoCompromisso\" WHERE id='" + idTermoCompromisso + "'";

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

        static public List<Library.TermoCompromisso> FindAdvanced(params Library.Classes.QItem[] args)
        {
            NpgsqlDataReader rdr = null;
            NpgsqlConnection conexao = null;

            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                using (NpgsqlCommand comando = new NpgsqlCommand())
                {
                    string query = "SELECT * FROM \"TermoCompromisso\" AS tc "
                                    + "INNER JOIN \"Cliente\" AS c ON c.id = tc.idCliente "
                                    + "INNER JOIN \"Empresa\" AS e ON e.id = tc.idEmpresa ";

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
                            case "tc.id":
                                query += pre + "(tc.id = @id)";
                                comando.Parameters.AddWithValue("@id", qi.Objeto);
                                break;
                            case "e.id":
                                query += pre + "(e.id = @idEmpresa)";
                                comando.Parameters.AddWithValue("@idEmpresa", qi.Objeto);
                                break;
                            case "c.id":
                                query += pre + "(c.id = @idCliente)";
                                comando.Parameters.AddWithValue("@idCliente", qi.Objeto);
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

                List<Library.TermoCompromisso> termos = new List<Library.TermoCompromisso>();

                while (rdr.Read())
                {
                    DateTime date = DateTime.MinValue;
                    DateTime.TryParse(rdr["data"].ToString(), out date);

                    Library.TermoCompromisso termoCompromisso = new TermoCompromisso();
                    termoCompromisso.Id = (long)rdr["id"];
                    termoCompromisso.Cliente = Library.ClienteBD.FindById((long)rdr["idCliente"]);
                    termoCompromisso.Empresa = Library.EmpresaBD.FindById((long)rdr["idEmpresa"]);
                    termoCompromisso.Valor = (double)rdr["valor"];
                    termoCompromisso.Data = date;
                    termoCompromisso.Status = (int)rdr["status"];

                    termos.Add(termoCompromisso);
                }

                return termos;
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

        static public List<Library.Cliente> FindClientesDistinct()
        {
            NpgsqlDataReader rdr = null;
            NpgsqlConnection conexao = null;

            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                using (NpgsqlCommand comando = new NpgsqlCommand())
                {
                    string query = "SELECT DISTINCT(idCliente) FROM \"TermoCompromisso\"";
                    
                    comando.CommandText = query;

                    comando.Connection = conexao;

                    conexao.Open();

                    rdr = comando.ExecuteReader();
                }
                List<Library.Cliente> clientes = new List<Library.Cliente>();

                while (rdr.Read())
                {
                    Library.Cliente cliente = Library.ClienteBD.FindById((long)rdr["idCliente"]);

                    clientes.Add(cliente);
                }

                return clientes;
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

        static public List<Library.Empresa> FindEmpresasDistinct()
        {
            NpgsqlDataReader rdr = null;
            NpgsqlConnection conexao = null;

            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                using (NpgsqlCommand comando = new NpgsqlCommand())
                {
                    string query = "SELECT DISTINCT(idEmpresa) FROM \"TermoCompromisso\"";

                    comando.CommandText = query;

                    comando.Connection = conexao;

                    conexao.Open();

                    rdr = comando.ExecuteReader();
                }
                List<Library.Empresa> empresas = new List<Library.Empresa>();

                while (rdr.Read())
                {
                    Library.Empresa empresa = Library.EmpresaBD.FindById((long)rdr["idEmpresa"]);

                    empresas.Add(empresa);
                }

                //empresas.Sort();
                empresas.Sort(delegate(Library.Empresa p1, Library.Empresa p2) { return p1.Nome.CompareTo(p2.Nome); });

               
                return empresas;
            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex);
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }
            return null;
        }

        static public Library.TermoCompromisso FindById(long idTermoCompromisso)
        {
            NpgsqlConnection conexao = null;
            NpgsqlDataAdapter dap = null;
            DataSet ds = null;
            //Library.TermoCompromisso TermoCompromisso = null;
            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                dap = new NpgsqlDataAdapter("SELECT * FROM \"TermoCompromisso\" WHERE id='" + idTermoCompromisso + "'", conexao);

                ds = new DataSet();

                dap.Fill(ds, "TermoCompromisso");

                if (ds.Tables["TermoCompromisso"].Rows.Count == 1)
                {
                    DateTime date = DateTime.MinValue;
                    DateTime.TryParse(ds.Tables["TermoCompromisso"].Rows[0]["data"].ToString(), out date);
                    
                    Library.TermoCompromisso termoCompromisso = new TermoCompromisso();
                    termoCompromisso.Id = (long)ds.Tables["TermoCompromisso"].Rows[0]["id"];
                    termoCompromisso.Cliente = Library.ClienteBD.FindById((long)ds.Tables["TermoCompromisso"].Rows[0]["idCliente"]);
                    termoCompromisso.Empresa = Library.EmpresaBD.FindById((long)ds.Tables["TermoCompromisso"].Rows[0]["idEmpresa"]);
                    termoCompromisso.Valor = (double)ds.Tables["TermoCompromisso"].Rows[0]["valor"];
                    termoCompromisso.Data = date;
                    termoCompromisso.Status = (int)ds.Tables["TermoCompromisso"].Rows[0]["status"];


                    return termoCompromisso;
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

                comando.CommandText = "SELECT MAX(id) AS lastId FROM \"TermoCompromisso\" ";

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
