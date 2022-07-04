 using BE7_FS4_UC9.Interfaces;

namespace BE7_FS4_UC9.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string ?cpf { get; set; }
        public string ?dataNascimento { get; set; }
        

        public override float PagarImposto(float rendimento)
        {
            throw new NotImplementedException();
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
            
        }
        */

        public bool ValidarDataNascimento(string dataNasc) //check > or < 18 years old
        {
            DateTime dataConvertida;
            if(DateTime.TryParse(dataNasc, out dataConvertida)){
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
    }
}