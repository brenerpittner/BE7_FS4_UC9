namespace BE7_FS4_UC9.Classes
{
    public class Endereco
    {
        public string ?Logradouro { get; set; }
        public int numero { get; set; }
        public string ?complemento { get; set; }
        public bool endComercial { get; set; }

        //public string ImprimirEndereco(){
        //    Console.WriteLine($"Logadouro: {this.Logradouro} \nNumero: {this.numero} \nComplemento: {this.complemento} \nEndComercial: {this.endComercial}");    
        //}

    }
}