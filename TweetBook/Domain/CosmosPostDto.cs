using Cosmonaut.Attributes;
using Newtonsoft.Json;

namespace TweetBook.Domain
{
    [CosmosCollection("posts")]
    public class CosmosPostDto
    {
        [CosmosPartitionKey]
        [JsonProperty("id")]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
