using System.Collections.Generic;

namespace DocumentsApi.Models
{
    public class DocumentCategory
    {
        public long DocumentId { get; set; }
        public Document Document { get; set; }

        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}