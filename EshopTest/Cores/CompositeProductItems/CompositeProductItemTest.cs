using EShopAPI.Common;
using EShopAPI.Cores.CompositeProductItems;
using EShopAPI.Cores.CompositeProductItems.DAOs;
using EShopAPI.Cores.CompositeProductItems.DTOs;
using EShopAPI.Cores.CompositeProductItems.Services;
using EShopAPI.Cores.ShopInventories;
using EShopAPI.Cores.ShopInventories.Services;
using EShopCores.Errors;
using EShopCores.Responses;
using Moq;
using System.Text.Json;

namespace EshopTest.Cores.CompositeProductItems
{
    /// <summary>
    /// 測試組合產品項目
    /// </summary>
    [TestFixture]
    public class CompositeProductItemTest
    {
        private Mock<ICompositeProductItemDao> _mockCompositeProductItemDao;
        private ICompositeProductItemService _compositeProductItemService;
        private Mock<IShopInventoryService> _mockShopInventoryService;
        private LoginUserData _loginUserData;

        private static readonly object[] _insertExistProductCases =
        {
            new object[]
            {
                new InsertCompositeProductItemDto
                {
                    CompositeProductId = 1,
                    ShopInventoryId = 1

                },
                new List<CompositeProductItem>
                {
                    new CompositeProductItem 
                    {
                        CompositeProductId = 1,
                        ShopInventoryId = 1
                    }
                }
            },
            new object[]
            {
                new InsertCompositeProductItemDto
                {
                    CompositeProductId = 1,
                    ShopInventoryId = 2

                },
                new List<CompositeProductItem>
                {
                    new CompositeProductItem
                    {
                         CompositeProductId = 1,
                         ShopInventoryId = 2
                    }
                }
            }
        };
        private static readonly object[] _insertDisableCases =
        {
            new object[]
            {
                new InsertCompositeProductItemDto
                {
                    CompositeProductId = 1,
                    ShopInventoryId = 1

                },
                new List<CompositeProductItem>
                {
                    new CompositeProductItem
                    {
                        CompositeProductId = 1,
                        ShopInventoryId = 2
                    }
                },
                new ShopInventory
                {
                    Id = 1,
                    IsEnable = false
                }
            },
            new object[]
            {
                new InsertCompositeProductItemDto
                {
                    CompositeProductId = 1,
                    ShopInventoryId = 2

                },
                new List<CompositeProductItem>
                {
                    new CompositeProductItem
                    {
                         CompositeProductId = 1,
                         ShopInventoryId = 3
                    }
                },
                new ShopInventory
                {
                    Id = 2,
                    IsEnable = false
                }
            }
        };

        private static readonly object[] _insertSuccessCases =
        {
            new object[]
            {
                new InsertCompositeProductItemDto
                {
                    CompositeProductId = 1,
                    ShopInventoryId = 1,
                    Price = 500,
                    Count = 3,
                    IsAlwaysSale = true,
                    Discount = 0.5,
                    SaleStartDate = null,
                    SaleEndDate = null,
                    EshopUnitId = 1,
                    Remarks = "新增備註01",
                    Languages = null
                },
                new CompositeProductItem
                {
                    Id = 1,
                    CompositeProductId = 1,
                    ShopInventoryId = 1,
                    Price = 500,
                    Count = 3,
                    IsAlwaysSale = true,
                    Discount = 0.5,
                    SaleStartDate = null,
                    SaleEndDate = null,
                    EshopUnitId = 1,
                    Remarks = "新增備註01",
                    Language = null
                },
            },
            new object[]
            {
                new InsertCompositeProductItemDto
                {
                    CompositeProductId = 2,
                    ShopInventoryId = 2,
                    Price = 900,
                    Count = 1,
                    IsAlwaysSale = true,
                    Discount = 0.5,
                    SaleStartDate = null,
                    SaleEndDate = null,
                    EshopUnitId = 1,
                    Remarks = "新增備註02",
                    Languages = null
                },
                new CompositeProductItem
                {
                    Id = 1,
                    CompositeProductId = 2,
                    ShopInventoryId = 2,
                    Price = 900,
                    Count = 1,
                    IsAlwaysSale = true,
                    Discount = 0.5,
                    SaleStartDate = null,
                    SaleEndDate = null,
                    EshopUnitId = 1,
                    Remarks = "新增備註02",
                    Language = null
                }
            }


        };

