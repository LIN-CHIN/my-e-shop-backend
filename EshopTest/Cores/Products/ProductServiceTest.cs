using EShopAPI.Common;
using EShopAPI.Cores.EShopUnits;
using EShopAPI.Cores.Products;
using EShopAPI.Cores.Products.DAOs;
using EShopAPI.Cores.Products.DTOs;
using EShopAPI.Cores.Products.Services;
using EShopAPI.Cores.ShopInventories;
using EShopAPI.Cores.ShopInventories.Services;
using EShopCores.Enums;
using EShopCores.Errors;
using EShopCores.Json;
using EShopCores.Responses;
using Jose;
using Moq;
using System.Text.Json;
using YamlDotNet.Core.Tokens;

namespace EshopTest.Cores.Products
{
    /// <summary>
    /// 測試產品Service 
    /// </summary>
    [TestFixture]
    public class ProductServiceTest
    {
        private Mock<IProductDao> _mockProductDao;
        private Mock<IShopInventoryService> _mockShopInventoryService;
        private LoginUserData _loginUserData;
        private IProductService _productService;

        private static readonly object[] _insertExistShopInventoryIdCases =
        {
            new object[]
            {
                new InsertProductDto
                {
                    ShopInventoryId = 1
                }
            },
            new object[]
            {
                new InsertProductDto
                {
                    ShopInventoryId = 2
                }
            }
        };
        private static readonly object[] _insertCompositeProductError =
       {
            new object[]
            {
                new InsertProductDto
                {
                    ShopInventoryId = 1
                },
                new ShopInventory
                {
                    Id = 2,
                    IsComposite = false,
                    IsCompositeOnly = true,
                }
            },
            new object[]
            {
                new InsertProductDto
                {
                    ShopInventoryId = 2
                },
                new ShopInventory
                {
                    Id = 2,
                    IsComposite = true,
                    IsCompositeOnly = false,
                }
            },
            new object[]
            {
                new InsertProductDto
                {
                    ShopInventoryId = 3
                },
                new ShopInventory
                {
                    Id = 3,
                    IsComposite = true,
                    IsCompositeOnly = true,
                }
            }
        };
        private static readonly object[] _insertSuccessCases =
        {
            new object[]
            {
                new InsertProductDto
                {
                    ShopInventoryId = 1,
                    Price = 300,
                    EShopUnitId = 1,
                    IsAlwaysSale = false,
                    Discount = 0.5,
                    SaleStartDate = 1698287488000,
                    SaleEndDate = 1698633088000,
                    IsUseCoupon = true,
                    VariantAttributes = new List<VariantAttributeJson>
                    {
                        new VariantAttributeJson
                        {
                            Key = "color",
                            Value = Guid.NewGuid().ToString()
                        }
                    },
                    Remarks = "備註001",
                    Languages = null
                },
                new Product
                {
                    Id = 1,
                    ShopInventoryId = 1,
                    Price = 300,
                    EShopUnitId = 1,
                    IsAlwaysSale = false,
                    Discount = 0.5,
                    SaleStartDate = 1698287488000,
                    SaleEndDate = 1698633088000,
                    IsUseCoupon = true,
                    VariantAttribute = JsonSerializer.SerializeToDocument(
                        new List<VariantAttributeJson>
                        {
                            new VariantAttributeJson
                            {
                                Key = "color",
                                Value = Guid.NewGuid().ToString()
                            }
                        }
                    ),
                    Remarks = "備註001",
                    Language = null
                },
                new ShopInventory
                {
                    Id = 1,
                    IsComposite = false,
                    IsCompositeOnly = false
                }
            },
            new object[]
            {
                new InsertProductDto
                {
                    ShopInventoryId = 2,
                    Price = 500,
                    EShopUnitId = 2,
                    IsAlwaysSale = true,
                    Discount = 0.9,
                    SaleStartDate = null,
                    SaleEndDate = null,
                    IsUseCoupon = false,
                    VariantAttributes = new List<VariantAttributeJson>
                    {
                        new VariantAttributeJson
                        {
                            Key = "color",
                            Value = Guid.NewGuid().ToString()
                        }
                    },
                    Remarks = "備註002",
                    Languages = null
                },
                new Product
                {
                    Id = 2,
                    ShopInventoryId = 2,
                    Price = 500,
                    EShopUnitId = 2,
                    IsAlwaysSale = true,
                    Discount = 0.9,
                    SaleStartDate = null,
                    SaleEndDate = null,
                    IsUseCoupon = false,
                    VariantAttribute = JsonSerializer.SerializeToDocument(
                        new List<VariantAttributeJson>
                        {
                            new VariantAttributeJson
                            {
                                Key = "color",
                                Value = Guid.NewGuid().ToString()
                            }
                        }
                    ),
                    Remarks = "備註002",
                    Language = null
                },
                new ShopInventory
                {
                    Id = 2,
                    IsComposite = false,
                    IsCompositeOnly = false
                }
            }
        };

