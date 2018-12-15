using System.Collections.Generic;

namespace DocumentsApi.Models
{
    public class Document
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<DocumentCategory> DocumentCategories { get; set; }

        public Department Department { get; set; }

    }
}