using BE7_FS4_UC9.Classes;

Console.Clear();
Console.WriteLine(@$"
=================================================================
=================================================================
|                                                               |
|               Bem vindo ao sistema de cadastro de             |
|                   Pessoas Físicas e Jurídicas                 |
|                                                               |
=================================================================
=================================================================
");
loading("Carregando", 50);

List<PessoaFisica> listaPf = new List<PessoaFisica>();

string? opcao;
do
{
    Console.Clear();
    Console.WriteLine(@$"
=================================================================
=================================================================
|                                                               |
|               Escolha uma das opções a seguir                 |
|                                                               |
|                   1 - Pessoa Física                           |
|                   2 - Pessoa Jurídica                         |
|                                                               |
|                   0 - Sair                                    |
|                                                               |
=================================================================
=================================================================
");

    opcao = Console.ReadLine();
    switch (opcao)
    {
        case "1":
            PessoaFisica metodoPf = new PessoaFisica();
            string? opcaoPf;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
=================================================================
=================================================================
|                                                               |
|               Escolha uma das opções a seguir                 |
|                                                               |
|                   1 - Cadastrar Pessoa Física                 |
|                   2 - Mostrar Pessoa Física                   |
|                                                               |
|                   0 - Sair                                    |
|                                                               |
=================================================================
=================================================================
");
                opcaoPf = Console.ReadLine();
                switch (opcaoPf)
                {
                    case "1":
                        PessoaFisica novaPf = new PessoaFisica();       //gerar obj pessoa física
                        Endereco novoEnd = new Endereco();              //gerar obj endereco
                        
                        Console.WriteLine($"Digite o nome da pessoa fisica que deseja cadastrar");
                        novaPf.nome = Console.ReadLine();
                        
                        bool dataValida;
                        do
                        {
                            Console.WriteLine($"Digite a data de nascimento Ex.: DD/MM/AAAA");
                            string? dataNasc = Console.ReadLine();

                            dataValida = metodoPf.ValidarDataNascimento(dataNasc);
                            if(dataValida){
                                novaPf.dataNascimento = dataNasc;
                            }else{
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"Data inválida, digite data válida");
                                Console.ResetColor();
                            }
                        } while (dataValida == false);

                        Console.WriteLine($"Digite o CPF:");
                        novaPf.cpf = Console.ReadLine();

                        Console.WriteLine($"Digite o rendimento mensal");
                        novaPf.rendimento = float.Parse(Console.ReadLine());
                        
                        Console.WriteLine($"Digite o logradouro");
                        novoEnd.Logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o numero");
                        novoEnd.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento (enter para vazio)");
                        novoEnd.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? S ou N");
                        string endCom = Console.ReadLine().ToUpper();

                        if (endCom == "S")
                        {
                            novoEnd.endComercial = true;
                        }else{
                            novoEnd.endComercial = false;
                        }

                        novaPf.endereco = novoEnd;
                        listaPf.Add(novaPf);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastrado com sucesso!");
                        Console.ResetColor();
                        break;
                    case "2":
                        Console.Clear();
                        if (listaPf.Count > 0){
                            foreach (PessoaFisica cadaPessoa in listaPf)
                            {
                                Console.Clear();
                                Console.WriteLine(@$"
                                    Nome: {cadaPessoa.nome}
                                    Logadouro: {cadaPessoa.endereco.Logradouro}, Numero: {cadaPessoa.endereco.numero}, Complemento: {cadaPessoa.endereco.complemento}, EndComercial: {cadaPessoa.endereco.endComercial}
                                    Data e Nascimento de idade: {cadaPessoa.dataNascimento}
                                    Taxa de Imposto: {metodoPf.PagarImposto(cadaPessoa.rendimento).ToString("C")}
                                ");
                                Console.WriteLine($"Aperte 'Enter' para continuar");
                                Console.ReadLine();
                                Console.Clear();
                            }

                        }else{
                            Console.WriteLine($"Lista vazia");
                            Thread.Sleep(3000);
                        }
                        break;
                    case "0":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção Inválida, por favor digite outra opção.");
                        Thread.Sleep(2000);
                        break;
                }
            } while (opcaoPf != "0");


            break;
        case "2":
            PessoaJuridica novaPj = new PessoaJuridica();
            Endereco novoEndPj = new Endereco();
            novaPj.nome = "MAGAZINE LUIZA";
            novaPj.cnpj = "47.960.950/0001-21";
            novaPj.razaoSocial = "MAGAZINE LUIZA S/A";
            novaPj.rendimento = 8000.0f;

            novoEndPj.Logradouro = "Avenida 6";
            novoEndPj.numero = 619;
            novoEndPj.complemento = "Casa 2";
            novoEndPj.endComercial = true;
            novaPj.endereco = novoEndPj;

            Console.WriteLine(@$"
                Nome: {novaPj.nome}
                Razão Social: {novaPj.razaoSocial}
                CNPJ: {novaPj.cnpj}
                CNPJ é valido: {(novaPj.ValidarCnpj(novaPj.cnpj) ? "sim":"não")}
                Taxa de Imposto: {novaPj.PagarImposto(novaPj.rendimento).ToString("C")}
            ");
            Console.WriteLine($"Aperte 'Enter para continuar'");
            Console.ReadLine();
            Console.Clear();
            break;
        case "0":
            loading("Finalizando", 1000);
            break;
        default:
            Console.Clear();
            Console.WriteLine($"Opção Invália, por favor digite outra opção.");
            Thread.Sleep(2000);
            Console.Clear();
            break;
    }
} while (opcao != "0");

static void loading(string texto, int tempo)
{
    Console.BackgroundColor = ConsoleColor.DarkCyan;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(texto + " ");
    for (var contador = 0; contador < 3; contador++)
    {
        Console.Write(". ");
        Thread.Sleep(tempo);
    }
    Console.Write("OK");
    Thread.Sleep(500);
    Console.ResetColor();
    Console.Clear();
}


//bool maior = novaPf.ValidarDataNascimento(new DateTime(1995,05,12));
//bool maior = novaPf.ValidarDataNascimento("1995,05,12");
//Console.WriteLine($"{maior}");