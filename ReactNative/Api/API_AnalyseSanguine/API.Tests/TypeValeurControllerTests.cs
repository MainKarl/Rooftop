using API_AnalyseSanguine.Controllers;
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
    public class TypeValeurControllerTests
    {
        private Mock<ITypeValeurService> _service;
        private Fixture _fixture;
        private TypeValeurController _controller;

        public TypeValeurControllerTests()
        {
            _fixture = new Fixture();
            _service = new Mock<ITypeValeurService>();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [TestMethod]
        public async Task GetAllTypeValeur()
        {
            var types = _fixture.CreateMany<TypeValeur>(3).ToList();

            _service.Setup(repo => repo.GetAllTypeValeur()).Returns(types);

            _controller = new TypeValeurController(_service.Object);

            var result = await _controller.GetAllTypeValeur();

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task GetTypeValeur()
        {
            var type = _fixture.Create<TypeValeur>();

            _service.Setup(repo => repo.GetTypeValeur(type.IdTypeValeur)).Returns(type);

            _controller = new TypeValeurController(_service.Object);

            var result = await _controller.GetTypeValeur(type.IdTypeValeur);

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task CreateTypeValeur()
        {
            var type = _fixture.Create<TypeValeur>();

            _service.Setup(repo => repo.CreateTypeValeur(It.IsAny<TypeValeur>())).Returns(type);

            _controller = new TypeValeurController(_service.Object);

            var result = await _controller.CreateTypeValeur(type);

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }
    }
}
