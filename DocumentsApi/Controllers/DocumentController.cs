using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentsApi.Models;
using DocumentsApi.Services;

public class DocumentForm
{
    public Document document { get; set; }
    
}

namespace DocumentsApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {

        private readonly IDocumentService _service; 

        public DocumentController(IDocumentService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Document>> GetDocuments()
        {
            return  Ok(_service.GetAllItems().ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Document> GetDocument(long id)
        {
            Document document = _service.GetById(id);
            if (document == null)
            {
                return NotFound();
            }
            return Ok(document);
        }

        [HttpPost]
        public IActionResult PostDocument([FromBody] DocumentForm documentPost)
        {
            Document document = documentPost.document;
            _service.Save(document);
            return CreatedAtAction("GetDocument", new { id = document.Id }, document);
        }
        [HttpPut("{id}")]
        public IActionResult PutDocument(long id, [FromBody]DocumentForm documentPost)
        {
            Document newDocument = documentPost.document;
            Document document = _service.Update(id,newDocument);
            return Ok(document);
        }
    }
}