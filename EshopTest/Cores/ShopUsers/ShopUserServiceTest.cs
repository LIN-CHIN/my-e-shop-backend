using EShopAPI.Cores.ShopRoles;
using EShopAPI.Cores.ShopUsers;
using EShopAPI.Cores.ShopUsers.DAOs;
using EShopAPI.Cores.ShopUsers.DTOs;
using EShopAPI.Cores.ShopUsers.Services;
using EShopCores.Errors;
using EShopCores.Responses;
using Moq;
using System.Text.Json;

namespace EshopTest.Cores.ShopUsers
{
    /// <summary>
    /// ShopUser Service 的測試
    /// </summary>
    [TestFixture]
    public class ShopUserServiceTest
    {
        private IShopUserService _shopUserService;
        private Mock<IShopUserDao> _mockShopUserDao;

        private static readonly object[] _insertCases =
        {
            new object[]
            {
                new InsertShopUserDto()
                {
                    Number = "Test001",
                    Name = "Test",
                    Pwd = "1234",
                    Address = "新增地址01",
                    Email = "新增email01",
                    Phone = "0912345678",
                    IsEnable = true,
                    Remarks = "新增備註01",
                    Language = new Dictionary<string, string>()
                    {
                        { "insert01", "value01"}
                    },
                    CreateUser = "shopAdmin"
                },
                new ShopUser()
                {
                    Id = 1,
                    Number = "Test001",
                    Name = "Test",
                    Pwd = "1234",
                    Address = "新增地址01",
                    Email = "新增email01",
                    Phone = "0912345678",
                    IsEnable = true,
                    Remarks = "新增備註01",
                    Language = JsonSerializer.SerializeToDocument(
                        new Dictionary<string, string>()
                        {
                            { "insert01", "value01"}
                        }
                    ),
                    CreateUser = "shopAdmin"
                }
            },
            new object[]
            {
                new InsertShopUserDto()
                {
                    Number = "Test002",
                    Name = "Test02",
                    Pwd = "5678",
                    Address = "新增地址02",
                    Email = "新增email02",
                    Phone = "0912345678",
                    IsEnable = false,
                    Remarks = "新增備註02",
                    Language = new Dictionary<string, string>()
                    {
                        { "insert02", "value02"}
                    },
                    CreateUser = "shopAdmin"
                },
                new ShopUser()
                {
                    Id = 1,
                    Number = "Test002",
                    Name = "Test02",
                    Pwd = "5678",
                    Address = "新增地址02",
                    Email = "新增email02",
                    Phone = "0912345678",
                    IsEnable = false,
                    Remarks = "新增備註02",
                    Language = JsonSerializer.SerializeToDocument(
                        new Dictionary<string, string>()
                        {
                            { "insert02", "value02"}
                        }
                    ),
                    CreateUser = "shopAdmin"
                }
            }
        };

        private static readonly object[] _updateCases =
        {
            new object[]
            {
                new UpdateShopUserDto()
                {
                    Id = 1,
                    Name = "TestUpdate",
                    Pwd = "1234",
                    Address = "測試編輯地址",
                    Email = "update@gmail.com",
                    Phone = "0998765432",
                    UpdateUser = "shopAdmin",
                    Remarks = "編輯備註",
                    Language = new Dictionary<string, string>()
                    {
                        { "update", "test" }
                    }
                },
                new ShopUser()
                {
                    Id = 1,
                    Name = "Test",
                    Pwd = "123",
                    Address = "地址",
                    Email = "aaa@gmail.com",
                    Phone = "0912345678",
                    UpdateUser = "shopAdmin",
                    Remarks = "備註",
                    Language = JsonSerializer.SerializeToDocument(
                        new Dictionary<string, string>()
                        {
                            { "update", "test" }
                        }
                    )
                }
            },
            new object[]
            {
                new UpdateShopUserDto()
                {
                    Id = 2,
                    Name = "TestUpdate02",
                    Pwd = "5678",
                    Address = "測試編輯地址02",
                    Email = "update02@gmail.com",
                    Phone = "0998765432",
                    UpdateUser = "shopAdmin",
                    Remarks = "編輯備註02",
                    Language = new Dictionary<string, string>()
                    {
                        { "update02", "test02" }
                    }
                },
                new ShopUser()
                {
                    Id = 2,
                    Name = "Test",
                    Pwd = "123",
                    Address = "地址",
                    Email = "aaa@gmail.com",
                    Phone = "0912345678",
                    UpdateUser = "shopAdmin",
                    Remarks = "備註",
                    Language = JsonSerializer.SerializeToDocument(
                        new Dictionary<string, string>()
                        {
                            { "update", "test" }
                        }
                    )
                }
            }
        };