        private static readonly object[] _updateNotFindIdCases =
        {
            new object[]
            {
                new UpdateCompositeProductItemDto
                {
                    Id = 1
                }
            },
            new object[]
            {
                new UpdateCompositeProductItemDto
                {
                    Id = 2
                }
            }
        };
        private static readonly object[] _updateSuccessCases =
        {
            new object[]
            {
                new UpdateCompositeProductItemDto
                {
                    Id = 1,
                    Price = 900,
                    Count = 1,
                    IsAlwaysSale = false,
                    Discount = 0.59,
                    SaleStartDate = 1699146591000,
                    SaleEndDate = 1699232991000,
                    EshopUnitId = 5,
                    Remarks = "編輯備註01",
                    Languages = null
                },
                new CompositeProductItem
                {
                    Id = 1,
                    CompositeProductId = 1,
                    ShopInventoryId = 1,
                    Price = 500,
                    Count = 3,
                    IsAlwaysSale = true,
                    Discount = 0.5,
                    SaleStartDate = null,
                    SaleEndDate = null,
                    EshopUnitId = 1,
                    Remarks = "新增備註01",
                    Language = null
                },
            },
            new object[]
            {
                new UpdateCompositeProductItemDto
                {
                    Id = 1,
                    Price = 900,
                    Count = 1,
                    IsAlwaysSale = false,
                    Discount = 0.4,
                    SaleStartDate = null,
                    SaleEndDate = null,
                    EshopUnitId = 5,
                    Remarks = "編輯備註02",
                    Languages = null
                },
                new CompositeProductItem
                {
                    Id = 2,
                    CompositeProductId = 2,
                    ShopInventoryId = 2,
                    Price = 500,
                    Count = 3,
                    IsAlwaysSale = false,
                    Discount = 0.5,
                    SaleStartDate = 1699146591000,
                    SaleEndDate = 1699232991000,
                    EshopUnitId = 1,
                    Remarks = "新增備註02",
                    Language = null
                },
            }
        };

        [SetUp]
        public void SetUp()
        {
            _loginUserData = new LoginUserData
            {
                UserNumber = "shopAdmin"
            };

            _mockCompositeProductItemDao = new Mock<ICompositeProductItemDao>(MockBehavior.Strict);
            _mockShopInventoryService = new Mock<IShopInventoryService>(MockBehavior.Strict);

            _compositeProductItemService = new CompositeProductItemService(
                _mockCompositeProductItemDao.Object,
                _mockShopInventoryService.Object,
                _loginUserData);
        }