        private static readonly object[] _updateNotFindIdCases =
        {
            new object[]
            {
                new UpdateProductDto
                {
                    Id = 1,
                }
            },
            new object[]
            {
                new UpdateProductDto
                {
                    Id = 2,
                }
            }
        };
        private static readonly object[] _updateSuccessCases =
        {
            new object[]
            {
                new UpdateProductDto
                {
                    Id = 1,
                    Price = 399,
                    EShopUnitId = 3,
                    IsAlwaysSale = true,
                    Discount = 0.7,
                    SaleStartDate = null,
                    SaleEndDate = null,
                    IsUseCoupon = true,
                    Remarks = "編輯備註001",
                    Languages = null
                },
                new Product
                {
                    Id = 1,
                    ShopInventoryId = 1,
                    Price = 300,
                    EShopUnitId = 1,
                    IsAlwaysSale = false,
                    Discount = 0.5,
                    SaleStartDate = 1698287488000,
                    SaleEndDate = 1698633088000,
                    IsUseCoupon = true,
                    VariantAttribute = JsonSerializer.SerializeToDocument(
                        new List<VariantAttributeJson>
                        {
                            new VariantAttributeJson
                            {
                                Key = "color",
                                Value = Guid.NewGuid().ToString()
                            }
                        }
                    ),
                    Remarks = "備註001",
                    Language = null
                }
            },
            new object[]
            {
                new UpdateProductDto
                {
                    Id = 2,
                    Price = 599,
                    EShopUnitId = 4,
                    IsAlwaysSale = false,
                    Discount = 0.2,
                    SaleStartDate = 1698287488000,
                    SaleEndDate = 1698633088000,
                    IsUseCoupon = true,
                    Remarks = "編輯備註002",
                    Languages = null
                },
                new Product
                {
                    Id = 2,
                    ShopInventoryId = 2,
                    Price = 500,
                    EShopUnitId = 2,
                    IsAlwaysSale = true,
                    Discount = 0.9,
                    SaleStartDate = null,
                    SaleEndDate = null,
                    IsUseCoupon = false,
                    VariantAttribute = JsonSerializer.SerializeToDocument(
                        new List<VariantAttributeJson>
                        {
                            new VariantAttributeJson
                            {
                                Key = "color",
                                Value = Guid.NewGuid().ToString()
                            }
                        }
                    ),
                    Remarks = "備註002",
                    Language = null
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
            _mockProductDao = new Mock<IProductDao>(MockBehavior.Strict);
            _mockShopInventoryService = new Mock<IShopInventoryService>(MockBehavior.Strict);

            _productService = new ProductService(_mockProductDao.Object,
                _mockShopInventoryService.Object,
                _loginUserData);
        }

        /// <summary>
        /// 測試InsertAsync(商店庫存id已存在)
        /// </summary>
        /// <param name="insertDto">要新增的產品資料</param>
        [TestCaseSource(nameof(_insertExistShopInventoryIdCases))]
        public void TestInsertAsyncExistShopInventoryId(InsertProductDto insertDto)
        {
            _mockProductDao.Setup(x => x.GetByShopInventoryIdAsync(It.IsAny<long>()))
                .ReturnsAsync(new Product());

            _mockProductDao.Setup(x => x.InsertAsync(It.IsAny<Product>()))
                .ReturnsAsync(new Product());

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _productService.InsertAsync(insertDto));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.DuplicateData));
        }

