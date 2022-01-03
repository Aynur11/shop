using Application.DTO;
using Application.FirstLevelImageSections;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FirstLevelImageSectionController : BaseApiController
    {
        [HttpGet]
        [Route("{id}")]
        public async Task<FirstLevelImageSectionDto> GetFirstLevelImageSection(int id)
        {
            return await Mediator.Send(new GetFirstLevelImageSection.Query(id));
        }

        [HttpPost]
        public async Task AddFirstLevelImageSection(FirstLevelImageSectionDto section)
        {
            await Mediator.Send(new CreateFirstLevelImageSection.Command(section));
        }

    }
}
