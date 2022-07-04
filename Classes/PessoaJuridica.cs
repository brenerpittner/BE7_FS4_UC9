 using BE7_FS4_UC9.Interfaces;
 using System.Text.RegularExpressions;

namespace BE7_FS4_UC9.Classes{
    public class PessoaJuridica : Pessoa, IPessoaJuridica{
        public string ?cnpj { get; set; }
        public string ?razaoSocial { get; set; }       
        
        public override float PagarImposto(float rendimento){
            throw new NotImplementedException();
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
    }
}