namespace BlazorCli.Client.Commands.Sample
{
  using FluentValidation;

  internal class SampleValidator : AbstractValidator<SampleRequest>
  {
    public SampleValidator()
    {
      RuleFor(aSetVersionRequest => aSetVersionRequest.Parameter1).MinimumLength(3);
      RuleFor(aSetVersionRequest => aSetVersionRequest.Parameter2).GreaterThanOrEqualTo(0);
      RuleFor(aSetVersionRequest => aSetVersionRequest.Parameter3).LessThanOrEqualTo(10);
      RuleFor(aSampleRequest => aSampleRequest)
        .Must(ValidateParameter3GreaterthanParameter2)
        .WithMessage("Parameter3 must be greater than Parameter2");
    }

    private bool ValidateParameter3GreaterthanParameter2(SampleRequest aSampleRequest) =>
      (aSampleRequest.Parameter3 > aSampleRequest.Parameter2);
  }
}