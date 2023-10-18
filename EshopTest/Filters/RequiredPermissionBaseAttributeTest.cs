using EShopAPI.Common;
using EShopAPI.Common.Enums;
using EShopAPI.Cores.Auth.JWTs;
using EShopAPI.Cores.MapUserRoles.Services;
using EShopAPI.Filters.RequiredPermissionFilters;
using Jose;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Moq;
using EShopAPI.Cores.MapUserRoles;
using EShopAPI.Cores.ShopRoles;
using EShopAPI.Cores.MapRolePermissions;
using EShopAPI.Cores.ShopPermissions;

namespace EshopTest.Filters
{
    /// <summary>
    /// 測試 RequiredPermissionBaseAttribute
    /// </summary>
    [TestFixture]
    public class RequiredPermissionBaseAttributeTest
    {
        private Mock<IJwtService> _mockJwtService;
        private Mock<IMapUserRoleService> _mockMapUserRoleService;
        private RequiredPermissionBaseAttribute _requiredPermissionBaseAttribute;

        private static readonly object[] _permissionError =
        {
            new object[]
            {
                new JwtPayload
                {
                    UserId = 1,
                    IsAdmin = false,
                },
                new List<MapUserRole>
                {
                    new MapUserRole
                    {
                        UserId = 1,
                        RoleId = 1,
                        ShopRole = new ShopRole()
                        {
                            MapRolePermissions = new List<MapRolePermission>()
                            {
                                new MapRolePermission()
                                {
                                    RoleId = 1,
                                    PermissionId = (long)ShopPermissionType.CompositeProductDetail,
                                    IsCreatePermission = true,
                                    IsReadPermission = true,
                                    IsUpdatePermission = true,
                                    IsDeletePermission = true,
                                    ShopPermission = new ShopPermission()
                                    {
                                        Number = ShopPermissionType.CompositeProductDetail.ToString()
                                    }
                                }
                            }
                        }
                    }
                }
            },
            new object[]
            {
                new JwtPayload
                {
                    UserId = 2,
                    IsAdmin = false,
                },
                new List<MapUserRole>
                {
                    new MapUserRole
                    {
                        UserId = 2,
                        RoleId = 2,
                        ShopRole = new ShopRole()
                        {
                            MapRolePermissions = new List<MapRolePermission>()
                            {
                                new MapRolePermission()
                                {
                                    RoleId = 2,
                                    PermissionId = (long)ShopPermissionType.DeliveryCategory,
                                    IsCreatePermission = true,
                                    IsReadPermission = true,
                                    IsUpdatePermission = true,
                                    IsDeletePermission = true,
                                    ShopPermission = new ShopPermission()
                                    {
                                        Number = ShopPermissionType.DeliveryCategory.ToString()
                                    }
                                }
                            }
                        }
                    }
                }
            }
        };

        private static readonly object[] _createPermissionError =
        {
            new object[]
            {
                new JwtPayload
                {
                    UserId = 1,
                    IsAdmin = false,
                },
                new List<MapUserRole>
                {
                    new MapUserRole
                    {
                        UserId = 1,
                        RoleId = 1,
                        ShopRole = new ShopRole()
                        {
                            MapRolePermissions = new List<MapRolePermission>()
                            {
                                new MapRolePermission()
                                {
                                    RoleId = 1,
                                    PermissionId = (long)ShopPermissionType.ProductMaster,
                                    IsCreatePermission = false,
                                    IsReadPermission = true,
                                    IsUpdatePermission = true,
                                    IsDeletePermission = true,
                                    ShopPermission = new ShopPermission()
                                    {
                                        Number = ShopPermissionType.ProductMaster.ToString()
                                    }
                                }
                            }
                        }
                    }
                }
            },
            new object[]
            {
                new JwtPayload
                {
                    UserId = 2,
                    IsAdmin = false,
                },
                new List<MapUserRole>
                {
                    new MapUserRole
                    {
                        UserId = 2,
                        RoleId = 2,
                        ShopRole = new ShopRole()
                        {
                            MapRolePermissions = new List<MapRolePermission>()
                            {
                                new MapRolePermission()
                                {
                                    RoleId = 2,
                                    PermissionId = (long)ShopPermissionType.ProductMaster,
                                    IsCreatePermission = false,
                                    IsReadPermission = true,
                                    IsUpdatePermission = true,
                                    IsDeletePermission = true,
                                    ShopPermission = new ShopPermission()
                                    {
                                        Number = ShopPermissionType.ProductMaster.ToString()
                                    }
                                }
                            }
                        }
                    }
                }
            }
        };

