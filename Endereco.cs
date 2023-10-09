namespace ConsultaCepAPI;

public record Endereco(
    string cep,
    string Logradouro,
    string Complemento,
    string Bairro,
    string Localidade,
    string UF 
);
