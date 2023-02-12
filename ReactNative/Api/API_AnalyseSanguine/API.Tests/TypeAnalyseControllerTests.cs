using API_AnalyseSanguine.Controllers;
using API_AnalyseSanguine.Dtos;
using API_AnalyseSanguine.Models;
using API_AnalyseSanguine.Services.Interfaces;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Tests
{
    [TestClass]
    public class TypeAnalyseControllerTests
    {
        private Mock<ITypeAnalyseService> _service;
        private Fixture _fixture;
        private TypeAnalyseController _controller;

        public TypeAnalyseControllerTests()
        {
            _fixture = new Fixture();
            _service = new Mock<ITypeAnalyseService>();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [TestMethod]
        public async Task GetAllCategoriesAndTypeAnalyse()
        {
            var types = _fixture.CreateMany<Category>(3).ToList();

            _service.Setup(repo => repo.GetAllCategoriesAndTypeAnalyse()).Returns(types);

            _controller = new TypeAnalyseController(_service.Object);

            var result = await _controller.GetAllCategoriesAndTypeAnalyse();

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task GetAllTypeAnalyse()
        {
            var resultatList = _fixture.CreateMany<TypeAnalyse>(3).ToList();

            _service.Setup(repo => repo.GetAllTypeAnalyse()).Returns(resultatList);

            _controller = new TypeAnalyseController(_service.Object);

            var result = await _controller.GetAllTypeAnalyse();

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task GetTypeAnalyse()
        {
            var type = _fixture.Create<TypeAnalyse>();

            _service.Setup(repo => repo.GetTypeAnalyse(type.IdTypeAnalyse)).Returns(type);

            _controller = new TypeAnalyseController(_service.Object);

            var result = await _controller.GetTypeAnalyse(type.IdTypeAnalyse);

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task CreateTypeAnalyse()
        {
            var type = _fixture.Create<TypeAnalyse>();

            _service.Setup(repo => repo.CreateTypeAnalyse(It.IsAny<TypeAnalyse>())).Returns(type);

            _controller = new TypeAnalyseController(_service.Object);

            var result = await _controller.CreateTypeAnalyse(type);

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }
    }
}