        private static readonly object[] _readPermissionError =
        {
            new object[]
            {
                new JwtPayload
                {
                    UserId = 1,
                    IsAdmin = false,
                },
                new List<MapUserRole>
                {
                    new MapUserRole
                    {
                        UserId = 1,
                        RoleId = 1,
                        ShopRole = new ShopRole()
                        {
                            MapRolePermissions = new List<MapRolePermission>()
                            {
                                new MapRolePermission()
                                {
                                    RoleId = 1,
                                    PermissionId = (long)ShopPermissionType.ProductMaster,
                                    IsCreatePermission = true,
                                    IsReadPermission = false,
                                    IsUpdatePermission = true,
                                    IsDeletePermission = true,
                                    ShopPermission = new ShopPermission()
                                    {
                                        Number = ShopPermissionType.ProductMaster.ToString()
                                    }
                                }
                            }
                        }
                    }
                }
            },
            new object[]
            {
                new JwtPayload
                {
                    UserId = 2,
                    IsAdmin = false,
                },
                new List<MapUserRole>
                {
                    new MapUserRole
                    {
                        UserId = 2,
                        RoleId = 2,
                        ShopRole = new ShopRole()
                        {
                            MapRolePermissions = new List<MapRolePermission>()
                            {
                                new MapRolePermission()
                                {
                                    RoleId = 2,
                                    PermissionId = (long)ShopPermissionType.ProductMaster,
                                    IsCreatePermission = true,
                                    IsReadPermission = false,
                                    IsUpdatePermission = true,
                                    IsDeletePermission = true,
                                    ShopPermission = new ShopPermission()
                                    {
                                        Number = ShopPermissionType.ProductMaster.ToString()
                                    }
                                }
                            }
                        }
                    }
                }
            }
        };

        private static readonly object[] _updatePermissionError =
       {
            new object[]
            {
                new JwtPayload
                {
                    UserId = 1,
                    IsAdmin = false,
                },
                new List<MapUserRole>
                {
                    new MapUserRole
                    {
                        UserId = 1,
                        RoleId = 1,
                        ShopRole = new ShopRole()
                        {
                            MapRolePermissions = new List<MapRolePermission>()
                            {
                                new MapRolePermission()
                                {
                                    RoleId = 1,
                                    PermissionId = (long)ShopPermissionType.ProductMaster,
                                    IsCreatePermission = true,
                                    IsReadPermission = true,
                                    IsUpdatePermission = false,
                                    IsDeletePermission = true,
                                    ShopPermission = new ShopPermission()
                                    {
                                        Number = ShopPermissionType.ProductMaster.ToString()
                                    }
                                }
                            }
                        }
                    }
                }
            },
            new object[]
            {
                new JwtPayload
                {
                    UserId = 2,
                    IsAdmin = false,
                },
                new List<MapUserRole>
                {
                    new MapUserRole
                    {
                        UserId = 2,
                        RoleId = 2,
                        ShopRole = new ShopRole()
                        {
                            MapRolePermissions = new List<MapRolePermission>()
                            {
                                new MapRolePermission()
                                {
                                    RoleId = 2,
                                    PermissionId = (long)ShopPermissionType.ProductMaster,
                                    IsCreatePermission = true,
                                    IsReadPermission = true,
                                    IsUpdatePermission = false,
                                    IsDeletePermission = true,
                                    ShopPermission = new ShopPermission()
                                    {
                                        Number = ShopPermissionType.ProductMaster.ToString()
                                    }
                                }
                            }
                        }
                    }
                }
            }
        };

