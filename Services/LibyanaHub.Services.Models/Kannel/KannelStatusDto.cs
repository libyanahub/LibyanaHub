using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Models.Kannel
{
	public class KannelStatusDto
	{
		public string Version { get; set; }
		public string Hostname { get; set; }
		public string IP { get; set; }
		public string Status { get; set; }
		public string Uptime { get; set; }

		public SmsStatDto Sms { get; set; }
		public List<SmscConnectionDto> SmscConnections { get; set; }
	}

	public class SmsStatDto
	{
		public int Received { get; set; }
		public int Sent { get; set; }
		public string InboundRate { get; set; }
		public string OutboundRate { get; set; }
	}

	public class SmscConnectionDto
	{
		public string Name { get; set; }
		public string SmscId { get; set; }      // Extracted ID: e.g., "cma"
		public string Host { get; set; }
		public string Status { get; set; }
		public int Received { get; set; }
		public int Sent { get; set; }
		public int Failed { get; set; }
		public int Queued { get; set; }
		public string Direction { get; set; }
	}
}
