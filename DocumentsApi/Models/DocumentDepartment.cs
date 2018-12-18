using System.Collections.Generic;

namespace DocumentsApi.Models
{
    public class DocumentDepartment
    {
        public long DocumentId { get; set; }
        public Document Document { get; set; }

        public long DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}