public class Program
{
    static void Main()
    {
        Aprendiz pessoa1 = new Aprendiz("Yuri", 30, 11234, "yuri@email.com");
        Aprendiz pessoa2 = new Aprendiz("Joana", 18, 11234, "joana@email.com");
        Funcionario pessoa3 = new Funcionario("Auri", 15, 11234, "soulindo@email.com", "vendedor");

        Console.WriteLine($"Nome: {pessoa1.Nome}"
            + Environment.NewLine
            + $"\tIdade: {pessoa1.Idade}"
            + Environment.NewLine
            + $"\tTelefone: {pessoa1.Telefone}"
            + Environment.NewLine
            + $"\tEmail: {pessoa1.Email}"
            + Environment.NewLine
            + $"\tSalario: {pessoa1.Salario().ToString("F2")}"
            + Environment.NewLine);

        Console.WriteLine($"Nome: {pessoa2.Nome}"
            + Environment.NewLine
            + $"\tIdade: {pessoa2.Idade}"
            + Environment.NewLine
            + $"\tTelefone: {pessoa2.Telefone}"
            + Environment.NewLine
            + $"\tEmail: {pessoa2.Email}"
            + Environment.NewLine
            + $"\tSalario: {pessoa2.Salario().ToString("F2")}"
            + Environment.NewLine);

        Console.WriteLine($"Nome: {pessoa3.Nome}"
            + Environment.NewLine
            + $"\tIdade: {pessoa3.Idade}"
            + Environment.NewLine
            + $"\tTelefone: {pessoa3.Telefone}"
            + Environment.NewLine
            + $"\tEmail: {pessoa3.Email}"
            + Environment.NewLine
            + $"\tSalario: {pessoa3.Salario().ToString("F2")}"
            + Environment.NewLine
            + $"\tFunção: {pessoa3.Funcao}");
        
    }
}