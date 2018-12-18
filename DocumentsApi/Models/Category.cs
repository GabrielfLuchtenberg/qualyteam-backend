using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace DocumentsApi.Models
{
    public class Category
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Document> Documents { get; set; }
    }
}