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
List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

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
                        
                        //listaPf.Add(novaPf);
                        
                        using (StreamWriter sw = new StreamWriter($"{novaPf.nome}.txt"))
                        {
                            sw.WriteLine(novaPf.nome);
                            sw.WriteLine(novaPf.dataNascimento);
                            sw.WriteLine(novaPf.cpf);
                            sw.WriteLine(novaPf.rendimento);
                            sw.WriteLine(novoEnd.Logradouro);
                            sw.WriteLine(novoEnd.numero);
                            sw.Write(novoEnd.complemento);
                        }
                        
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastrado com sucesso!");
                        Console.ResetColor();
                        break;
                    case "2":
                        Console.Clear();
                        /*
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
                        */
                        using (StreamReader sr = new StreamReader($"marcelino.txt"))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                Console.WriteLine(line);
                            }
                        }
                        Console.WriteLine($"Aperte ENTER para continuar...");
                        Console.ReadLine();                        
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
            PessoaJuridica metodoPj = new PessoaJuridica();
            string? opcaoPj;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
=================================================================
=================================================================
|                                                               |
|               Escolha uma das opções a seguir                 |
|                                                               |
|                   1 - Cadastrar Pessoa Jurídica               |
|                   2 - Mostrar Pessoa Jurídica                 |
|                                                               |
|                   0 - Sair                                    |
|                                                               |
=================================================================
=================================================================
");
                opcaoPj = Console.ReadLine();
                switch (opcaoPj)
                {
                    case "1":
                        PessoaJuridica novaPj = new PessoaJuridica();
                        Endereco novoEndPj = new Endereco();

                        Console.WriteLine($"Digite o nome da pessoa jurídica que deseja cadastrar");
                        novaPj.nome = Console.ReadLine();

                        bool cnpjValida;
                        do
                        {
                            Console.WriteLine($"Digite o cnpj Ex.: xx.xxx.xxx/xxxx-xx");
                            string? cnpjString = Console.ReadLine();

                            cnpjValida = metodoPj.ValidarCnpj(cnpjString);
                            if(cnpjValida){
                                novaPj.cnpj = cnpjString;
                            }else{
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"CNPJ inválida, digite CNPJ válida"); //to test 80.804.340/0001-04
                                Console.ResetColor();
                            }
                        } while (cnpjValida == false);

                        Console.WriteLine($"Digite a razão social");
                        novaPj.razaoSocial = Console.ReadLine();

                        Console.WriteLine($"Digite o rendimento mensal");
                        novaPj.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o logradouro");
                        novoEndPj.Logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o numero");
                        novoEndPj.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento (enter para vazio)");
                        novoEndPj.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? S ou N");
                        string endCom = Console.ReadLine().ToUpper();
                        
                        if (endCom == "S")
                        {
                            novoEndPj.endComercial = true;
                        }else{
                            novoEndPj.endComercial = false;
                        }

                        novaPj.endereco = novoEndPj;
                        metodoPj.Inserir(novaPj);
                        //listaPj.Add(novaPj);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastrado com sucesso!");
                        Console.ResetColor();
                        break;
                    case "2":
                        Console.Clear();
                        List<PessoaJuridica> listPj = metodoPj.Ler();
                        
                        foreach (PessoaJuridica cadaPessoa in listPj)
                        {
                            Console.WriteLine(@$"
                                Nome: {cadaPessoa.nome}
                                Razão Social: {cadaPessoa.razaoSocial}
                                CNPJ: {cadaPessoa.cnpj}
                                CNPJ é valido: {(cadaPessoa.ValidarCnpj(cadaPessoa.cnpj) ? "sim":"não")}
                                Taxa de Imposto: {cadaPessoa.PagarImposto(cadaPessoa.rendimento).ToString("C")}
                            ");
                            Console.WriteLine($"Aperte 'Enter para continuar'");
                            Console.ReadLine();
                            Console.Clear();
                        }

                        /*
                        if (listaPj.Count > 0){
                            foreach (PessoaJuridica cadaPessoa in listaPj)
                            {
                                Console.WriteLine(@$"
                                    Nome: {cadaPessoa.nome}
                                    Razão Social: {cadaPessoa.razaoSocial}
                                    CNPJ: {cadaPessoa.cnpj}
                                    CNPJ é valido: {(cadaPessoa.ValidarCnpj(cadaPessoa.cnpj) ? "sim":"não")}
                                    Taxa de Imposto: {cadaPessoa.PagarImposto(cadaPessoa.rendimento).ToString("C")}
                                ");
                                Console.WriteLine($"Aperte 'Enter para continuar'");
                                Console.ReadLine();
                                Console.Clear();
                            }

                        }else{
                            Console.WriteLine($"Lista vazia");
                            Thread.Sleep(3000);
                        }
                        */
                        break;
                    case "0":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção Inválida, por favor digite outra opção.");
                        Thread.Sleep(2000);
                        break;
                }
            } while (opcaoPj != "0");

        /*

            */
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