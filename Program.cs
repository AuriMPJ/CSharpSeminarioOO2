public class Program
{
    static void Main()
    {

        SQLiteConnection sqlite_conn = CreateConnection;

        CreateTable(sqlite_conn);

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
            int opcao = Console.ReadLine();

            if(opcao == 1){

                Console.WriteLine("|-------------------------|");
                Console.WriteLine("|                         |");
                Console.WriteLine("|      1 - Funcionario    |");
                Console.WriteLine("|      2 - Aprendiz       |");
                Console.WriteLine("|                         |");
                Console.WriteLine("|-------------------------|");
                    
                int opcao2 = Console.ReadLine();

                if(opcao2 == 1){

                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Idade: ");
                    int idade = Console.ReadLine();
                    Console.Write("Telefone: ");
                    string telefone = Console.ReadLine();
                    Console.Write("E-mail: ");
                    string email = Console.ReadLine();
                    Console.Write("Função: ");
                    string funcao = Console.ReadLine();

                    Funcionario fun = new Funcionario(nome, idade, telefone, email, funcao);

                    cadastrarFuncionario(sqlite_conn, fun);

                }else if(opcao2 == 2){

                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Idade: ");
                    int idade = Console.ReadLine();
                    Console.Write("Telefone: ");
                    string telefone = Console.ReadLine();
                    Console.Write("E-mail: ");
                    string email = Console.ReadLine();

                    Aprendiz apre = new Aprendiz(nome, idade, telefone, email);

                    cadastrarAprendiz(sqlite_conn, apre);

                }

            }else if(opcao == 2){

                Console.WriteLine("|-------------------------|");
                Console.WriteLine("|                         |");
                Console.WriteLine("|      1 - Funcionarios   |");
                Console.WriteLine("|      2 - Aprendizes     |");
                Console.WriteLine("|                         |");
                Console.WriteLine("|-------------------------|");

                int opcao2 = Console.ReadLine();

                if(opcao2 == 1){
                    listarFuncionario();
                }else if(opcao2 == 2){
                    listarAprendiz();
                }

            }else if(opcao == 3){
                Console.WriteLine("|-------------------------|");
                Console.WriteLine("|                         |");
                Console.WriteLine("|      1 - Funcionario    |");
                Console.WriteLine("|      2 - Aprendiz       |");
                Console.WriteLine("|                         |");
                Console.WriteLine("|-------------------------|");

                int opcao2 = Console.ReadLine();

                if(opcao2 == 1){

                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Idade: ");
                    int idade = Console.ReadLine();
                    Console.Write("Telefone: ");
                    string telefone = Console.ReadLine();
                    Console.Write("E-mail: ");
                    string email = Console.ReadLine();
                    Console.Write("Função: ");
                    string funcao = Console.ReadLine();

                    Funcionario fun = new Funcionario(nome, idade, telefone, email, funcao);

                    editarFuncionario(sqlite_conn, fun);
                }else if(opcao2 == 2){

                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Idade: ");
                    int idade = Console.ReadLine();
                    Console.Write("Telefone: ");
                    string telefone = Console.ReadLine();
                    Console.Write("E-mail: ");
                    string email = Console.ReadLine();

                    Aprendiz apre = new Aprendiz(nome, idade, telefone, email);

                    editarFuncionario(sqlite_conn, apre);
                }

            }else if(opcao == 4){
                Console.WriteLine("|-------------------------|");
                Console.WriteLine("|                         |");
                Console.WriteLine("|      1 - Funcionario    |");
                Console.WriteLine("|      2 - Aprendiz       |");
                Console.WriteLine("|                         |");
                Console.WriteLine("|-------------------------|");

                int opcao2 = Console.ReadLine();

                if(opcao2 == 1){

                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();

                    deletarFuncionario(sqlite_conn, nome);
                }else if(opcao2 == 2){

                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();

                    deletarAprendiz(sqlite_conn, nome);
                }

            }

        }
        while (opcao != 0);
        
    }

      static SQLiteConnection CreateConnection()
      {

         SQLiteConnection sqlite_conn;
         sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
         try
         {
            sqlite_conn.Open();
         }
         catch (Exception ex)
         {

         }
         return sqlite_conn;
      }

      static void CreateTable(SQLiteConnection conn)
      {

         SQLiteCommand sqlite_cmd;
         string Createsql = "CREATE TABLE funcionario(nome VARCHAR(25), idade INT, telefone VARCHAR(15), email VARCHAR(35)), funcao VARCHAR(20)";
         string Createsql1 = "CREATE TABLE aprendiz(nome VARCHAR(25), idade INT, telefone VARCHAR(15), email VARCHAR(35))";
         sqlite_cmd = conn.CreateCommand();
         sqlite_cmd.CommandText = Createsql;
         sqlite_cmd.ExecuteNonQuery();
         sqlite_cmd.CommandText = Createsql1;
         sqlite_cmd.ExecuteNonQuery();

      }

    static void cadastrarFuncionario(SQLiteConnection conn, Funcionario funcionario)
    {
        SQLiteCommand sqlite_cmd;
        sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "INSERT INTO funcionario(nome, idade, telefone, email, funcao) VALUES (@nome, @idade, @telefone, @email, @funcao);";
        this.sqlite_cmd.Parameters.Add(new SQLiteParameter("@nome", funcionario.Nome));
        this.sqlite_cmd.Parameters.Add(new SQLiteParameter("@idade", funcionario.Idade));
        this.sqlite_cmd.Parameters.Add(new SQLiteParameter("@telefone", funcionario.Telefone));
        this.sqlite_cmd.Parameters.Add(new SQLiteParameter("@email", funcionario.Email));
        this.sqlite_cmd.Parameters.Add(new SQLiteParameter("@funcao", funcionario.Funcao));

        sqlite_cmd.ExecuteNonQuery();

    }

    static void cadastrarAprendiz(SQLiteConnection conn, Aprendiz aprendiz)
    {
        SQLiteCommand sqlite_cmd;
        sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "INSERT INTO aprendiz(nome, idade, telefone, email) VALUES (@nome, @idade, @telefone, @email);";
        this.sqlite_cmd.Parameters.Add(new SQLiteParameter("@nome", aprendiz.Nome));
        this.sqlite_cmd.Parameters.Add(new SQLiteParameter("@idade", aprendiz.Idade));
        this.sqlite_cmd.Parameters.Add(new SQLiteParameter("@telefone", aprendiz.Telefone));
        this.sqlite_cmd.Parameters.Add(new SQLiteParameter("@email", aprendiz.Email));
        

        sqlite_cmd.ExecuteNonQuery();

    }

    static void listarFuncionario(SQLiteConnection conn)
    {
        SQLiteDataReader sqlite_datareader;
        SQLiteCommand sqlite_cmd;
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

    static void listarAprendiz(SQLiteConnection conn)
    {
        SQLiteDataReader sqlite_datareader;
        SQLiteCommand sqlite_cmd;
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

    static void editarFuncionario(SQLiteConnection conn, Funcionario funcionario)
    {
        SQLiteCommand sqlite_cmd;
        sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "UPDATE funcionario SET idade = @idade, telefone = @telefone, email = @email, funcao = @funcao where nome = @nome;";

        this.sqlite_cmd.Parameters.Add(new SQLiteParameter("@idade", funcionario.Idade));
        this.sqlite_cmd.Parameters.Add(new SQLiteParameter("@telefone", funcionario.Telefone));
        this.sqlite_cmd.Parameters.Add(new SQLiteParameter("@email", funcionario.Email));
        this.sqlite_cmd.Parameters.Add(new SQLiteParameter("@funcao", funcionario.Funcao));
        this.sqlite_cmd.Parameters.Add(new SQLiteParameter("@nome", funcionario.Nome));

        sqlite_cmd.ExecuteNonQuery();

    }

    static void editarAprendiz(SQLiteConnection conn, Aprendiz aprendiz)
    {
        SQLiteCommand sqlite_cmd;
        sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "UPDATE aprendiz SET idade = @idade, telefone = @telefone, email = @email where nome = @nome;";

        this.sqlite_cmd.Parameters.Add(new SQLiteParameter("@idade", funcionario.Idade));
        this.sqlite_cmd.Parameters.Add(new SQLiteParameter("@telefone", funcionario.Telefone));
        this.sqlite_cmd.Parameters.Add(new SQLiteParameter("@email", funcionario.Email));
        this.sqlite_cmd.Parameters.Add(new SQLiteParameter("@nome", funcionario.Nome));

        sqlite_cmd.ExecuteNonQuery();

    }

    static void deletarFuncionario(SQLiteConnection conn, string nome)
    {
        SQLiteCommand sqlite_cmd;
        sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "DELETE FROM funcionario WHERE nome=@nome;";
        this.sqlite_cmd.Parameters.Add(new SQLiteParameter("@nome", nome));

        sqlite_cmd.ExecuteNonQuery();

    }

    static void deletarAprendiz(SQLiteConnection conn, string nome)
    {
        SQLiteCommand sqlite_cmd;
        sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "DELETE FROM aprendiz WHERE nome=@nome;";
        this.sqlite_cmd.Parameters.Add(new SQLiteParameter("@nome", nome));

        sqlite_cmd.ExecuteNonQuery();

    }

}