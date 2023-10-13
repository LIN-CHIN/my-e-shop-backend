using EShopAPI.Common;
using EShopAPI.Cores.Auth.JWTs;
using EShopCores.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EShopAPI.Filters
{
    /// <summary>
    /// 加入該Filter就必須登入才能使用api(也就是要有Token)
    /// </summary>
    public class RequiredLoginFilter : IAuthorizationFilter
    {
        private readonly IJwtService _jwtService;
        private readonly LoginUserData _loginUserData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="jwtService"></param>
        /// <param name="loginUserData"></param>
        public RequiredLoginFilter(IJwtService jwtService, LoginUserData loginUserData)
        {
            _jwtService = jwtService;
            _loginUserData = loginUserData;
        }

        /// <inheritdoc/>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string? token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrWhiteSpace(token)) 
            {
                context.Result = new ObjectResult(
                    GenericResponse<string>.GetResult(ResponseCodeType. TokenIsNullOrEmpty, "Token不可為null或空白"))
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };

                return;
            }

            JwtPayload jwtPayload = _jwtService.DecryptToken(token!);
            jwtPayload.SetLoginUserData(_loginUserData);
        }
    }
}
