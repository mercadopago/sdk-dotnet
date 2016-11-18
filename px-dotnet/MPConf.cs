using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace px_dotnet
{
	public class MPConf
	{
		private const String DEFAULT_BASE_URL = "https://api.mercadopago.com";

		private static String clientSecret = null;
		private static String clientId = null;
		private static String accessToken = null;
		private static String appId = null;
		private static String baseUrl = DEFAULT_BASE_URL;

		/// <summary>  
		///  Getter/Setter for ClientSecret 
		/// </summary>  
		public static string GetClientSecret()
		{
			return clientSecret;
		}
	}

}
