using FluentValidation;
using WildlifePoaching.API.Models.DTOs.Transactions;

namespace WildlifePoaching.API.Models.Validators.Transactions
{
    public class CreateTransactionDtoValidator : AbstractValidator<CreateTransactionDto>
    {
        public CreateTransactionDtoValidator()
        {
            RuleFor(x => x.AnimalId)
                .GreaterThan(0);

            RuleFor(x => x.UserId)
                .GreaterThan(0);

            RuleFor(x => x.Amount)
                .GreaterThan(0);

            RuleFor(x => x.TransactionType)
                .IsInEnum();
        }
    }
}
