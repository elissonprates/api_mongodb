using dominio;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;

namespace repositorio;

public class RepositorioDeEquipamento : IRepositorioDeEquipamento
{
    private readonly IMongoCollection<Equipamento> _equipamentos;
    private IMongoDatabase _database;

    public RepositorioDeEquipamento(IDatabaseConfig databaseConfig)
    {
        var client = new MongoClient(databaseConfig.ConnectionString);
        _database = client.GetDatabase(databaseConfig.DatabaseName);
    }

    public async Task<Equipamento> Obter(int? codigo)
    {

        var _equipamentos = _database.GetCollection<Equipamento>($"equipamentos_{codigo}");

        var equipamento = _equipamentos.Find(filter => filter.codigo == codigo).FirstOrDefault();
        return equipamento;
    }

    public async Task Salvar(int? codigo, string nome)
    {
        var _equipamentos = _database.GetCollection<Equipamento>($"equipamentos_{codigo}");

        

        var equipamento = new Equipamento {codigo = codigo, nome = nome };

        _equipamentos.InsertOne(equipamento);
    }
}
