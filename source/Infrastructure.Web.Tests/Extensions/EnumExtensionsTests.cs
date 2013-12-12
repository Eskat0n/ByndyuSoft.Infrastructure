namespace Codeparts.Frameplate.Web.Tests.Extensions
{
    using System.Linq;
    using Codeparts.Frameplate.Web.Extensions;
    using NUnit.Framework;

    [TestFixture]
    public class EnumExtensionsTests
    {
        [Test]
        public void CreateSelectListFromEnum()
        {
            var selectedList = EnumExtensions.ToSelectedList<TestEnum>();

            var items = selectedList.Items.Cast<object>();

            Assert.AreEqual(2, items.Count());
        }

        #region Nested type: TestEnum

        private enum TestEnum
        {
            First,
            Second
        }

        #endregion
    }
}