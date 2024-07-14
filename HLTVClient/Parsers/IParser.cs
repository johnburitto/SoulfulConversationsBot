using HLTVClient.Client;

namespace HLTVClient.Parsers
{
    public interface IParser<T>
    {
        T ParseAsync(HLTVRequestClient client, string? page);
    }
}
