using BE7_FS4_UC9.Classes;
/*
PessoaFisica novaPf = new PessoaFisica();
Endereco novoEnd = new Endereco();

PessoaFisica metodoPf = new PessoaFisica();

novaPf.nome = "Brener Pittner";
novaPf.dataNascimento = "12/05/1995";
novaPf.cpf = "12345678900";
novaPf.rendimento = "600.0f";

novoEnd.Logradouro = "Avenida 6";
novoEnd.numero = 619;
novoEnd.complemento = "Casa 2";
novoEnd.endComercial = true;

novaPf.endereco = novoEnd;
Console.WriteLine(@$"
Nome: {novaPf.nome}
Logadouro: {novaPf.endereco.Logradouro}, Numero: {novaPf.endereco.numero}, Complemento: {novaPf.endereco.complemento}, EndComercial: {novaPf.endereco.endComercial}
Maior de idade: {metodoPf.ValidarDataNascimento(novaPf.dataNascimento)}
");
*/

PessoaJuridica novaPj = new PessoaJuridica();
Endereco novoEndPj = new Endereco();
novaPj.nome = "MAGAZINE LUIZA";
novaPj.cnpj = "47.960.950/0001-21";
novaPj.razaoSocial = "MAGAZINE LUIZA S/A";
novaPj.rendimento = "8000.0f";

novoEndPj.Logradouro = "Avenida 6";
novoEndPj.numero = 619;
novoEndPj.complemento = "Casa 2";
novoEndPj.endComercial = true;
novaPj.endereco = novoEndPj;

Console.WriteLine(@$"
    Nome: {novaPj.nome}
    Razão Social: {novaPj.razaoSocial}
    CNPJ: {novaPj.cnpj}
    CNPJ é valido: {novaPj.ValidarCnpj(novaPj.cnpj)}
    CNPJ é valido2: {novaPj.IsCnpj(novaPj.cnpj)}
");
 

//bool maior = novaPf.ValidarDataNascimento(new DateTime(1995,05,12));
//bool maior = novaPf.ValidarDataNascimento("1995,05,12");
//Console.WriteLine($"{maior}");


