using EShopAPI.Common;
using EShopAPI.Cores.CompositeProducts;
using EShopAPI.Cores.CompositeProducts.DAOs;
using EShopAPI.Cores.CompositeProducts.DTOs;
using EShopAPI.Cores.CompositeProducts.Services;
using EShopAPI.Cores.Products;
using EShopCores.Enums;
using EShopCores.Errors;
using EShopCores.Json;
using EShopCores.Responses;
using Jose;
using Moq;
using System.Text.Json;

namespace EshopTest.Cores.CompositeProducts
{
    /// <summary>
    /// 測試組合產品的Service
    /// </summary>
    [TestFixture]
    public class CompositeProductServiceTest
    {
        private Mock<ICompositeProductDao> _mockCompositeProductDao;
        private ICompositeProductService _compositeProductService;
        private LoginUserData _loginUserData;

        private static readonly object[] _insertExistShopInventoryIdCases =
        {
            new object[]
            {
                new InsertCompositeProductDto
                {
                    ShopInventoryId = 1,
                }
            },
            new object[]
            {
                new InsertCompositeProductDto
                {
                    ShopInventoryId = 2,
                }
            }
        };
        private static readonly object[] _insertSuccessCases =
        {
            new object[]
            {
                new InsertCompositeProductDto
                {
                    ShopInventoryId = 1,
                    EShopUnitId = 1,
                    IsUseCoupon = true,
                    Remarks = "備註一",
                    Languages = null
                },
                new CompositeProduct
                {
                    Id = 1,
                    ShopInventoryId = 1,
                    EShopUnitId = 1,
                    IsUseCoupon = true,
                    Remarks = "備註一",
                    Language = null
                }
            },
            new object[]
            {
                new InsertCompositeProductDto
                {
                    ShopInventoryId = 2,
                    EShopUnitId = 2,
                    IsUseCoupon = false,
                    Remarks = "備註二",
                    Languages = new List<LanguageJson>
                    {
                        new LanguageJson {
                            LanguageKey = LanguageType.TW,
                            LanguageValue = "組合產品一"
                        },
                        new LanguageJson {
                            LanguageKey = LanguageType.EN_US,
                            LanguageValue = "composite-product-1"
                        }
                    }
                },
                new CompositeProduct
                {
                    Id = 2,
                    ShopInventoryId = 2,
                    EShopUnitId = 2,
                    IsUseCoupon = false,
                    Remarks = "備註二",
                    Language = JsonSerializer.SerializeToDocument(
                        new List<LanguageJson>
                        {
                            new LanguageJson {
                                LanguageKey = LanguageType.TW,
                                LanguageValue = "組合產品一"
                            },
                            new LanguageJson {
                                LanguageKey = LanguageType.EN_US,
                                LanguageValue = "composite-product-1"
                            }
                        }
                    )
                }
            }
        };

        private static readonly object[] _updateNotFindIdCases =
        {
            new object[]
            {
                new UpdateCompositeProductDto
                {
                    Id = 1
                }
            },
            new object[]
            {
                new UpdateCompositeProductDto
                {
                    Id = 2
                }
            }
        };
        private static readonly object[] _updateSuccessCases =
        {
            new object[]
            {
                new UpdateCompositeProductDto
                {
                    Id = 1,
                    EShopUnitId = 1,
                    IsUseCoupon = true,
                    Remarks = "編輯備註一",
                    Languages = null
                },
                new CompositeProduct
                {
                    Id = 1,
                    EShopUnitId = 2,
                    IsUseCoupon = false,
                    Remarks = "備註一",
                    Language = JsonSerializer.SerializeToDocument(
                        new List<LanguageJson>
                        {
                            new LanguageJson {
                                LanguageKey = LanguageType.TW,
                                LanguageValue = "組合產品一"
                            },
                            new LanguageJson {
                                LanguageKey = LanguageType.EN_US,
                                LanguageValue = "composite-product-1"
                            }
                        }
                    )
                }
            },
            new object[]
            {
                new UpdateCompositeProductDto
                {
                    Id = 2,
                    EShopUnitId = 2,
                    IsUseCoupon = false,
                    Remarks = "編輯備註二",
                    Languages = new List<LanguageJson>
                    {
                        new LanguageJson {
                            LanguageKey = LanguageType.TW,
                            LanguageValue = "組合產品一"
                        },
                        new LanguageJson {
                            LanguageKey = LanguageType.EN_US,
                            LanguageValue = "composite-product-1"
                        }
                    }
                },
                new CompositeProduct
                {
                    Id = 2,
                    EShopUnitId = 3,
                    IsUseCoupon = true,
                    Remarks = "備註一",
                    Language = null
                }
            }
        };

