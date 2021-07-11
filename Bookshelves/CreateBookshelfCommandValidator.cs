using FluentValidation;

namespace BookshelfManager.Bookshelves
{
    public class CreateBookshelfCommandValidator : AbstractValidator<CreateBookshelfCommand>
    {
        public CreateBookshelfCommandValidator()
        {
            RuleFor(c => c.Books)
                .NotEmpty();

            RuleForEach(c => c.Books)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(250);
        }
    }
}