        /// <summary>
        /// 測試InsertAsync(組合產品不可以新增)
        /// </summary>
        /// <param name="insertDto">要新增的產品資料</param>
        /// <param name="shopInventory">商店庫存實體</param>
        [TestCaseSource(nameof(_insertCompositeProductError))]
        public void TestInsertAsyncCompositeProductError(InsertProductDto insertDto,
            ShopInventory shopInventory)
        {
            _mockProductDao.Setup(x => x.GetByShopInventoryIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            _mockShopInventoryService.Setup(x => x.ThrowNotFindByIdAsync(insertDto.ShopInventoryId))
                .ReturnsAsync(shopInventory);

            _mockProductDao.Setup(x => x.InsertAsync(It.IsAny<Product>()))
                .ReturnsAsync(new Product());

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _productService.InsertAsync(insertDto));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.NotInsertCompositeProduct));
        }

        /// <summary>
        /// 測試InsertAsync(商店庫存id已存在)
        /// </summary>
        /// <param name="insertDto">要新增的產品資料</param>
        /// <param name="rtnProduct">新增後回傳的實體</param>
        /// <param name="shopInventory">查詢到的商店庫存實體</param>
        [TestCaseSource(nameof(_insertSuccessCases))]
        public async Task TestInsertAsyncSuccess(InsertProductDto insertDto, Product rtnProduct,
            ShopInventory shopInventory)
        {
            bool isPass = false;

            _mockProductDao.Setup(x => x.GetByShopInventoryIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            _mockShopInventoryService.Setup(x => x.ThrowNotFindByIdAsync(insertDto.ShopInventoryId))
                .ReturnsAsync(shopInventory);

            _mockProductDao.Setup(x => x.InsertAsync(It.IsAny<Product>()))
                .Callback<Product>(product =>
                {
                    if (product.ShopInventoryId == insertDto.ShopInventoryId &&
                        product.Price == insertDto.Price &&
                        product.EShopUnitId == insertDto.EShopUnitId &&
                        product.IsAlwaysSale == insertDto.IsAlwaysSale &&
                        product.Discount == insertDto.Discount &&
                        product.SaleStartDate == insertDto.SaleStartDate &&
                        product.SaleEndDate == insertDto.SaleEndDate &&
                        product.IsUseCoupon == insertDto.IsUseCoupon &&
                        JsonSerializer.Serialize(product.VariantAttribute) ==
                        JsonSerializer.Serialize(insertDto.VariantAttributes) &&
                        product.Remarks == insertDto.Remarks &&
                        JsonSerializer.Serialize(product.Language) ==
                        JsonSerializer.Serialize(insertDto.Languages))
                    {
                        isPass = true;
                    }
                })
                .ReturnsAsync(rtnProduct);

            try
            {
                await _productService.InsertAsync(insertDto);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試UpdateAsync(產品id不存在)
        /// </summary>
        /// <param name="updateDto">要新增的產品資料</param>
        [TestCaseSource(nameof(_updateNotFindIdCases))]
        public void TestUpdateAsyncNotFindId(UpdateProductDto updateDto)
        {
            _mockProductDao.Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            _mockProductDao.Setup(x => x.UpdateAsync(It.IsAny<Product>()))
                .Returns(Task.FromResult(false));

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _productService.UpdateAsync(updateDto));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試UpadteAsync(成功)
        /// </summary>
        /// <param name="updateDto">要編輯的產品資料</param>
        /// <param name="product"></param>
        /// <returns></returns>
        [TestCaseSource(nameof(_updateSuccessCases))]
        public async Task TestUpdateAsyncSuccess(UpdateProductDto updateDto, Product product) 
        {
            bool isPass = false;

            _mockProductDao.Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(product);

            _mockProductDao
                .Setup(x => x.UpdateAsync(It.IsAny<Product>()))
                .Callback<Product>(input => 
                {
                    if (input.Id == updateDto.Id &&
                        input.Price == updateDto.Price &&
                        input.EShopUnitId == updateDto.EShopUnitId &&
                        input.IsAlwaysSale == updateDto.IsAlwaysSale &&
                        input.Discount == updateDto.Discount &&
                        input.SaleStartDate == updateDto.SaleStartDate &&
                        input.SaleEndDate == updateDto.SaleEndDate &&
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
                await _productService.UpdateAsync(updateDto);
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
            _mockProductDao.Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            _mockProductDao.Setup(x => x.DeleteAsync(It.IsAny<Product>()))
                .Returns(Task.FromResult(false));

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _productService.DeleteAsync(It.IsAny<long>()));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試DeleteAsync(成功)
        /// </summary>
        [Test]
        public async Task TestDeleteAsyncSuccess()
        {
            _mockProductDao.Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(new Product());

            _mockProductDao.Setup(x => x.DeleteAsync(It.IsAny<Product>()))
                .Returns(Task.FromResult(false));

            try
            {
                await _productService.DeleteAsync(It.IsAny<long>());
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.Pass();
        }

        /// <summary>
        /// 測試ThrowNotFindByIdAsync (失敗)
        /// </summary>
        [Test]
        public void TestThrowNotFindByIdAsyncError()
        {
            _mockProductDao.Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _productService.ThrowNotFindByIdAsync(It.IsAny<long>()));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試ThrowNotFindByIdAsync (成功)
        /// </summary>
        [Test]
        public async Task TestThrowNotFindByIdAsyncSuccess()
        {
            _mockProductDao.Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(new Product());

            try
            {
                await _productService.ThrowNotFindByIdAsync(It.IsAny<long>());
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.Pass();
        }

        /// <summary>
        /// 測試 ThrowExistShopInventoryIdAsync (失敗)
        /// </summary>
        [Test]
        public void TestThrowExistShopInventoryIdAsyncError()
        {
            _mockProductDao.Setup(x => x.GetByShopInventoryIdAsync(It.IsAny<long>()))
                .ReturnsAsync(new Product());

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _productService.ThrowExistShopInventoryIdAsync(It.IsAny<long>()));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.DuplicateData));
        }

        /// <summary>
        /// 測試 ThrowExistShopInventoryIdAsync (成功)
        /// </summary>
        [Test]
        public async Task TestThrowExistShopInventoryIdAsyncSuccess()
        {
            _mockProductDao.Setup(x => x.GetByShopInventoryIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            try
            {
                await _productService.ThrowExistShopInventoryIdAsync(It.IsAny<long>());
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.Pass();
        }
    }
}
