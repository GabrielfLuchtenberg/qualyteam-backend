using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DocumentsApi.Models
{
    public class Document
    {
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Code { get; set; }

        [Required]
        public List<DocumentCategory> DocumentCategories { get; set; }
        [Required]
        public Department Department { get; set; }

    }
}