        private static readonly object[] _enableCases =
        {
            new object[]
            {
                new ShopUser()
                {
                    Id = 1,
                    Number = "Test001",
                    Name = "Test",
                    Pwd = "1234",
                    Address = "新增地址01",
                    Email = "新增email01",
                    Phone = "0912345678",
                    IsEnable = false,
                    Remarks = "新增備註01",
                    Language = JsonSerializer.SerializeToDocument(
                        new Dictionary<string, string>()
                        {
                            { "insert01", "value01"}
                        }
                    ),
                    CreateUser = "shopAdmin"
                }
            },
            new object[]
            {
                new ShopUser()
                {
                    Id = 2,
                    Number = "Test002",
                    Name = "Test",
                    Pwd = "1234",
                    Address = "新增地址02",
                    Email = "新增email02",
                    Phone = "0912345678",
                    IsEnable = false,
                    Remarks = "新增備註02",
                    Language = JsonSerializer.SerializeToDocument(
                        new Dictionary<string, string>()
                        {
                            { "insert02", "value02"}
                        }
                    ),
                    CreateUser = "shopAdmin"
                }
            }
        };

        private static readonly object[] _disableCases =
        {
            new object[]
            {
                new ShopUser()
                {
                    Id = 1,
                    Number = "Test001",
                    Name = "Test",
                    Pwd = "1234",
                    Address = "新增地址01",
                    Email = "新增email01",
                    Phone = "0912345678",
                    IsEnable = true,
                    Remarks = "新增備註01",
                    Language = JsonSerializer.SerializeToDocument(
                        new Dictionary<string, string>()
                        {
                            { "insert01", "value01"}
                        }
                    ),
                    CreateUser = "shopAdmin"
                }
            },
            new object[]
            {
                new ShopUser()
                {
                    Id = 2,
                    Number = "Test002",
                    Name = "Test",
                    Pwd = "1234",
                    Address = "新增地址02",
                    Email = "新增email02",
                    Phone = "0912345678",
                    IsEnable = true,
                    Remarks = "新增備註02",
                    Language = JsonSerializer.SerializeToDocument(
                        new Dictionary<string, string>()
                        {
                            { "insert02", "value02"}
                        }
                    ),
                    CreateUser = "shopAdmin"
                }
            }
        };

        /// <summary>
        /// Setup 
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _mockShopUserDao = new Mock<IShopUserDao>(MockBehavior.Strict);
            _shopUserService = new ShopUserService(_mockShopUserDao.Object);
        }

