using FluentValidation;
using WildlifePoaching.API.Helpers;
using WildlifePoaching.API.Models.DTOs.Animal;

namespace WildlifePoaching.API.Models.Validators.Animals
{
    public class CreateAnimalDtoValidator : AbstractValidator<CreateAnimalDto>
    {
        public CreateAnimalDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Price)
                .GreaterThan(0);

            RuleFor(x => x.LocationId)
                .GreaterThan(0);

            RuleFor(x => x.AnimalTypeId)
                .GreaterThan(0);

            RuleFor(x => x.PrimaryImage)
                .Must(ValidationHelper.IsValidImageFile)
                .When(x => x.PrimaryImage != null)
                .WithMessage("Invalid primary image file");

            RuleForEach(x => x.AdditionalImages)
                .Must(ValidationHelper.IsValidImageFile)
                .When(x => x.AdditionalImages != null)
                .WithMessage("Invalid additional image file");
        }
    }
}
