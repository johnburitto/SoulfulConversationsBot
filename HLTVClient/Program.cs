// See https://aka.ms/new-console-template for more information
using HLTVClient.Client;

var client = new HLTVRequestClient("https://www.hltv.org");

await client.GetTopAsync();
