using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DocumentsApi.Models
{
    public class Category
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public ICollection<DocumentCategory> DocumentCategories { get; set; }
    }
}