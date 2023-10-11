using EShopAPI.Cores.ProductMasters;
using EShopAPI.Cores.ProductMasters.DAOs;
using EShopAPI.Cores.ProductMasters.DTOs;
using EShopAPI.Cores.ProductMasters.Json;
using EShopAPI.Cores.ProductMasters.Services;
using EShopCores.Enums;
using EShopCores.Errors;
using EShopCores.Extensions;
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

        private static readonly object[] _updateCases =
       {
            new object[]
            {
                new UpdateProductMasterDto()
                {
                    Id = 1,
                    Name = "編輯滑鼠",
                    VariantAttributes = new List<VariantAttributeJson>()
                    {
                        new VariantAttributeJson()
                        {
                            AttributeKey = "color",
                            AttributeValue = new List<string>(){ "edit-red", "edit-bule" }
                        },
                        new VariantAttributeJson()
                        {
                            AttributeKey = "size",
                            AttributeValue = new List<string>(){ "edit-L", "edit-M" }
                        }
                    },
                    UpdateUser = "shopAdmin",
                    Remarks = "編輯備註01",
                    Languages = new List<LanguageJson>()
                    {
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.TW,
                            LanguageValue = "編輯滑鼠"
                        },
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.EN_US,
                            LanguageValue = "edit-Mouse"
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
                new UpdateProductMasterDto()
                {
                    Id = 2,
                    Name = "編輯鍵盤",
                    VariantAttributes = new List<VariantAttributeJson>()
                    {
                        new VariantAttributeJson()
                        {
                            AttributeKey = "color",
                            AttributeValue = new List<string>(){ "edit-red", "edit-bule" }
                        },
                        new VariantAttributeJson()
                        {
                            AttributeKey = "size",
                            AttributeValue = new List<string>(){ "edit-L", "edit-M" }
                        }
                    },
                    UpdateUser = "shopAdmin",
                    Remarks = "編輯備註02",
                    Languages = new List<LanguageJson>()
                    {
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.TW,
                            LanguageValue = "編輯鍵盤"
                        },
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.EN_US,
                            LanguageValue = "edit-Keyboard"
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
            }
        };

        private static readonly object[] _enableCases =
        {
            new object[]
            {
                new ProductMaster()
                {
                    Id = 1,
                    IsEnable = false,
                    UpdateDate = null
                }
            },
            new object[]
            {
                new ProductMaster()
                {
                    Id = 2,
                    IsEnable = false,
                    UpdateDate = null
                }
            },
            new object[]
            {
                new ProductMaster()
                {
                    Id = 3,
                    IsEnable = false,
                    UpdateDate = null
                }
            }
        };

        private static readonly object[] _disableCases =
        {
            new object[]
            {
                new ProductMaster()
                {
                    Id = 1,
                    IsEnable = true,
                    UpdateDate = null
                }
            },
            new object[]
            {
                new ProductMaster()
                {
                    Id = 2,
                    IsEnable = true,
                    UpdateDate = null
                }
            },
            new object[]
            {
                new ProductMaster()
                {
                    Id = 3,
                    IsEnable = true,
                    UpdateDate = null
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

            Assert.Multiple(() =>
            {
                Assert.That(productMaster, Is.Not.Null);
                Assert.That(productMaster.Id, Is.Not.Zero);
                Assert.That(isPass, Is.True);
            });
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
        /// 測試編輯 (找不到產品id)
        /// </summary>
        /// <param name="updateDto">要編輯的資料</param>
        /// <param name="productMaster">編輯前的實體</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_updateCases))]
        public void TaskUpdateNotFindIdAsync(UpdateProductMasterDto updateDto, ProductMaster productMaster)
        {
            _mockProductMasterDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            _mockProductMasterDao
                .Setup(x => x.UpdateAsync(updateDto.SetEntity(productMaster)))
                .Returns(Task.CompletedTask);

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
                await _productMasterService.UpdateAsync(updateDto));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試編輯 (成功)
        /// </summary>
        /// <param name="updateDto">要編輯的資料</param>
        /// <param name="productMaster">編輯前的實體</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_updateCases))]
        public async Task TaskUpdateSuccessAsync(UpdateProductMasterDto updateDto, ProductMaster productMaster)
        {
            bool isPass = false;

            _mockProductMasterDao
                .Setup(x => x.GetByIdAsync(updateDto.Id))
                .ReturnsAsync(productMaster);

            _mockProductMasterDao
                .Setup(x => x.UpdateAsync(updateDto.SetEntity(productMaster)))
                .Callback<ProductMaster>(inputParams =>
                {
                    if (inputParams.Id == updateDto.Id &&
                        inputParams.Name == updateDto.Name &&
                        JsonSerializer.Serialize(inputParams.VariantAttribute) ==
                        JsonSerializer.Serialize(updateDto.VariantAttributes) &&
                        inputParams.UpdateUser == updateDto.UpdateUser &&
                        inputParams.UpdateDate == updateDto.UpdateDate &&
                        inputParams.Remarks == updateDto.Remarks &&
                        JsonSerializer.Serialize(inputParams.Language) ==
                        JsonSerializer.Serialize(updateDto.Languages))
                    {
                        isPass = true;
                    }
                })
                .Returns(Task.CompletedTask);

            try
            {
                await _productMasterService.UpdateAsync(updateDto);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試啟用 (找不到id)
        /// </summary>
        /// <param name="productMaster">要被啟用的資料</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_enableCases))]
        public void TaskEnableNotFindIdAsync(ProductMaster productMaster)
        {
            _mockProductMasterDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            _mockProductMasterDao
                .Setup(x => x.UpdateAsync(productMaster))
                .Returns(Task.CompletedTask);

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
                await _productMasterService.EnableAsync(productMaster.Id, true));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試啟用 (成功)
        /// </summary>
        /// <param name="productMaster">要被啟用的資料</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_enableCases))]
        public async Task TaskEnableSuccessAsync(ProductMaster productMaster)
        {
            bool isPass = false;

            _mockProductMasterDao
                .Setup(x => x.GetByIdAsync(productMaster.Id))
                .ReturnsAsync(productMaster);

            _mockProductMasterDao
                .Setup(x => x.UpdateAsync(productMaster))
                .Callback<ProductMaster>(inputParams =>
                {
                    if (inputParams.Id == productMaster.Id &&
                        inputParams.UpdateDate is not null &&
                        inputParams.IsEnable)
                    {
                        isPass = true;
                    }
                })
                .Returns(Task.CompletedTask);

            try
            {
                await _productMasterService.EnableAsync(productMaster.Id, true);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試停用 (找不到id)
        /// </summary>
        /// <param name="productMaster">要被停用的資料</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_disableCases))]
        public void TaskDisableNotFindIdAsync(ProductMaster productMaster)
        {
            _mockProductMasterDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            _mockProductMasterDao
                .Setup(x => x.UpdateAsync(productMaster))
                .Returns(Task.CompletedTask);

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
                await _productMasterService.EnableAsync(productMaster.Id, false));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試停用 (成功)
        /// </summary>
        /// <param name="productMaster">要被停用的資料</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_disableCases))]
        public async Task TaskDisableSuccessAsync(ProductMaster productMaster)
        {
            bool isPass = false;

            _mockProductMasterDao
                .Setup(x => x.GetByIdAsync(productMaster.Id))
                .ReturnsAsync(productMaster);

            _mockProductMasterDao
                .Setup(x => x.UpdateAsync(productMaster))
                .Callback<ProductMaster>(inputParams =>
                {
                    if (inputParams.Id == productMaster.Id &&
                        inputParams.UpdateDate is not null &&
                        !inputParams.IsEnable)
                    {
                        isPass = true;
                    }
                })
                .Returns(Task.CompletedTask);

            try
            {
                await _productMasterService.EnableAsync(productMaster.Id, false);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(isPass, Is.True);
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
