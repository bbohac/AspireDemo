using FluentValidation;

namespace AspireDemo.Api.Api.Weather;

public sealed class ForecastRequestValidator : AbstractValidator<ForecastRequestDto>
{
    public ForecastRequestValidator() => RuleFor(x => x.Days).GreaterThan(0).LessThanOrEqualTo(14);
}
