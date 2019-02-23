using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Npgsql;

namespace Library
{
    public class Empresa
    {
        public Empresa()
        {
        }


        public long Id { get; set; }
        public string Bairro { get; set; }
        public string Celular { get; set; }
        public string Cep { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Cidade { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Estado { get; set; }
        public string Fax { get; set; }
        public string InscricaoEstadual { get; set; }
        public DateTime? Nascimento { get; set; }
        public string Nome { get; set; }
        public string NomeContato { get; set; }
        public string NomeFantasia { get; set; }
        public string Observacoes { get; set; }
        public string Pessoa { get; set; }
        public string Rg { get; set; }
        public string ReferenciaComercial { get; set; }
        public string Site { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataCadastro { get; set; }
    }
    public class EmpresaBD
    {
        private EmpresaBD()
        {
        }

        static public void Save(Library.Empresa empresa)
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                using (NpgsqlCommand comando = conexao.CreateCommand())
                {
                    long id = GetNextId();

                    comando.CommandText = "INSERT INTO \"Empresa\" (bairro, celular, cep, cpf, cnpj, cidade, email, endereco, estado, fax, inscricaoEstadual, nascimento, nome, nomeContato, nomeFantasia, observacoes, pessoa, rg, referenciaComercial, site, telefone, dataCadastro) VALUES (@bairro, @celular, @cep, @cpf, @cnpj, @cidade, @email, @endereco, @estado, @fax, @inscricaoEstadual, @nascimento, @nome, @nomeContato, @nomeFantasia, @observacoes, @pessoa, @rg, @referenciaComercial, @site, @telefone, @dataCadastro)";

                    comando.Parameters.AddWithValue("@bairro", empresa.Bairro);
                    comando.Parameters.AddWithValue("@celular", empresa.Celular);
                    comando.Parameters.AddWithValue("@cep", empresa.Cep);
                    comando.Parameters.AddWithValue("@cpf", empresa.Cpf);
                    comando.Parameters.AddWithValue("@cnpj", empresa.Cnpj);
                    comando.Parameters.AddWithValue("@cidade", empresa.Cidade);
                    comando.Parameters.AddWithValue("@email", empresa.Email);
                    comando.Parameters.AddWithValue("@endereco", empresa.Endereco);
                    comando.Parameters.AddWithValue("@estado", empresa.Estado);
                    comando.Parameters.AddWithValue("@fax", empresa.Fax);
                    comando.Parameters.AddWithValue("@inscricaoEstadual", empresa.InscricaoEstadual);
                    comando.Parameters.AddWithValue("@nascimento", empresa.Nascimento);
                    comando.Parameters.AddWithValue("@nome", empresa.Nome);
                    comando.Parameters.AddWithValue("@nomeContato", empresa.NomeContato);
                    comando.Parameters.AddWithValue("@nomeFantasia", empresa.NomeFantasia);
                    comando.Parameters.AddWithValue("@observacoes", empresa.Observacoes);
                    comando.Parameters.AddWithValue("@pessoa", empresa.Pessoa);
                    comando.Parameters.AddWithValue("@rg", empresa.Rg);
                    comando.Parameters.AddWithValue("@referenciaComercial", empresa.ReferenciaComercial);
                    comando.Parameters.AddWithValue("@site", empresa.Site);
                    comando.Parameters.AddWithValue("@telefone", empresa.Telefone);
                    comando.Parameters.AddWithValue("@dataCadastro", empresa.DataCadastro);

                    conexao.Open();

                    //
                    empresa.Id = id;

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

        static public void Update(Library.Empresa empresa)
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                using (NpgsqlCommand comando = conexao.CreateCommand())
                {

                    comando.CommandText = "UPDATE \"Empresa\" SET bairro = @bairro, celular = @celular, cep = @cep, cpf = @cpf, cnpj = @cnpj, cidade = @cidade, email = @email, endereco = @endereco, estado = @estado, fax = @fax, inscricaoEstadual = @inscricaoEstadual, nascimento = @nascimento, nome = @nome, nomeContato = @nomeContato, nomeFantasia = @nomeFantasia, observacoes = @observacoes, pessoa = @pessoa, rg = @rg, referenciaComercial = @referenciaComercial, site = @site, telefone = @telefone, dataCadastro = @dataCadastro WHERE (id= " + empresa.Id + ")";

                    comando.Parameters.AddWithValue("@bairro", empresa.Bairro);
                    comando.Parameters.AddWithValue("@celular", empresa.Celular);
                    comando.Parameters.AddWithValue("@cep", empresa.Cep);
                    comando.Parameters.AddWithValue("@cpf", empresa.Cpf);
                    comando.Parameters.AddWithValue("@cnpj", empresa.Cnpj);
                    comando.Parameters.AddWithValue("@cidade", empresa.Cidade);
                    comando.Parameters.AddWithValue("@email", empresa.Email);
                    comando.Parameters.AddWithValue("@endereco", empresa.Endereco);
                    comando.Parameters.AddWithValue("@estado", empresa.Estado);
                    comando.Parameters.AddWithValue("@fax", empresa.Fax);
                    comando.Parameters.AddWithValue("@inscricaoEstadual", empresa.InscricaoEstadual);
                    comando.Parameters.AddWithValue("@nascimento", empresa.Nascimento);
                    comando.Parameters.AddWithValue("@nome", empresa.Nome);
                    comando.Parameters.AddWithValue("@nomeContato", empresa.NomeContato);
                    comando.Parameters.AddWithValue("@nomeFantasia", empresa.NomeFantasia);
                    comando.Parameters.AddWithValue("@observacoes", empresa.Observacoes);
                    comando.Parameters.AddWithValue("@pessoa", empresa.Pessoa);
                    comando.Parameters.AddWithValue("@rg", empresa.Rg);
                    comando.Parameters.AddWithValue("@referenciaComercial", empresa.ReferenciaComercial);
                    comando.Parameters.AddWithValue("@site", empresa.Site);
                    comando.Parameters.AddWithValue("@telefone", empresa.Telefone);
                    comando.Parameters.AddWithValue("@dataCadastro", empresa.DataCadastro);

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

        static public void DeleteById(long idEmpresa)
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());
                NpgsqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM \"Empresa\" WHERE id='" + idEmpresa + "'";

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

        static public List<Library.Empresa> FindAdvanced(params Library.Classes.QItem[] args)
        {
            NpgsqlDataReader rdr = null;
            NpgsqlConnection conexao = null;

            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                using (NpgsqlCommand comando = new NpgsqlCommand())
                {
                    string query = "SELECT * FROM \"Empresa\" AS e ";

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
                            case "e.id":
                                query += pre + "(e.id = @id)";
                                comando.Parameters.AddWithValue("@id", qi.Objeto);
                                break;
                            case "e.nome LIKE %%":
                                query += pre + "(e.nome IILIKE '%' || @nome || '%')";
                                comando.Parameters.AddWithValue("@nome", qi.Objeto);
                                break;
                            case "e.pessoa":
                                query += pre + "(e.pessoa = @pessoa)";
                                comando.Parameters.AddWithValue("@pessoa", qi.Objeto);
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
                List<Library.Empresa> empresas = new List<Library.Empresa>();

                while (rdr.Read())
                {
                    Library.Empresa empresa = new Empresa();
                    empresa.Id = (long)rdr["id"];
                    empresa.Bairro = rdr["bairro"].ToString();
                    empresa.Celular = rdr["celular"].ToString();
                    empresa.Cep = rdr["cep"].ToString();
                    empresa.Cpf = rdr["cpf"].ToString();
                    empresa.Cnpj = rdr["cnpj"].ToString();
                    empresa.Cidade = rdr["cidade"].ToString();
                    empresa.Email = rdr["email"].ToString();
                    empresa.Endereco = rdr["endereco"].ToString();
                    empresa.Estado = rdr["estado"].ToString();
                    empresa.Fax = rdr["fax"].ToString();
                    empresa.InscricaoEstadual = rdr["inscricaoEstadual"].ToString();
                    // ////
                    DateTime nasc = DateTime.MinValue;
                    DateTime.TryParse(rdr["nascimento"].ToString(), out nasc);
                    empresa.Nascimento = nasc;
                    // ////
                    empresa.Nome = rdr["nome"].ToString();
                    empresa.NomeContato = rdr["nomeContato"].ToString();
                    empresa.NomeFantasia = rdr["nomeFantasia"].ToString();
                    empresa.Observacoes = rdr["observacoes"].ToString();
                    empresa.Pessoa = rdr["pessoa"].ToString();
                    empresa.Rg = rdr["Rg"].ToString();
                    empresa.ReferenciaComercial = rdr["referenciaComercial"].ToString();
                    empresa.Site = rdr["site"].ToString();
                    empresa.Telefone = rdr["telefone"].ToString();
                    empresa.DataCadastro = DateTime.Parse(rdr["dataCadastro"].ToString());

                    empresas.Add(empresa);
                }

                return empresas;
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

        static public Library.Empresa FindById(long idEmpresa)
        {
            NpgsqlConnection conexao = null;
            NpgsqlDataAdapter dap = null;
            DataSet ds = null;
            Library.Empresa Empresa = null;
            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                dap = new NpgsqlDataAdapter("SELECT * FROM \"Empresa\" WHERE id='" + idEmpresa + "'", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Empresa");

                if (ds.Tables["Empresa"].Rows.Count == 1)
                {
                    Empresa = new Empresa();
                    Empresa.Id = (long)ds.Tables["Empresa"].Rows[0]["id"];
                    Empresa.Bairro = ds.Tables["Empresa"].Rows[0]["bairro"].ToString();
                    Empresa.Celular = ds.Tables["Empresa"].Rows[0]["celular"].ToString();
                    Empresa.Cep = ds.Tables["Empresa"].Rows[0]["cep"].ToString();
                    Empresa.Cpf = ds.Tables["Empresa"].Rows[0]["cpf"].ToString();
                    Empresa.Cnpj = ds.Tables["Empresa"].Rows[0]["cnpj"].ToString();
                    Empresa.Cidade = ds.Tables["Empresa"].Rows[0]["cidade"].ToString();
                    Empresa.Email = ds.Tables["Empresa"].Rows[0]["email"].ToString();
                    Empresa.Endereco = ds.Tables["Empresa"].Rows[0]["endereco"].ToString();
                    Empresa.Estado = ds.Tables["Empresa"].Rows[0]["estado"].ToString();
                    Empresa.Fax = ds.Tables["Empresa"].Rows[0]["fax"].ToString();
                    Empresa.InscricaoEstadual = ds.Tables["Empresa"].Rows[0]["inscricaoEstadual"].ToString();
                    if (Empresa.Nascimento != null)
                        Empresa.Nascimento = (DateTime?)ds.Tables["Empresa"].Rows[0]["nascimento"];
                    else
                        Empresa.Nascimento = null;
                    Empresa.Nome = ds.Tables["Empresa"].Rows[0]["nome"].ToString();
                    Empresa.NomeContato = ds.Tables["Empresa"].Rows[0]["nomeContato"].ToString();
                    Empresa.NomeFantasia = ds.Tables["Empresa"].Rows[0]["nomeFantasia"].ToString();
                    Empresa.Observacoes = ds.Tables["Empresa"].Rows[0]["observacoes"].ToString();
                    Empresa.Pessoa = ds.Tables["Empresa"].Rows[0]["pessoa"].ToString();
                    Empresa.Rg = ds.Tables["Empresa"].Rows[0]["Rg"].ToString();
                    Empresa.ReferenciaComercial = ds.Tables["Empresa"].Rows[0]["referenciaComercial"].ToString();
                    Empresa.Site = ds.Tables["Empresa"].Rows[0]["site"].ToString();
                    Empresa.Telefone = ds.Tables["Empresa"].Rows[0]["telefone"].ToString();
                    Empresa.DataCadastro = (DateTime)ds.Tables["Empresa"].Rows[0]["dataCadastro"];

                    return Empresa;
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

                comando.CommandText = "SELECT MAX(id) AS lastId FROM \"Empresa\" ";

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
