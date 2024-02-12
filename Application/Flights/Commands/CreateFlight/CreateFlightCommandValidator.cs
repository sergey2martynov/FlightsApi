using FluentValidation;

namespace Application.Flights.Commands.CreateFlight
{
    public class CreateFlightCommandValidator : AbstractValidator<CreateFlightCommand>
    {
        public CreateFlightCommandValidator() 
        {
            RuleFor(v => v.Origin).MaximumLength(256).NotEmpty();
            RuleFor(v => v.Destination).MaximumLength(256).NotEmpty();
            RuleFor(v => v.Departure).NotEmpty();
            RuleFor(v => v.Arrival).NotEmpty();
            RuleFor(v => v.Status).NotEmpty();
        }
    }
}
