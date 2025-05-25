using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Domain.StaticData
{
	public static class SD
	{
		public static class Schema
		{
			public const string EsmeCheckers = "esmecheckerschema";
		}



		public static class Roles
		{
			public const string Admin = "Admin";
			public const string Employee = "Employee";
			public const string Commercial = "Commercial";
			public const string Coach = "Coach";
			public const string Trainee = "Trainee";
		}

		public static class EmailProvider
		{
			public const string Gmail = "gmail";
			public const string Outlook = "outlook";
		}

		public static class Kannel_SD
		{
			public const string ConnectionType_Transmitter = "Transmitter";
			public const string ConnectionType_Receiver = "Receiver";
			public const string ConnectionType_Transceiver = "Transceiver";


			public const string ConnectionStatus_Online = "online";
			public const string ConnectionStatus_Re_Connecting = "re-connecting";
		}
	}
}

