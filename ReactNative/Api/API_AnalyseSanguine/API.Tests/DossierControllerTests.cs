using API_AnalyseSanguine.Controllers;
using API_AnalyseSanguine.Dtos;
using API_AnalyseSanguine.Models;
using API_AnalyseSanguine.Services;
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
    public class DossierControllerTests
    {
        private Mock<IDossierService> _service;
        private Fixture _fixture;
        private DossierController _controller;

        public DossierControllerTests()
        {
            _fixture= new Fixture();
            _service = new Mock<IDossierService>();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [TestMethod]
        public async Task GetDossierDetaille()
        {
            var dossier = _fixture.Create<DossierDetailleDto>();

            _service.Setup(repo => repo.GetDossierDetaille(dossier.IdDossier)).Returns(dossier);

            _controller = new DossierController(_service.Object);

            var result = await _controller.GetDossierDetaille(dossier.IdDossier);

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task GetDossierSimple()
        {
            var dossierList = _fixture.CreateMany<DossierSimpleDto>(3).ToList();

            _service.Setup(repo => repo.GetDossierSimple()).Returns(dossierList);

            _controller = new DossierController(_service.Object);

            var result = await _controller.GetDossierSimple();

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task CreateDossier()
        {
            var employee = _fixture.Create<Dossier>();

            _service.Setup(repo => repo.CreateDossier(It.IsAny<Dossier>())).Returns(employee);

            _controller = new DossierController(_service.Object);

            var result = await _controller.CreateDossier(employee);

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task UpdateDossier()
        {
            var employee = _fixture.Create<Dossier>();

            _service.Setup(repo => repo.UpdateDossier(employee.IdDossier, It.IsAny<Dossier>())).Returns(employee);

            _controller = new DossierController(_service.Object);

            var result = await _controller.UpdateDossier(employee.IdDossier, employee);

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task DeleteDossier()
        {
            _service.Setup(repo => repo.DeleteDossier(It.IsAny<long>())).Returns(true);

            _controller = new DossierController(_service.Object);

            var result = await _controller.DeleteDossier(It.IsAny<long>());

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }
    }
}
