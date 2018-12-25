using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DocumentsApi.Models;
using DocumentsApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DocumentsApi.Exceptions;


namespace DocumentsApi.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly DatabaseContext _context;

        public DocumentService(DatabaseContext context){
            _context = context;
        }

        public IEnumerable<Document> GetAllItems()
        {
            return _context.
                        Documents
                        .OrderBy(d => d.Title)
                        .Include(d => d.Category)
                        .Include(d => d.DocumentDepartments)
                            .ThenInclude(dc => dc.Department);
        }

        public Document GetById(long id)
        {
            var document = _context.Documents.Single(d => d.Id == id);
            _context.Entry(document)
                .Collection(d => d.DocumentDepartments)
                .Load();
            
            return document;
        }

        public Document Save(Document document)
        {

            int documentCodeCount = _context.Documents.Count( d => d.Code == document.Code);
            if(documentCodeCount > 0){ 
                throw new NotUniqueKeyException("Código já cadastrado.");
             }
            _context.Documents.Add(document);
            _context.SaveChanges();
        return document;
        }

        public Document Update(long id, Document document){
            int documentCodeCount = _context.Documents.Where(d => d.Id != document.Id).Count( d => d.Code == document.Code);
            if(documentCodeCount > 0){
                throw new NotUniqueKeyException("Código já cadastrado");
            }
            if (id != document.Id)
            {
                return document;
            }
            _context.Entry(document).State = EntityState.Modified;
            _context.SaveChanges();

            return document;
        }
    }
}