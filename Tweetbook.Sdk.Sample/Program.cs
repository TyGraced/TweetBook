using Refit;
using System.Threading.Tasks;
using TweetBook.Contracts.V1.Requests;

namespace TweetBook.Sdk.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cachedToken = string.Empty;

            var identityApi = RestService.For<IIdentityApi>("https://localhost:5001");
             var tweetbookApi = RestService.For<ITweetbookApi>("https://localhost:5001", new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });

            var registerResponse = await identityApi.RegisterAsync(new UserRegistrationRequest
            {
                Email = "sdkaccount@gmail.com",
                Password = "Tee1234!"
            });

            var loginResponse = await identityApi.LoginAsync(new UserLoginRequest
            {
                Email = "sdkaccount@gmail.com",
                Password = "Tee1234!"
            });

            cachedToken = loginResponse.Content.Token;

            var allPosts = await tweetbookApi.GetAllAsync();

            var createdPost = await tweetbookApi.CreateAsync(new CreatePostRequest
            {
                Name = "This is recreated by the SDK",
                Tags = new []{ "sdk" }
            });

            var retrievedPost = await tweetbookApi.GetAsync(createdPost.Content.Data.Id);

            var updatedPost = await tweetbookApi.UpdateAsync(createdPost.Content.Data.Id, new UpdatePostRequest
            {
                Name = "This is updated by the SDK"
            });

            var deletePost = await tweetbookApi.DeleteAsync(createdPost.Content.Data.Id);
        }
    }
}