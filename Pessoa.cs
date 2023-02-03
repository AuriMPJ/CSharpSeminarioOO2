class Pessoa
{
    public string Nome { get; set; }

    public int Idade { get; set; }

    public int Telefone { get; set; }

    public string Email { get; set; }
   
    public Pessoa(string nome, int idade, int telefone, string email)
    {
        Nome = nome;
        Idade = idade;
        Telefone = telefone;
        Email = email;
    }

    public virtual double Salario() => 1500;
}

