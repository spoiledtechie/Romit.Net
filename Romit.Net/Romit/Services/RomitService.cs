using System;

namespace Romit
{
    public abstract class RomitService
    {
        public string ApiKey { get; set; }

        protected RomitService(string apiKey)
        {
            ApiKey = apiKey;
        }

        protected RomitRequestOptions SetupRequestOptions(RomitRequestOptions requestOptions)
        {
            if (requestOptions == null) requestOptions = new RomitRequestOptions();

            if (!String.IsNullOrEmpty(ApiKey))
                requestOptions.ApiKey = ApiKey;

            return requestOptions;
        }
    }
}
