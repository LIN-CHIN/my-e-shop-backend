using EShopAPI.Common;
using EShopAPI.Cores.CustomVariantAttributes;
using EShopAPI.Cores.EShopUnits;
using EShopAPI.Cores.EShopUnits.DAOs;
using EShopAPI.Cores.EShopUnits.DTOs;
using EShopAPI.Cores.EShopUnits.Services;
using EShopCores.Enums;
using EShopCores.Errors;
using EShopCores.Json;
using EShopCores.Responses;
using Jose;
using Moq;
using System.Text.Json;
using System.Xml.Linq;

namespace EshopTest.Cores.EShopUnits
{
    /// <summary>
    /// 測試商店單位 Service
    /// </summary>
    [TestFixture]
    public class EShopUnitServiceTest
    {
        private Mock<IEShopUnitDao> _mockEShopUntiDao;
        private IEShopUnitService _eShopUnitService;
        private LoginUserData _loginUserData;

        private static readonly object[] _insertExistNumberCases =
        {
            new object[]
            {
                new InsertEShopUnitDto
                {
                    Number = "A001"
                }
            },
            new object[]
            {
                new InsertEShopUnitDto
                {
                    Number = "B001"
                }
            }
        };
        private static readonly object[] _insertSuccessCases =
        {
            new object[]
            {
                new InsertEShopUnitDto
                {
                    Number = "Test001",
                    Name = "測試001",
                    IsEnable = true,
                    Remarks = "測試備註1",
                    Languages = new List<LanguageJson>
                    {
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.TW,
                            LanguageValue = "測試001"
                        },
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.EN_US,
                            LanguageValue = "Test001"
                        }
                    }
                },
                new EShopUnit
                {
                    Id = 1,
                    Number = "Test001",
                    Name = "測試001",
                    IsEnable = true,
                    Remarks = "測試備註1",
                    Language = JsonSerializer.SerializeToDocument(
                        new List<LanguageJson>
                        {
                            new LanguageJson
                            {
                                LanguageKey = LanguageType.TW,
                                LanguageValue = "測試001"
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
                new InsertEShopUnitDto
                {
                    Number = "Test002",
                    Name = "測試002",
                    IsEnable = false,
                    Remarks = "測試備註2",
                    Languages = new List<LanguageJson>
                    {
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.TW,
                            LanguageValue = "測試002"
                        },
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.EN_US,
                            LanguageValue = "Test002"
                        }
                    }
                },
                new EShopUnit
                {
                    Id = 2,
                    Number = "Test002",
                    Name = "測試002",
                    IsEnable = false,
                    Remarks = "測試備註2",
                    Language = JsonSerializer.SerializeToDocument(
                        new List<LanguageJson>
                        {
                            new LanguageJson
                            {
                                LanguageKey = LanguageType.TW,
                                LanguageValue = "測試002"
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
                new UpdateEShopUnitDto
                {
                    Id = 1,
                }
            },
            new object[]
            {
                new UpdateEShopUnitDto
                {
                    Id = 2,
                }
            }
        };
        private static readonly object[] _updateSuccessCases =
       {
            new object[]
            {
                new UpdateEShopUnitDto
                {
                    Id = 1,
                    Name = "編輯測試001",
                    Remarks = "編輯備註1",
                    Languages = new List<LanguageJson>
                    {
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.TW,
                            LanguageValue = "編輯測試001"
                        },
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.EN_US,
                            LanguageValue = "EditTest001"
                        }
                    }
                },
                new EShopUnit
                {
                    Id = 1,
                    Name = "測試001",
                    Remarks = "備註1",
                    Language = JsonSerializer.SerializeToDocument(
                        new List<LanguageJson>
                        {
                            new LanguageJson
                            {
                                LanguageKey = LanguageType.TW,
                                LanguageValue = "測試001"
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
                new UpdateEShopUnitDto
                {
                    Id = 2,
                    Name = "編輯測試002",
                    Remarks = "編輯備註2",
                    Languages = new List<LanguageJson>
                    {
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.TW,
                            LanguageValue = "編輯測試002"
                        },
                        new LanguageJson
                        {
                            LanguageKey = LanguageType.EN_US,
                            LanguageValue = "EditTest002"
                        }
                    }
                },
                new EShopUnit
                {
                    Id = 2,
                    Name = "測試002",
                    Remarks = "備註2",
                    Language = JsonSerializer.SerializeToDocument(
                        new List<LanguageJson>
                        {
                            new LanguageJson
                            {
                                LanguageKey = LanguageType.TW,
                                LanguageValue = "測試002"
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
                new EShopUnit
                {
                    Id = 1,
                    IsEnable = false
                }
            },
            new object[]
            {
                2,
                new EShopUnit
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
                new EShopUnit
                {
                    Id = 1,
                    IsEnable = true
                }
            },
            new object[]
            {
                2,
                new EShopUnit
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
            _mockEShopUntiDao = new Mock<IEShopUnitDao>(MockBehavior.Strict);
            _eShopUnitService = new EShopUnitService(_mockEShopUntiDao.Object, _loginUserData);
        }

        /// <summary>
        /// 測試InsertAsync (代碼已存在)
        /// </summary>
        /// <param name="insertDto">要新增的資料</param>
        [TestCaseSource(nameof(_insertExistNumberCases))]
        public void TestInsertAsyncExistNumber(InsertEShopUnitDto insertDto) 
        {
            _mockEShopUntiDao
                .Setup(x => x.GetByNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(new EShopUnit());

            _mockEShopUntiDao
                .Setup(x => x.InsertAsync(It.IsAny<EShopUnit>()))
                .ReturnsAsync(It.IsAny<EShopUnit>());

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _eShopUnitService
                   .InsertAsync(insertDto));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.DuplicateData));
        }

        /// <summary>
        /// 測試InsertAsync (成功)
        /// </summary>
        /// <param name="insertDto">要新增的資料</param>
        /// <param name="rtnEShopUnit">新增成功後回傳的實體</param>
        [TestCaseSource(nameof(_insertSuccessCases))]
        public async Task TestInsertAsyncSuccess(InsertEShopUnitDto insertDto, EShopUnit rtnEShopUnit)
        {
            bool isPass = false;

            _mockEShopUntiDao
                .Setup(x => x.GetByNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(value: null);

            _mockEShopUntiDao
                .Setup(x => x.InsertAsync(It.IsAny<EShopUnit>()))
                .Callback<EShopUnit>( eShopUnit => 
                {
                    if (eShopUnit.Number == insertDto.Number &&
                        eShopUnit.Name == insertDto.Name &&
                        eShopUnit.IsEnable == insertDto.IsEnable &&
                        eShopUnit.IsSystemDefault == insertDto.IsSystemDefault &&
                        eShopUnit.Remarks == insertDto.Remarks &&
                        JsonSerializer.Serialize(eShopUnit.Language) ==
                        JsonSerializer.Serialize(insertDto.Languages) &&
                        eShopUnit.CreateUser == _loginUserData.UserNumber)
                    {
                        isPass = true;
                    }
                })
                .ReturnsAsync(rtnEShopUnit);

            try
            {
                await _eShopUnitService.InsertAsync(insertDto);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試UpdateAsync (id不存在)
        /// </summary>
        /// <param name="updateDto">要編輯的資料</param>
        [TestCaseSource(nameof(_updateNotFindIdCases))]
        public void TestUpdateAsyncNotFindId(UpdateEShopUnitDto updateDto)
        {
            _mockEShopUntiDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            _mockEShopUntiDao
                .Setup(x => x.UpdateAsync(It.IsAny<EShopUnit>()))
                .Returns(Task.FromResult(false));

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _eShopUnitService
                   .UpdateAsync(updateDto));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試UpdateAsync (成功)
        /// </summary>
        /// <param name="updateDto">要編輯的資料</param>
        /// <param name="eShopUnit">要被編輯的實體</param>
        [TestCaseSource(nameof(_updateSuccessCases))]
        public async Task TestUpdateAsyncSuccess(UpdateEShopUnitDto updateDto, EShopUnit eShopUnit)
        {
            bool isPass = false;

            _mockEShopUntiDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(eShopUnit);

            _mockEShopUntiDao
                .Setup(x => x.UpdateAsync(It.IsAny<EShopUnit>()))
                .Callback<EShopUnit>(input => 
                {
                    if ( input.Id == updateDto.Id &&
                         input.Name == updateDto.Name &&
                         input.Remarks == updateDto.Remarks &&
                         JsonSerializer.Serialize(input.Language) ==
                         JsonSerializer.Serialize(updateDto.Languages) &&
                         input.UpdateUser == _loginUserData.UserNumber ) 
                    {
                        isPass = true;
                    }
                })
                .Returns(Task.FromResult(false));

            try
            {
                await _eShopUnitService.UpdateAsync(updateDto);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試EnableAsync(找不到id)
        /// </summary>
        [Test]
        public void TestEnableAsyncNotFindId() 
        {
            _mockEShopUntiDao
                 .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                 .ReturnsAsync(value: null);

            _mockEShopUntiDao
                .Setup(x => x.UpdateAsync(It.IsAny<EShopUnit>()))
                .Returns(Task.FromResult(false));

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _eShopUnitService
                   .EnableAsync(It.IsAny<long>(), true));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試EnableAsync(啟用成功)
        /// </summary>
        /// <param name="id">要啟用的id</param>
        /// <param name="eShopUnit">要被啟用的實體</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_enableSuccessCases))]
        public async Task TestEnableAsyncSuccess(long id, EShopUnit eShopUnit) 
        {
            bool isPass = false;

            _mockEShopUntiDao
                .Setup(x => x.GetByIdAsync(id))
                .ReturnsAsync(eShopUnit);

            _mockEShopUntiDao
                .Setup(x => x.UpdateAsync(It.IsAny<EShopUnit>()))
                .Callback<EShopUnit>(input => 
                {
                    if (input.Id == eShopUnit.Id &&
                        input.IsEnable)
                    {
                        isPass = true;
                    }
                })
                .Returns(Task.FromResult(false));

            try
            {
                await _eShopUnitService.EnableAsync(id, true);
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.That(isPass, Is.True);
        }

        /// <summary>
        /// 測試EnableAsync(停用成功)
        /// </summary>
        /// <param name="id">要停用的id</param>
        /// <param name="eShopUnit">要被停用的實體</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_enableSuccessCases))]
        public async Task TestDisableSuccess(long id, EShopUnit eShopUnit)
        {
            bool isPass = false;

            _mockEShopUntiDao
                .Setup(x => x.GetByIdAsync(id))
                .ReturnsAsync(eShopUnit);

            _mockEShopUntiDao
                .Setup(x => x.UpdateAsync(It.IsAny<EShopUnit>()))
                .Callback<EShopUnit>(input =>
                {
                    if (input.Id == eShopUnit.Id &&
                        !input.IsEnable)
                    {
                        isPass = true;
                    }
                })
                .Returns(Task.FromResult(false));

            try
            {
                await _eShopUnitService.EnableAsync(id, false);
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
            _mockEShopUntiDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(value: null);

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
               await _eShopUnitService
                   .ThrowNotFindByIdAsync(It.IsAny<long>()));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.RequestParameterError));
        }

        /// <summary>
        /// 測試ThrowNotFindByIdAsync(Success)
        /// </summary>
        [Test]
        public async Task TestThrowNotFindByIdAsyncSuccess()
        {
            _mockEShopUntiDao
                .Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(new EShopUnit());

            try
            {
                await _eShopUnitService.ThrowNotFindByIdAsync(It.IsAny<long>());
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
            _mockEShopUntiDao
                .Setup(x => x.GetByNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(new EShopUnit());

            var ex = Assert.ThrowsAsync<EShopException>(async () =>
                await _eShopUnitService
                    .ThrowExistByNumberAsync(It.IsAny<string>()));

            Assert.That(ex.Code, Is.EqualTo(ResponseCodeType.DuplicateData));
        }

        /// <summary>
        /// 測試ThrowExistByNumberAsync(Success)
        /// </summary>
        [Test]
        public async Task TestThrowExistByNumberAsyncSuccess()
        {
            _mockEShopUntiDao
                .Setup(x => x.GetByNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(value: null);

            try
            {
                await _eShopUnitService.ThrowExistByNumberAsync(It.IsAny<string>());
            }
            catch (Exception)
            {
                Assert.Fail("should not get the error");
            }

            Assert.Pass();
        }
    }
}
