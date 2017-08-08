using MongoDB.Bson;
using System.Runtime.Serialization;

namespace Restful.Service.Entities
{
    public class Address
    {
        public string Country { get; set; }

        public string City { get; set; }
    }
}