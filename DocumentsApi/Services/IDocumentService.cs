using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DocumentsApi.Models;

namespace DocumentsApi.Services
{
    public interface IDocumentService
    {
         IEnumerable<Document> GetAllItems();

        Document GetById(long id);

        Document Save(Document document);
        Document Update(long id, Document document);

    }
}