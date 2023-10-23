using EShopAPI.Cores.ShopRoles.DAOs;
using EShopAPI.Cores.ShopRoles.Services;
using EShopCores.Errors;
using EShopCores.Responses;
using Moq;
using EShopAPI.Cores.ShopRoles.DTOs;
using System.Text.Json;
using EShopAPI.Cores.ShopRoles;
using Jose;
using EShopCores.Json;
using EShopCores.Enums;
using EShopAPI.Common;

namespace EshopTest.Cores.ShopRoles
{
    /// <summary>
    /// ShopRole Service 測試
    /// </summary>
    [TestFixture]
    public class ShopRoleServiceTest
    {
        private IShopRoleService _shopRoleService;
        private Mock<IShopRoleDao> _mockShopRoleDao;
        private LoginUserData _loginUserData;

        private static readonly object[] _insertCases =
        {
            new object[]
            {
                new InsertShopRoleDto()
                {
                    Number = "role01",
                    Name = "角色01",
                    IsEnable = true,
                    Remarks = "新增備註01",
                    Languages = new List<LanguageJson>()
                    {
                        new LanguageJson { 
                            LanguageKey = LanguageType.TW,
                            LanguageValue = "角色01"
                        },
                        new LanguageJson {
                            LanguageKey = LanguageType.EN_US,
                            LanguageValue = "role01"
                        }
                    },

                },
                new ShopRole()
                {
                    Id = 1,
                    Number = "role01",
                    Name = "角色01",
                    IsEnable = true,
                    CreateUser = "shopAdmin",
                    Remarks = "新增備註01",
                    Language = JsonSerializer.SerializeToDocument(
                        new List<LanguageJson>()
                        {
                            new LanguageJson {
                                LanguageKey = LanguageType.TW,
                                LanguageValue = "角色01"
                            },
                            new LanguageJson {
                                LanguageKey = LanguageType.EN_US,
                                LanguageValue = "role01"
                            }
                        }
                    ),
                }
            },
            new object[]
            {
                new InsertShopRoleDto()
                {
                    Number = "role02",
                    Name = "角色02",
                    IsEnable = false,
                    Remarks = "新增備註02",
                    Languages = new List<LanguageJson>()
                    {
                        new LanguageJson {
                            LanguageKey = LanguageType.TW,
                            LanguageValue = "角色02"
                        },
                        new LanguageJson {
                            LanguageKey = LanguageType.EN_US,
                            LanguageValue = "role02"
                        }
                    }

                },
                new ShopRole()
                {
                    Id = 1,
                    Number = "role02",
                    Name = "角色02",
                    IsEnable = false,
                    CreateUser = "shopAdmin",
                    Remarks = "新增備註02",
                    Language = JsonSerializer.SerializeToDocument(
                        new List<LanguageJson>()
                        {
                            new LanguageJson {
                                LanguageKey = LanguageType.TW,
                                LanguageValue = "角色02"
                            },
                            new LanguageJson {
                                LanguageKey = LanguageType.EN_US,
                                LanguageValue = "role02"
                            }
                        }
                    ),
                }
            }
        };

        private static readonly object[] _updateCases =
        {
            new object[]
            {
                new UpdateShopRoleDto()
                {
                    Id = 1,
                    Name = "TestUpdate01",
                    Remarks = "編輯備註01",
                    Languages = new List<LanguageJson>()
                    {
                        new LanguageJson {
                            LanguageKey = LanguageType.TW,
                            LanguageValue = "角色01"
                        },
                        new LanguageJson {
                            LanguageKey = LanguageType.EN_US,
                            LanguageValue = "role01"
                        }
                    },
                },
                new ShopRole()
                {
                    Id = 1,
                    Number = "role01",
                    Name = "角色01",
                    IsEnable = true,
                    CreateUser = "shopAdmin",
                    Remarks = "新增備註01",
                    Language = JsonSerializer.SerializeToDocument(
                        new List<LanguageJson>()
                        {
                            new LanguageJson {
                                LanguageKey = LanguageType.TW,
                                LanguageValue = "角色01"
                            },
                            new LanguageJson {
                                LanguageKey = LanguageType.EN_US,
                                LanguageValue = "role01"
                            }
                        }
                    ),
                }
            },
            new object[]
            {
                new UpdateShopRoleDto()
                {
                    Id = 2,
                    Name = "TestUpdate02",
                    Remarks = "編輯備註02",
                    Languages = new List<LanguageJson>()
                    {
                        new LanguageJson {
                            LanguageKey = LanguageType.TW,
                            LanguageValue = "角色02"
                        },
                        new LanguageJson {
                            LanguageKey = LanguageType.EN_US,
                            LanguageValue = "role02"
                        }
                    }
                },
                new ShopRole()
                {
                    Id = 2,
                    Number = "role02",
                    Name = "角色02",
                    IsEnable = false,
                    CreateUser = "shopAdmin",
                    Remarks = "新增備註02",
                    Language = JsonSerializer.SerializeToDocument(
                        new List<LanguageJson>()
                        {
                            new LanguageJson {
                                LanguageKey = LanguageType.TW,
                                LanguageValue = "角色02"
                            },
                            new LanguageJson {
                                LanguageKey = LanguageType.EN_US,
                                LanguageValue = "role02"
                            }
                        }
                    ),
                }
            }
        };

