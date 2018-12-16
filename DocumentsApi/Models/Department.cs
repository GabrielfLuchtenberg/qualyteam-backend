using System.Collections.Generic;
using Newtonsoft.Json;
namespace DocumentsApi.Models
{
    public class Department
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Document> Documents { get; set; }
    }
}