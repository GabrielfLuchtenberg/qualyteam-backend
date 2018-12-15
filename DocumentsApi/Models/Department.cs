using System.Collections.Generic;

namespace DocumentsApi.Models
{
    public class Department
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Document> Documents { get; set; }
    }
}