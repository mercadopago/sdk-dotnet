using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace Mercadopago.Exceptions
{
    [Serializable]
	public class MPException : Exception
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
			string reqIdStr = string.Empty;
			if (!string.IsNullOrEmpty(RequestId))
				reqIdStr = "; request-id: " + RequestId;

            string statCodeStr = string.Empty;
			if (StatusCode.HasValue)
				statCodeStr = "; status_code: " + StatusCode.Value;

			return base.ToString() + reqIdStr + statCodeStr;
		}

        #region ISerializable Members

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("RequestId", RequestId);
            info.AddValue("StatusCode", StatusCode);
        }

        #endregion
    }
}
