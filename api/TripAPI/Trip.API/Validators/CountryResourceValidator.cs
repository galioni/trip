using FluentValidation;
using Trip.API.Resources;

namespace Trip.API.Validators
{
	public class CountryResourceValidator : AbstractValidator<CountryResource>
	{
		public CountryResourceValidator()
		{
			RuleFor(a => a.Code)
				.NotEmpty()
				.NotNull()
				.MaximumLength(3);

			RuleFor(a => a.Name)
				.NotEmpty()
				.NotNull()
				.MaximumLength(80);
		}
	}
}
