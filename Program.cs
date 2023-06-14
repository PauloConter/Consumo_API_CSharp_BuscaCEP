using System.Text;
using System;
using viaCepApi;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Digite o CEP para consulta:");
        var cep = Console.ReadLine();
        var endereco = ConsultaCEP.BuscarCEPAsync(cep).Result;

        Console.WriteLine(
            endereco is null ? "CEP não encontrado" : $"""             
                                Logradouro: {endereco.Logradouro},
                                Bairro: {endereco.Bairro},
                                Cidade: {endereco.Localidade},
                                Estado: {endereco.UF}                                
                                """
        );




    }
}
