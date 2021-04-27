using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using projeto_api_dotnet_mongodb.Data.Collections;
using projeto_api_dotnet_mongodb.Data;
using projeto_api_dotnet_mongodb.Models;

namespace projeto_api_dotnet_mongodb.Controllers
{
    [ApiController] //Notação
    [Route("[controller]")] //Rota considerando o nome da Controller
    public class InfectadoController: ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;
        
        public InfectadoController(Data.MongoDB mongoDB)
        {
            //Injetado MongoDb
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost] //Endpoint POST
        public ActionResult SalvarInfectado([FromBody] InfectadoDTO dto)
        {
            var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

            _infectadosCollection.InsertOne(infectado);

            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpGet] //Endpoint 
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();

            return Ok(infectados);
        }

        //Ponto de melhora - estudar UPDATE/REPLACE/DELETE e implementar.
    }
}