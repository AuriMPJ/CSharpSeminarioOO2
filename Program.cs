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

            if(opcao == "1"){

                Console.WriteLine("|-------------------------|");
                Console.WriteLine("|                         |");
                Console.WriteLine("|      1 - Funcionario    |");
                Console.WriteLine("|      2 - Aprendiz       |");
                Console.WriteLine("|                         |");
                Console.WriteLine("|-------------------------|");
                
                var opcao2 = Console.ReadLine();

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

                }

            }else if(opcao == "2"){

                Console.WriteLine("|-------------------------|");
                Console.WriteLine("|                         |");
                Console.WriteLine("|      1 - Funcionarios   |");
                Console.WriteLine("|      2 - Aprendizes     |");
                Console.WriteLine("|                         |");
                Console.WriteLine("|-------------------------|");

                string sOpcao2 = Console.ReadLine();
                int opcao2 = Convert.ToInt32(sOpcao2);

                if(opcao2 == 1){
                    listarFuncionario(con);
                }else if(opcao2 == 2){
                    listarAprendiz(con);
                }

            }else if(opcao == "3"){
                Console.WriteLine("|-------------------------|");
                Console.WriteLine("|                         |");
                Console.WriteLine("|      1 - Funcionario    |");
                Console.WriteLine("|      2 - Aprendiz       |");
                Console.WriteLine("|                         |");
                Console.WriteLine("|-------------------------|");

                string opcao2 = Console.ReadLine();

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

                    editarFuncionario(con, fun);
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

                    editarAprendiz(con, apre);
                }

            }else if(opcao == "4"){
                Console.WriteLine("|-------------------------|");
                Console.WriteLine("|                         |");
                Console.WriteLine("|      1 - Funcionario    |");
                Console.WriteLine("|      2 - Aprendiz       |");
                Console.WriteLine("|                         |");
                Console.WriteLine("|-------------------------|");

                string sOpcao2 = Console.ReadLine();
                int opcao2 = Convert.ToInt32(sOpcao2);

                if(opcao2 == 1){

                    Console.Write("Nome: ");
                    var nome = Console.ReadLine();

                    deletarFuncionario(con, nome);
                }else if(opcao2 == 2){

                    Console.Write("Nome: ");
                    var nome = Console.ReadLine();

                    deletarAprendiz(con, nome);
                }

            }

        }
        while (opcao != "0");
        
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

        }
        return connection;
      }

      static void CreateTable(SqliteConnection conn)
      {

        var createTableCmd = conn.CreateCommand();
        createTableCmd.CommandText = "CREATE TABLE IF NOT EXISTS funcionario(nome VARCHAR(25), idade INT, telefone VARCHAR(15), email VARCHAR(35), funcao VARCHAR(20))";
        createTableCmd.ExecuteNonQuery();

        createTableCmd.CommandText = "CREATE TABLE IF NOT EXISTS aprendiz(nome VARCHAR(25), idade INT, telefone VARCHAR(15), email VARCHAR(35))";
        createTableCmd.ExecuteNonQuery();

      }

    static void cadastrarFuncionario(SqliteConnection conn, Funcionario funcionario)
    {
        SqliteCommand sqlite_cmd;
        sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "INSERT INTO funcionario(nome, idade, telefone, email, funcao) VALUES (@nome, @idade, @telefone, @email, @funcao);";
        sqlite_cmd.Parameters.Add(new SqliteParameter("@nome", funcionario.Nome));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@idade", funcionario.Idade));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@telefone", funcionario.Telefone));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@email", funcionario.Email));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@funcao", funcionario.Funcao));

        sqlite_cmd.ExecuteNonQuery();

    }

    static void cadastrarAprendiz(SqliteConnection conn, Aprendiz aprendiz)
    {
        SqliteCommand sqlite_cmd;
        sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "INSERT INTO aprendiz(nome, idade, telefone, email) VALUES (@nome, @idade, @telefone, @email);";
        sqlite_cmd.Parameters.Add(new SqliteParameter("@nome", aprendiz.Nome));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@idade", aprendiz.Idade));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@telefone", aprendiz.Telefone));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@email", aprendiz.Email));
        

        sqlite_cmd.ExecuteNonQuery();

    }

    static void listarFuncionario(SqliteConnection conn)
    {
        SqliteDataReader sqlite_datareader;
        SqliteCommand sqlite_cmd;
        sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "SELECT * FROM funcionario";

        sqlite_datareader = sqlite_cmd.ExecuteReader();
        while (sqlite_datareader.Read())
        {
            string myreader = sqlite_datareader.GetString(0);
            Console.WriteLine(myreader);
        }
        conn.Close();
    }

    static void listarAprendiz(SqliteConnection conn)
    {
        SqliteDataReader sqlite_datareader;
        SqliteCommand sqlite_cmd;
        sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "SELECT * FROM aprendiz";

        sqlite_datareader = sqlite_cmd.ExecuteReader();
        while (sqlite_datareader.Read())
        {
            string myreader = sqlite_datareader.GetString(0);
            Console.WriteLine(myreader);
        }
        conn.Close();
    }

    static void editarFuncionario(SqliteConnection conn, Funcionario funcionario)
    {
        SqliteCommand sqlite_cmd;
        sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "UPDATE funcionario SET idade = @idade, telefone = @telefone, email = @email, funcao = @funcao where nome = @nome;";

        sqlite_cmd.Parameters.Add(new SqliteParameter("@idade", funcionario.Idade));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@telefone", funcionario.Telefone));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@email", funcionario.Email));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@funcao", funcionario.Funcao));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@nome", funcionario.Nome));

        sqlite_cmd.ExecuteNonQuery();

    }

    static void editarAprendiz(SqliteConnection conn, Aprendiz aprendiz)
    {
        SqliteCommand sqlite_cmd;
        sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "UPDATE aprendiz SET idade = @idade, telefone = @telefone, email = @email where nome = @nome;";

        sqlite_cmd.Parameters.Add(new SqliteParameter("@idade", aprendiz.Idade));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@telefone", aprendiz.Telefone));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@email", aprendiz.Email));
        sqlite_cmd.Parameters.Add(new SqliteParameter("@nome", aprendiz.Nome));

        sqlite_cmd.ExecuteNonQuery();

    }

    static void deletarFuncionario(SqliteConnection conn, string nome)
    {
        SqliteCommand sqlite_cmd;
        sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "DELETE FROM funcionario WHERE nome=@nome;";
        sqlite_cmd.Parameters.Add(new SqliteParameter("@nome", nome));

        sqlite_cmd.ExecuteNonQuery();

    }

    static void deletarAprendiz(SqliteConnection conn, string nome)
    {
        SqliteCommand sqlite_cmd;
        sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "DELETE FROM aprendiz WHERE nome=@nome;";
        sqlite_cmd.Parameters.Add(new SqliteParameter("@nome", nome));

        sqlite_cmd.ExecuteNonQuery();

    }

}