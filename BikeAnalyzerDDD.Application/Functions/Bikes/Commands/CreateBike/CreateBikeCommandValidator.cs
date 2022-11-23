using BikeAnalyzerDDD.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BikeAnalyzerDDD.Application.Functions.Bikes.Commands.CreateBike
{
    public class CreateBikeCommandValidator : AbstractValidator<CreateBikeCommand>
    {
        private readonly IBikeRepository _bikeRepository;

        public CreateBikeCommandValidator(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;

            RuleFor(p => p).
                MustAsync(IsBrandAndModelAlreadyExist)
                .WithMessage("This model bike already exist");

            RuleFor(p => p.Brand)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(80)
                .WithMessage("{PropertyName} must not exceed 80 characters");
            RuleFor(p => p.Model)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(80)
                .WithMessage("{PropertyName} must not exceed 80 characters");
            RuleFor(p => p.YearOfProduction)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull();
            RuleFor(p => p.HeadTubeAngle)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .InclusiveBetween(65, 70)
                .WithMessage("{PropertyName} is beetween 65 to 70");
            RuleFor(p => p.SeatTubeEffectiveAngle)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .InclusiveBetween(70, 80)
                .WithMessage("{PropertyName} is beetween 70 to 80");
            RuleFor(p => p.TravelFrontWheel)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .InclusiveBetween(100, 120)
                .WithMessage("{PropertyName} is beetween 100 to 120");
            RuleFor(p => p.TravelBackWheel)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .InclusiveBetween(100, 120)
                .WithMessage("{PropertyName} is beetween 100 to 120");
            RuleFor(p => p.InnerRimWidth)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .InclusiveBetween(20, 30)
                .WithMessage("{PropertyName} is beetween 20 to 30");
            RuleFor(p => p.TireWidth)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .InclusiveBetween(2, 2.4)
                .WithMessage("{PropertyName} is beetween 2 to 2.4");
            RuleFor(p => p.Weigth)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .InclusiveBetween(9, 14)
                .WithMessage("{PropertyName} is beetween 9 to 14");
        }

        private async Task<bool> IsBrandAndModelAlreadyExist(CreateBikeCommand e, CancellationToken cancellationToken)
        {
            var check = await _bikeRepository.IsModelAndBrandAlreadyExist(e.Brand, e.Model);

            return !check;
        }
    }
}