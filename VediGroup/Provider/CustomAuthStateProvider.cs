

using Core;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Principal;
using VediGroup.Services;

namespace VediGroup.Provider
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        public CustomAuthStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        } 
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorageService.GetAsync<Pages.Account.SecurityToken>(nameof(Pages.Account.SecurityToken));
            var identity = new ClaimsIdentity();
            if (token != null)
            {
                var dbUser = DataAccess.GetUser(token.Username, token.Password);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Country, "Russia"),
                    new Claim(ClaimTypes.Name, token.Username),
                    new Claim(ClaimTypes.Role, dbUser?.Role?.Name ?? "None"),
                };

                identity = new ClaimsIdentity(claims, "Token");
            }


            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }
        public void Logout()
        {
            _localStorageService.RemoveAsync(nameof(Pages.Account.SecurityToken));
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(state));
        }
    }
}
