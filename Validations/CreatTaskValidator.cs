namespace Tasks_Api.Validations
{
    public sealed class CreatTaskValidator : AbstractValidator<CreatTaskRequest>
    {
        public CreatTaskValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .MaximumLength(500);
        }
    }
}
