using BikeAnalyzerDDD.Application.Functions.Bikes.Commands.CreateBike;
using BikeAnalyzerDDD.Application.Functions.Bikes.Commands.DeleteBike;
using BikeAnalyzerDDD.Application.Functions.Bikes.Commands.UpdateBike;
using BikeAnalyzerDDD.Application.Functions.Bikes.Queries.GetBikeDetail;
using BikeAnalyzerDDD.Application.Functions.Bikes.Queries.GetBikesLists;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeAnalyzerDDD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BikeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllBikes")]
        public async Task<ActionResult<List<BikeInListViewModel>>> GetAllBikes()
        {
            var list = await _mediator.Send(new GetBikesListQuery());
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetBikeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BikeDetailViewModel>> GetBikeById(int id)
        {
            var detailViewModel = await _mediator.Send
                (new GetBikeDetailQuery() { Id = id });
            return Ok(detailViewModel);
        }

        [HttpPost(Name = "AddBike")]
        public async Task<ActionResult<int>> Create([FromBody] CreateBikeCommand createBikeCommand)
        {
            var result = await _mediator.Send(createBikeCommand);
            return Ok(result.Id);
        }

        [HttpPut(Name = "UpdateBike")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateBikeCommand updateBikeCommand)
        {
            await _mediator.Send(updateBikeCommand);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteBike")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteBikeCommand = new DeleteBikeCommand() { Id = id };
            await _mediator.Send(deleteBikeCommand);
            return NoContent();
        }
    }
}