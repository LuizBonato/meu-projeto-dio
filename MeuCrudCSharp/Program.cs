using System;
using System.Collections.Generic;
using System.Linq;

// Classe que representa um usuário
class User
{
    public int Id { get; set; }                 // Id único do usuário
    public string Nome { get; set; } = null!;  // Nome do usuário (não pode ser nulo)
    public string Email { get; set; } = null!; // Email do usuário (não pode ser nulo)
}

class Program
{
    // Lista que armazena os usuários cadastrados
    static List<User> usuarios = new List<User>();

    // Variável para gerar o próximo Id automaticamente
    static int nextId = 1;

    static void Main(string[] args)
    {
        while (true) // Loop infinito para o menu
        {
            Console.WriteLine("\n=== CRUD Usuários ===");
            Console.WriteLine("1 - Adicionar usuário");
            Console.WriteLine("2 - Listar usuários");
            Console.WriteLine("3 - Atualizar usuário");
            Console.WriteLine("4 - Deletar usuário");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarUsuario();
                    break;
                case "2":
                    ListarUsuarios();
                    break;
                case "3":
                    AtualizarUsuario();
                    break;
                case "4":
                    DeletarUsuario();
                    break;
                case "0":
                    return; // Sai do programa
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    // Método para adicionar um novo usuário
    static void AdicionarUsuario()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        // Cria o usuário com novo Id e adiciona na lista
        var usuario = new User { Id = nextId++, Nome = nome, Email = email };
        usuarios.Add(usuario);

        Console.WriteLine("Usuário adicionado com sucesso!");
    }

    // Método para listar todos os usuários
    static void ListarUsuarios()
    {
        Console.WriteLine("\nLista de usuários:");
        foreach (var u in usuarios)
        {
            Console.WriteLine($"ID: {u.Id} | Nome: {u.Nome} | Email: {u.Email}");
        }
        if (usuarios.Count == 0)
            Console.WriteLine("Nenhum usuário cadastrado.");
    }

    // Método para atualizar um usuário existente pelo Id
    static void AtualizarUsuario()
    {
        Console.Write("Digite o ID do usuário para atualizar: ");
        if (int.TryParse(Console.ReadLine(), out int id)) // Verifica se o Id é número
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id); // Busca usuário na lista
            if (usuario != null)
            {
                Console.Write("Novo nome: ");
                string nome = Console.ReadLine();

                Console.Write("Novo email: ");
                string email = Console.ReadLine();

                // Atualiza dados do usuário
                usuario.Nome = nome;
                usuario.Email = email;

                Console.WriteLine("Usuário atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    // Método para deletar usuário pelo Id
    static void DeletarUsuario()
    {
        Console.Write("Digite o ID do usuário para deletar: ");
        if (int.TryParse(Console.ReadLine(), out int id)) // Verifica se o Id é número
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id); // Busca usuário na lista
            if (usuario != null)
            {
                usuarios.Remove(usuario); // Remove usuário da lista
                Console.WriteLine("Usuário deletado com sucesso!");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }
}
