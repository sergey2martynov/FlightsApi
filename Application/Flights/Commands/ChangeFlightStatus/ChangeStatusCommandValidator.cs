using FluentValidation;

namespace Application.Flights.Commands.ChangeFlightStatus
{
    public class ChangeStatusCommandValidator : AbstractValidator<ChangeStatusCommand>
    {
        public ChangeStatusCommandValidator()
        {
            RuleFor(f => f.Status).IsInEnum().WithMessage("Invalid status value.");
        }
    }
}
