using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Npgsql;


namespace Library
{
    public class Funcionario
    {
        public Funcionario()
        {
        }

        public long Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Celular { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Estado { get; set; }
        public DateTime? Nascimento { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Site { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataCadastro { get; set; }
    }
    public class FuncionarioBD
    {
        private FuncionarioBD()
        {
        }

        static public void Save(Library.Funcionario funcionario)
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                long id = GetNextId();

                NpgsqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO \"Funcionario\" (login, senha, bairro, cep, celular, cpf, email, endereco, estado, nascimento,nome,rg,site,telefone,dataCadastro) VALUES ( @login, @senha, @bairro, @cep, @celular, @cpf, @email, @endereco, @estado, @nascimento, @nome, @rg, @site, @telefone, @dataCadastro)";

                comando.Parameters.AddWithValue("@login", funcionario.Login);
                comando.Parameters.AddWithValue("@senha", new Library.Classes.Password(funcionario.Senha).ToString());
                comando.Parameters.AddWithValue("@bairro", funcionario.Bairro);
                comando.Parameters.AddWithValue("@cep", funcionario.Cep);
                comando.Parameters.AddWithValue("@celular", funcionario.Celular);
                comando.Parameters.AddWithValue("@cpf", funcionario.Cpf);
                comando.Parameters.AddWithValue("@email", funcionario.Email);
                comando.Parameters.AddWithValue("@endereco", funcionario.Endereco);
                comando.Parameters.AddWithValue("@estado", funcionario.Estado);
                comando.Parameters.AddWithValue("@nascimento", funcionario.Nascimento);
                comando.Parameters.AddWithValue("@nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@rg", funcionario.Rg);
                comando.Parameters.AddWithValue("@site", funcionario.Site);
                comando.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                comando.Parameters.AddWithValue("@dataCadastro", funcionario.DataCadastro);
                
                conexao.Open();

                funcionario.Id = id;

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

        static public void Update(Library.Funcionario funcionario)
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());
                NpgsqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "UPDATE \"Funcionario\" SET login = @login, senha = @senha, bairro = @bairro, cep = @cep, celular = @celular, cpf = @cpf, email = @email, endereco = @endereco, estado = @estado,  nascimento = @nascimento, nome = @nome, rg = @rg, telefone = @telefone, dataCadastro = @dataCadastro WHERE (id= " + funcionario.Id + ")";
                
                comando.Parameters.AddWithValue("@login", funcionario.Login);
                comando.Parameters.AddWithValue("@senha", new Library.Classes.Password(funcionario.Senha).ToString());
                comando.Parameters.AddWithValue("@bairro", funcionario.Bairro);
                comando.Parameters.AddWithValue("@cep", funcionario.Cep);
                comando.Parameters.AddWithValue("@celular", funcionario.Celular);
                comando.Parameters.AddWithValue("@cpf", funcionario.Cpf);
                comando.Parameters.AddWithValue("@email", funcionario.Email);
                comando.Parameters.AddWithValue("@endereco", funcionario.Endereco);
                comando.Parameters.AddWithValue("@estado", funcionario.Estado);
                comando.Parameters.AddWithValue("@nascimento", funcionario.Nascimento);
                comando.Parameters.AddWithValue("@nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@rg", funcionario.Rg);
                comando.Parameters.AddWithValue("@site", funcionario.Site);
                comando.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                comando.Parameters.AddWithValue("@dataCadastro", funcionario.DataCadastro);

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

        static public void DeleteById(long idFuncionario)
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());
                NpgsqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM \"Funcionario\" WHERE id='" + idFuncionario + "'";

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

        static public List<Library.Funcionario> FindAdvanced(params Library.Classes.QItem[] args)
        {
            NpgsqlDataReader rdr = null;
            NpgsqlConnection conexao = null;
            NpgsqlCommand comando = null;

            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                comando = new NpgsqlCommand();

                string query = "SELECT * FROM \"Funcionario\" AS f ";

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
                        case "f.id":
                            query += pre + "(f.id = @id)";
                            comando.Parameters.AddWithValue("@id", qi.Objeto);
                            break;
                        case "f.nome LIKE %%":
                            query += pre + "(f.nome ILIKE '%' || @nome || '%')";
                            comando.Parameters.AddWithValue("@nome", qi.Objeto);
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

                List<Library.Funcionario> funcionarios = new List<Library.Funcionario>();

                while (rdr.Read())
                {
                    DateTime date = DateTime.MinValue;
                    DateTime.TryParse(rdr["nascimento"].ToString(), out date);

                    DateTime dataCadastro = DateTime.MinValue;
                    DateTime.TryParse(rdr["dataCadastro"].ToString(), out dataCadastro);


                    Library.Funcionario funcionario = new Funcionario();
                    funcionario.Id = (long)rdr["id"];
                    funcionario.Login = rdr["login"].ToString();
                    funcionario.Senha = rdr["senha"].ToString();
                    funcionario.Bairro = rdr["bairro"].ToString();
                    funcionario.Cep = rdr["cep"].ToString();
                    funcionario.Celular = rdr["celular"].ToString();
                    funcionario.Cpf = rdr["cpf"].ToString();
                    funcionario.Email = rdr["email"].ToString();
                    funcionario.Endereco = rdr["endereco"].ToString();
                    funcionario.Estado = rdr["estado"].ToString();
                    funcionario.Nascimento = date;
                    funcionario.Nome = rdr["nome"].ToString();
                    funcionario.Rg = rdr["rg"].ToString();
                    funcionario.Site = rdr["site"].ToString();
                    funcionario.Telefone = rdr["telefone"].ToString();
                    funcionario.DataCadastro = dataCadastro;

                    funcionarios.Add(funcionario);
                }

                return funcionarios;
            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex); ;
            }
            finally
            {
                conexao.Close();
                comando.Dispose();
            }
            return null;
        }