        private static readonly object[] _enableSuccessCases =
       {
            new object[]
            {
                1,
                new CompositeProduct
                {
                    Id = 1,
                    IsEnable = false
                }
            },
            new object[]
            {
                2,
                new CompositeProduct
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
                new CompositeProduct
                {
                    Id = 1,
                    IsEnable = true
                }
            },
            new object[]
            {
                2,
                new CompositeProduct
                {
                    Id = 2,
                    IsEnable = true
                }
            }
        };

        [SetUp]
        public void SetUp() 
        {
            _loginUserData = new LoginUserData
            {
                UserNumber = "shopAdmin"
            };

            _mockCompositeProductDao = new Mock<ICompositeProductDao>(MockBehavior.Strict);
            _compositeProductService = new CompositeProductService(
                _mockCompositeProductDao.Object,
                _loginUserData
            );
        }

        /// <summary>
        /// 測試InsertAsync(商店庫存id已存在)
        /// </summary>
        /// <param name="insertDto"></param>
        [TestCaseSource(nameof(_insertExistShopInventoryIdCases))]
        public void TestInsertAsyncExistShopInventoryId(InsertCompositeProductDto insertDto) 
        {
            _mockCompositeProductDao
                .Setup(x => x.GetByShopInventoryIdAsync(It.IsAny<long>()))
                .ReturnsAsync(new CompositeProduct());

            _mockCompositeProductDao
                .Setup(x => x.InsertAsync(It.IsAny<CompositeProduct>()))
                .ReturnsAsync(It.IsAny<CompositeProduct>());

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _compositeProductService
                   .InsertAsync(insertDto));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.DuplicateData));
        }

        /// <summary>
        /// 測試InsertAsync(成功)
        /// </summary>
        /// <param name="insertDto">要新增的組合產品資訊</param>
        /// <param name="rtnCompositeProduct">新增後回傳的組合產品實體</param>
        [TestCaseSource(nameof(_insertSuccessCases))]
        public async Task TestInsertAsyncSuccess(InsertCompositeProductDto insertDto,
            CompositeProduct rtnCompositeProduct)
        {
            bool isPass = false;

            _mockCompositeProductDao
                .Setup(x => x.GetByShopInventoryIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            _mockCompositeProductDao
                .Setup(x => x.InsertAsync(It.IsAny<CompositeProduct>()))
                .Callback<CompositeProduct>(compositeProduct => 
                {
                    if (compositeProduct.ShopInventoryId == insertDto.ShopInventoryId &&
                        compositeProduct.EShopUnitId == insertDto.EShopUnitId &&
                        compositeProduct.IsUseCoupon == insertDto.IsUseCoupon &&
                        compositeProduct.Remarks == insertDto.Remarks &&
                        JsonSerializer.Serialize(compositeProduct.Language) ==
                        JsonSerializer.Serialize(insertDto.Languages))
                    {
                        isPass = true;
                    }
                })
                .ReturnsAsync(rtnCompositeProduct);

            try
            {
                await _compositeProductService.InsertAsync(insertDto);
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
        /// <param name="updateDto"></param>
        [TestCaseSource(nameof(_updateNotFindIdCases))]
        public void TestUpdateAsyncNotFindId(UpdateCompositeProductDto updateDto)
        {
            _mockCompositeProductDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            _mockCompositeProductDao
                .Setup(x => x.UpdateAsync(It.IsAny<CompositeProduct>()))
                .Returns(Task.FromResult(false));

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _compositeProductService
                   .UpdateAsync(updateDto));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試UpdateAsync(成功)
        /// </summary>
        /// <param name="updateDto">要編輯的組合產品資訊</param>
        /// <param name="compositeProduct">根據id取得的組合產品實體</param>
        [TestCaseSource(nameof(_updateSuccessCases))]
        public async Task TestUpdateAsyncSuccess(UpdateCompositeProductDto updateDto,
            CompositeProduct compositeProduct )
        {
            bool isPass = false;

            _mockCompositeProductDao
                .Setup(x => x.GetByIdAsync(updateDto.Id))
                .ReturnsAsync(compositeProduct);

            _mockCompositeProductDao
                .Setup(x => x.UpdateAsync(It.IsAny<CompositeProduct>()))
                .Callback<CompositeProduct>(input =>
                {
                    if (input.Id == updateDto.Id &&
                        input.EShopUnitId == updateDto.EShopUnitId &&
                        input.IsUseCoupon == updateDto.IsUseCoupon &&
                        input.Remarks == updateDto.Remarks &&
                        JsonSerializer.Serialize(input.Language) ==
                        JsonSerializer.Serialize(updateDto.Languages))
                    {
                        isPass = true;
                    }
                })
                .Returns(Task.FromResult(false));

            try
            {
                await _compositeProductService.UpdateAsync(updateDto);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試DeleteAsync(產品id不存在)
        /// </summary>
        [Test]
        public void TestDeleteAsyncNotFindId()
        {
            _mockCompositeProductDao.Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            _mockCompositeProductDao.Setup(x => x.DeleteAsync(It.IsAny<CompositeProduct>()))
                .Returns(Task.FromResult(false));

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _compositeProductService.DeleteAsync(It.IsAny<long>()));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試DeleteAsync(成功)
        /// </summary>
        [Test]
        public async Task TestDeleteAsyncSuccess()
        {
            _mockCompositeProductDao.Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(new CompositeProduct());

            _mockCompositeProductDao.Setup(x => x.DeleteAsync(It.IsAny<CompositeProduct>()))
                .Returns(Task.FromResult(false));

            try
            {
                await _compositeProductService.DeleteAsync(It.IsAny<long>());
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.Pass();
        }

        /// <summary>
        /// 測試EnableAsync(失敗)
        /// </summary>
        [Test]
        public void TestEnableAsyncError()
        {
            _mockCompositeProductDao.Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _compositeProductService.EnableAsync(It.IsAny<long>(), true));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試EnableAsync(啟用成功)
        /// </summary>
        /// <param name="id">要啟用的id</param>
        /// <param name="compositeProduct">根據id查到要啟用的實體</param>
        [TestCaseSource(nameof(_enableSuccessCases))]
        public async Task TestEnableAsyncSuccess(long id, CompositeProduct compositeProduct)
        {
            bool isPass = false;

            _mockCompositeProductDao.Setup(x => x.GetByIdAsync(id))
                .ReturnsAsync(compositeProduct);

            _mockCompositeProductDao.Setup(x => x.UpdateAsync(It.IsAny<CompositeProduct>()))
                .Callback<CompositeProduct>(input =>
                {
                    if (input.Id == compositeProduct.Id &&
                        input.IsEnable &&
                        compositeProduct.UpdateUser != null &&
                        compositeProduct.UpdateDate != null)
                    {
                        isPass = true;
                    }
                })
                .Returns(Task.FromResult(false));
            try
            {
                await _compositeProductService.EnableAsync(id, true);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試DisableAsync(停用成功)
        /// </summary>
        /// <param name="id">要停用的id</param>
        /// <param name="compositeProduct">根據id查到要停用的實體</param>
        [TestCaseSource(nameof(_disableSuccessCases))]
        public async Task TestDisableAsyncSuccess(long id, CompositeProduct compositeProduct)
        {
            bool isPass = false;

            _mockCompositeProductDao.Setup(x => x.GetByIdAsync(id))
                .ReturnsAsync(compositeProduct);

            _mockCompositeProductDao.Setup(x => x.UpdateAsync(It.IsAny<CompositeProduct>()))
                .Callback<CompositeProduct>(input =>
                {
                    if (input.Id == compositeProduct.Id &&
                        !input.IsEnable &&
                        compositeProduct.UpdateUser != null &&
                        compositeProduct.UpdateDate != null)
                    {
                        isPass = true;
                    }
                })
                .Returns(Task.FromResult(false));
            try
            {
                await _compositeProductService.EnableAsync(id, false);
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
            _mockCompositeProductDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _compositeProductService
                   .ThrowNotFindByIdAsync(It.IsAny<long>()));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試ThrowNotFindByIdAsync(成功)
        /// </summary>
        [Test]
        public async Task TestThrowNotFindByIdAsyncSuccess()
        {
            _mockCompositeProductDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(new CompositeProduct());

            try
            {
                await _compositeProductService.ThrowNotFindByIdAsync(It.IsAny<long>());
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.Pass();
        }

        /// <summary>
        /// 測試ThrowExistShopInventoryIdAsync(失敗)
        /// </summary>
        [Test]
        public void TestThrowExistShopInventoryIdAsyncError()
        {
            _mockCompositeProductDao
                .Setup(x => x.GetByShopInventoryIdAsync(It.IsAny<long>()))
                .ReturnsAsync(new CompositeProduct());

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _compositeProductService
                   .ThrowExistShopInventoryIdAsync(It.IsAny<long>()));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.DuplicateData));
        }

        /// <summary>
        /// 測試ThrowExistShopInventoryIdAsync(成功)
        /// </summary>
        [Test]
        public async Task TestThrowExistShopInventoryIdAsyncSuccess()
        {
            _mockCompositeProductDao
                .Setup(x => x.GetByShopInventoryIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            try
            {
                await _compositeProductService.ThrowExistShopInventoryIdAsync(It.IsAny<long>());
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.Pass();
        }
    }
}
