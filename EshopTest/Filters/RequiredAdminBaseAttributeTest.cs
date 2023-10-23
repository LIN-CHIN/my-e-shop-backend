using EShopAPI.Common;
using EShopAPI.Cores.Auth.JWTs;
using EShopAPI.Filters.RequiredAdminFilters;
using Jose;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopTest.Filters
{
    /// <summary>
    /// 測試 必須有Admin權限的 Base Filter
    /// </summary>
    [TestFixture]
    public class RequiredAdminBaseAttributeTest
    {
        private Mock<IJwtService> _mockJwtService;
        private RequiredAdminBaseAttribute _requiredAdminBaseAttribute;

        private static readonly object[] _isNotAdminCases =
        {
            new object[] 
            {
                new JwtPayload
                {
                    UserId = 1,
                    IsAdmin = false
                }
            },
            new object[]
            {
                new JwtPayload
                {
                    UserId = 2,
                    IsAdmin = false
                }
            },
            new object[]
            {
                new JwtPayload
                {
                    UserId = 3,
                    IsAdmin = false
                }
            }
        };
        private static readonly object[] _adminCases = {
            new object[]
            {
                new JwtPayload
                {
                    UserId = 1,
                    IsAdmin = true
                }
            },
            new object[]
            {
                new JwtPayload
                {
                    UserId = 2,
                    IsAdmin = true
                }
            },
            new object[]
            {
                new JwtPayload
                {
                    UserId = 3,
                    IsAdmin = true
                }
            }
        };

        /// <summary>
        /// Setup 
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _mockJwtService = new Mock<IJwtService>(MockBehavior.Strict);
            _requiredAdminBaseAttribute = new RequiredAdminBaseAttribute(_mockJwtService.Object, new LoginUserData());
        }

        /// <summary>
        /// 測試Token為空時失敗
        /// </summary>
        [Test]
        public void TestAccessTokenIsEmpty() 
        {
            AuthorizationFilterContext fakeAuthFilterContext = GetFakeAuthorizationFilterContext(string.Empty);

            _requiredAdminBaseAttribute.OnAuthorization(fakeAuthFilterContext);
            ObjectResult? result = fakeAuthFilterContext.Result as ObjectResult;

            Assert.That(result!.StatusCode, Is.EqualTo(401) );
        }

        /// <summary>
        /// 測試Token Decode 失敗
        /// </summary>
        [Test]
        public void TestAccessTokenDecodeError()
        {
            AuthorizationFilterContext fakeAuthFilterContext = GetFakeAuthorizationFilterContext("fakeToken");
            _mockJwtService.Setup(x => x.DecryptToken(It.IsAny<string>()))
                .Throws(new IntegrityException(""));

            _requiredAdminBaseAttribute.OnAuthorization(fakeAuthFilterContext);
            ObjectResult? result = fakeAuthFilterContext.Result as ObjectResult;

            Assert.That(result!.StatusCode, Is.EqualTo(401));
        }

        /// <summary>
        /// 測試登入者非管理員
        /// </summary>
        [TestCaseSource(nameof(_isNotAdminCases))]
        public void TestIsNotAdmin(JwtPayload jwtPayload)
        {
            AuthorizationFilterContext fakeAuthFilterContext = GetFakeAuthorizationFilterContext("fakeToken");
            _mockJwtService.Setup(x => x.DecryptToken(It.IsAny<string>()))
               .Returns(jwtPayload);

            _requiredAdminBaseAttribute.OnAuthorization(fakeAuthFilterContext);
            ObjectResult? result = fakeAuthFilterContext.Result as ObjectResult;

            Assert.That(result!.StatusCode, Is.EqualTo(403));
        }

        /// <summary>
        /// 測試登入者為管理員
        /// </summary>
        [TestCaseSource(nameof(_adminCases))]
        public void TestAdminCases(JwtPayload jwtPayload)
        {
            AuthorizationFilterContext fakeAuthFilterContext = GetFakeAuthorizationFilterContext("fakeToken");
            _mockJwtService.Setup(x => x.DecryptToken(It.IsAny<string>()))
               .Returns(jwtPayload);

            _requiredAdminBaseAttribute.OnAuthorization(fakeAuthFilterContext);
            ObjectResult? result = fakeAuthFilterContext.Result as ObjectResult;

            Assert.That(result, Is.Null);
        }

        /// <summary>
        /// 取得假的 AuthorizationFilterContext
        /// </summary>
        /// <param name="mockHttpContext"></param>
        /// <param name="token">預期帶入Header Authorization 的token值</param>
        /// <returns></returns>
        private static AuthorizationFilterContext GetFakeAuthorizationFilterContext(string token)
        {
            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext
              .Setup(x => x.Request.Headers["Authorization"])
              .Returns(token);

            ActionContext fakeActionContext = new ActionContext(
                    mockHttpContext.Object,
                    new Microsoft.AspNetCore.Routing.RouteData(),
                    new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());

            return new AuthorizationFilterContext(
                fakeActionContext,
                new List<IFilterMetadata>());
        }
    }
}
