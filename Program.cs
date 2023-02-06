using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    static void Main()
    {

        string opcao = string.Empty;
        SqliteConnection con = CreateConnection();

        con.Open();

        CreateTable(con);

        do 
        {

            Console.WriteLine("|-------------------------|");
            Console.WriteLine("|                         |");
            Console.WriteLine("|      0 - Sair           |");
            Console.WriteLine("|      1 - Cadastrar      |");
            Console.WriteLine("|      2 - Listar         |");
            Console.WriteLine("|      3 - Editar         |");
            Console.WriteLine("|      4 - Remover        |");
            Console.WriteLine("|                         |");
            Console.WriteLine("|-------------------------|");
            opcao = Console.ReadLine();

            Console.Clear();

            if(opcao == "1"){

                Console.WriteLine("|-------------------------|");
                Console.WriteLine("|                         |");
                Console.WriteLine("|      1 - Funcionario    |");
                Console.WriteLine("|      2 - Aprendiz       |");
                Console.WriteLine("|                         |");
                Console.WriteLine("|-------------------------|");
                
                string opcao2 = Console.ReadLine();

                Console.Clear();

                if(opcao2 == "1"){

                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Idade: ");
                    string sIdade = Console.ReadLine();
                    int idade = Convert.ToInt32(sIdade);
                    Console.Write("Telefone: ");
                    string telefone = Console.ReadLine();
                    Console.Write("E-mail: ");
                    string email = Console.ReadLine();
                    Console.Write("Função: ");
                    string funcao = Console.ReadLine();

                    Funcionario fun = new Funcionario(nome, idade, telefone, email, funcao);

                    cadastrarFuncionario(con, fun);

                    Console.Clear();

                }else if(opcao2 == "2"){

                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Idade: ");
                    string sIdade = Console.ReadLine();
                    int idade = Convert.ToInt32(sIdade);
                    Console.Write("Telefone: ");
                    string telefone = Console.ReadLine();
                    Console.Write("E-mail: ");
                    string email = Console.ReadLine();

                    Aprendiz apre = new Aprendiz(nome, idade, telefone, email);

                    cadastrarAprendiz(con, apre);

                    Console.Clear();

                }

            }else if(opcao == "2"){

                Console.WriteLine("|-------------------------|");
                Console.WriteLine("|                         |");
                Console.WriteLine("|      1 - Funcionarios   |");
                Console.WriteLine("|      2 - Aprendizes     |");
                Console.WriteLine("|                         |");
                Console.WriteLine("|-------------------------|");

                string opcao2 = Console.ReadLine();

                Console.Clear();

                if(opcao2 == "1"){
                    listarFuncionario(con);
                }else if(opcao2 == "2"){
                    listarAprendiz(con);
                }

                Console.ReadLine();
                Console.Clear();

            }else if(opcao == "3"){
                Console.WriteLine("|-------------------------|");
                Console.WriteLine("|                         |");
                Console.WriteLine("|      1 - Funcionario    |");
                Console.WriteLine("|      2 - Aprendiz       |");
                Console.WriteLine("|                         |");
                Console.WriteLine("|-------------------------|");

                string opcao2 = Console.ReadLine();

                Console.Clear();

                if(opcao2 == "1"){

                    listarFuncionario(con);

                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Idade: ");
                    string sIdade = Console.ReadLine();
                    int idade = Convert.ToInt32(sIdade);
                    Console.Write("Telefone: ");
                    string telefone = Console.ReadLine();
                    Console.Write("E-mail: ");
                    string email = Console.ReadLine();
                    Console.Write("Função: ");
                    string funcao = Console.ReadLine();

                    Funcionario fun = new Funcionario(nome, idade, telefone, email, funcao);

                    editarFuncionario(con, fun);

                    Console.Clear();

                }else if(opcao2 == "2"){

                    listarAprendiz(con);

                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Idade: ");
                    string sIdade = Console.ReadLine();
                    int idade = Convert.ToInt32(sIdade);
                    Console.Write("Telefone: ");
                    string telefone = Console.ReadLine();
                    Console.Write("E-mail: ");
                    string email = Console.ReadLine();

                    Aprendiz apre = new Aprendiz(nome, idade, telefone, email);

                    editarAprendiz(con, apre);

                    Console.Clear();

                }

            }else if(opcao == "4"){
                Console.WriteLine("|-------------------------|");
                Console.WriteLine("|                         |");
                Console.WriteLine("|      1 - Funcionario    |");
                Console.WriteLine("|      2 - Aprendiz       |");
                Console.WriteLine("|                         |");
                Console.WriteLine("|-------------------------|");

                string opcao2 = Console.ReadLine();
                Console.Clear();

                if(opcao2 == "1"){

                    listarFuncionario(con);

                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();

                    deletarFuncionario(con, nome);

                    Console.Clear();
                    
                }else if(opcao2 == "2"){

                    listarAprendiz(con);

                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();

                    deletarAprendiz(con, nome);

                    Console.Clear();
                }

            }

        }
        while (opcao != "0");

        con.Close();
        
    }

      static SqliteConnection CreateConnection()
      {

        var connectionStringBuilder = new SqliteConnectionStringBuilder();
        connectionStringBuilder.DataSource = "./Nome.db";

        var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
        try
        {
            connection.Open();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        return connection;
      }

      static void CreateTable(SqliteConnection conn)
      {

        conn.Open();

        var createTableCmd = conn.CreateCommand();
        createTableCmd.CommandText = "CREATE TABLE IF NOT EXISTS funcionario(nome VARCHAR(25), idade INT, telefone VARCHAR(15), email VARCHAR(35), funcao VARCHAR(20), salario INT)";
        createTableCmd.ExecuteNonQuery();

        createTableCmd.CommandText = "CREATE TABLE IF NOT EXISTS aprendiz(nome VARCHAR(25), idade INT, telefone VARCHAR(15), email VARCHAR(35), salario INT)";
        createTableCmd.ExecuteNonQuery();

        conn.Close();

      }

    static void cadastrarFuncionario(SqliteConnection conn, Funcionario funcionario)
    {

       conn.Open();

        SqliteCommand sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "INSERT INTO funcionario(nome, idade, telefone, email, funcao, salario) VALUES (@nome, @idade, @telefone, @email, @funcao, @salario);";
        sqlite_cmd.Parameters.Add(new SqliteParameter("@nome", funcionario.Nome));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@idade", funcionario.Idade));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@telefone", funcionario.Telefone));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@email", funcionario.Email));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@funcao", funcionario.Funcao));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@salario", funcionario.Salario()));
        

        sqlite_cmd.ExecuteNonQuery();

        conn.Close();

    }

    static void cadastrarAprendiz(SqliteConnection conn, Aprendiz aprendiz)
    {

        conn.Open();

        SqliteCommand sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "INSERT INTO aprendiz(nome, idade, telefone, email, salario) VALUES (@nome, @idade, @telefone, @email, @salario);";
        sqlite_cmd.Parameters.Add(new SqliteParameter("@nome", aprendiz.Nome));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@idade", aprendiz.Idade));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@telefone", aprendiz.Telefone));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@email", aprendiz.Email));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@salario", aprendiz.Salario()));


        sqlite_cmd.ExecuteNonQuery();

        conn.Close();

    }

    static void listarFuncionario(SqliteConnection conn)
    {

        conn.Open();

        SqliteDataReader sqlite_datareader;
        SqliteCommand sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "SELECT * FROM funcionario";

        sqlite_datareader = sqlite_cmd.ExecuteReader();
        while (sqlite_datareader.Read())
        {
            string myreader = $"Nome: {sqlite_datareader.GetString(0)}" + $", Idade: {sqlite_datareader.GetString(1)}" + $", Telefone: {sqlite_datareader.GetString(2)}" + $", email: {sqlite_datareader.GetString(3)}" + $" função: {sqlite_datareader.GetString(4)}"+ $", Salario: {sqlite_datareader.GetString(5)}";
            Console.WriteLine(myreader);
        }
        conn.Close();
    }

    static void listarAprendiz(SqliteConnection conn)
    {

        conn.Open();

        SqliteDataReader sqlite_datareader;
        SqliteCommand sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "SELECT * FROM aprendiz";

        sqlite_datareader = sqlite_cmd.ExecuteReader();
        while (sqlite_datareader.Read())
        {
            string myreader = $"Nome: {sqlite_datareader.GetString(0)}" + $", Idade: {sqlite_datareader.GetString(1)}" + $", Telefone: {sqlite_datareader.GetString(2)}" + $", email: {sqlite_datareader.GetString(3)}"+ $", Salario: {sqlite_datareader.GetString(4)}";
            Console.WriteLine(myreader);
        }
        conn.Close();
    }

    static void editarFuncionario(SqliteConnection conn, Funcionario funcionario)
    {

        conn.Open();

        SqliteCommand sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "UPDATE funcionario SET idade = @idade, telefone = @telefone, email = @email, funcao = @funcao where nome = @nome;";

        sqlite_cmd.Parameters.Add(new SqliteParameter("@idade", funcionario.Idade));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@telefone", funcionario.Telefone));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@email", funcionario.Email));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@funcao", funcionario.Funcao));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@nome", funcionario.Nome));

        sqlite_cmd.ExecuteNonQuery();

        conn.Close();

    }

    static void editarAprendiz(SqliteConnection conn, Aprendiz aprendiz)
    {

        conn.Open();

        SqliteCommand sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "UPDATE aprendiz SET idade = @idade, telefone = @telefone, email = @email where nome = @nome;";

        sqlite_cmd.Parameters.Add(new SqliteParameter("@idade", aprendiz.Idade));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@telefone", aprendiz.Telefone));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@email", aprendiz.Email));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@nome", aprendiz.Nome));

        sqlite_cmd.ExecuteNonQuery();

        conn.Close();

    }

    static void deletarFuncionario(SqliteConnection conn, string nome)
    {

        conn.Open();

        SqliteCommand sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "DELETE FROM funcionario WHERE nome=@nome;";
        sqlite_cmd.Parameters.Add(new SqliteParameter("@nome", nome));

        sqlite_cmd.ExecuteNonQuery();

        conn.Close();

    }

    static void deletarAprendiz(SqliteConnection conn, string nome)
    {

        conn.Open();

        SqliteCommand sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "DELETE FROM aprendiz WHERE nome=@nome;";
        sqlite_cmd.Parameters.Add(new SqliteParameter("@nome", nome));

        sqlite_cmd.ExecuteNonQuery();

        conn.Close();

    }

}