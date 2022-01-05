using Application.DTO;
using Application.FirstLevelImageSections;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO.UpdateEntity;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FirstLevelImageSectionsController : BaseApiController
    {
        [HttpPost("AddFirstLevelImageSection")]
        public async Task AddFirstLevelImageSection(FirstLevelImageSectionDto section)
        {
            await Mediator.Send(new CreateFirstLevelImageSection.Command(section));
        }

        [HttpDelete("DeleteFirstLevelImageSection")]
        public async Task DeleteFirstLevelImageSection(int id)
        {
            await Mediator.Send(new DeleteFirstLevelImageSection.Command(id));
        }

        [HttpGet("GetAllFirstLevelImageSection")]
        public async Task<List<FirstLevelImageSectionDto>> GetAllFirstLevelImageSection()
        {
            return await Mediator.Send(new GetAllFirstLevelImageSection.Query());
        }

        [HttpGet("GetFirstLevelImageSection/{id:int}")]
        public async Task<FirstLevelImageSectionDto> GetFirstLevelImageSection(int id)
        {
            return await Mediator.Send(new GetFirstLevelImageSection.Query(id));
        }

        [HttpPut("UpdateFirstLevelImageSection")]
        public async Task UpdateFirstLevelImageSection(UpdateFirstLevelImageSectionDto section)
        {
            await Mediator.Send(new UpdateFirstLevelImageSection.Command(section));
        }
    }
}
