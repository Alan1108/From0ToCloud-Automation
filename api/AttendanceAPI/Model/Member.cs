using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace AttendanceAPI.Model
{
    [BsonIgnoreExtraElements]
    public class Member
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("NOMBRES")]
        public string Name { get; set; }
        [BsonElement("APELLIDOS")]
        public string LastName { get; set; }
        [BsonElement("CÉDULA")]
        public int Identification { get; set; }
        [BsonElement("ID")]
        public string Idespe { get; set; }
        [BsonElement("CARRERA")]
        public string Career { get; set; }
        [BsonElement("NIVEL")]
        public string Level { get; set; }
        [BsonElement("N° CELULAR")]
        public int Phone { get; set; }
        [BsonElement("CORREO INSTITUCIONAL")]
        public string Email { get; set; }
        


    }
}
