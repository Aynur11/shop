using Application.DTO;
using Application.DTO.UpdateEntity;
using Application.SecondLevelSections;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecondLevelSectionsController : BaseApiController
    {
        [HttpPost("AddSecondLevelSection")]
        public async Task AddSecondLevelSection(SecondLevelSectionDto section)
        {
            await Mediator.Send(new CreateSecondLevelSection.Command(section));
        }

        [HttpDelete("DeleteSecondLevelSection")]
        public async Task DeleteSecondLevelSection(int id)
        {
            await Mediator.Send(new DeleteSecondLevelSection.Command(id));
        }

        [HttpGet("GetAllSecondLevelSection")]
        public async Task<List<SecondLevelSectionDto>> GetAllSecondLevelSection()
        {
            return await Mediator.Send(new GetAllSecondLevelSection.Query());
        }

        [HttpGet("GetSecondLevelSection/{id:int}")]
        public async Task<SecondLevelSectionDto> GetSecondLevelSection(int id)
        {
            return await Mediator.Send(new GetSecondLevelSection.Query(id));
        }

        [HttpPut("UpdateSecondLevelSection")]
        public async Task UpdateSecondLevelSection(UpdateSecondLevelSectionDto section)
        {
            await Mediator.Send(new UpdateSecondLevelSection.Command(section));
        }
    }
}
