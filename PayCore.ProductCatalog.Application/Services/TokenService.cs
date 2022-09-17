using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PayCore.ProductCatalog.Application.Interfaces;
using PayCore.ProductCatalog.Domain.Entities;
using PayCore.ProductCatalog.Domain.Jwt;
using PayCore.ProductCatalog.Domain.Token;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Application
{

    public class TokenService : ITokenService
    {
        protected readonly IAccountRepository accountRepository;
        private readonly JwtConfig jwtConfig;

        public TokenService(IOptionsMonitor<JwtConfig> jwtConfig, IAccountRepository accountRepository)
        {
            this.jwtConfig = jwtConfig.CurrentValue;
            this.accountRepository = accountRepository;
           
        }

        public async Task<TokenResponse> GenerateToken(TokenRequest tokenRequest)
        {
            if (tokenRequest is null)
            {
                throw new CredentialException("Please validate your informations that you provided");
            }

            var accounts = await accountRepository.GetAll(x => x.UserName.Equals(tokenRequest.UserName));
            var account = accounts.FirstOrDefault();
            if (account is null)
            {
                throw new CredentialException("Please validate your informations that you provided");
            }

            if (!account.Password.Equals(tokenRequest.Password))
            {
                throw new CredentialException("Please validate your informations that you provided");
            }

            DateTime now = DateTime.UtcNow;
            string token = GetToken(account, now);

            account.LastActivity = now;

            await accountRepository.Update(account);

            TokenResponse tokenResponse = new TokenResponse
            {
                AccessToken = token,
                ExpireTime = now.AddMinutes(jwtConfig.AccessTokenExpiration),
                Role = account.Role,
                UserName = account.UserName,
                SessionTimeInSecond = jwtConfig.AccessTokenExpiration * 60
            };

            return tokenResponse;
        }
        private string GetToken(Account account, DateTime date)
        {
            Claim[] claims = GetClaims(account);
            byte[] secret = Encoding.ASCII.GetBytes(jwtConfig.Secret);

            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);

            var jwtToken = new JwtSecurityToken(
                jwtConfig.Issuer,
                shouldAddAudienceClaim ? jwtConfig.Audience : string.Empty,
                claims,
                expires: date.AddMinutes(jwtConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return accessToken;
        }

        private Claim[] GetClaims(Account account)
        {
            var claims = new[]
         {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.UserName),
                new Claim(ClaimTypes.Role, account.Role),
                new Claim("AccountId", account.Id.ToString()),
                new Claim("Email",account.Email)
            };
            return claims;
        }
    }
}
