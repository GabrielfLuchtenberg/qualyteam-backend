using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentsApi.Models;

namespace DocumentsApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public DocumentController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Document>> GetDocuments()
        {
            return _context.Documents.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Document> GetDocument(long id)
        {
            var document = _context.Documents.Find(id);

            if (document == null)
            {
                return NotFound();
            }

            return document;
        }

        [HttpPost]
        public IActionResult PostDocument([FromBody] Document document)
        {
            _context.Documents.Add(document);
            // document.DocumentCategories = document.DocumentCategories.Select(dc => new DocumentCategory() { DocumentId = document.Id, CategoryId = dc.CategoryId }).ToList();
            _context.SaveChanges();

            return CreatedAtAction("GetDocument", new { id = document.Id }, document);
        }
        [HttpPut]
        public IActionResult PutDocument(long id, [FromBody]Document document)
        {
            if (id != document.Id)
            {
                return BadRequest();
            }
            _context.Entry(document).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }
    }
}