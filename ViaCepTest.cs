using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;


namespace AutomacaoBackend_RestSharp
{  

    public class CepResponse
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }
        public string ddd { get; set; }
        public string siafi { get; set; }
    }

    [TestFixture, Category("Consultar CEP")]
    public class ViaCepTest
    {
        CepResponse bodyRequest = new CepResponse();

        [TestCase(TestName = "Consultar CEP - Sucesso")]
        public void ConsultarCEP()
        {
            //Arrange - Os pré requisitos do teste    
            string cep = "01001000";

            //Act - De fato vamos fazer nosso teste
            RestClient client = new RestClient($"https://viacep.com.br/ws/{cep}/json/");

            RestRequest request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);

            //Assert - Onde fazemos as nossas validações
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
