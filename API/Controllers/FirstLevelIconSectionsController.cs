using System.Collections.Generic;
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
        [HttpPost("AddFirstLevelIconSection")]
        public async Task AddFirstLevelIconSection(FirstLevelIconSectionDto section)
        {
            await Mediator.Send(new CreateFirstLevelIconSection.Command(section));
        }

        [HttpDelete("DeleteFirstLevelIconSection")]
        public async Task DeleteFirstLevelIconSection(int id)
        {
            await Mediator.Send(new DeleteFirstLevelIconSection.Command(id));
        }

        [HttpGet("GetAllFirstLevelIconSection")]
        public async Task<List<FirstLevelIconSectionDto>> GetAllFirstLevelIconSection()
        {
            return await Mediator.Send(new GetAllFirstLevelIconSections.Query());
        }

        [HttpGet("GetFirstLevelIconSection/{id}")]
        public async Task<FirstLevelIconSectionDto> GetFirstLevelIconSection(int id)
        {
            return await Mediator.Send(new GetFirstLevelIconSection.Query(id));
        }

        [HttpPut("UpdateFirstLevelIconSection")]
        public async Task UpdateFirstLevelIconSection(FirstLevelIconSectionDto section)
        {
            await Mediator.Send(new UpdateFirstLevelIconSection.Command(section));
        }
    }
}