        /// <summary>
        /// 測試InsertAsync(同一個組合產品下已經有重複的產品)
        /// </summary>
        /// <param name="insertDto"></param>
        /// <param name="compositeProductItems"></param>
        [TestCaseSource(nameof(_insertExistProductCases))]
        public void TestInsertAsyncExistProduct(InsertCompositeProductItemDto insertDto,
            List<CompositeProductItem> compositeProductItems) 
        {
            _mockCompositeProductItemDao
                .Setup(x => x.GetByCompositeProductId(insertDto.CompositeProductId))
                .Returns(compositeProductItems.AsQueryable());

            _mockCompositeProductItemDao
                .Setup(x => x.InsertAsync(It.IsAny<CompositeProductItem>()))
                .ReturnsAsync(new CompositeProductItem());

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _compositeProductItemService.InsertAsync(insertDto));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.DuplicateData));
        }

        /// <summary>
        /// 測試 InsertAsync (當產品為停用時不可新增)
        /// </summary>
        /// <param name="insertDto">要新增的資料</param>
        /// <param name="compositeProductItems"></param>
        /// <param name="shopInventory"></param>
        [TestCaseSource(nameof(_insertDisableCases))]
        public void TestInsertAsyncDisable(InsertCompositeProductItemDto insertDto,
            List<CompositeProductItem> compositeProductItems,
            ShopInventory shopInventory)
        {
            _mockCompositeProductItemDao
               .Setup(x => x.GetByCompositeProductId(insertDto.CompositeProductId))
               .Returns(compositeProductItems.AsQueryable());

            _mockShopInventoryService
                .Setup(x => x.GetByIdAsync(insertDto.ShopInventoryId))
                .ReturnsAsync(shopInventory);

            _mockCompositeProductItemDao
                .Setup(x => x.InsertAsync(It.IsAny<CompositeProductItem>()))
                .ReturnsAsync(new CompositeProductItem());

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _compositeProductItemService.InsertAsync(insertDto));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.DataIsDisabled));
        }

        /// <summary>
        /// 測試InsertAsync(成功)
        /// </summary>
        /// <param name="insertDto">要新增的資料</param>
        /// <param name="rtnCompositeProductItem">新增後回傳的實體</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_insertSuccessCases))]
        public async Task TestInsertAsyncSuccess(InsertCompositeProductItemDto insertDto,
            CompositeProductItem rtnCompositeProductItem) 
        {
            bool isPass = false;

            _mockCompositeProductItemDao
               .Setup(x => x.GetByCompositeProductId(insertDto.CompositeProductId))
               .Returns(new List<CompositeProductItem>().AsQueryable());

            _mockCompositeProductItemDao
                .Setup(x => x.InsertAsync(It.IsAny<CompositeProductItem>()))
                .Callback<CompositeProductItem>( input => 
                {
                    if ( input.CompositeProductId == insertDto.CompositeProductId &&
                         input.ShopInventoryId == insertDto.ShopInventoryId &&
                         input.Price == insertDto.Price &&
                         input.Count == insertDto.Count &&
                         input.IsAlwaysSale == insertDto.IsAlwaysSale &&
                         input.Discount == insertDto.Discount &&
                         input.SaleStartDate == insertDto.SaleStartDate &&
                         input.SaleEndDate == insertDto.SaleEndDate &&
                         input.EshopUnitId == insertDto.EshopUnitId &&
                         input.Remarks == insertDto.Remarks &&
                         JsonSerializer.Serialize(input.Language) ==
                         JsonSerializer.Serialize(insertDto.Languages))
                    {
                        isPass = true;
                    }
                })
                .ReturnsAsync(rtnCompositeProductItem);

            try
            {
                await _compositeProductItemService.InsertAsync(insertDto);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試 UpdateAsync (找不到id) 
        /// </summary>
        /// <param name="updateDto">要編輯的資料</param>
        [TestCaseSource(nameof(_updateNotFindIdCases))]
        public void TestUpdateAsyncNotFindId(UpdateCompositeProductItemDto updateDto) 
        {
            _mockCompositeProductItemDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            _mockCompositeProductItemDao
                .Setup(x => x.UpdateAsync(It.IsAny<CompositeProductItem>()))
                .Returns(Task.FromResult(false));

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _compositeProductItemService.UpdateAsync(updateDto));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試 UpdateAsync (成功) 
        /// </summary>
        /// <param name="updateDto">要編輯的資料</param>
        /// <param name="compositeProductItem">要被編輯的資料(根據id找到)</param>
        [TestCaseSource(nameof(_updateSuccessCases))]
        public async Task TestUpdateAsyncSuccess(UpdateCompositeProductItemDto updateDto, CompositeProductItem compositeProductItem)
        {
            bool isPass = false; 

            _mockCompositeProductItemDao
                .Setup(x => x.GetByIdAsync(updateDto.Id))
                .ReturnsAsync(compositeProductItem);

            _mockCompositeProductItemDao
                .Setup(x => x.UpdateAsync(It.IsAny<CompositeProductItem>()))
                .Callback<CompositeProductItem>(input => 
                {
                    if ( input.Id == updateDto.Id &&
                         input.Price == updateDto.Price &&
                         input.Count == updateDto.Count &&
                         input.IsAlwaysSale == updateDto.IsAlwaysSale &&
                         input.Discount == updateDto.Discount &&
                         input.SaleStartDate == updateDto.SaleStartDate &&
                         input.SaleEndDate == updateDto.SaleEndDate &&
                         input.EshopUnitId == updateDto.EshopUnitId &&
                         JsonSerializer.Serialize(input.Language) ==
                         JsonSerializer.Serialize(updateDto.Languages)) 
                    {
                        isPass = true;
                    }
                })
                .Returns(Task.FromResult(false));

            try
            {
                await _compositeProductItemService.UpdateAsync(updateDto);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試 DeleteAsync (找不到id)
        /// </summary>
        [Test]
        public void TestDeleteAsyncNotFindId() 
        {
            _mockCompositeProductItemDao
                   .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                   .ReturnsAsync(value: null);

            _mockCompositeProductItemDao
                .Setup(x => x.DeleteAsync(It.IsAny<CompositeProductItem>()))
                .Returns(Task.FromResult(false));

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _compositeProductItemService.DeleteAsync(It.IsAny<long>()));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試 DeleteAsync (成功)
        /// </summary>
        [Test]
        public async Task TestDeleteAsyncSuccess()
        {
            _mockCompositeProductItemDao
                   .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                   .ReturnsAsync(new CompositeProductItem());

            _mockCompositeProductItemDao
                .Setup(x => x.DeleteAsync(It.IsAny<CompositeProductItem>()))
                .Returns(Task.FromResult(false));

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _compositeProductItemService.DeleteAsync(It.IsAny<long>()));

            try
            {
                await _compositeProductItemService.DeleteAsync(It.IsAny<long>());
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.Pass();
        }

        /// <summary>
        /// 測試ThrowNotFindByIdAsync(失敗)
        /// </summary>
        [Test]
        public void TestThrowNotFindByIdAsyncError()
        {
            _mockCompositeProductItemDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _compositeProductItemService
                   .ThrowNotFindByIdAsync(It.IsAny<long>()));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試ThrowNotFindByIdAsync(成功)
        /// </summary>
        [Test]
        public async Task TestThrowNotFindByIdAsyncSuccess()
        {
            _mockCompositeProductItemDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(new CompositeProductItem());

            try
            {
                await _compositeProductItemService.ThrowNotFindByIdAsync(It.IsAny<long>());
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.Pass();
        }
    }
}
