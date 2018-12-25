using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DocumentsApi.Models
{
    public class DocumentDepartment
    {
        [Required]
        public long DocumentId { get; set; }
        public Document Document { get; set; }
        [Required]
        public long DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}