using LibyanaHub.Services.Domain.Models.Kannel;
using System.Text.RegularExpressions;
using LibyanaHub.Services.Domain.StaticData;


namespace LibyanaHub.Services.Application.Helper
{
	public class KannelHelper
	{
		public static KannelStatusDto MappingKannelStatus(string statusContent)
		{
			var lines = statusContent.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

			var status = new KannelStatusDto
			{
				SmscConnections = new List<SmscConnectionDto>()
			};

			foreach (var line in lines)
			{
				if (line.StartsWith("Kannel bearerbox version"))
				{
					var versionMatch = Regex.Match(line, @"version `([^`]+)'");
					if (versionMatch.Success)
						status.Version = versionMatch.Groups[1].Value;
				}

				if (line.Contains("Hostname"))
				{
					var hostnameMatch = Regex.Match(line, @"Hostname (\S+), IP (\S+)");
					if (hostnameMatch.Success)
					{
						status.Hostname = hostnameMatch.Groups[1].Value;
						status.IP = hostnameMatch.Groups[2].Value;
					}
				}

				if (line.StartsWith("Status:"))
				{
					var parts = line.Split(", uptime ");
					status.Status = parts[0].Replace("Status:", "").Trim();
					status.Uptime = parts.Length > 1 ? parts[1].Trim() : "";
				}

				if (line.StartsWith("SMS: received"))
				{
					var match = Regex.Match(line, @"SMS: received (\d+).+sent (\d+).+");
					if (match.Success)
					{
						status.Sms = new SmsStatDto
						{
							Received = int.Parse(match.Groups[1].Value),
							Sent = int.Parse(match.Groups[2].Value)
						};
					}
				}

				if (line.StartsWith("SMS: inbound"))
				{
					var match = Regex.Match(line, @"inbound \(([^)]+)\).+outbound \(([^)]+)\)");
					if (match.Success && status.Sms != null)
					{
						status.Sms.InboundRate = match.Groups[1].Value;
						status.Sms.OutboundRate = match.Groups[2].Value;
					}
				}

				if (line.Trim().StartsWith("ivas_") || line.Contains("SMPP:"))
				{
					var smscMatch = Regex.Match(line, @"^\s*(\S+)\s+SMPP:([^\s:]+):(\d+)/(\d+):.*?(online|re-connecting).*?rcvd: sms (\d+).+sent: sms (\d+).+failed (\d+), queued (\d+) msgs");
					if (smscMatch.Success)
					{
						var port1 = smscMatch.Groups[3].Value;
						var port2 = smscMatch.Groups[4].Value;
						string direction = (port1, port2) switch
						{
							("0", _) => SD.Kannel_SD.ConnectionType_Receiver,
							(_, "0") => SD.Kannel_SD.ConnectionType_Transmitter,
							_ when port1 == port2 => SD.Kannel_SD.ConnectionType_Transceiver,
							_ => "Unknown"
						};

						var nameFull = smscMatch.Groups[1].Value;
						var smscId = nameFull.Contains("[") ? nameFull.Split('[')[0] : nameFull;

						status.SmscConnections.Add(new SmscConnectionDto
						{
							//Name = smscMatch.Groups[1].Value,
							Name = nameFull,
							SmscId = smscId,
							Host = smscMatch.Groups[2].Value,
							Status = smscMatch.Groups[5].Value,
							Received = int.Parse(smscMatch.Groups[6].Value),
							Sent = int.Parse(smscMatch.Groups[7].Value),
							Failed = int.Parse(smscMatch.Groups[8].Value),
							Queued = int.Parse(smscMatch.Groups[9].Value),
							Direction = direction
						});
					}

				}
			}

			return status;
		}
	}
}