        /// <summary>
        /// 測試新增成功
        /// </summary>
        /// <param name="insertDto">要新增的資料</param>
        /// <param name="rtnShopUser">新增後回傳的資料</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_insertCases))]
        public async Task TestInsertAsync(InsertShopUserDto insertDto, ShopUser rtnShopUser)
        {
            bool isPass = false;

            _mockShopUserDao
                .Setup(x => x.InsertAsync(It.IsAny<ShopUser>()))
                .Callback<ShopUser>(shopUser =>
                {
                    if (shopUser.Number == rtnShopUser.Number &&
                      shopUser.Name == rtnShopUser.Name &&
                      shopUser.Pwd == rtnShopUser.Pwd &&
                      shopUser.CreateUser == rtnShopUser.CreateUser &&
                      rtnShopUser.Id != 0)
                    {
                        isPass = true;
                    }
                })
                .ReturnsAsync(rtnShopUser);

            _mockShopUserDao
                .Setup(x => x.GetByNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(value: null);

            try
            {
                ShopUser result = await _shopUserService.InsertAsync(insertDto);
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
        /// <param name="shopUser">根據id取到的使用者</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_updateCases))]
        public async Task TestUpdateAsync(UpdateShopUserDto updateDto, ShopUser shopUser)
        {
            bool isPass = false;

            _mockShopUserDao
                .Setup(x => x.UpdateAsync(It.IsAny<ShopUser>()))
                .Callback<ShopUser>(inputEntity =>
                {
                    if (inputEntity.Id == updateDto.Id &&
                        inputEntity.Name == updateDto.Name &&
                        inputEntity.Pwd == updateDto.Pwd &&
                        inputEntity.Address == updateDto.Address &&
                        inputEntity.Email == updateDto.Email &&
                        inputEntity.Phone == updateDto.Phone &&
                        inputEntity.UpdateUser == updateDto.UpdateUser &&
                        inputEntity.Remarks == updateDto.Remarks &&
                        JsonSerializer.Serialize(inputEntity.Language) == JsonSerializer.Serialize(updateDto.Language))
                    {
                        isPass = true;
                    }
                })
                .Returns(Task.FromResult(false));

            _mockShopUserDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(shopUser);

            try
            {
                await _shopUserService.UpdateAsync(updateDto);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(isPass, Is.True);
        }

        /// <summary>
		/// 測試根據使用者帳號取得使用者，是否正常throw exception
		/// </summary>
        [Test]
        public void TestThrowExistByNumber()
        {
            _mockShopUserDao.Setup(x => x.GetByNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(new ShopUser());

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
                await _shopUserService.ThrowExistByNumberAsync(It.IsAny<string>()));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.DuplicateData));
        }

        /// <summary>
		/// 測試根據使用者id取得使用者，是否正常throw exception
		/// </summary>
        [Test]
        public void TestThrowNotFindByIdAsync()
        {
            _mockShopUserDao.Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
                await _shopUserService.ThrowNotFindByIdAsync(It.IsAny<long>()));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試啟用角色
        /// </summary>
        /// <param name="shopRole">根據id取得的使用者實體</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_enableCases))]
        public async Task TestEnableAsync(ShopUser shopUser)
        {
            bool isPass = false;

            _mockShopUserDao
                .Setup(x => x.GetByIdAsync(shopUser.Id))
                .ReturnsAsync(shopUser);

            _mockShopUserDao
                .Setup(x => x.UpdateAsync(shopUser))
                .Callback<ShopUser>(inputEntity =>
                {
                    if (inputEntity.IsEnable == true)
                    {
                        isPass = true;
                    }
                })
                .Returns(Task.FromResult(false));

            await _shopUserService.EnableAsync(shopUser.Id, true);

            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試停用角色
        /// </summary>
        /// <param name="shopUser">根據id取得的使用者實體</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_disableCases))]
        public async Task TestDisableAsync(ShopUser shopUser)
        {
            bool isPass = false;

            _mockShopUserDao
                .Setup(x => x.GetByIdAsync(shopUser.Id))
                .ReturnsAsync(shopUser);

            _mockShopUserDao
                .Setup(x => x.UpdateAsync(shopUser))
                .Callback<ShopUser>(inputEntity =>
                {
                    if (inputEntity.IsEnable == false)
                    {
                        isPass = true;
                    }
                })
                .Returns(Task.FromResult(false));

            await _shopUserService.EnableAsync(shopUser.Id, false);

            Assert.That(isPass, Is.True);
        }
    }
}
