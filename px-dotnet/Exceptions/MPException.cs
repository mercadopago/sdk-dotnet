using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace px_dotnet.Exceptions
{
	class MPException : Exception
	{
		public string RequestId { get; private set; }
		public int? StatusCode { get; private set; }

		public MPException(string message) : base(message) {
		}

		public MPException(string message, Exception innerException) : base(message, innerException) {
		}

		public MPException(string message, string requestId, int? statusCode) : base(message) {
			RequestId = requestId;
			StatusCode = statusCode;
		}

		public MPException(String message, String requestId, int statusCode, Exception innerException)
					: base(message, innerException){
			RequestId = requestId;
			StatusCode = statusCode;
		}

		public override string ToString() {
			string reqIdStr = "";
			if (string.IsNullOrEmpty(RequestId))
				reqIdStr = "; request-id: " + RequestId;
			string statCodeStr = "";
			if (StatusCode.HasValue)
				statCodeStr = "; status_code: " + StatusCode.Value;
			return base.ToString() + reqIdStr + statCodeStr;
		}
	}
}
