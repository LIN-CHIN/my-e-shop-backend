using EShopAPI.Common;
using EShopAPI.Cores.CustomVariantAttributes;
using EShopAPI.Cores.CustomVariantAttributes.DAOs;
using EShopAPI.Cores.CustomVariantAttributes.DTOs;
using EShopAPI.Cores.CustomVariantAttributes.Services;
using EShopCores.Enums;
using EShopCores.Errors;
using EShopCores.Json;
using EShopCores.Responses;
using Moq;
using System.Text.Json;

namespace EshopTest.Cores.CustomVariantAttributes
{
    /// <summary>
    /// 測試自訂變種屬性 Service
    /// </summary>
    [TestFixture]
    public class CustomVariantAttributeServiceTest
    {
        private Mock<ICustomVariantAttributeDao> _mockCustomVariantAttributeDao;
        private ICustomVariantAttributeService _customVariantAttributeService;
        private LoginUserData _loginUserData;

        private static readonly object[] _insertExistNumberCases =
        {
            new object[]
            {
                new InsertCustomVariantAttributeDto
                {
                    Number = "Test001"
                }
            },
            new object[]
            {
                new InsertCustomVariantAttributeDto
                {
                    Number = "Test002"
                }
            }
        };
        private static readonly object[] _insertSuccessCases =
        {
            new object[]
            {
                new InsertCustomVariantAttributeDto
                {
                    Number = "Test001",
                    Name = "測試屬性001",
                    AttributeType = CustomVariantAttributeType.Number,
                    IsEnable = true,
                    Options = new List<VariantAttributeOptionJson>
                    {
                        new VariantAttributeOptionJson
                        {
                            Name = "S",
                            Value = "S"
                        },
                        new VariantAttributeOptionJson
                        {
                            Name = "L",
                            Value = "L"
                        }
                    },
                    Remarks = "測試屬性001的備註",
                    Languages = new List<LanguageJson>
                    {
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.TW,
                            LanguageValue = "測試屬性001"
                        },
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.EN_US,
                            LanguageValue = "Test001"
                        }
                    }
                },
                new CustomVariantAttribute
                {
                    Id = 1,
                    Number = "Test001",
                    Name = "測試屬性001",
                    AttributeType = CustomVariantAttributeType.Number,
                    IsSystemDefault = false,
                    IsEnable = true,
                    Options = JsonSerializer.SerializeToDocument(
                        new List<VariantAttributeOptionJson>
                        {
                            new VariantAttributeOptionJson
                            {
                                Name = "S",
                                Value = "S"
                            },
                            new VariantAttributeOptionJson
                            {
                                Name = "L",
                                Value = "L"
                            }
                        }
                    ),
                    Remarks = "測試屬性001的備註",
                    Language = JsonSerializer.SerializeToDocument(
                        new List<LanguageJson>
                        {
                            new LanguageJson
                            {
                                LanguageKey = LanguageType.TW,
                                LanguageValue = "測試屬性001"
                            },
                            new LanguageJson
                            {
                                LanguageKey = LanguageType.EN_US,
                                LanguageValue = "Test001"
                            }
                        }
                    )
                }
            },
            new object[]
            {
                new InsertCustomVariantAttributeDto
                {
                    Number = "Test002",
                    Name = "測試屬性002",
                    AttributeType = CustomVariantAttributeType.Color,
                    IsEnable = false,
                    Options = new List<VariantAttributeOptionJson>
                    {
                        new VariantAttributeOptionJson
                        {
                            Name = "黑色",
                            Value = "#000000"
                        },
                        new VariantAttributeOptionJson
                        {
                            Name = "白色",
                            Value = "#FFFFFF"
                        }
                    },
                    Remarks = "測試屬性002的備註",
                    Languages = new List<LanguageJson>
                    {
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.TW,
                            LanguageValue = "測試屬性002"
                        },
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.EN_US,
                            LanguageValue = "Test002"
                        }
                    }
                },
                new CustomVariantAttribute
                {
                    Id = 2,
                    Number = "Test002",
                    Name = "測試屬性002",
                    AttributeType = CustomVariantAttributeType.Color,
                    IsSystemDefault = false,
                    IsEnable = false,
                    Options = JsonSerializer.SerializeToDocument(
                        new List<VariantAttributeOptionJson>
                        {
                            new VariantAttributeOptionJson
                            {
                                Name = "黑色",
                                Value = "#000000"
                            },
                            new VariantAttributeOptionJson
                            {
                                Name = "白色",
                                Value = "#FFFFFF"
                            }
                        }
                    ),
                    Remarks = "測試屬性001的備註",
                    Language = JsonSerializer.SerializeToDocument(
                        new List<LanguageJson>
                        {
                            new LanguageJson
                            {
                                LanguageKey = LanguageType.TW,
                                LanguageValue = "測試屬性002"
                            },
                            new LanguageJson
                            {
                                LanguageKey = LanguageType.EN_US,
                                LanguageValue = "Test002"
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
                new UpdateCustomVariantAttributeDto
                {
                    Id = 1
                }
            },
            new object[]
            {
                new UpdateCustomVariantAttributeDto
                {
                    Id = 2
                }
            }
        };
        private static readonly object[] _updateSuccessCases =
        {
            new object[]
            {
                new UpdateCustomVariantAttributeDto
                {
                    Id = 1,
                    Name = "編輯測試屬性001",
                    Options = new List<VariantAttributeOptionJson>
                    {
                        new VariantAttributeOptionJson
                        {
                            Name = "S",
                            Value = "S"
                        },
                        new VariantAttributeOptionJson
                        {
                            Name = "L",
                            Value = "L"
                        }
                    },
                    Remarks = "編輯測試屬性001的備註",
                    Languages = new List<LanguageJson>
                    {
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.TW,
                            LanguageValue = "編輯測試屬性001"
                        },
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.EN_US,
                            LanguageValue = "edit-Test001"
                        }
                    }
                },
                new CustomVariantAttribute
                {
                    Id = 1,
                    Number = "Test001",
                    Name = "測試屬性001",
                    AttributeType = CustomVariantAttributeType.Number,
                    IsSystemDefault = false,
                    IsEnable = true,
                    Options = JsonSerializer.SerializeToDocument(
                        new List<VariantAttributeOptionJson>
                        {
                            new VariantAttributeOptionJson
                            {
                                Name = "S",
                                Value = "S"
                            },
                            new VariantAttributeOptionJson
                            {
                                Name = "L",
                                Value = "L"
                            }
                        }
                    ),
                    Remarks = "測試屬性001的備註",
                    Language = JsonSerializer.SerializeToDocument(
                        new List<LanguageJson>
                        {
                            new LanguageJson
                            {
                                LanguageKey = LanguageType.TW,
                                LanguageValue = "測試屬性001"
                            },
                            new LanguageJson
                            {
                                LanguageKey = LanguageType.EN_US,
                                LanguageValue = "Test001"
                            }
                        }
                    )
                }
            },
            new object[]
            {
                new UpdateCustomVariantAttributeDto
                {
                    Name = "編輯測試屬性002",
                    Options = new List<VariantAttributeOptionJson>
                    {
                        new VariantAttributeOptionJson
                        {
                            Name = "編輯黑色",
                            Value = "#000000"
                        },
                        new VariantAttributeOptionJson
                        {
                            Name = "編輯白色",
                            Value = "#FFFFFF"
                        }
                    },
                    Remarks = "編輯測試屬性002的備註",
                    Languages = new List<LanguageJson>
                    {
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.TW,
                            LanguageValue = "編輯測試屬性002"
                        },
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.EN_US,
                            LanguageValue = "edit-Test002"
                        }
                    }
                },
                new CustomVariantAttribute
                {
                    Id = 2,
                    Number = "Test002",
                    Name = "測試屬性002",
                    AttributeType = CustomVariantAttributeType.Color,
                    IsSystemDefault = false,
                    IsEnable = false,
                    Options = JsonSerializer.SerializeToDocument(
                        new List<VariantAttributeOptionJson>
                        {
                            new VariantAttributeOptionJson
                            {
                                Name = "黑色",
                                Value = "#000000"
                            },
                            new VariantAttributeOptionJson
                            {
                                Name = "白色",
                                Value = "#FFFFFF"
                            }
                        }
                    ),
                    Remarks = "測試屬性001的備註",
                    Language = JsonSerializer.SerializeToDocument(
                        new List<LanguageJson>
                        {
                            new LanguageJson
                            {
                                LanguageKey = LanguageType.TW,
                                LanguageValue = "測試屬性002"
                            },
                            new LanguageJson
                            {
                                LanguageKey = LanguageType.EN_US,
                                LanguageValue = "Test002"
                            }
                        }
                    )
                }
            }
        };

        private static readonly object[] _enableSuccessCases =
         {
            new object[]
            {
                1,
                new CustomVariantAttribute
                {
                    Id = 1,
                    IsEnable = false
                }
            },
            new object[]
            {
                2,
                new CustomVariantAttribute
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
                new CustomVariantAttribute
                {
                    Id = 1,
                    IsEnable = true
                }
            },
            new object[]
            {
                2,
                new CustomVariantAttribute
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

            _mockCustomVariantAttributeDao = 
                new Mock<ICustomVariantAttributeDao>(MockBehavior.Strict);

            _customVariantAttributeService = new CustomVariantAttributeService(
                _mockCustomVariantAttributeDao.Object,
                _loginUserData);
        }

        /// <summary>
        /// 測試新增(number已存在)
        /// </summary>
        /// <param name="insertDto"></param>
        [TestCaseSource(nameof(_insertExistNumberCases))]
        public void TestInsertAsyncExistNumber(InsertCustomVariantAttributeDto insertDto) 
        {
            _mockCustomVariantAttributeDao
                .Setup(x => x.GetByNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(new CustomVariantAttribute());

            _mockCustomVariantAttributeDao
                .Setup(x => x.InsertAsync(It.IsAny<CustomVariantAttribute>()))
                .ReturnsAsync(new CustomVariantAttribute());

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
                await _customVariantAttributeService
                    .InsertAsync(insertDto));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.DuplicateData));
        }

        /// <summary>
        /// 測試新增(成功)
        /// </summary>
        /// <param name="insertDto">要新增的資料</param>
        /// <param name="rtnEntity">新增後回傳的實體</param>
        [TestCaseSource(nameof(_insertSuccessCases))]
        public async Task TestInsertAsyncSuccess(InsertCustomVariantAttributeDto insertDto,
            CustomVariantAttribute rtnEntity)
        {
            bool isPass = false;

            _mockCustomVariantAttributeDao
                .Setup(x => x.GetByNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(value: null);

            _mockCustomVariantAttributeDao
                .Setup(x => x.InsertAsync(It.IsAny<CustomVariantAttribute>()))
                .Callback<CustomVariantAttribute>( input => 
                {
                    if ( input.Number == insertDto.Number && 
                         input.Name == insertDto.Name &&
                         input.AttributeType == insertDto.AttributeType &&
                         input.IsSystemDefault == insertDto.IsSystemDefault &&
                         input.IsEnable == insertDto.IsEnable &&
                         JsonSerializer.Serialize(input.Options) ==
                         JsonSerializer.Serialize(insertDto.Options) &&
                         input.Remarks == insertDto.Remarks &&
                         JsonSerializer.Serialize(input.Language) ==
                         JsonSerializer.Serialize(insertDto.Languages))
                    {
                        isPass = true;
                    }
                })
                .ReturnsAsync(rtnEntity);

            try
            {
                await _customVariantAttributeService.InsertAsync(insertDto);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試編輯(id不存在)
        /// </summary>
        /// <param name="updateDto"></param>
        [TestCaseSource(nameof(_updateNotFindIdCases))]
        public void TestUpdateAsyncNotFindId(UpdateCustomVariantAttributeDto updateDto)
        {
            _mockCustomVariantAttributeDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            _mockCustomVariantAttributeDao
                .Setup(x => x.UpdateAsync(It.IsAny<CustomVariantAttribute>()))
                .Returns(Task.FromResult(false));

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
                await _customVariantAttributeService
                    .UpdateAsync(updateDto));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試編輯(成功)
        /// </summary>
        /// <param name="updateDto">要編輯的資料</param>
        /// <param name="entity">根據id查詢到的實體</param>
        [TestCaseSource(nameof(_updateSuccessCases))]
        public async Task TestUpdateAsyncSuccess(UpdateCustomVariantAttributeDto updateDto,
            CustomVariantAttribute entity)
        {
            bool isPass = false;

            _mockCustomVariantAttributeDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(entity);

            _mockCustomVariantAttributeDao
                .Setup(x => x.UpdateAsync(updateDto
                    .SetEntity(entity, _loginUserData.UserNumber)))
                .Callback<CustomVariantAttribute>(input =>
                {
                    if ( input.Name == updateDto.Name &&
                         JsonSerializer.Serialize(input.Options) ==
                         JsonSerializer.Serialize(updateDto.Options) &&
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
                await _customVariantAttributeService.UpdateAsync(updateDto);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試ThrowNotFindByIdAsync(Error)
        /// </summary>
        [Test]
        public void TestThrowNotFindByIdAsyncError()
        {
            _mockCustomVariantAttributeDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
                await _customVariantAttributeService
                    .ThrowNotFindByIdAsync(It.IsAny<long>()));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試EnableAsync(Error)
        /// </summary>
        [Test]
        public void TestEnableAsyncError()
        {
            _mockCustomVariantAttributeDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
                await _customVariantAttributeService
                    .EnableAsync(It.IsAny<long>(), true));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試啟用(Success)
        /// </summary>
        /// <param name="id">要被啟用的id</param>
        /// <param name="entity">要被啟用的實體</param>
        [TestCaseSource(nameof(_enableSuccessCases))]
        public async Task TestEnableAsyncSuccess(long id, CustomVariantAttribute entity)
        {
            bool isPass = false;

            _mockCustomVariantAttributeDao
                .Setup(x => x.GetByIdAsync(id))
                .ReturnsAsync(entity);

            _mockCustomVariantAttributeDao
                .Setup(x => x.UpdateAsync(entity))
                .Callback<CustomVariantAttribute>(input => 
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
                await _customVariantAttributeService.EnableAsync(id, true);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試停用(Success)
        /// </summary>
        /// <param name="id">要被停用的id</param>
        /// <param name="entity">要被停用的實體</param>
        [TestCaseSource(nameof(_disableSuccessCases))]
        public async Task TestDisableAsyncSuccess(long id, CustomVariantAttribute entity)
        {
            bool isPass = false;

            _mockCustomVariantAttributeDao
                .Setup(x => x.GetByIdAsync(id))
                .ReturnsAsync(entity);

            _mockCustomVariantAttributeDao
                .Setup(x => x.UpdateAsync(entity))
                .Callback<CustomVariantAttribute>(input =>
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
                await _customVariantAttributeService.EnableAsync(id, false);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試ThrowNotFindByIdAsync(Success)
        /// </summary>
        [Test]
        public async Task TestThrowNotFindByIdAsyncSuccess()
        {
            _mockCustomVariantAttributeDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(new CustomVariantAttribute());

            try
            {
                await _customVariantAttributeService.ThrowNotFindByIdAsync(It.IsAny<long>());
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.Pass();
        }

        /// <summary>
        /// 測試ThrowExistByNumberAsync(Error)
        /// </summary>
        [Test]
        public void TestThrowExistByNumberAsyncError()
        {
            _mockCustomVariantAttributeDao
                .Setup(x => x.GetByNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(new CustomVariantAttribute());

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
                await _customVariantAttributeService
                    .ThrowExistByNumberAsync(It.IsAny<string>()));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.DuplicateData));
        }

        /// <summary>
        /// 測試ThrowExistByNumberAsync(Success)
        /// </summary>
        [Test]
        public async Task TestThrowExistByNumberAsyncSuccess()
        {
            _mockCustomVariantAttributeDao
                .Setup(x => x.GetByNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(value: null);

            try
            {
                await _customVariantAttributeService.ThrowExistByNumberAsync(It.IsAny<string>());
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.Pass();
        }
    }
}
