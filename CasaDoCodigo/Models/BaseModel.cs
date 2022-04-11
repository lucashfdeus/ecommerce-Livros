using System.Runtime.Serialization;

namespace CasaDoCodigo.Models
{
    public class BaseModel
    {
        [DataMember]
        public int Id { get; protected set; }
    }
}
