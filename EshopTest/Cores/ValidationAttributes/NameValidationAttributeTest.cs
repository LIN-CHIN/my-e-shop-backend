using EShopAPI.Validations;
using EShopCores.Enums;
using NUnit.Framework;

namespace EshopTest.Cores.ValidationAttributes
{
    /// <summary>
    /// 測試Name驗證屬性
    /// </summary>
    [TestFixture]
    public class NameValidationAttributeTest
    {
        private static readonly object[] _nameErrorCases =
        {
            new object[]
            {
                "非法\\的名稱"
            },
            new object[]
            {
                "非法，的名稱"
            },
            new object[]
            {
                "「非法的名稱"
            },
            new object[]
            {
                "非法的名稱」"
            },
            new object[]
            {
                "非法：的名稱"
            }
        };

        private static readonly object[] _nameSuccessCases =
        {
            new object[]
            {
                "名稱(合法)"
            },
            new object[]
            {
                "名稱/合法"
            },
            new object[]
            {
                "* 名稱 合法 *"
            },
            new object[]
            {
                "名稱:合法"
            }
        };

        /// <summary>
        /// Setup 
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// 測試Name驗證(失敗)
        /// </summary>
        /// <param name="name">要測試的名稱</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_nameErrorCases))]
        public void TaskInsertDtoNameValidationError(string name)
        {
            var validation = new NameValidationAttribute();
            var result = validation.IsValid(name);
            Assert.That(result, Is.False);
        }

        /// <summary>
        /// 測試Name驗證(成功)
        /// </summary>
        /// <param name="name">要測試的名稱</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_nameSuccessCases))]
        public void TaskInsertDtoNameValidationSuccess(string name)
        {
            var validation = new NameValidationAttribute();
            var result = validation.IsValid(name);
            Assert.That(result, Is.True);
        }
    }
}
