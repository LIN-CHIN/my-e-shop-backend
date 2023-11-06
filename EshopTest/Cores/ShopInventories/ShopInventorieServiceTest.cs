using EShopAPI.Common;
using EShopAPI.Cores.ShopInventories;
using EShopAPI.Cores.ShopInventories.DAOs;
using EShopAPI.Cores.ShopInventories.DTOs;
using EShopAPI.Cores.ShopInventories.Services;
using EShopCores.Enums;
using EShopCores.Errors;
using EShopCores.Json;
using EShopCores.Responses;
using Jose;
using Moq;
using System.Text.Json;

namespace EshopTest.Cores.ShopInventories
{
    /// <summary>
    /// 測試商店庫存Service
    /// </summary>
    [TestFixture]
    public class ShopInventorieServiceTest
    {
        private IShopInventoryService _shopInventoryService;
        private Mock<IShopInventoryDao> _mockShopInventoryDao;
        private LoginUserData _loginUserData;

        private static readonly object[] _insertExistNumberCases =
        {
            new object[]
            {
                new InsertShopInventoryDto
                {
                    Number = "A001",
                    Name = "產品一",
                }
            },
            new object[]
            {
                new InsertShopInventoryDto
                {
                    Number = "A002",
                    Name = "產品二",
                }
            }
        };
        private static readonly object[] _updateNotFindIdCases =
        {
            new object[]
            { 
                new UpdateShopInventoryDto
                {
                    Id = 1
                }
            },
            new object[]
            {
                new UpdateShopInventoryDto
                {
                    Id = 2
                }
            }
        };

