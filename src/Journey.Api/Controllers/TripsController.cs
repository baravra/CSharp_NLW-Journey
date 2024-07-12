using Journey.Application.UseCases.Activities.Complete;
using Journey.Application.UseCases.Activities.Delete;
using Journey.Application.UseCases.Activities.Register;
using Journey.Application.UseCases.Trips.Delete;
using Journey.Application.UseCases.Trips.GetAll;
using Journey.Application.UseCases.Trips.GetById;
using Journey.Application.UseCases.Trips.Register;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Journey.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {

        [HttpPost] // recebe um post
        [ProducesResponseType(typeof(ResponseShortTripJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register( [FromBody] RequestRegisterTripJson request) // FromBody -> ler do obj do body da requisicao
        {
            var useCase = new RegisterTripUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
            // retornando status 201 (created)
            // 400 -> bad request
            // 200 -> sucesso
            // 201 -> created

        }



        [HttpGet]
        [ProducesResponseType(typeof(ResponseTripsJson), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var useCase = new GetAllTripsUseCase();
            var result = useCase.Execute();
            
            return Ok(result);
        }



        // nao pode ter dois ou mais => coloca uma rota específica
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseTripJson), StatusCodes.Status200OK) ] // melhorar documentação => resposta do método sucesso
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound) ]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var useCase = new GetTripByIdUseCase();

            var response = useCase.Execute(id);

            return Ok(response);
        }



        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent) ] // melhorar documentação => resposta do método sucesso
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound) ]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var useCase = new DeleteTripByIdUseCase();

            useCase.Execute(id);

            return NoContent(); // nao tem corpo de resposta
        }



        [HttpPost]
        [Route("{tripId}/activity")]
        [ProducesResponseType(typeof(ResponseActivityJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult RegisterActivity(
            [FromRoute]Guid tripId,
            [FromBody] RequestRegisterActivityJson request)
        {
            var useCase = new RegisterActivityForTripUseCase();

            var response = useCase.Execute(tripId, request);

            return Created(string.Empty, response);
        }



        [HttpPut]
        [Route("{tripId}/activity/{activityId}/complete")]
        [ProducesResponseType(typeof(ResponseActivityJson), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult CompleteActivity(
            [FromRoute] Guid tripId,
            [FromRoute] Guid activityId)
        {
            var useCase = new CompleteActivityForTripUseCase();

            useCase.Execute(tripId, activityId);

            return NoContent();
        }


        [HttpDelete]
        [Route("{tripId}/activity/{activityId}")]
        [ProducesResponseType(typeof(ResponseActivityJson), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult DeleteActivity(
            [FromRoute] Guid tripId,
            [FromRoute] Guid activityId)
        {
            var useCase = new DeleteActivityForTripUseCase();

            useCase.Execute(tripId, activityId);

            return NoContent();
        }


    }
}
