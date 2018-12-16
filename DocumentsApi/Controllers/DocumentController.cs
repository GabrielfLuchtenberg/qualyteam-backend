using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentsApi.Models;


public class DocumentPostModel
{
    public Document document { get; set; }
    public long DepartmentId {get;set;}

    public List<long> categoryIds {get;set;}
}

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
            return _context.
                        Documents
                        .Include(d => d.Department)
                        .Include(d => d.DocumentCategories)
                            .ThenInclude(dc => dc.Category)
                        .ToList();
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
        public IActionResult PostDocument([FromBody] DocumentPostModel DocumentPost)
        {
            Document document = DocumentPost.document;
            System.Console.Clear();
            foreach(long categoryId in DocumentPost.categoryIds){
                DocumentCategory docCategory = new DocumentCategory{CategoryId= categoryId};
                document.DocumentCategories.Add( docCategory);
            }
            document.Department = _context.Departments.Find( DocumentPost.DepartmentId);
            _context.Documents.Add(document);
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