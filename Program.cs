using System;
using Npgsql;

class Program
{
    static void Main(string[] args)
    {
        // Substitua pela sua string de conexão
        string connectionString = "Host=localhost;Database=FuncionarioRepository;Username=SEU_USER;Password=SUA_SENHA";

        var funcionarioRepo = new FuncionarioRepository(connectionString);

        Console.WriteLine("Testando CRUD de Funcionários...");

        // Teste do método CREATE
        Console.WriteLine("\nAdicionando novo funcionário...");
        bool sucessoCreate = funcionarioRepo.AdicionarFuncionario("João Silva", "Desenvolvedor", 5000.00m);
        Console.WriteLine(sucessoCreate ? "Funcionário adicionado com sucesso!" : "Falha ao adicionar funcionário");

        // Teste do método READ
        Console.WriteLine("\nBuscando funcionário...");
        var funcionario = funcionarioRepo.BuscarFuncionarioPorId(1);

        if (funcionario != null)
        {
            Console.WriteLine($"Funcionário encontrado: ID: {funcionario.Id}, Nome: {funcionario.Nome}, Cargo: {funcionario.Cargo}, Salário: {funcionario.Salario:C}");
        }
        else
        {
            Console.WriteLine("Funcionário não encontrado");
        }

        // Teste do método UPDATE
        Console.WriteLine("\nAtualizando salário...");
        bool sucessoUpdate = funcionarioRepo.AtualizarSalario(1, 5500.00m);
        Console.WriteLine(sucessoUpdate ? "Salário atualizado com sucesso!" : "Falha ao atualizar salário");

        // Verificando a atualização
        funcionario = funcionarioRepo.BuscarFuncionarioPorId(1);
        if (funcionario != null)
        {
            Console.WriteLine($"Novo salário: {funcionario.Salario:C}");
        }

        Console.WriteLine("\nPressione qualquer tecla para sair...");
        Console.ReadKey();
    }
}