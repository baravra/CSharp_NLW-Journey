using FluentValidation;
using Journey.Communication.Requests;
using Journey.Exception;

namespace Journey.Application.UseCases.Trips.Register
{
    public class RegisterTripValidator : AbstractValidator<RequestRegisterTripJson> // qual classe validar
    {
        // validador

        public RegisterTripValidator()
        {
            // Criando regra para a propriedade name do request
            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage(ResourceErrorMessages.NAME_EMPTY);

            RuleFor(request => request.StartDate.Date)
                .GreaterThanOrEqualTo(DateTime.Now.Date)
                .WithMessage(ResourceErrorMessages.DATE_TRIP_MUST_BE_LATER_THAN_TODAY);

            // compara dois atributos => must
            RuleFor(request => request)
                .Must(request => request.EndDate.Date > request.StartDate.Date) // comparação que retorna vdd 
                .WithMessage(ResourceErrorMessages.END_DATE_TRIP_MUST_BE_LATER_START_DATE);

        }

    }
}