        private static readonly object[] _enableCases =
        {
            new object[]
            {
                new ShopRole()
                {
                    Id = 1,
                    Number = "role01",
                    Name = "角色01",
                    IsEnable = false,
                    CreateUser = "shopAdmin",
                }
            },
            new object[]
            {
                new ShopRole()
                {
                    Id = 2,
                    Number = "role02",
                    Name = "角色02",
                    IsEnable = false,
                    CreateUser = "shopAdmin",
                }
            }
        };

        private static readonly object[] _disableCases =
        {
            new object[]
            {
                new ShopRole()
                {
                    Id = 1,
                    Number = "role01",
                    Name = "角色01",
                    IsEnable = true,
                    CreateUser = "shopAdmin",
                }
            },
            new object[]
            {
                new ShopRole()
                {
                    Id = 2,
                    Number = "role02",
                    Name = "角色02",
                    IsEnable = true,
                    CreateUser = "shopAdmin",
                }
            }
        };

        /// <summary>
        /// Setup 
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _loginUserData = new LoginUserData()
            {
                UserNumber = "shopAdmin"
            };

            _mockShopRoleDao = new Mock<IShopRoleDao>(MockBehavior.Strict);
            _shopRoleService = new ShopRoleService(_mockShopRoleDao.Object, _loginUserData);
        }

        /// <summary>
        /// 測試新增成功
        /// </summary>
        /// <param name="insertDto">要新增的資料</param>
        /// <param name="rtnShopRole">新增後回傳的資料</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_insertCases))]
        public async Task TestInsertAsync(InsertShopRoleDto insertDto, ShopRole rtnShopRole)
        {
            bool isPass = false;

            _mockShopRoleDao
                .Setup(x => x.InsertAsync(It.IsAny<ShopRole>()))
                .Callback<ShopRole>(shopRole =>
                {
                    if (shopRole.Number == rtnShopRole.Number &&
                      shopRole.Name == rtnShopRole.Name &&
                      shopRole.IsEnable == rtnShopRole.IsEnable &&
                      shopRole.Remarks == rtnShopRole.Remarks &&
                      shopRole.CreateUser == rtnShopRole.CreateUser &&
                      JsonSerializer.Serialize(shopRole.Language) == JsonSerializer.Serialize(rtnShopRole.Language) &&
                      rtnShopRole.Id != 0)
                    {
                        isPass = true;
                    }
                })
                .ReturnsAsync(rtnShopRole);

            _mockShopRoleDao
                .Setup(x => x.GetByNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(value: null);

            try
            {
                ShopRole result = await _shopRoleService.InsertAsync(insertDto);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試編輯成功
        /// </summary>
        /// <param name="updateDto">要編輯的資訊</param>
        /// <param name="shopRole">根據id取到的使用者</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_updateCases))]
        public async Task TestUpdateAsync(UpdateShopRoleDto updateDto, ShopRole shopRole)
        {
            bool isPass = false;

            _mockShopRoleDao
                .Setup(x => x.UpdateAsync(It.IsAny<ShopRole>()))
                .Callback<ShopRole>(inputEntity =>
                {
                    if (inputEntity.Id == updateDto.Id &&
                        inputEntity.Name == updateDto.Name &&
                        inputEntity.Remarks == updateDto.Remarks &&
                        JsonSerializer.Serialize(inputEntity.Language) == JsonSerializer.Serialize(updateDto.Languages))
                    {
                        isPass = true;
                    }
                })
                .Returns(Task.FromResult(false));

            _mockShopRoleDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(shopRole);

            try
            {
                await _shopRoleService.UpdateAsync(updateDto);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試根據id取得角色實體，如果找不到id有沒有正常throw exception
        /// </summary>
        [Test]
        public void TestThrowNotFindByIdAsync() 
        {
            _mockShopRoleDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
                await _shopRoleService.ThrowNotFindByIdAsync(It.IsAny<long>()));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試啟用角色
        /// </summary>
        /// <param name="shopRole">根據id取得的角色實體</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_enableCases))]
        public async Task TestEnableAsync(ShopRole shopRole) 
        {
            bool isPass = false; 

            _mockShopRoleDao
                .Setup(x => x.GetByIdAsync(shopRole.Id))
                .ReturnsAsync(shopRole);

            _mockShopRoleDao
                .Setup(x => x.UpdateAsync(shopRole))
                .Callback<ShopRole>(inputEntity =>
                {
                    if (inputEntity.IsEnable == true)
                    {
                        isPass = true;
                    }
                })
                .Returns(Task.FromResult(false));

            await _shopRoleService.EnableAsync(shopRole.Id, true);

            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試停用角色
        /// </summary>
        /// <param name="shopRole">根據id取得的角色實體</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_disableCases))]
        public async Task TestDisableAsync(ShopRole shopRole)
        {
            bool isPass = false;

            _mockShopRoleDao
                .Setup(x => x.GetByIdAsync(shopRole.Id))
                .ReturnsAsync(shopRole);

            _mockShopRoleDao
                .Setup(x => x.UpdateAsync(shopRole))
                .Callback<ShopRole>(inputEntity =>
                {
                    if (inputEntity.IsEnable == false)
                    {
                        isPass = true;
                    }
                })
                .Returns(Task.FromResult(false));

            await _shopRoleService.EnableAsync(shopRole.Id, false);

            Assert.That(isPass, Is.True);
        }
    }
}
