 using BE7_FS4_UC9.Interfaces;

namespace BE7_FS4_UC9.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string ?cpf { get; set; }
        public string ?dataNascimento { get; set; }
        public string caminho { get; set; } = "Database/PessoaFisica.csv";
       
        public override float PagarImposto(float rendimento)
        {
            /* Impostos
            até    1500 - isento
            1500 - 3500 - 2%
            3500 - 6000 - 3,5%
            acima  6000 - 5%
            */
            if (rendimento <= 1500){
                return 0;
            }else if (rendimento > 1500 && rendimento <= 3500){
                return (rendimento/100)*2;
            }else if (rendimento > 3500 && rendimento <=6000){
                return (rendimento/100)*3.5f;
            }else{
                return (rendimento/100)*5;
            }
        }

        /*
        public bool ValidarDataNascimento(DateTime dataNasc) //check > or < 18 years old
        {
            DateTime dataAtual = DateTime.Today;
            double anos = (dataAtual - dataNasc).TotalDays /365;
            Console.WriteLine($"Data atual: {dataAtual} \nAnos: {anos}");
            
            if(anos >= 18){
                return true;
            }else{
                return false;
            }
        }*/

        public bool ValidarDataNascimento(string dataNasc) //check > or < 18 years old
        {
            DateTime dataConvertida;
            if(DateTime.TryParse(dataNasc, out dataConvertida))
            {
                //Console.WriteLine($"{dataConvertida}");
                DateTime dataAtual = DateTime.Today;
                double anos = (dataAtual - dataConvertida).TotalDays /365;
                Console.WriteLine($"Data atual: {dataAtual} \nAnos: {anos}");
                if(anos >= 18){
                    return true;
                }else{
                    return false;
                }  
            }
            return false;            
        }

        public void Inserir(PessoaFisica pf)
        {
            VerificarPastaArquivo(caminho);

            string[] pfString = {$"{pf.nome},{pf.cpf},{pf.dataNascimento}"};
            File.AppendAllLines(caminho, pfString);
        }

        public List<PessoaFisica> Ler()
        {
            List<PessoaFisica> listaPf = new List<PessoaFisica>();

            string[] linhas = File.ReadAllLines(caminho);
            foreach(string cadalinha in linhas)
            {
                string[] atributos = cadalinha.Split(',');

                PessoaFisica cadaPf = new PessoaFisica();
                cadaPf.nome = atributos[0];
                cadaPf.cpf = atributos[1];
                cadaPf.dataNascimento = atributos[2];

                listaPf.Add(cadaPf);
            }
            return listaPf;
        }
    }
}