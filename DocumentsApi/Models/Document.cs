using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DocumentsApi.Models
{
    public class Document
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string code { get; set; }

        public ICollection<DocumentCategory> DocumentCategories { get; set; }

        public Department Department { get; set; }

    }
}