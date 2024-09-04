using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;
using MicroMultiBusiness.DTOLayer.IdentityDTOs.LoginDTOs;
using MicroMultiBusiness.WebUI.Services.Abstract;
using MicroMultiBusiness.WebUI.Settings;
using Microsoft.Extensions.Options;

namespace MicroMultiBusiness.WebUI.Services.Concrete
{
    public class ClientCredentialTokenService : IClientCredentialTokenService
    {
        private readonly ServiceAPISettings _serviceAPISettings;
        private readonly HttpClient _httpClient;
        private readonly IClientAccessTokenCache _clientAccessTokenCache;
        private readonly ClientSettings _clientSettings;

        public ClientCredentialTokenService(IOptions<ServiceAPISettings> serviceAPISettings, HttpClient httpClient, IClientAccessTokenCache clientAccessTokenCache, IOptions<ClientSettings> clientSettings)
        {
            _serviceAPISettings = serviceAPISettings.Value;
            _httpClient = httpClient;
            _clientAccessTokenCache = clientAccessTokenCache;
            _clientSettings = clientSettings.Value;
        }

        public async Task<string> GetToken()
        {
            var currentToken = await _clientAccessTokenCache.GetAsync("MicroMultiBusinessToken");
            if (currentToken != null) 
            { 
                return currentToken.AccessToken;
            }

            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync( new DiscoveryDocumentRequest
            {
                Address = _serviceAPISettings.IdentityServerURL,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }
            });

            var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _clientSettings.MicroMultiBusinessVisitorClient.ClientId,
                ClientSecret = _clientSettings.MicroMultiBusinessVisitorClient.ClientSecret,
                Address = discoveryEndPoint.TokenEndpoint
            };

            var newToken = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);

            await _clientAccessTokenCache.SetAsync("MicroMultiBusinessToken", newToken.AccessToken, newToken.ExpiresIn);

            return newToken.AccessToken;
        }
    }
}
