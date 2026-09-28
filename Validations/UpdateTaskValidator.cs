using FluentValidation;
using Tasks_Api.DTOs;

namespace Tasks_Api.Validators;

public class UpdateTaskValidator : AbstractValidator<UpdateTaskRequest>
{
    public UpdateTaskValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(500);
    }
}