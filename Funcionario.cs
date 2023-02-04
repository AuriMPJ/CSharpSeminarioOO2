// Herança usando o : para definir de onde vem a classe pai desta
class Funcionario : Pessoa
{
    public string Funcao{get; set;}

    public Funcionario(string nome, int idade, string telefone, string email, string funcao) : base(nome, idade, telefone, email)
    {
        Funcao = funcao;
    }
// Polimorfismo onde o metodo salario sobrescreve o metodo da classe pai
    public override double Salario()
    {
        return base.Salario() * 3;
    }
}