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
    public class RequeteControllerTests
    {
        private Mock<IRequeteService> _service;
        private Fixture _fixture;
        private RequeteController _controller;

        public RequeteControllerTests()
        {
            _fixture = new Fixture();
            _service = new Mock<IRequeteService>();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [TestMethod]
        public async Task GetRequete()
        {
            var requete = _fixture.Create<RequeteAnalyse>();

            _service.Setup(repo => repo.GetRequete(requete.IdRequete)).Returns(requete);

            _controller = new RequeteController(_service.Object);

            var result = await _controller.GetRequete(requete.IdRequete);

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task GetAllRequete()
        {
            var requeteList = _fixture.CreateMany<RequeteAnalyse>(3).ToList();

            _service.Setup(repo => repo.GetAllRequete(It.IsAny<int>())).Returns(requeteList);

            _controller = new RequeteController(_service.Object);

            var result = await _controller.GetAllRequete(It.IsAny<int>());

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task CreateRequete()
        {
            var requeteDto = _fixture.Create<CreateRequeteDto>();

            var requete = new RequeteAnalyse()
            {
                CodeAcces = Guid.NewGuid(),
                DateEchantillon = DateTime.Now,
                DossierIdDossier = requeteDto.DossierIdDossier,
                MedecinIdMedecin = requeteDto.MedecinIdMedecin,
                NomTechnicien = requeteDto.NomTechnicien,
                AnalyseDemande = requeteDto.analyseDemande
            };

            _service.Setup(repo => repo.CreateRequete(It.IsAny<RequeteAnalyse>())).Returns(requete);

            _controller = new RequeteController(_service.Object);

            var result = await _controller.CreateRequete(requeteDto);

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task UpdateRequete()
        {
            var requete = _fixture.Create<RequeteAnalyse>();

            _service.Setup(repo => repo.UpdateRequete(requete.IdRequete, It.IsAny<RequeteAnalyse>())).Returns(requete);

            _controller = new RequeteController(_service.Object);

            var result = await _controller.UpdateRequete(requete.IdRequete, requete);

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task DeleteRequete()
        {
            _service.Setup(repo => repo.DeleteRequete(It.IsAny<int>())).Returns(true);

            _controller = new RequeteController(_service.Object);

            var result = await _controller.DeleteRequete(It.IsAny<int>());

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }
    }
}
