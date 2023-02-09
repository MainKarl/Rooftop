using API_AnalyseSanguine.Context.Data;
using API_AnalyseSanguine.Dtos;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_AnalyseSanguine.Tests.Controllers
{
    public class DossierControllerTests
    {
        private readonly ApplicationDbContext _context;

        public DossierControllerTests()
        {
            _context = A.Fake<ApplicationDbContext>();
        }

        [Fact]
        public void DossierController_Create()
        {
            //Arange
            var dossier = A.Fake<ICollection<DossierSimpleDto>>();
            var dossierList = A.Fake<List<DossierSimpleDto>>();
                
            //Act

            //Assert
        }
    }
}
