using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Npgsql;

namespace Library
{
    public class Cliente
    {
        public Cliente()
        {
        }


        public long Id { get; set; }
        public Library.Empresa Empresa { get; set; }
        public string Bairro { get; set; }
        public string Celular { get; set; }
        public string Cep { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Cidade { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string EnderecoNumero { get; set; }
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
    public class ClienteBD
    {
        private ClienteBD()
        {
        }

        static public void Save(Library.Cliente cliente)
        {
            NpgsqlConnection conexao = null;
            try
            {
                long id = GetNextId();
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                using (NpgsqlCommand comando = conexao.CreateCommand())
                {

                    comando.CommandText = "INSERT INTO \"Cliente\" ( bairro, celular, cep, cpf, cnpj, cidade, email, endereco, enderecoNumero, estado, fax, inscricaoEstadual, nascimento, nome, nomeContato, nomeFantasia, observacoes, pessoa, rg, referenciaComercial, site, telefone, dataCadastro) VALUES (@bairro, @celular, @cep, @cpf, @cnpj, @cidade, @email, @endereco, @enderecoNumero, @estado, @fax, @inscricaoEstadual, @nascimento, @nome, @nomeContato, @nomeFantasia, @observacoes, @pessoa, @rg, @referenciaComercial, @site, @telefone, @dataCadastro)";

                    comando.Parameters.AddWithValue("@bairro", cliente.Bairro);
                    comando.Parameters.AddWithValue("@celular", cliente.Celular);
                    comando.Parameters.AddWithValue("@cep", cliente.Cep);
                    comando.Parameters.AddWithValue("@cpf", cliente.Cpf);
                    comando.Parameters.AddWithValue("@cnpj", cliente.Cnpj);
                    comando.Parameters.AddWithValue("@cidade", cliente.Cidade);
                    comando.Parameters.AddWithValue("@email", cliente.Email);
                    comando.Parameters.AddWithValue("@endereco", cliente.Endereco);
                    comando.Parameters.AddWithValue("@enderecoNumero", cliente.EnderecoNumero);
                    comando.Parameters.AddWithValue("@estado", cliente.Estado);
                    comando.Parameters.AddWithValue("@fax", cliente.Fax);
                    comando.Parameters.AddWithValue("@inscricaoEstadual", cliente.InscricaoEstadual);
                    comando.Parameters.AddWithValue("@nascimento", cliente.Nascimento);
                    comando.Parameters.AddWithValue("@nome", cliente.Nome);
                    comando.Parameters.AddWithValue("@nomeContato", cliente.NomeContato);
                    comando.Parameters.AddWithValue("@nomeFantasia", cliente.NomeFantasia);
                    comando.Parameters.AddWithValue("@observacoes", cliente.Observacoes);
                    comando.Parameters.AddWithValue("@pessoa", cliente.Pessoa);
                    comando.Parameters.AddWithValue("@rg", cliente.Rg);
                    comando.Parameters.AddWithValue("@referenciaComercial", cliente.ReferenciaComercial);
                    comando.Parameters.AddWithValue("@site", cliente.Site);
                    comando.Parameters.AddWithValue("@telefone", cliente.Telefone);
                    comando.Parameters.AddWithValue("@dataCadastro", cliente.DataCadastro);

                    conexao.Open();

                    cliente.Id = id;

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

        static public void Update(Library.Cliente cliente)
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                using (NpgsqlCommand comando = conexao.CreateCommand())
                {

                    comando.CommandText = "UPDATE \"Cliente\" SET  bairro = @bairro, celular = @celular, cep = @cep, cpf = @cpf, cnpj = @cnpj, cidade = @cidade, email = @email, endereco = @endereco, enderecoNumero = @enderecoNumero, estado = @estado, fax = @fax, inscricaoEstadual = @inscricaoEstadual, nascimento = @nascimento, nome = @nome, nomeContato = @nomeContato, nomeFantasia = @nomeFantasia, observacoes = @observacoes, pessoa = @pessoa, rg = @rg, referenciaComercial = @referenciaComercial, site = @site, telefone = @telefone, dataCadastro = @dataCadastro WHERE (id= " + cliente.Id + ")";

                    comando.Parameters.AddWithValue("@bairro", cliente.Bairro);
                    comando.Parameters.AddWithValue("@celular", cliente.Celular);
                    comando.Parameters.AddWithValue("@cep", cliente.Cep);
                    comando.Parameters.AddWithValue("@cpf", cliente.Cpf);
                    comando.Parameters.AddWithValue("@cnpj", cliente.Cnpj);
                    comando.Parameters.AddWithValue("@cidade", cliente.Cidade);
                    comando.Parameters.AddWithValue("@email", cliente.Email);
                    comando.Parameters.AddWithValue("@endereco", cliente.Endereco);
                    comando.Parameters.AddWithValue("@enderecoNumero", cliente.EnderecoNumero);
                    comando.Parameters.AddWithValue("@estado", cliente.Estado);
                    comando.Parameters.AddWithValue("@fax", cliente.Fax);
                    comando.Parameters.AddWithValue("@inscricaoEstadual", cliente.InscricaoEstadual);
                    comando.Parameters.AddWithValue("@nascimento", cliente.Nascimento);
                    comando.Parameters.AddWithValue("@nome", cliente.Nome);
                    comando.Parameters.AddWithValue("@nomeContato", cliente.NomeContato);
                    comando.Parameters.AddWithValue("@nomeFantasia", cliente.NomeFantasia);
                    comando.Parameters.AddWithValue("@observacoes", cliente.Observacoes);
                    comando.Parameters.AddWithValue("@pessoa", cliente.Pessoa);
                    comando.Parameters.AddWithValue("@rg", cliente.Rg);
                    comando.Parameters.AddWithValue("@referenciaComercial", cliente.ReferenciaComercial);
                    comando.Parameters.AddWithValue("@site", cliente.Site);
                    comando.Parameters.AddWithValue("@telefone", cliente.Telefone);
                    comando.Parameters.AddWithValue("@dataCadastro", cliente.DataCadastro);

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

        static public void DeleteById(long idCliente)
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());
                NpgsqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM \"Cliente\" WHERE id='" + idCliente + "'";

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

        static public List<Library.Cliente> FindAdvanced(params Library.Classes.QItem[] args)
        {
            NpgsqlDataReader rdr = null;
            NpgsqlConnection conexao = null;

            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                using (NpgsqlCommand comando = new NpgsqlCommand())
                {
                    string query = "SELECT * FROM \"Cliente\" AS c ";

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
                            case "c.id":
                                query += pre + "(c.id = @id)";
                                comando.Parameters.AddWithValue("@id", qi.Objeto);
                                break;
                            case "c.nome LIKE %%":
                                query += pre + "(c.nome ILIKE '%'||@nome||'%')";
                                comando.Parameters.AddWithValue("@nome", qi.Objeto);
                                break;
                            case "c.pessoa":
                                query += pre + "(c.pessoa = @pessoa)";
                                comando.Parameters.AddWithValue("@pessoa", qi.Objeto);
                                break;
                            case "c.cpf":
                                query += pre + "(c.cpf LIKE @cpf)";
                                comando.Parameters.AddWithValue("@cpf", qi.Objeto);
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
                List<Library.Cliente> clientes = new List<Library.Cliente>();

                while (rdr.Read())
                {
                    DateTime date = DateTime.MinValue;
                    DateTime.TryParse(rdr["nascimento"].ToString(), out date);

                    DateTime dataCadastro = DateTime.MinValue;
                    DateTime.TryParse(rdr["dataCadastro"].ToString(), out dataCadastro);

                    Library.Cliente cliente = new Cliente();
                    cliente.Id = (long)rdr["id"];
                    cliente.Bairro = rdr["bairro"].ToString();
                    cliente.Celular = rdr["celular"].ToString();
                    cliente.Cep = rdr["cep"].ToString();
                    cliente.Cpf = rdr["cpf"].ToString();
                    cliente.Cnpj = rdr["cnpj"].ToString();
                    cliente.Cidade = rdr["cidade"].ToString();
                    cliente.Email = rdr["email"].ToString();
                    cliente.Endereco = rdr["endereco"].ToString();
                    cliente.EnderecoNumero = rdr["enderecoNumero"].ToString();
                    cliente.Estado = rdr["estado"].ToString();
                    cliente.Fax = rdr["fax"].ToString();
                    cliente.InscricaoEstadual = rdr["inscricaoEstadual"].ToString();
                    cliente.Nascimento = date;
                    cliente.Nome = rdr["nome"].ToString();
                    cliente.NomeContato = rdr["nomeContato"].ToString();
                    cliente.NomeFantasia = rdr["nomeFantasia"].ToString();
                    cliente.Observacoes = rdr["observacoes"].ToString();
                    cliente.Pessoa = rdr["pessoa"].ToString();
                    cliente.Rg = rdr["Rg"].ToString();
                    cliente.ReferenciaComercial = rdr["referenciaComercial"].ToString();
                    cliente.Site = rdr["site"].ToString();
                    cliente.Telefone = rdr["telefone"].ToString();
                    cliente.DataCadastro = dataCadastro;
                    

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

        static public Library.Cliente FindById(long idCliente)
        {
            NpgsqlConnection conexao = null;
            NpgsqlDataAdapter dap = null;
            DataSet ds = null;
            Library.Cliente cliente = null;
            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                dap = new NpgsqlDataAdapter("SELECT * FROM \"Cliente\" WHERE id='" + idCliente + "'", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Cliente");

                if (ds.Tables["Cliente"].Rows.Count == 1)
                {
                    DateTime date = DateTime.MinValue;
                    DateTime.TryParse(ds.Tables["Cliente"].Rows[0]["nascimento"].ToString(), out date);

                    DateTime dataCadastro = DateTime.MinValue;
                    DateTime.TryParse(ds.Tables["Cliente"].Rows[0]["dataCadastro"].ToString(), out dataCadastro);

                    cliente = new Cliente();
                    cliente.Id = (long)ds.Tables["Cliente"].Rows[0]["id"];
                    cliente.Bairro = ds.Tables["Cliente"].Rows[0]["bairro"].ToString();
                    cliente.Celular = ds.Tables["Cliente"].Rows[0]["celular"].ToString();
                    cliente.Cep = ds.Tables["Cliente"].Rows[0]["cep"].ToString();
                    cliente.Cpf = ds.Tables["Cliente"].Rows[0]["cpf"].ToString();
                    cliente.Cnpj = ds.Tables["Cliente"].Rows[0]["cnpj"].ToString();
                    cliente.Cidade = ds.Tables["Cliente"].Rows[0]["cidade"].ToString();
                    cliente.Email = ds.Tables["Cliente"].Rows[0]["email"].ToString();
                    cliente.Endereco = ds.Tables["Cliente"].Rows[0]["endereco"].ToString();
                    cliente.EnderecoNumero = ds.Tables["Cliente"].Rows[0]["enderecoNumero"].ToString();
                    cliente.Estado = ds.Tables["Cliente"].Rows[0]["estado"].ToString();
                    cliente.Fax = ds.Tables["Cliente"].Rows[0]["fax"].ToString();
                    cliente.InscricaoEstadual = ds.Tables["Cliente"].Rows[0]["inscricaoEstadual"].ToString();
                    cliente.Nascimento = date;
                    cliente.Nome = ds.Tables["Cliente"].Rows[0]["nome"].ToString();
                    cliente.NomeContato = ds.Tables["Cliente"].Rows[0]["nomeContato"].ToString();
                    cliente.NomeFantasia = ds.Tables["Cliente"].Rows[0]["nomeFantasia"].ToString();
                    cliente.Observacoes = ds.Tables["Cliente"].Rows[0]["observacoes"].ToString();
                    cliente.Pessoa = ds.Tables["Cliente"].Rows[0]["pessoa"].ToString();
                    cliente.Rg = ds.Tables["Cliente"].Rows[0]["Rg"].ToString();
                    cliente.ReferenciaComercial = ds.Tables["Cliente"].Rows[0]["referenciaComercial"].ToString();
                    cliente.Site = ds.Tables["Cliente"].Rows[0]["site"].ToString();
                    cliente.Telefone = ds.Tables["Cliente"].Rows[0]["telefone"].ToString();
                    cliente.DataCadastro = dataCadastro;
                    

                    return cliente;
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

                comando.CommandText = "SELECT MAX(id) AS lastId FROM \"Cliente\" ";

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


        static public List<Library.TermoCompromissoParcela> GetParcelasAtrasadasById(long idCliente)
        {
            NpgsqlDataReader rdr = null;
            NpgsqlConnection conexao = null;
            NpgsqlCommand comando = null;

            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                comando = new NpgsqlCommand();

                string query = "SELECT tcp.data, tcp.id, tcp.idTermoCompromisso, tcp.valor, tcp.pago FROM \"Cliente\" AS c " +
                                    "INNER JOIN \"TermoCompromisso\" AS tc ON c.id = tc.idCliente " +
                                    "INNER JOIN \"TermoCompromissoParcela\" AS tcp ON tcp.idTermoCompromisso = tc.id " +
                                    "WHERE (c.id = " + idCliente + ") AND (tcp.pago = 0) AND (tcp.data < NOW())";

                comando.CommandText = query;

                comando.Connection = conexao;

                conexao.Open();

                rdr = comando.ExecuteReader();

                List<Library.TermoCompromissoParcela> termos = new List<Library.TermoCompromissoParcela>();

                while (rdr.Read())
                {
                    DateTime date = DateTime.MinValue;
                    DateTime.TryParse(rdr["data"].ToString(), out date);

                    Library.TermoCompromissoParcela termoCompromissoParcela = new TermoCompromissoParcela();
                    termoCompromissoParcela.Id = (long)rdr["id"];
                    termoCompromissoParcela.TermoCompromisso = Library.TermoCompromissoBD.FindById((long)rdr["idTermoCompromisso"]);
                    termoCompromissoParcela.Valor = (double)rdr["valor"];
                    termoCompromissoParcela.Data = date;
                    termoCompromissoParcela.Pago = (int)rdr["pago"];

                    termos.Add(termoCompromissoParcela);
                }

                return termos;
            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex);
            }
            finally
            {
                conexao.Close();
                comando.Dispose();
            }
            return null;
        }
    }
}
