using DocumentsApi.Models;
using DocumentsApi.Services;
using System.Collections.Generic;
using System;
namespace DocumentsApi.Tests.Services
{
    public class DocumentServiceFake : IDocumentService
    {
        private readonly List<Document> _documents;

        public DocumentServiceFake(){
            Category category1 = new Category(){ Id = 1, Name = "Procedimentos operacionais" };
            Category category2 = new Category(){ Id = 2, Name = "Procedimentos operacionais" };
            Category category3 = new Category(){ Id = 3, Name = "Planejamento de processo" };
            

            Department department1 = new Department(){ Id = 1, Name = "Desenvolvimento" };
            Department department2 = new Department(){ Id = 2, Name = "Comercial" };
            Department department3 = new Department(){ Id = 3, Name = "Suporte" };

            _documents = new List<Document>(){
                new Document() {
                     Id = 1, 
                     Title= "Document 1", 
                     Code = "123", 
                     Category = category1,
                     DocumentDepartments = new List<DocumentDepartment>(){
                             new DocumentDepartment(){Department = department1}
                         } 
                },
                new Document() {
                     Id = 2,
                     Title= "Document 2", 
                     Code = "321", 
                     Category = category2,
                     DocumentDepartments = new List<DocumentDepartment>(){
                        new DocumentDepartment(){Department = department1},
                        new DocumentDepartment(){Department = department2}
                    }
                },
                new Document() {
                     Id = 3,
                     Title= "Document 3",
                     Code = "3214",
                     Category = category3,
                     DocumentDepartments = new List<DocumentDepartment>(){
                        new DocumentDepartment(){Department = department1},
                        new DocumentDepartment(){Department = department3}
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
            _documents.Add(document);
            return document;
        }

        public Document Update(long id, Document document)
        {
            throw new NotImplementedException();
        }
    }
}