using DocumentsApi.Models;
using DocumentsApi.Services;
using System.Collections.Generic;
using DocumentsApi.Exceptions;
using System.Linq;

using System;
namespace DocumentsApi.Tests.Services
{
    public class DocumentServiceFake : IDocumentService
    {
        private readonly List<Document> _documents;

        private readonly  List<Category> _categories;

        private readonly List<Department> _departments;
    
        public DocumentServiceFake()
        {
            _categories = new List<Category>(){
                 new Category(){ Id = 1, Name = "Procedimentos operacionais" },
                 new Category(){ Id = 2, Name = "Procedimentos operacionais" },
                 new Category(){ Id = 3, Name = "Planejamento de processo" }
            };

            _departments = new List<Department>(){
                 new Department() { Id = 1, Name = "Desenvolvimento" },
                 new Department() { Id = 2, Name = "Comercial" },
                 new Department() { Id = 3, Name = "Suporte" }
            };

            _documents = new List<Document>(){
                new Document() {
                     Id = 1,
                     Title= "Document 1",
                     Code = "123",
                     Category = _categories.Find(c => c.Id == 1),
                     DocumentDepartments = new List<DocumentDepartment>(){
                             new DocumentDepartment(){Department = _departments.Find(d => d.Id == 1)}
                         }
                },
                new Document() {
                     Id = 2,
                     Title= "Document 2",
                     Code = "321",
                     Category = _categories.Find(c => c.Id == 2 ),
                     DocumentDepartments = new List<DocumentDepartment>(){
                        new DocumentDepartment(){Department = _departments.Find(d => d.Id == 1)},
                        new DocumentDepartment(){Department = _departments.Find(d => d.Id == 2)}
                    }
                },
                new Document() {
                     Id = 3,
                     Title= "Document 3",
                     Code = "3214",
                     Category = _categories.Find(c => c.Id == 3 ),
                     DocumentDepartments = new List<DocumentDepartment>(){
                        new DocumentDepartment(){Department = _departments.Find(d => d.Id == 1)},
                        new DocumentDepartment(){Department = _departments.Find(d => d.Id == 3)}
                    }
                },
            };
        }
        public IEnumerable<Document> GetAllItems()
        {
            return _documents;

        }

        public Document GetById(long id)
        {
            return _documents.Find(d => d.Id == id);
        }

        public Document Save(Document document)
        {
            document.Id = 4;
            bool documentCodeCount = _documents.Any(d => {
                return d.Id != document.Id && d.Code == document.Code;
            });
            if(documentCodeCount){
                throw new NotUniqueKeyException("Código já cadastrado");
            }
            _documents.Add(document);
            return document;
        }

        public Document Update(long id, Document document)
        {
            throw new NotImplementedException();
        }
    }
}