using EShopAPI.Validations;

namespace EshopTest.ValidationAttributes
{
    /// <summary>
    /// 測試Number驗證屬性
    /// </summary>
    [TestFixture]
    public class NumberValidationAttributeTest
    {
        private static readonly object[] _numberErrorCases =
        {
            new object[]
            {
                "中文不合法"
            },
            new object[]
            {
                "A01/B01"
            },
            new object[]
            {
                "A01\\B01"
            },
            new object[]
            {
                "A01 B01"
            },
            new object[]
            {
                "A01&&B01"
            }
        };

        private static readonly object[] _numberSuccessCases =
        {
            new object[]
            {
                "2023-10-12-0001"
            },
            new object[]
            {
                "ABC202310120001"
            },
            new object[]
            {
                "20231012_0001"
            },
        };

        /// <summary>
        /// Setup 
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// 測試Number驗證(失敗)
        /// </summary>
        /// <param name="number">要測試的number</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_numberErrorCases))]
        public void TaskInsertDtoNumberValidationError(string number)
        {
            var validation = new NumberValidationAttribute();
            var result = validation.IsValid(number);
            Assert.That(result, Is.False);
        }

        /// <summary>
        /// 測試Number驗證(成功)
        /// </summary>
        /// <param name="number">要測試的number</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_numberSuccessCases))]
        public void TaskInsertDtoNumberValidationSuccess(string number)
        {
            var validation = new NumberValidationAttribute();
            var result = validation.IsValid(number);
            Assert.That(result, Is.True);
        }
    }
}