        private static readonly object[] _deletePermissionError =
       {
            new object[]
            {
                new JwtPayload
                {
                    UserId = 1,
                    IsAdmin = false,
                },
                new List<MapUserRole>
                {
                    new MapUserRole
                    {
                        UserId = 1,
                        RoleId = 1,
                        ShopRole = new ShopRole()
                        {
                            MapRolePermissions = new List<MapRolePermission>()
                            {
                                new MapRolePermission()
                                {
                                    RoleId = 1,
                                    PermissionId = (long)ShopPermissionType.ProductMaster,
                                    IsCreatePermission = true,
                                    IsReadPermission = true,
                                    IsUpdatePermission = true,
                                    IsDeletePermission = false,
                                    ShopPermission = new ShopPermission()
                                    {
                                        Number = ShopPermissionType.ProductMaster.ToString()
                                    }
                                }
                            }
                        }
                    }
                }
            },
            new object[]
            {
                new JwtPayload
                {
                    UserId = 2,
                    IsAdmin = false,
                },
                new List<MapUserRole>
                {
                    new MapUserRole
                    {
                        UserId = 2,
                        RoleId = 2,
                        ShopRole = new ShopRole()
                        {
                            MapRolePermissions = new List<MapRolePermission>()
                            {
                                new MapRolePermission()
                                {
                                    RoleId = 2,
                                    PermissionId = (long)ShopPermissionType.ProductMaster,
                                    IsCreatePermission = true,
                                    IsReadPermission = true,
                                    IsUpdatePermission = true,
                                    IsDeletePermission = false,
                                    ShopPermission = new ShopPermission()
                                    {
                                        Number = ShopPermissionType.ProductMaster.ToString()
                                    }
                                }
                            }
                        }
                    }
                }
            }
        };

        private static readonly object[] _compositePermissionError =
       {
            new object[]
            {
                new JwtPayload
                {
                    UserId = 1,
                    IsAdmin = false,
                },
                new List<MapUserRole>
                {
                    new MapUserRole
                    {
                        UserId = 1,
                        RoleId = 1,
                        ShopRole = new ShopRole()
                        {
                            MapRolePermissions = new List<MapRolePermission>()
                            {
                                new MapRolePermission()
                                {
                                    RoleId = 1,
                                    PermissionId = (long)ShopPermissionType.ProductMaster,
                                    IsCreatePermission = true,
                                    IsReadPermission = true,
                                    IsUpdatePermission = true,
                                    IsDeletePermission = false,
                                    ShopPermission = new ShopPermission()
                                    {
                                        Number = ShopPermissionType.ProductMaster.ToString()
                                    }
                                }
                            }
                        }
                    }
                }
            },
            new object[]
            {
                new JwtPayload
                {
                    UserId = 2,
                    IsAdmin = false,
                },
                new List<MapUserRole>
                {
                    new MapUserRole
                    {
                        UserId = 2,
                        RoleId = 2,
                        ShopRole = new ShopRole()
                        {
                            MapRolePermissions = new List<MapRolePermission>()
                            {
                                new MapRolePermission()
                                {
                                    RoleId = 2,
                                    PermissionId = (long)ShopPermissionType.ProductMaster,
                                    IsCreatePermission = true,
                                    IsReadPermission = true,
                                    IsUpdatePermission = true,
                                    IsDeletePermission = false,
                                    ShopPermission = new ShopPermission()
                                    {
                                        Number = ShopPermissionType.ProductMaster.ToString()
                                    }
                                }
                            }
                        }
                    }
                }
            }
        };

