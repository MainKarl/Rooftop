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
    public class ResultatControllerTests
    {
        private Mock<IResultatService> _service;
        private Fixture _fixture;
        private ResultatController _controller;

        public ResultatControllerTests()
        {
            _fixture = new Fixture();
            _service = new Mock<IResultatService>();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [TestMethod]
        public async Task GetResultat()
        {
            var resultat = _fixture.Create<ResultatAnalyse>();

            _service.Setup(repo => repo.GetResultat(resultat.IdResultatAnalyse)).Returns(resultat);

            _controller = new ResultatController(_service.Object);

            var result = await _controller.GetResultat(resultat.IdResultatAnalyse);

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task GetAllResultat()
        {
            var resultatList = _fixture.CreateMany<ResultatAnalyse>(3).ToList();

            _service.Setup(repo => repo.GetAllResultat()).Returns(resultatList);

            _controller = new ResultatController(_service.Object);

            var result = await _controller.GetAllResultat();

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task CreateResultat()
        {
            var resultat = _fixture.Create<ResultatAnalyse>();

            _service.Setup(repo => repo.CreateResultat(It.IsAny<ResultatAnalyse>())).Returns(resultat);

            _controller = new ResultatController(_service.Object);

            var result = await _controller.CreateResultat(resultat);

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task UpdateResultat()
        {
            var resultat = _fixture.Create<ResultatAnalyse>();

            _service.Setup(repo => repo.UpdateResultat(resultat.IdResultatAnalyse, It.IsAny<ResultatAnalyse>())).Returns(resultat);

            _controller = new ResultatController(_service.Object);

            var result = await _controller.UpdateResultat(resultat.IdResultatAnalyse, resultat);

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task DeleteResultat()
        {
            _service.Setup(repo => repo.DeleteResultat(It.IsAny<int>())).Returns(true);

            _controller = new ResultatController(_service.Object);

            var result = await _controller.DeleteResultat(It.IsAny<int>());

            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }
    }
}
