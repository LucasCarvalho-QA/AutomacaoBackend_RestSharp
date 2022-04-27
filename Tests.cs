using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AutomacaoBackend_RestSharp
{
    public class UsuarioBodyPayload
    {
        public string name { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string status { get; set; }
    }

    [TestFixture, Category("Usuário")]
    public class Usuario
    {
        UsuarioBodyPayload bodyRequest = new UsuarioBodyPayload();
        string token = "4c97e60b3df0585dec6c0c67b40167544635f7e6e796ddadea302f2ff3ea2c44";

        [TestCase(TestName = "Criar usuário - Sucesso")]
        public void CriarUsuario_Sucesso()
        {
            //Arrange - Os pré requisitos do teste            
            bodyRequest.email = "chiquinho1@auditeste.com.br";
            bodyRequest.name = "Chiquinho QA";
            bodyRequest.status = "active";
            bodyRequest.gender = "male";

            //Act - De fato vamos fazer nosso teste
            RestClient client = new RestClient("https://gorest.co.in/public/v2/users");
            client.Authenticator = new JwtAuthenticator(token);

            RestRequest request = new RestRequest(Method.POST);
            request.AddJsonBody(bodyRequest);

            IRestResponse response = client.Execute(request);

            //Assert - Onde fazemos as nossas validações
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }
    }
}
