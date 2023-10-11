using EShopAPI.Cores.ProductMasters;
using EShopAPI.Cores.ProductMasters.DAOs;
using EShopAPI.Cores.ProductMasters.DTOs;
using EShopAPI.Cores.ProductMasters.Json;
using EShopAPI.Cores.ProductMasters.Services;
using EShopCores.Enums;
using EShopCores.Errors;
using EShopCores.Json;
using EShopCores.Responses;
using Moq;
using NUnit.Framework;
using System.Text.Json;
using System.Xml.Linq;

namespace EshopTest.Cores.ProductMasters
{
    [TestFixture]
    public class ProductMasterServiceTest
    {
        private Mock<IProductMasterDao> _mockProductMasterDao;
        private IProductMasterService _productMasterService;

        private static readonly object[] _insertCases = 
        {
            new object[] 
            {
                new InsertProductMasterDto()
                {
                    Number = "PM2023100600001",
                    Name = "滑鼠",
                    ProductType = ProductType.Variant,
                    IsEnable = true,
                    VariantAttributes = new List<VariantAttributeJson>()
                    {
                        new VariantAttributeJson()
                        {
                            AttributeKey = "color",
                            AttributeValue = new List<string>(){ "red", "bule" }
                        },
                        new VariantAttributeJson()
                        {
                            AttributeKey = "size",
                            AttributeValue = new List<string>(){ "L", "M" }
                        }
                    },
                    CreateUser = "shopAdmin",
                    Remarks = "新增備註01",
                    Languages = new List<LanguageJson>()
                    {
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.TW,
                            LanguageValue = "滑鼠"
                        },
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.EN_US,
                            LanguageValue = "Mouse"
                        },
                    }
                },
                new ProductMaster()
                {
                    Id = 1,
                    Number = "PM2023100600001",
                    Name = "滑鼠",
                    ProductType = ProductType.Variant,
                    IsEnable = true,
                    VariantAttribute = JsonSerializer.SerializeToDocument(
                        new List<VariantAttributeJson>()
                        {
                            new VariantAttributeJson()
                            {
                                AttributeKey = "color",
                                AttributeValue = new List<string>(){ "red", "bule" }
                            },
                            new VariantAttributeJson()
                            {
                                AttributeKey = "size",
                                AttributeValue = new List<string>(){ "L", "M" }
                            }
                        }
                    ),
                    CreateUser = "shopAdmin",
                    Remarks = "新增備註01",
                    Language = JsonSerializer.SerializeToDocument(
                        new List<LanguageJson>()
                        {
                            new LanguageJson
                            {
                                LanguageKey = LanguageType.TW,
                                LanguageValue = "滑鼠"
                            },
                            new LanguageJson
                            {
                                LanguageKey = LanguageType.EN_US,
                                LanguageValue = "Mouse"
                            },
                        }
                    )
                }
            },
            new object[]
            {
                new InsertProductMasterDto()
                {
                    Number = "PM2023100600002",
                    Name = "鍵盤",
                    ProductType = ProductType.Variant,
                    IsEnable = true,
                    VariantAttributes = new List<VariantAttributeJson>()
                    {
                        new VariantAttributeJson()
                        {
                            AttributeKey = "color",
                            AttributeValue = new List<string>(){ "red", "bule" }
                        },
                        new VariantAttributeJson()
                        {
                            AttributeKey = "size",
                            AttributeValue = new List<string>(){ "L", "M" }
                        }
                    },
                    CreateUser = "shopAdmin",
                    Remarks = "新增備註02",
                    Languages = new List<LanguageJson>()
                    {
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.TW,
                            LanguageValue = "鍵盤"
                        },
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.EN_US,
                            LanguageValue = "Keyboard"
                        },
                    }
                },
                new ProductMaster()
                {
                    Id = 2,
                    Number = "PM2023100600002",
                    Name = "鍵盤",
                    ProductType = ProductType.Variant,
                    IsEnable = true,
                    VariantAttribute = JsonSerializer.SerializeToDocument(
                        new List<VariantAttributeJson>()
                        {
                            new VariantAttributeJson()
                            {
                                AttributeKey = "color",
                                AttributeValue = new List<string>(){ "red", "bule" }
                            },
                            new VariantAttributeJson()
                            {
                                AttributeKey = "size",
                                AttributeValue = new List<string>(){ "L", "M" }
                            }
                        }
                    ),
                    CreateUser = "shopAdmin",
                    Remarks = "新增備註02",
                    Language = JsonSerializer.SerializeToDocument(
                        new List<LanguageJson>()
                        {
                            new LanguageJson
                            {
                                LanguageKey = LanguageType.TW,
                                LanguageValue = "鍵盤"
                            },
                            new LanguageJson
                            {
                                LanguageKey = LanguageType.EN_US,
                                LanguageValue = "Keyboard"
                            },
                        }
                    )
                }
            },
            new object[]
            {
                new InsertProductMasterDto()
                {
                    Number = "PM2023100600003",
                    Name = "單一商品",
                    ProductType = ProductType.Fiexd,
                    IsEnable = true,
                    VariantAttributes = null,
                    CreateUser = "shopAdmin",
                    Remarks = null,
                    Languages = new List<LanguageJson>()
                    {
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.TW,
                            LanguageValue = "單一商品"
                        }
                    }
                },
                new ProductMaster()
                {
                    Id = 3,
                    Number = "PM2023100600003",
                    Name = "單一商品",
                    ProductType = ProductType.Fiexd,
                    IsEnable = true,
                    VariantAttribute = null,
                    CreateUser = "shopAdmin",
                    Remarks = null,
                    Language = JsonSerializer.SerializeToDocument(
                        new List<LanguageJson>()
                        {
                            new LanguageJson
                            {
                                LanguageKey = LanguageType.TW,
                                LanguageValue = "單一商品"
                            }
                        }
                    )
                }
            }
        };

        /// <summary>
        /// Setup 
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _mockProductMasterDao = new Mock<IProductMasterDao>(MockBehavior.Strict);
            _productMasterService = new ProductMasterService(_mockProductMasterDao.Object);
        }

        /// <summary>
        /// 測試新增 (成功)
        /// </summary>
        /// <param name="insertDto">要新增的資料</param>
        /// <param name="productMaster">新增成功後的實體</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_insertCases))]
        public async Task TaskInsertSuccess(InsertProductMasterDto insertDto, ProductMaster productMaster)
        {
            bool isPass = false; 

            _mockProductMasterDao
                .Setup(x => x.GetByNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(value: null);

            _mockProductMasterDao
                .Setup(x => x.InsertAsync(It.IsAny<ProductMaster>()))
                .Callback<ProductMaster>( entity => 
                {
                    if(insertDto.Number == entity.Number &&
                        insertDto.Name == entity.Name &&
                        insertDto.ProductType == entity.ProductType &&
                        insertDto.IsEnable == entity.IsEnable &&
                        JsonSerializer.Serialize(insertDto.VariantAttributes) ==
                        JsonSerializer.Serialize(entity.VariantAttribute) &&
                        insertDto.CreateUser == entity.CreateUser &&
                        insertDto.Remarks == entity.Remarks) 
                    {
                        isPass = true;
                    }
                })
                .ReturnsAsync(productMaster);

            ProductMaster result;

            try
            {
                result = await _productMasterService.InsertAsync(insertDto);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(productMaster, Is.Not.Null);
            Assert.That(productMaster.Id, Is.Not.Zero);
            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試新增 (重複的產品代碼)
        /// </summary>
        /// <param name="insertDto">要新增的資料</param>
        /// <param name="productMaster">新增成功後的實體</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_insertCases))]
        public void TaskInsertDuplicatedNumberAsync(InsertProductMasterDto insertDto, ProductMaster productMaster) 
        {
            _mockProductMasterDao
                .Setup(x => x.GetByNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(new ProductMaster());

            _mockProductMasterDao
                .Setup(x => x.InsertAsync(insertDto.ToEntity()))
                .ReturnsAsync(productMaster);

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
                await _productMasterService.InsertAsync(insertDto));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.DuplicateData));
        }

        /// <summary>
        /// 測試根據主產品代碼取得產品主檔，如果代碼已存在，會不會正常throw exception
        /// </summary>
        /// <returns></returns>
        [Test]
        public void TestThrowExistByNumberAsync() 
        {
            _mockProductMasterDao
                .Setup(x => x.GetByNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(new ProductMaster());

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
                await _productMasterService.ThrowExistByNumberAsync(It.IsAny<string>()));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.DuplicateData));
        }

        /// <summary>
        /// 測試根據產品主檔id取得產品主檔，如果id不存在，會不會正常throw exception
        /// </summary>
        /// <returns></returns>
        [Test]
        public void TestThrowNotFindByIdAsync()
        {
            _mockProductMasterDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
                await _productMasterService.ThrowNotFindByIdAsync(It.IsAny<long>()));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }
    }
}
