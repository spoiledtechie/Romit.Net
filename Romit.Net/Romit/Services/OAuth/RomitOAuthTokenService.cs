namespace Romit
{
    public class RomitOAuthTokenService : RomitService
    {
        public RomitOAuthTokenService(string apiKey = null) : base(apiKey) { }
        public virtual RomitOauthToken Create(RomitOAuthTokenCreateOptions createOptions, RomitRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var url = this.ApplyAllParameters(createOptions, Urls.OAuthToken, false);

            var response = Requestor.PostStringBearer(url, requestOptions);

            return Mapper<RomitOauthToken>.MapFromJson(response);
        }
    }
}
