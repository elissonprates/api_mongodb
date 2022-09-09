using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dominio;

public abstract class Entidade
{ 
    public Entidade()
    {
        identificador_loja = ObjectId.GenerateNewId();
        identificador_nuvem = Guid.NewGuid();
    }

    [BsonId]
    public ObjectId identificador_loja { get; set; }
    public Guid identificador_nuvem { get; set; }

}
