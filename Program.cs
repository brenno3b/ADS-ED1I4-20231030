using ADS_ED1I4_20231030;

Cadastro _controller = new();

_controller.Download();

void Sair()
{
    _controller.Upload();

    Environment.Exit(0);
}

void SalvarAmbiente()
{
    Console.WriteLine("\n--- Cadastrar ambiente ---\n");

    Console.Write("Digite o ID: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Console.Write("Digite o nome: ");
    String nome = Console.ReadLine();
    Console.WriteLine();

    Ambiente newAmbiente = new(id, nome);

    _controller.AdicionarAmbiente(newAmbiente);

    Console.WriteLine("Ambiente adicionado.");

    Console.WriteLine("\n--- Fim do cadastro de ambiente ---\n");
}

void PesquisarAmbiente()
{
    Console.WriteLine("\n--- Pesquisar ambiente ---\n");

    Console.Write("Digite o ID: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Ambiente queryAmbiente = new(id);

    Ambiente foundAmbiente = _controller.PesquisarAmbiente(queryAmbiente);

    if (foundAmbiente.Id == -1)
    {
        Console.WriteLine("Ambiente não encontrado.");
    } 
    else
    {
        Console.WriteLine(foundAmbiente.ToString());
    }

    Console.WriteLine("\n--- Fim da pesquisa de ambiente ---\n");
}

void ExcluirAmbiente()
{
    Console.WriteLine("\n--- Excluir ambiente ---\n");

    Console.Write("Digite o ID: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Ambiente queryAmbiente = new(id);

    bool isSuccess = _controller.RemoverAmbiente(queryAmbiente);

    if (isSuccess)
    {
        Console.WriteLine("Ambiente removido.");
    } else
    {
        Console.WriteLine("Falha ao remover ambiente.");
    }

    Console.WriteLine("\n--- Fim da exclusão de ambiente ---\n");
}

void SalvarUsuario()
{
    Console.WriteLine("\n--- Cadastrar usuário ---\n");

    Console.Write("Digite o ID: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Console.Write("Digite o nome: ");
    String nome = Console.ReadLine();
    Console.WriteLine();

    Usuario newUsuario = new(id, nome);

    _controller.AdicionarUsuario(newUsuario);

    Console.WriteLine("Usuário adicionado.");

    Console.WriteLine("\n--- Fim do cadastro de usuário ---\n");
}

void PesquisarUsuario()
{
    Console.WriteLine("\n--- Pesquisar usuário ---\n");

    Console.Write("Digite o ID: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Usuario queryUsuario = new(id);

    Usuario foundUsuario = _controller.PesquisarUsuario(queryUsuario);

    if (foundUsuario.Id == -1)
    {
        Console.WriteLine("Usuário não encontrado.");
    }
    else
    {
        Console.WriteLine(foundUsuario.ToString());
    }

    Console.WriteLine("\n--- Fim da pesquisa de usuário ---\n");
}

void ExcluirUsuario()
{
    Console.WriteLine("\n--- Excluir usuário ---\n");

    Console.Write("Digite o ID: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Usuario queryUsuario = new(id);

    bool isSuccess = _controller.RemoverUsuario(queryUsuario);

    if (isSuccess)
    {
        Console.WriteLine("Usuário removido.");
    }
    else
    {
        Console.WriteLine("Falha ao remover usuário.");
    }

    Console.WriteLine("\n--- Fim da exclusão de usuário ---\n");
}

void ConcederPermissao()
{
    Console.WriteLine("\n--- Conceder permissão de acesso ao usuário ---\n");

    Console.Write("Digite o ID do ambiente: ");
    int idAmbiente = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Ambiente queryAmbiente = new(idAmbiente);

    Ambiente foundAmbiente = _controller.PesquisarAmbiente(queryAmbiente);

    if (foundAmbiente.Id == -1)
    {
        Console.WriteLine("Ambiente não encontrado.");
    }
    else
    {
        Console.Write("Digite o ID do usuário: ");
        int idUsuario = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        Usuario queryUsuario = new(idUsuario);

        Usuario foundUsuario = _controller.PesquisarUsuario(queryUsuario);

        if (foundUsuario.Id == -1)
        {
            Console.WriteLine("Usuário não encontrado.");
        }
        else
        {
            bool isSuccess = foundUsuario.ConcederPermissão(foundAmbiente);

            if (isSuccess)
            {
                Console.WriteLine($"Permissão concedida ao usuário {foundUsuario.Nome}.");
            } else
            {
                Console.WriteLine($"Falha ao conceder permissão ao usuário: {foundUsuario}");
            }
        }
    }

    Console.WriteLine("\n--- Fim da concessão de permissão ---\n");
}

void RevogarPermissao()
{
    Console.WriteLine("\n--- Revogar permissão de acesso ao usuário ---\n");

    Console.Write("Digite o ID do ambiente: ");
    int idAmbiente = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Ambiente queryAmbiente = new(idAmbiente);

    Ambiente foundAmbiente = _controller.PesquisarAmbiente(queryAmbiente);

    if (foundAmbiente.Id == -1)
    {
        Console.WriteLine("Ambiente não encontrado.");
    }
    else
    {
        Console.Write("Digite o ID do usuário: ");
        int idUsuario = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        Usuario queryUsuario = new(idUsuario);

        Usuario foundUsuario = _controller.PesquisarUsuario(queryUsuario);

        if (foundUsuario.Id == -1)
        {
            Console.WriteLine("Usuário não encontrado.");
        }
        else
        {
            bool isSuccess = foundUsuario.RevogarPermissão(foundAmbiente);

            if (isSuccess)
            {
                Console.WriteLine($"Permissão revogada ao usuário {foundUsuario.Nome}.");
            }
            else
            {
                Console.WriteLine($"Falha ao revogar permissão ao usuário: {foundUsuario.Nome}");
            }
        }
    }

    Console.WriteLine("\n--- Fim da revogação de permissão ---\n");
}

void RegistrarAcesso()
{
    Console.WriteLine("\n--- Registrar Log ---\n");

    Console.Write("Digite o ID do ambiente: ");
    int idAmbiente = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Ambiente queryAmbiente = new(idAmbiente);

    Ambiente foundAmbiente = _controller.PesquisarAmbiente(queryAmbiente);

    if (foundAmbiente.Id == -1)
    {
        Console.WriteLine("Ambiente não encontrado.");
    }
    else
    {
        Console.Write("Digite o ID do usuário: ");
        int idUsuario = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        Usuario queryUsuario = new(idUsuario);

        Usuario foundUsuario = _controller.PesquisarUsuario(queryUsuario);

        if (foundUsuario.Id == -1)
        {
            Console.WriteLine("Usuário não encontrado.");
        }
        else
        {
            Log newLog = new(foundUsuario);

            foundAmbiente.RegistrarLog(newLog);

            Console.WriteLine("Log registrado.");
        }
    }

    Console.WriteLine("\n--- Fim do registro de Log ---\n");
}

void ConsultarLogs()
{
    Console.WriteLine("\n--- Consultar Logs ---\n");

    Console.Write("Digite o ID do ambiente: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Ambiente queryAmbiente = new(id);

    Ambiente foundAmbiente = _controller.PesquisarAmbiente(queryAmbiente);

    if (foundAmbiente.Id == -1)
    {
        Console.WriteLine("Ambiente não encontrado.");
    }
    else
    {
        Console.WriteLine("\n--- Todos ---\n");

        foreach (Log log in foundAmbiente.Logs)
        {
            Console.WriteLine(log.ToString());
        }

        Console.WriteLine("\n--- Autorizados ---\n");

        foreach (Log log in foundAmbiente.Logs)
        {
            if (log.TipoAcesso) Console.WriteLine(log.ToString());
        }

        Console.WriteLine("\n--- Negados ---\n");

        foreach (Log log in foundAmbiente.Logs)
        {
            if (!log.TipoAcesso) Console.WriteLine(log.ToString());
        }
    }


    Console.WriteLine("\n--- Fim da consulta de Logs ---\n");
}

while (true)
{
    Console.WriteLine("0. Sair");
    Console.WriteLine("1. Cadastrar ambiente");
    Console.WriteLine("2. Consultar ambiente");
    Console.WriteLine("3. Excluir ambiente");
    Console.WriteLine("4. Cadastrar usuário");
    Console.WriteLine("5. Consultar usuário");
    Console.WriteLine("6. Excluir usuário");
    Console.WriteLine("7. Conceder permissão de acesso ao usuário");
    Console.WriteLine("8. Revogar permissão de acesso ao usuário");
    Console.WriteLine("9. Registrar acesso");
    Console.WriteLine("10. Consultar logs de acesso");

    Console.WriteLine();

    int option = Convert.ToInt32(Console.ReadLine());
    Console.Clear();

    if (option == 0) Sair();
    if (option == 1) SalvarAmbiente();
    if (option == 2) PesquisarAmbiente();
    if (option == 3) ExcluirAmbiente();
    if (option == 4) SalvarUsuario();
    if (option == 5) PesquisarUsuario();
    if (option == 6) ExcluirUsuario();
    if (option == 7) ConcederPermissao();
    if (option == 8) RevogarPermissao();
    if (option == 9) RegistrarAcesso();
    if (option == 10) ConsultarLogs();
}