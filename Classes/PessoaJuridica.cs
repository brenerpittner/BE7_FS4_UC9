 using BE7_FS4_UC9.Interfaces;
 using System.Text.RegularExpressions;

namespace BE7_FS4_UC9.Classes
{
	public class PessoaJuridica : Pessoa, IPessoaJuridica
	{
        public string ?cnpj { get; set; }
        public string ?razaoSocial { get; set; }
        public string caminho { get; set; } = "Database/PessoaJuridica.csv";

        public override float PagarImposto(float rendimento){
            /* Impostos
            até    1500 - 3%
            1500 - 3500 - 5%
            3500 - 6000 - 7%
            acima  6000 - 9%
            */
		
            if (rendimento <= 1500){
                return (rendimento/100)*3;
            }else if (rendimento > 1500 && rendimento <= 3500) {
                return (rendimento/100)*5;
            }else if (rendimento > 3500 && rendimento <=6000) {
                return (rendimento/100)*7;
            }else {
                return (rendimento/100)*9;
            }
        }

        public bool ValidarCnpj(string cnpj){
            if (Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)")){ // xx.xxx.xxx/xxxx-xx ou xxxxxxxxxxxxxx
                if(cnpj.Length == 18){
                    if(cnpj.Substring(11,4) == "0001"){// após as 11 verifica as proxima 4 casas
                        return true;
                    }
                }else if(cnpj.Length == 14){
                    if(cnpj.Substring(8,4) == "0001"){// após as 11 verifica as proxima 4 casas
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsCnpj(string cnpj){
			int[] multiplicador1 = new int[12] {5,4,3,2,9,8,7,6,5,4,3,2};
			int[] multiplicador2 = new int[13] {6,5,4,3,2,9,8,7,6,5,4,3,2};
			int soma, resto;
			string digito, tempCnpj;

			cnpj = cnpj.Trim();
			cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

			if (cnpj.Length != 14)
				return false;

			tempCnpj = cnpj.Substring(0, 12);

			soma = 0;
			for(int i=0; i<12; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

			resto = (soma % 11);
			if ( resto < 2)
				resto = 0;
			else
				resto = 11 - resto;

			digito = resto.ToString();

			tempCnpj = tempCnpj + digito;
			soma = 0;
			for (int i = 0; i < 13; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;

			digito = digito + resto.ToString();

			return cnpj.EndsWith(digito);
		}

        public void Inserir(PessoaJuridica pj)
        {
            VerificarPastaArquivo(caminho);

            string[] pjString = {$"{pj.nome},{pj.cnpj},{pj.razaoSocial}"};
            File.AppendAllLines(caminho, pjString);
        }

        public List<PessoaJuridica> Ler()
        {
            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

            string[] linhas = File.ReadAllLines(caminho);
            foreach(string cadalinha in linhas)
            {
                string[] atributos = cadalinha.Split(',');

                PessoaJuridica cadaPj = new PessoaJuridica();
                cadaPj.nome = atributos[0];
                cadaPj.cnpj = atributos[1];
                cadaPj.razaoSocial = atributos[2];
                listaPj.Add(cadaPj);
            }
            return listaPj;
        }
    }
}