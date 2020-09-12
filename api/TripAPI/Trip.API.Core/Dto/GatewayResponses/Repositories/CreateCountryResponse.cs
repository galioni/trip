using System.Collections.Generic;

namespace Trip.API.Core.Dto.GatewayResponses.Repositories
{
	public sealed class CreateCountryResponse : BaseGatewayResponse
	{
		public int Id { get; }

		public CreateCountryResponse(int Id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
		{
			this.Id = Id;
		}
	}
}
