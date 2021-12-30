using Application.DTO;
using Application.FirstLevelIconSections;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FirstLevelIconSectionsController : BaseApiController
    {
        [HttpGet]
        [Route("{id}")]
        public async Task<FirstLevelIconSectionDto> GetFirstLevelIconSection(int id)
        {
            return await Mediator.Send(new GetFirstLevelIconSection.Query(id));
        }

        [HttpPost]
        public async Task AddFirstLevelIconSection(FirstLevelIconSectionDto section)
        {
            await Mediator.Send(new CreateFirstLevelIconSection.Command(section));
        }
    }
}