        static public Library.Funcionario FindById(long idFuncionario)
        {
            NpgsqlConnection conexao = null;
            NpgsqlDataAdapter dap = null;
            DataSet ds = null;
            Library.Funcionario Funcionario = null;
            try
            {
                conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());

                dap = new NpgsqlDataAdapter("SELECT * FROM \"Funcionario\" WHERE id='" + idFuncionario + "'", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Funcionario");

                if (ds.Tables["Funcionario"].Rows.Count == 1)
                {
                    DateTime date = DateTime.MinValue;
                    DateTime.TryParse(ds.Tables["Funcionario"].Rows[0]["nascimento"].ToString(), out date);

                    DateTime dataCadastro = DateTime.MinValue;
                    DateTime.TryParse(ds.Tables["Funcionario"].Rows[0]["dataCadastro"].ToString(), out dataCadastro);

                    Funcionario = new Funcionario();
                    Funcionario.Id = (long)ds.Tables["Funcionario"].Rows[0]["id"];
                    Funcionario.Login = ds.Tables["Funcionario"].Rows[0]["login"].ToString();
                    Funcionario.Senha = ds.Tables["Funcionario"].Rows[0]["senha"].ToString();
                    Funcionario.Bairro = ds.Tables["Funcionario"].Rows[0]["bairro"].ToString();
                    Funcionario.Cep = ds.Tables["Funcionario"].Rows[0]["cep"].ToString();
                    Funcionario.Celular = ds.Tables["Funcionario"].Rows[0]["celular"].ToString();
                    Funcionario.Cpf = ds.Tables["Funcionario"].Rows[0]["cpf"].ToString();
                    Funcionario.Email = ds.Tables["Funcionario"].Rows[0]["email"].ToString();
                    Funcionario.Endereco = ds.Tables["Funcionario"].Rows[0]["endereco"].ToString();
                    Funcionario.Estado = ds.Tables["Funcionario"].Rows[0]["estado"].ToString();
                    Funcionario.Nascimento = date;
                    Funcionario.Nome = ds.Tables["Funcionario"].Rows[0]["nome"].ToString();
                    Funcionario.Rg = ds.Tables["Funcionario"].Rows[0]["rg"].ToString();
                    Funcionario.Site = ds.Tables["Funcionario"].Rows[0]["site"].ToString();
                    Funcionario.Telefone = ds.Tables["Funcionario"].Rows[0]["telefone"].ToString();
                    Funcionario.DataCadastro = dataCadastro;
                }
                return Funcionario;
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

                comando.CommandText = "SELECT MAX(id) AS lastId FROM \"Funcionario\" ";

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

        static public bool Logar(string login, string senha, out Library.Funcionario funcionario, out string menssage)
        {
            NpgsqlDataReader rdr1 = null;
            NpgsqlDataReader rdr2 = null;
            NpgsqlConnection conexao = null;
            int count1 = 0;
            int count2 = 0;

            try
            {



                using (NpgsqlCommand comando1 = new NpgsqlCommand())
                {
                    conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());
                    conexao.Open();

                    string query1 = "SELECT * FROM \"Funcionario\" WHERE login = @login";
                    comando1.Parameters.AddWithValue("@login", login);
                    comando1.Connection = conexao;
                    comando1.CommandText = query1;
                    rdr1 = comando1.ExecuteReader();

                    while (rdr1.Read())
                        count1++;

                    //conexao = null;
                }


                List<Library.Funcionario> funcionarios = new List<Library.Funcionario>();

                if (count1 > 0)
                {
                    using (NpgsqlCommand comando2 = new NpgsqlCommand())
                    {
                        conexao = new NpgsqlConnection(global::Connection.Connection.StringPostgree());
                        conexao.Open();

                        string query2 = "SELECT * FROM \"Funcionario\" WHERE login = @login AND senha = @senha";
                        comando2.Parameters.AddWithValue("@login", login);
                        comando2.Parameters.AddWithValue("@senha", new Library.Classes.Password(senha).ToString());
                        comando2.Connection = conexao;
                        comando2.CommandText = query2;

                        rdr2 = comando2.ExecuteReader();

                        while (rdr2.Read())
                        {
                            count2++;

                            Library.Funcionario funcionarioTMP = new Funcionario();
                            funcionarioTMP.Id = (long)rdr2["id"];
                            funcionarioTMP.Login = rdr2["login"].ToString();
                            funcionarioTMP.Senha = rdr2["senha"].ToString();
                            funcionarioTMP.Bairro = rdr2["bairro"].ToString();
                            funcionarioTMP.Cep = rdr2["cep"].ToString();
                            funcionarioTMP.Celular = rdr2["celular"].ToString();
                            funcionarioTMP.Cpf = rdr2["cpf"].ToString();
                            funcionarioTMP.Email = rdr2["email"].ToString();
                            funcionarioTMP.Endereco = rdr2["endereco"].ToString();
                            funcionarioTMP.Estado = rdr2["estado"].ToString();
                            //funcionarioTMP.Nascimento = DateTime.Parse(rdr2["nascimento"].ToString());
                            funcionarioTMP.Nome = rdr2["nome"].ToString();
                            funcionarioTMP.Rg = rdr2["rg"].ToString();
                            funcionarioTMP.Site = rdr2["site"].ToString();
                            funcionarioTMP.Telefone = rdr2["telefone"].ToString();
                            //funcionarioTMP.DataCadastro = DateTime.Parse(rdr2["dataCadastro"].ToString());

                            funcionarios.Add(funcionarioTMP);
                        }
                        //conexao = null;
                    }

                    if (count2 != 0)
                    {
                        funcionario = funcionarios[0];
                        menssage = "Usuário encontrado!";
                        return true;
                    }
                    else
                    {
                        menssage = "Login e Senha incompatíveis!";
                        funcionario = null;
                        return false;
                    }
                }
                else
                {
                    menssage = "Usuário não encontrado!";
                    funcionario = null;
                    return false;
                }
            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex);
            }
            finally
            {
                //if (conexao != null)
                    //conexao.Close();
            }
            menssage = "Erro ao tentar conectar com banco de dados! - Contate um desenvolvedor. [(22) 3852-3522]";
            funcionario = null;
            return false;
        }
    }
}
