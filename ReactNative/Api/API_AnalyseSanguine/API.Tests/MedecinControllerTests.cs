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
    public class MedecinControllerTests
    {
        private Mock<IMedecinService> _service;
        private Fixture _fixture;
        private MedecinController _controller;

        public MedecinControllerTests()
        {
            _fixture = new Fixture();
            _service = new Mock<IMedecinService>();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [TestMethod]
        public async Task GetMedecin()
        {
            var medecin = _fixture.Create<Medecin>();

            _service.Setup(repo => repo.GetMedecin(medecin.IdMedecin)).Returns(medecin);

            _controller = new MedecinController(_service.Object);

            var result = await _controller.GetMedecin(medecin.IdMedecin);

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task GetAllMedecin()
        {
            var medecinList = _fixture.CreateMany<Medecin>(3).ToList();

            _service.Setup(repo => repo.GetAllMedecin()).Returns(medecinList);

            _controller = new MedecinController(_service.Object);

            var result = await _controller.GetAllMedecin();

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task CreateMedecin()
        {
            var medecin = _fixture.Create<Medecin>();

            _service.Setup(repo => repo.CreateMedecin(It.IsAny<Medecin>())).Returns(medecin);

            _controller = new MedecinController(_service.Object);

            var result = await _controller.CreateMedecin(medecin);

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task UpdateMedecin()
        {
            var medecin = _fixture.Create<Medecin>();

            _service.Setup(repo => repo.UpdateMedecin(medecin.IdMedecin, It.IsAny<Medecin>())).Returns(medecin);

            _controller = new MedecinController(_service.Object);

            var result = await _controller.UpdateMedecin(medecin.IdMedecin, medecin);

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task DeleteMedecin()
        {
            _service.Setup(repo => repo.DeleteMedecin(It.IsAny<int>())).Returns(true);

            _controller = new MedecinController(_service.Object);

            var result = await _controller.DeleteMedecin(It.IsAny<int>());

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }
    }
}
