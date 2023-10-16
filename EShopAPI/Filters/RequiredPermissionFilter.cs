using EShopAPI.Common;
using EShopAPI.Cores.Auth.JWTs;
using EShopCores.Responses;
using Jose;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EShopAPI.Filters
{
    /// <summary>
    /// 加入該Filter就必須登入且有權限才能使用功能
    /// </summary>
    public class RequiredPermissionFilter : IAuthorizationFilter
    {
        private readonly IJwtService _jwtService;
        private readonly LoginUserData _loginUserData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="jwtService"></param>
        /// <param name="loginUserData"></param>
        public RequiredPermissionFilter(IJwtService jwtService, LoginUserData loginUserData)
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

            JwtPayload jwtPayload;
            try
            {
                jwtPayload  = _jwtService.DecryptToken(token!);
               

            }
            catch (IntegrityException integrityException) 
            {
                context.Result = new ObjectResult(
                    GenericResponse<string>.GetResult(ResponseCodeType.InvalidToken,
                    $"Token decode Error. exception:{integrityException}"))
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };

                return;
            }

            _loginUserData.SetLoginUserData(jwtPayload);
        }
    }
}
