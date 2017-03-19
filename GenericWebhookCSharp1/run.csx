#r "Newtonsoft.Json"

using System;
using System.Net;
using Newtonsoft.Json;

public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info($"Webhook was triggered!");

	var msg = await req.Content.ReadAsAsync<Data>();
	
	return req.CreateResponse(HttpStatusCode.OK, new {
		pong = msg.ping,		
	});
}

class Data
{	
	public string ping { get; set; }
}s