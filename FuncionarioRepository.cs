using System;
using Npgsql;

public class FuncionarioRepository
{
    private readonly string _connectionString;

    public FuncionarioRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Método CREATE - Adiciona um novo funcionário
    public bool AdicionarFuncionario(string nome, string cargo, decimal salario)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            try
            {
                connection.Open();
                var sql = "INSERT INTO funcionarios (nome, cargo, salario) VALUES (@nome, @cargo, @salario)";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@nome", nome);
                    command.Parameters.AddWithValue("@cargo", cargo);
                    command.Parameters.AddWithValue("@salario", salario);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar funcionário: {ex.Message}");
                return false;
            }
        }
    }

    // Método READ - Busca um funcionário pelo ID
    public Funcionario BuscarFuncionarioPorId(int id)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            try
            {
                connection.Open();
                var sql = "SELECT id, nome, cargo, salario FROM funcionarios WHERE id = @id";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Funcionario
                            {
                                Id = reader.GetInt32(0),
                                Nome = reader.GetString(1),
                                Cargo = reader.GetString(2),
                                Salario = reader.GetDecimal(3)
                            };
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar funcionário: {ex.Message}");
                return null;
            }
        }
    }

    // Método UPDATE - Atualiza o salário de um funcionário
    public bool AtualizarSalario(int id, decimal novoSalario)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            try
            {
                connection.Open();
                var sql = "UPDATE funcionarios SET salario = @novoSalario WHERE id = @id";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@novoSalario", novoSalario);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar salário: {ex.Message}");
                return false;
            }
        }
    }
}

public class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public decimal Salario { get; set; }
}