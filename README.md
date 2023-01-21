System.ArgumentOutOfRangeException: IDX10653: The encryption algorithm 'System.String' requires a key size of at least 'System.Int32' bits. Key 'Microsoft.IdentityModel.Tokens.SymmetricSecurityKey', is of size: 'System.Int32'. (Parameter 'key')
   at Microsoft.IdentityModel.Tokens.SymmetricSignatureProvider..ctor(SecurityKey key, String algorithm, Boolean willCreateSignatures)
   at Microsoft.IdentityModel.Tokens.CryptoProviderFactory.CreateSignatureProvider(SecurityKey key, String algorithm, Boolean willCreateSignatures, Boolean cacheProvider)
   at Microsoft.IdentityModel.Tokens.CryptoProviderFactory.CreateForSigning(SecurityKey key, String algorithm, Boolean cacheProvider)
   at Microsoft.IdentityModel.Tokens.CryptoProviderFactory.CreateForSigning(SecurityKey key, String algorithm)
   at Microsoft.IdentityModel.JsonWebTokens.JwtTokenUtilities.CreateEncodedSignature(String input, SigningCredentials signingCredentials)
   at System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler.WriteToken(SecurityToken token)
   at ParksApi.Controllers.TokenController.Post(UserInfo _userData) in /Users/Holcomb/Desktop/C#/ParksApi/Controllers/TokenController.cs:line 53
   at Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor.TaskOfIActionResultExecutor.Execute(IActionResultTypeMapper mapper, ObjectMethodExecutor executor, Object controller, Object[] arguments)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeActionMethodAsync>g__Awaited|12_0(ControllerActionInvoker invoker, ValueTask`1 actionResultValueTask)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeNextActionFilterAsync>g__Awaited|10_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Rethrow(ActionExecutedContextSealed context)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeInnerFilterAsync>g__Awaited|13_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeFilterPipelineAsync>g__Awaited|20_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
   at Microsoft.AspNetCore.Routing.EndpointMiddleware.<Invoke>g__AwaitRequestTask|6_0(Endpoint endpoint, Task requestTask, ILogger logger)
   at Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.Authentication.AuthenticationMiddleware.Invoke(HttpContext context)
   at Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIMiddleware.Invoke(HttpContext httpContext)
   at Swashbuckle.AspNetCore.Swagger.SwaggerMiddleware.Invoke(HttpContext httpContext, ISwaggerProvider swaggerProvider)
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(HttpContext context)

HEADERS
=======
Accept: */*
Connection: keep-alive
Host: localhost:5001
User-Agent: Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36
Accept-Encoding: gzip, deflate, br
Accept-Language: en-US,en;q=0.9,la;q=0.8
Content-Type: application/json
Cookie: .AspNetCore.Antiforgery.4U1v_TLZ-_E=CfDJ8KMlFfWTNwJIspi8rOeTQsYLy73G3EUbjq8v1R3DXEQXL08flRJrPWbHbHMCYyKzNOwlEn1NbZImWSBs49P7JiLJjZkcDvWu5Z-uHJALqHYQJnPeKevCDlFmX6igAUT5-942G-YQG3tKE-vLA8etUH4; .AspNetCore.Antiforgery.7aDDzmi7cAg=CfDJ8KMlFfWTNwJIspi8rOeTQsaajQ1DV9NXlY4whTin4ezUOxFm3h1uljbu0lIGAJx_cl-ZETefHpwIAwQpdoQNs4FPX_b7HwUDn8eBip9NEAYZ01vK89z4O47aJS9i3CkutSO2wAG8gUA8X3W17m691p0; .AspNetCore.Identity.Application=CfDJ8KMlFfWTNwJIspi8rOeTQsYRc9A6zWcbtY6IvaZK8AieAox7q00yFZSEyHyRSJZrVz9MfDgOx9V59n6fLM80kNjPU-rstFHSZP32-QA9VoTZCL4cgLeQpWyuGfDspbvzVSzCg-t6grrh84_zxTZykewMFqGcemb_5vKeMyurtmcFmtQ-CpkTgi-Hpbp6bNFyzvhSriFVDSm1T-KxeNPRgeScW9YAKeIG2rvReWOEl2h4YIiweEGz5yBxjaQ4q4iGKzauS3m-TlC0bAKVNOzuUI204-fLv_l3P8i_PhTtplVt2_4dql19ZfYdC5k-ACXGGhk47YUoWU5dzWPwW3Lwp0fv2B7weZFAkFpRrU5yL60sZ1va-vwFHh6q5cQkUQ3LDyLSdf0sMAVpV1-V48Trz9h-2DdDE_abzz8J9zl3s9SWOtC4H45Dyv6uJd4gj1fr1pPOu8av_a-LyaTJ4GKPuMMYDn7T-zpl5yzvJ1P4f8yd801YVdXoTrI_4dC67tICJ1yC9PID-JOuBViEd94hDs7WqVKWJ-hlk1kx1zeK_gGr7FbQCma0h_M2gd7kHpqHzP6q4xqptbMgv1O-0o25XuJa3OmzUfVvF8lfmP1OzHhiE6EJWJqfLpP-z87OVpW09A; .AspNetCore.Antiforgery.DCipDdEpRgE=CfDJ8KMlFfWTNwJIspi8rOeTQsaKFXzoGkjj0ZnLqRZVy56roH1Ix6O_rxuxbGxXaA-Cq85b-n7POZqgEvmpLHg39374KVH_IwDaIile2Ov_9a4E7gXQhWdKBDEqjSwCAGuoG1CEPEm7o24jcZb7VnN-WI0
Origin: https://localhost:5001
Referer: https://localhost:5001/swagger/index.html
Content-Length: 56
sec-ch-ua: "Not_A Brand";v="99", "Google Chrome";v="109", "Chromium";v="109"
sec-ch-ua-mobile: ?0
sec-ch-ua-platform: "macOS"
Sec-Fetch-Site: same-origin
Sec-Fetch-Mode: cors
Sec-Fetch-Dest: empty

using ParksApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace HomeController.Controllers
{
    public class HomeController : Controller
    {
        
    }
}