        private static readonly object[] _insertSuccessCases =
        {
            new object[] 
            {
                new InsertShopInventoryDto
                {
                    Number = "A001",
                    Name = "產品一",
                    InventoryQuantity = 5,
                    InventoryAlert = 2,
                    Supplier = "供應商",
                    Brand = "品牌",
                    ProductType = ProductType.Variant,
                    IsComposite = false,
                    IsCompositeOnly = false,
                    IsEnable = true,
                    VariantAttributes = new List<VariantAttributeJson>()
                    {
                        new VariantAttributeJson
                        {
                            Key = "Color",
                            Value = "紅色",
                        },
                        new VariantAttributeJson
                        {
                            Key = "Size",
                            Value = "S",
                        },
                    },
                    Remarks = "新增備註001",
                    Languages = new List<LanguageJson>()
                    {
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.TW,
                            LanguageValue = "產品一"
                        },
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.EN_US,
                            LanguageValue = "product01"
                        }
                    }
                },
                new ShopInventory()
                {
                    Id = 1,
                    Number = "A001",
                    Name = "產品一",
                    InventoryQuantity = 5,
                    InventoryAlert = 2,
                    Supplier = "供應商",
                    Brand = "品牌",
                    ProductType = ProductType.Variant,
                    IsComposite = false,
                    IsCompositeOnly = false,
                    IsEnable = true,
                    VariantAttribute = JsonSerializer.SerializeToDocument(
                        new List<VariantAttributeJson>()
                        {
                            new VariantAttributeJson
                            {
                                Key = "Color",
                                Value = "紅色",
                            },
                            new VariantAttributeJson
                            {
                                Key = "Size",
                                Value = "S",
                            },
                        }
                    ),
                    Remarks = "新增備註001",
                    Language = JsonSerializer.SerializeToDocument(
                        new List<LanguageJson>()
                        {
                            new LanguageJson
                            {
                                LanguageKey = LanguageType.TW,
                                LanguageValue = "產品一"
                            },
                            new LanguageJson
                            {
                                LanguageKey = LanguageType.EN_US,
                                LanguageValue = "product01"
                            }
                        }
                    )
                }
            },
            new object[]
            {
                new InsertShopInventoryDto
                {
                    Number = "A002",
                    Name = "產品二",
                    InventoryQuantity = 0,
                    InventoryAlert = 1,
                    Supplier = "供應商",
                    Brand = "品牌",
                    ProductType = ProductType.Fiexd,
                    IsComposite = false,
                    IsCompositeOnly = false,
                    IsEnable = true,
                    VariantAttributes = null,
                    Remarks = "新增備註002",
                    Languages = new List<LanguageJson>()
                    {
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.TW,
                            LanguageValue = "產品二"
                        },
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.EN_US,
                            LanguageValue = "product02"
                        }
                    }
                },
                new ShopInventory()
                {
                    Id = 1,
                    Number = "A002",
                    Name = "產品二",
                    InventoryQuantity = 0,
                    InventoryAlert = 1,
                    Supplier = "供應商",
                    Brand = "品牌",
                    ProductType = ProductType.Fiexd,
                    IsComposite = false,
                    IsCompositeOnly = false,
                    IsEnable = true,
                    VariantAttribute = null,
                    Remarks = "新增備註002",
                    Language = JsonSerializer.SerializeToDocument(
                        new List<LanguageJson>()
                        {
                            new LanguageJson
                            {
                                LanguageKey = LanguageType.TW,
                                LanguageValue = "產品二"
                            },
                            new LanguageJson
                            {
                                LanguageKey = LanguageType.EN_US,
                                LanguageValue = "product02"
                            }
                        }
                    )
                }
            }
        };
        private static readonly object[] _updateSuccessCases =
        {
            new object[]
            {
                new UpdateShopInventoryDto
                {
                    Id = 1,
                    Name = "編輯產品001",
                    InventoryQuantity = 5,
                    InventoryAlert = 3,
                    Supplier = null,
                    Brand = null,
                    Remarks = null,
                    Languages = new List<LanguageJson>()
                    {
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.TW,
                            LanguageValue = "產品一"
                        },
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.EN_US,
                            LanguageValue = "product01"
                        }
                    }
                },
                new ShopInventory
                {
                    Id = 1,
                    Name = "產品001",
                    InventoryQuantity = 50,
                    InventoryAlert = 30,
                    Supplier = "供應商",
                    Brand = "品牌",
                    Remarks = "備註",
                    Language = null
                },
            },
            new object[]
            {
                new UpdateShopInventoryDto
                {
                    Id = 2,
                    Name = "編輯產品002",
                    InventoryQuantity = 50,
                    InventoryAlert = 30,
                    Supplier = "供應商",
                    Brand = "品牌",
                    Remarks = "備註",
                    Languages = null
                },
                new ShopInventory
                {
                    Id = 2,
                    Name = "產品002",
                    InventoryQuantity = 5,
                    InventoryAlert = 3,
                    Supplier = null,
                    Brand = null,
                    Remarks = null,
                    Language = null
                },
            }
        };
        private static readonly object[] _enableSuccessCases =
        {
            new object[]
            {
                1,
                new ShopInventory
                {
                    Id = 1,
                    IsEnable = false
                }
            },
            new object[]
            {
                2,
                new ShopInventory
                {
                    Id = 2,
                    IsEnable = false
                }
            }
        };
        private static readonly object[] _disableSuccessCases =
        {
            new object[]
            {
                1,
                new ShopInventory
                {
                    Id = 1,
                    IsEnable = true
                }
            },
            new object[]
            {
                2,
                new ShopInventory
                {
                    Id = 2,
                    IsEnable = true
                }
            }
        };

        [SetUp]
        public void Setup() 
        {
            _loginUserData = new LoginUserData()
            {
                UserNumber = "shopAdmin"
            };

            _mockShopInventoryDao = new Mock<IShopInventoryDao>(MockBehavior.Strict);
            _shopInventoryService = new ShopInventoryService(_mockShopInventoryDao.Object, _loginUserData);
        }

        /// <summary>
        /// 測試新增(重複的產品代碼)
        /// </summary>
        [TestCaseSource(nameof(_insertExistNumberCases))]
        public void TestInsertAsyncExistNumber(InsertShopInventoryDto insertDto)
        {
            _mockShopInventoryDao
                .Setup(x => x.GetByNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(new ShopInventory());

            _mockShopInventoryDao
                .Setup(x => x.InsertAsync(It.IsAny<ShopInventory>()))
                .ReturnsAsync(It.IsAny<ShopInventory>());

            EShopException ex = Assert.ThrowsAsync<EShopException>(async () =>
                await _shopInventoryService.InsertAsync(insertDto));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.DuplicateData));
        }

        /// <summary>
        /// 測試InsertAsync(成功)
        /// </summary>
        /// <param name="insertDto">要新增的資料</param>
        /// <param name="rtnEntity">回傳新增後的實體</param>
        [TestCaseSource(nameof(_insertSuccessCases))]
        public async Task TestInsertAsyncSuccess(InsertShopInventoryDto insertDto, ShopInventory rtnEntity)
        {
            bool isPass = false;

            _mockShopInventoryDao
                .Setup(x => x.GetByNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(value: null);

            _mockShopInventoryDao
                .Setup(x => x.InsertAsync(It.IsAny<ShopInventory>()))
                .Callback<ShopInventory>(shopInventory => 
                {
                    if (shopInventory.Number == insertDto.Number &&
                        shopInventory.Name == insertDto.Name &&
                        shopInventory.InventoryQuantity == insertDto.InventoryQuantity &&
                        shopInventory.InventoryAlert == insertDto.InventoryAlert &&
                        shopInventory.Supplier == insertDto.Supplier &&
                        shopInventory.Brand == insertDto.Brand &&
                        shopInventory.ProductType == insertDto.ProductType &&
                        shopInventory.IsComposite == insertDto.IsComposite &&
                        shopInventory.IsCompositeOnly == insertDto.IsCompositeOnly &&
                        shopInventory.IsEnable == insertDto.IsEnable &&
                        JsonSerializer.Serialize(shopInventory.VariantAttribute) ==
                        JsonSerializer.Serialize(insertDto.VariantAttributes) &&
                        shopInventory.Remarks == insertDto.Remarks &&
                        JsonSerializer.Serialize(shopInventory.Language) ==
                        JsonSerializer.Serialize(insertDto.Languages)) 
                    {
                        isPass = true;
                    }
                })
                .ReturnsAsync(rtnEntity);

            try
            {
                await _shopInventoryService.InsertAsync(insertDto);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試UpdateAsync(找不到id)
        /// </summary>
        /// <returns></returns>
        [TestCaseSource(nameof(_updateNotFindIdCases))]
        public void TestUpdateAsyncNotFindId(UpdateShopInventoryDto updateDto) 
        {
            _mockShopInventoryDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            _mockShopInventoryDao
                .Setup(x => x.UpdateAsync(It.IsAny<ShopInventory>()))
                .Returns(Task.FromResult(false));

            EShopException ex = Assert.ThrowsAsync<EShopException>(async () =>
                await _shopInventoryService.UpdateAsync(updateDto));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試UpdateAsync(成功)
        /// </summary>
        /// <param name="updateDto">要修改的資料</param>
        /// <param name="shopInventory">根據id取出的資料</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_updateSuccessCases))]
        public async Task TestUpdateAsyncSuccess(UpdateShopInventoryDto updateDto, ShopInventory shopInventory ) 
        {
            bool isPass = false;

            _mockShopInventoryDao
                .Setup(x => x.GetByIdAsync(updateDto.Id))
                .ReturnsAsync(shopInventory);

            _mockShopInventoryDao
                .Setup(x => x.UpdateAsync(
                    updateDto.SetEntity(shopInventory, _loginUserData.UserNumber)))
                .Callback<ShopInventory>( input => 
                {
                    if (input.Id == updateDto.Id &&
                        input.Name == updateDto.Name &&
                        input.InventoryQuantity == updateDto.InventoryQuantity &&
                        input.InventoryAlert == updateDto.InventoryAlert &&
                        input.Supplier == updateDto.Supplier &&
                        input.Brand == updateDto.Brand &&
                        input.Remarks == updateDto.Remarks &&
                        JsonSerializer.Serialize(input.Language) == 
                        JsonSerializer.Serialize(updateDto.Languages) &&
                        input.UpdateUser == _loginUserData.UserNumber &&
                        input.UpdateDate != null) 
                    {
                        isPass = true;
                    }
                })
                .Returns(Task.FromResult(false));

            try
            {
                await _shopInventoryService.UpdateAsync(updateDto);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試ThrowNotFindByIdAsync(失敗)
        /// </summary>
        [Test]
        public void TestThrowNotFindByIdAsyncError() 
        {
            _mockShopInventoryDao
             .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
             .ReturnsAsync(value: null);

            EShopException ex = Assert.ThrowsAsync<EShopException>(async () =>
                await _shopInventoryService.ThrowNotFindByIdAsync(It.IsAny<long>()));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試ThrowNotFindByIdAsync(成功)
        /// </summary>
        [Test]
        public async Task TestThrowNotFindByIdAsyncSuccess()
        {
            _mockShopInventoryDao
             .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
             .ReturnsAsync(new ShopInventory());

            try
            {
                await _shopInventoryService.ThrowNotFindByIdAsync(It.IsAny<long>());
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.Pass();
        }

        /// <summary>
        /// 測試ThrowExistByNumberAsync(失敗)
        /// </summary>
        [Test]
        public void TestThrowExistByNumberAsyncError()
        {
            _mockShopInventoryDao
             .Setup(x => x.GetByNumberAsync(It.IsAny<string>()))
             .ReturnsAsync(new ShopInventory());

            EShopException ex = Assert.ThrowsAsync<EShopException>(async () =>
                await _shopInventoryService.ThrowExistByNumberAsync(It.IsAny<string>()));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.DuplicateData));
        }

        /// <summary>
        /// 測試ThrowExistByNumberAsync(成功)
        /// </summary>
        [Test]
        public async Task TestThrowExistByNumberAsyncSuccess()
        {
            _mockShopInventoryDao
             .Setup(x => x.GetByNumberAsync(It.IsAny<string>()))
             .ReturnsAsync(value: null);

            try
            {
                await _shopInventoryService.ThrowExistByNumberAsync(It.IsAny<string>());
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.Pass();
        }

        /// <summary>
        /// 測試 EnableAsync (找不到id)
        /// </summary>
        [Test]
        public void TestEnableAsyncNotFindId() 
        {
            _mockShopInventoryDao
             .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
             .ReturnsAsync(value: null);

            EShopException ex = Assert.ThrowsAsync<EShopException>(async () =>
                await _shopInventoryService.EnableAsync(It.IsAny<long>(), true));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試 EnableAsync (成功)
        /// </summary>
        /// <param name="id">要啟用的id</param>
        /// <param name="shopInventory">根據id找到的實體</param>
        [TestCaseSource(nameof(_enableSuccessCases))]
        public async Task TestEnableAsyncSuccess(long id, ShopInventory shopInventory)
        {
            bool isPass = false;

            _mockShopInventoryDao
             .Setup(x => x.GetByIdAsync(id))
             .ReturnsAsync(shopInventory);

            _mockShopInventoryDao
             .Setup(x => x.UpdateAsync(shopInventory))
             .Callback<ShopInventory>(input =>
             {
                 if (input.Id == id &&
                     input.IsEnable) 
                 {
                     isPass = true;
                 }
             })
             .Returns(Task.FromResult(false));

            try
            {
                await _shopInventoryService.EnableAsync(id, true);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試 DisableAsync (成功)
        /// </summary>
        /// <param name="id">要停用的id</param>
        /// <param name="shopInventory">根據id找到的實體</param>
        [TestCaseSource(nameof(_disableSuccessCases))]
        public async Task TestDisableAsyncSuccess(long id, ShopInventory shopInventory)
        {
            bool isPass = false;

            _mockShopInventoryDao
             .Setup(x => x.GetByIdAsync(id))
             .ReturnsAsync(shopInventory);

            _mockShopInventoryDao
             .Setup(x => x.UpdateAsync(shopInventory))
             .Callback<ShopInventory>(input =>
             {
                 if (input.Id == id &&
                     !input.IsEnable)
                 {
                     isPass = true;
                 }
             })
             .Returns(Task.FromResult(false));

            try
            {
                await _shopInventoryService.EnableAsync(id, false);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試 IsProductEnableAsync (找不到id)
        /// </summary>
        [Test]
        public void TestIsProductEnableAsyncNotFindId() 
        {
            _mockShopInventoryDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            EShopException ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _shopInventoryService.IsProductEnableAsync(It.IsAny<long>()));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試 IsProductEnableAsync (成功)
        /// </summary>
        [Test]
        public async Task TestIsProductEnableAsyncSuccess()
        {
            _mockShopInventoryDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(new ShopInventory());

            try
            {
                await _shopInventoryService.IsProductEnableAsync(It.IsAny<long>());
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.Pass();
        }
    }
}
