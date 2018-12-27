using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DocumentsApi.Controllers;
using DocumentsApi.Services;
using DocumentsApi.Models;
using DocumentsApi.Tests.Services;
using DocumentsApi.Exceptions;


namespace DocumentsApi.Tests
{

    
    public class DocumentControllerTest
    {
        DocumentController _controller;
        IDocumentService _service;
        private readonly  List<Category> _categories;

        private readonly List<Department> _departments;
    
        public DocumentControllerTest()
        {
            _service = new DocumentServiceFake();
            _controller = new DocumentController(_service);

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
        }

        [Fact]
        public void Get_Whencalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            //Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<Document>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }
        [Fact]
        public void GetById_UnknownId_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get(10);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistinId_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get(1);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Act
            var okResult = _controller.Get(1).Result as OkObjectResult;

            // Assert
            Assert.IsType<Document>(okResult.Value);
            Assert.Equal(1, (okResult.Value as Document).Id);
        }


        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            Document testItem = new Document()
            {
                Id = 1,
                Title = "Document 4",

                Category = _categories.Find(c => c.Id == 1),
                DocumentDepartments = new List<DocumentDepartment>(){
                    new DocumentDepartment(){Department = _departments.Find(d => d.Id == 1)}
                }
            };
            _controller.ModelState.AddModelError("Code", "Required");

            // Act
            IActionResult badResponse = _controller.Post(new DocumentForm(){ document = testItem });

            // Assert
            Assert.IsType<BadRequestResult>(badResponse);
        }


        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
           
            Document testItem = new Document()
            {
                Id = 1,
                Title = "Document 4",
                Code = "123456789a",
                Category = _categories.Find(c => c.Id == 1),
                DocumentDepartments = new List<DocumentDepartment>(){
                    new DocumentDepartment(){Department = _departments.Find(d => d.Id == 1)}
                }
            };

            // Act            
            IActionResult createdResponse = _controller.Post(new DocumentForm(){ document = testItem });

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }


        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            Document testItem = new Document()
            {
                Id = 1,
                Title = "Document 4",
                Code = "123456789a",
                Category = _categories.Find(c => c.Id == 1),
                DocumentDepartments = new List<DocumentDepartment>(){
                    new DocumentDepartment(){Department =  _departments.Find(d => d.Id == 1)}
                }
            };

            // Act
            CreatedAtActionResult createdResponse =  _controller.Post(new DocumentForm(){ document = testItem }) as CreatedAtActionResult;
            Document item = createdResponse.Value as Document;

            // Assert
            Assert.IsType<Document>(item);
            Assert.Equal("Document 4", item.Title);
        }

         [Fact]
        public void Add_ValidObjectWithDuplicatedCode_ReturnsBadRequest()
        {
            // Arrange
            Document testItem = new Document()
            {
                Id = 1,
                Title = "Document 4",
                Code = "123",
                Category = _categories.Find(c => c.Id == 2),
                DocumentDepartments = new List<DocumentDepartment>(){
                    new DocumentDepartment(){Department =  _departments.Find(d => d.Id == 3)}
                }
            };

            Assert.Throws<NotUniqueKeyException>(() => _controller.Post(new DocumentForm(){ document = testItem }));
        }
    }
}