        private static readonly object[] _compositePermissionSuccess =
       {
            new object[]
            {
                new JwtPayload
                {
                    UserId = 1,
                    IsAdmin = false,
                },
                new List<MapUserRole>
                {
                    new MapUserRole
                    {
                        UserId = 1,
                        RoleId = 1,
                        ShopRole = new ShopRole()
                        {
                            MapRolePermissions = new List<MapRolePermission>()
                            {
                                new MapRolePermission()
                                {
                                    RoleId = 1,
                                    PermissionId = (long)ShopPermissionType.ProductMaster,
                                    IsCreatePermission = true,
                                    IsReadPermission = true,
                                    IsUpdatePermission = true,
                                    IsDeletePermission = true,
                                    ShopPermission = new ShopPermission()
                                    {
                                        Number = ShopPermissionType.ProductMaster.ToString()
                                    }
                                }
                            }
                        }
                    }
                }
            },
            new object[]
            {
                new JwtPayload
                {
                    UserId = 2,
                    IsAdmin = false,
                },
                new List<MapUserRole>
                {
                    new MapUserRole
                    {
                        UserId = 2,
                        RoleId = 2,
                        ShopRole = new ShopRole()
                        {
                            MapRolePermissions = new List<MapRolePermission>()
                            {
                                new MapRolePermission()
                                {
                                    RoleId = 2,
                                    PermissionId = (long)ShopPermissionType.ProductMaster,
                                    IsCreatePermission = true,
                                    IsReadPermission = true,
                                    IsUpdatePermission = true,
                                    IsDeletePermission = true,
                                    ShopPermission = new ShopPermission()
                                    {
                                        Number = ShopPermissionType.ProductMaster.ToString()
                                    }
                                }
                            }
                        }
                    }
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
            _mockMapUserRoleService = new Mock<IMapUserRoleService>(MockBehavior.Strict);

            //預設，給還不需要驗證CRUD的Cases使用
            _requiredPermissionBaseAttribute = GenerateBaseAttribute(ShopPermissionType.ProductMaster);
        }

        /// <summary>
        /// 測試Token為空時失敗
        /// </summary>
        [Test]
        public void TestAccessTokenIsEmpty()
        {
            AuthorizationFilterContext fakeAuthFilterContext = GetFakeAuthorizationFilterContext(string.Empty);
            _requiredPermissionBaseAttribute.OnAuthorization(fakeAuthFilterContext);
            ObjectResult? result = fakeAuthFilterContext.Result as ObjectResult;

            Assert.That(result!.StatusCode, Is.EqualTo(401));
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

            _requiredPermissionBaseAttribute.OnAuthorization(fakeAuthFilterContext);
            ObjectResult? result = fakeAuthFilterContext.Result as ObjectResult;

            Assert.That(result!.StatusCode, Is.EqualTo(401));
        }

        /// <summary>
        /// 測試沒有該API權限(失敗)
        /// </summary>
        [TestCaseSource(nameof(_permissionError))]
        public void TestPermissionError(JwtPayload jwtPayload, IList<MapUserRole> mapUserRoles)
        {
            AuthorizationFilterContext fakeAuthFilterContext = GetFakeAuthorizationFilterContext("fakeToken");

            _mockJwtService.Setup(x => x.DecryptToken(It.IsAny<string>()))
                .Returns(jwtPayload);

            _mockMapUserRoleService.Setup(x => x.GetByUserId(jwtPayload.UserId))
                .Returns(mapUserRoles.AsQueryable());

            //以ProductMaster功能當作測試案例
            _requiredPermissionBaseAttribute = GenerateBaseAttribute(
                ShopPermissionType.ProductMaster,
                HttpMethodType.POST);

            _requiredPermissionBaseAttribute.OnAuthorization(fakeAuthFilterContext);
            ObjectResult? result = fakeAuthFilterContext.Result as ObjectResult;

            Assert.That(result!.StatusCode, Is.EqualTo(403));
        }

        /// <summary>
        /// 測試Create權限(失敗)
        /// </summary>
        [TestCaseSource(nameof(_createPermissionError))]
        public void TestCreatePermissionError(JwtPayload jwtPayload, IList<MapUserRole> mapUserRoles )
        {
            AuthorizationFilterContext fakeAuthFilterContext = GetFakeAuthorizationFilterContext("fakeToken");

            _mockJwtService.Setup(x => x.DecryptToken(It.IsAny<string>()))
                .Returns(jwtPayload);

            _mockMapUserRoleService.Setup(x => x.GetByUserId(jwtPayload.UserId))
                .Returns(mapUserRoles.AsQueryable());

            //以ProductMaster功能當作測試案例
            _requiredPermissionBaseAttribute = GenerateBaseAttribute(
                ShopPermissionType.ProductMaster,
                HttpMethodType.POST);

            _requiredPermissionBaseAttribute.OnAuthorization(fakeAuthFilterContext);
            ObjectResult? result = fakeAuthFilterContext.Result as ObjectResult;

            Assert.That(result!.StatusCode, Is.EqualTo(403));
        }

        /// <summary>
        /// 測試Read權限(失敗)
        /// </summary>
        [TestCaseSource(nameof(_readPermissionError))]
        public void TestReadPermissionError(JwtPayload jwtPayload, IList<MapUserRole> mapUserRoles)
        {
            AuthorizationFilterContext fakeAuthFilterContext = GetFakeAuthorizationFilterContext("fakeToken");

            _mockJwtService.Setup(x => x.DecryptToken(It.IsAny<string>()))
                .Returns(jwtPayload);

            _mockMapUserRoleService.Setup(x => x.GetByUserId(jwtPayload.UserId))
                .Returns(mapUserRoles.AsQueryable());

            //以ProductMaster功能當作測試案例
            _requiredPermissionBaseAttribute = GenerateBaseAttribute(
                ShopPermissionType.ProductMaster,
                HttpMethodType.GET);

            _requiredPermissionBaseAttribute.OnAuthorization(fakeAuthFilterContext);
            ObjectResult? result = fakeAuthFilterContext.Result as ObjectResult;

            Assert.That(result!.StatusCode, Is.EqualTo(403));
        }

        /// <summary>
        /// 測試Patch權限(失敗)
        /// </summary>
        [TestCaseSource(nameof(_updatePermissionError))]
        public void TestPatchPermissionError(JwtPayload jwtPayload, IList<MapUserRole> mapUserRoles)
        {
            AuthorizationFilterContext fakeAuthFilterContext = GetFakeAuthorizationFilterContext("fakeToken");

            _mockJwtService.Setup(x => x.DecryptToken(It.IsAny<string>()))
                .Returns(jwtPayload);

            _mockMapUserRoleService.Setup(x => x.GetByUserId(jwtPayload.UserId))
                .Returns(mapUserRoles.AsQueryable());

            //以ProductMaster功能當作測試案例
            _requiredPermissionBaseAttribute = GenerateBaseAttribute(
                ShopPermissionType.ProductMaster,
                HttpMethodType.PATCH);

            _requiredPermissionBaseAttribute.OnAuthorization(fakeAuthFilterContext);
            ObjectResult? result = fakeAuthFilterContext.Result as ObjectResult;

            Assert.That(result!.StatusCode, Is.EqualTo(403));
        }

        /// <summary>
        /// 測試Put權限(失敗)
        /// </summary>
        [TestCaseSource(nameof(_updatePermissionError))]
        public void TestPutPermissionError(JwtPayload jwtPayload, IList<MapUserRole> mapUserRoles)
        {
            AuthorizationFilterContext fakeAuthFilterContext = GetFakeAuthorizationFilterContext("fakeToken");

            _mockJwtService.Setup(x => x.DecryptToken(It.IsAny<string>()))
                .Returns(jwtPayload);

            _mockMapUserRoleService.Setup(x => x.GetByUserId(jwtPayload.UserId))
                .Returns(mapUserRoles.AsQueryable());

            //以ProductMaster功能當作測試案例
            _requiredPermissionBaseAttribute = GenerateBaseAttribute(
                ShopPermissionType.ProductMaster,
                HttpMethodType.PUT);

            _requiredPermissionBaseAttribute.OnAuthorization(fakeAuthFilterContext);
            ObjectResult? result = fakeAuthFilterContext.Result as ObjectResult;

            Assert.That(result!.StatusCode, Is.EqualTo(403));
        }

        /// <summary>
        /// 測試Delete權限(失敗)
        /// </summary>
        [TestCaseSource(nameof(_deletePermissionError))]
        public void TestDeletePermissionError(JwtPayload jwtPayload, IList<MapUserRole> mapUserRoles)
        {
            AuthorizationFilterContext fakeAuthFilterContext = GetFakeAuthorizationFilterContext("fakeToken");

            _mockJwtService.Setup(x => x.DecryptToken(It.IsAny<string>()))
                .Returns(jwtPayload);

            _mockMapUserRoleService.Setup(x => x.GetByUserId(jwtPayload.UserId))
                .Returns(mapUserRoles.AsQueryable());

            //以ProductMaster功能當作測試案例
            _requiredPermissionBaseAttribute = GenerateBaseAttribute(
                ShopPermissionType.ProductMaster,
                HttpMethodType.DELETE);

            _requiredPermissionBaseAttribute.OnAuthorization(fakeAuthFilterContext);
            ObjectResult? result = fakeAuthFilterContext.Result as ObjectResult;

            Assert.That(result!.StatusCode, Is.EqualTo(403));
        }

        /// <summary>
        /// 測試組合權限(失敗)
        /// </summary>
        [TestCaseSource(nameof(_compositePermissionError))]
        public void TestCompositePermissionError(JwtPayload jwtPayload, IList<MapUserRole> mapUserRoles)
        {
            AuthorizationFilterContext fakeAuthFilterContext = GetFakeAuthorizationFilterContext("fakeToken");

            _mockJwtService.Setup(x => x.DecryptToken(It.IsAny<string>()))
                .Returns(jwtPayload);

            _mockMapUserRoleService.Setup(x => x.GetByUserId(jwtPayload.UserId))
                .Returns(mapUserRoles.AsQueryable());

            //以ProductMaster功能當作測試案例
            _requiredPermissionBaseAttribute = GenerateBaseAttribute(
                ShopPermissionType.ProductMaster,
                HttpMethodType.GET,
                HttpMethodType.POST,
                HttpMethodType.PUT,
                HttpMethodType.DELETE);

            _requiredPermissionBaseAttribute.OnAuthorization(fakeAuthFilterContext);
            ObjectResult? result = fakeAuthFilterContext.Result as ObjectResult;

            Assert.That(result!.StatusCode, Is.EqualTo(403));
        }

        /// <summary>
        /// 測試組合權限(成功)
        /// </summary>
        [TestCaseSource(nameof(_compositePermissionSuccess))]
        public void TestCompositePermissionSuccess(JwtPayload jwtPayload, IList<MapUserRole> mapUserRoles)
        {
            AuthorizationFilterContext fakeAuthFilterContext = GetFakeAuthorizationFilterContext("fakeToken");

            _mockJwtService.Setup(x => x.DecryptToken(It.IsAny<string>()))
                .Returns(jwtPayload);

            _mockMapUserRoleService.Setup(x => x.GetByUserId(jwtPayload.UserId))
                .Returns(mapUserRoles.AsQueryable());

            //以ProductMaster功能當作測試案例
            _requiredPermissionBaseAttribute = GenerateBaseAttribute(
                ShopPermissionType.ProductMaster,
                HttpMethodType.GET,
                HttpMethodType.POST,
                HttpMethodType.PUT,
                HttpMethodType.DELETE);

            _requiredPermissionBaseAttribute.OnAuthorization(fakeAuthFilterContext);
            ObjectResult? result = fakeAuthFilterContext.Result as ObjectResult;

            Assert.That(result, Is.Null);
        }

        /// <summary>
        /// 生成一個 RequiredPermissionBaseAttribute
        /// </summary>
        /// <param name="permissionType">要驗證的權限類型</param>
        /// <param name="cruds">同時要驗證的CRUD清單</param>
        /// <returns></returns>
        private RequiredPermissionBaseAttribute GenerateBaseAttribute(
            ShopPermissionType permissionType,
            params HttpMethodType[] cruds) 
        {
            //以ProductMaster功能當作測試案例
            return new RequiredPermissionBaseAttribute(
                _mockJwtService.Object,
                _mockMapUserRoleService.Object,
                new LoginUserData(),
                permissionType,
                cruds);
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
