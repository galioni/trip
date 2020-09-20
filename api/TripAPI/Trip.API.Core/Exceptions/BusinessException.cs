using System;

namespace Trip.API.Core.Exceptions
{
	public class BusinessException : Exception
	{
		public string HandledErrorMessage { get; private set; }
		public BusinessErrorCodes ErrorCode { get; private set; }

		public BusinessException(string errorMessage, BusinessErrorCodes errorCode)
		{
			ErrorCode = errorCode;
			HandledErrorMessage = errorMessage;
		}
	}
}
