using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DocumentsApi.Controllers;
using DocumentsApi.Services;
using DocumentsApi.Models;
using DocumentsApi.Tests.Services;

namespace DocumentsApi.Tests
{
    public class DocumentControllerTest
    {
        DocumentController _controller;
        IDocumentService _service;

        public DocumentControllerTest()
        {
            _service = new DocumentServiceFake();
            _controller = new DocumentController(_service);
        }

        [Fact]
        public void Get_Whencalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetDocuments();

            //Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetDocuments().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<Document>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }
        [Fact]
        public void GetById_UnknownId_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetDocument(10);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistinId_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetDocument(1);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Act
            var okResult = _controller.GetDocument(1).Result as OkObjectResult;

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

                Category = category1,
                DocumentDepartments = new List<DocumentDepartment>(){
                    new DocumentDepartment(){Department = department1}
                }
            };
            _controller.ModelState.AddModelError("Code", "Required");

            // Act
            var badResponse = _controller.Post(testItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Category category1 = new Category(){ Id = 1, Name = "Procedimentos operacionais" };
            Department department1 = new Department(){ Id = 1, Name = "Desenvolvimento" };

            Document testItem = new Document()
            {
                Id = 1,
                Title = "Document 4",
                Code = "123456789a",
                Category = category1,
                DocumentDepartments = new List<DocumentDepartment>(){
                    new DocumentDepartment(){Department = department1}
                }
            };

            // Act
            var createdResponse = _controller.PostDocument(testItem);

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
                Category = category1,
                DocumentDepartments = new List<DocumentDepartment>(){
                    new DocumentDepartment(){Department = department1}
                }
            };

            // Act
            var createdResponse = _controller.Post(testItem) as CreatedAtActionResult;
            var item = createdResponse.Value as Document;

            // Assert
            Assert.IsType<Document>(item);
            Assert.Equal("Guinness Original 6 Pack", item.Name);
        }
    }
}
