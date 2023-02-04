// Herança usando o : para definir de onde vem a classe pai desta
class Aprendiz : Pessoa
{
    public Aprendiz(string nome, int idade, string telefone, string email) : base(nome, idade, telefone, email)
    {
    }
// Polimorfismo onde o metodo salario sobrescreve o metodo da classe pai
    public override double Salario()
    {
        return base.Salario() * 2;
    }
}
