using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AspNetWebFormsDataFederation.Tests
{
    [TestClass]
    public class MainMasterTests
    {
        private MainMaster _mainMaster;

        [TestInitialize]
        public void Setup()
        {
            _mainMaster = new MainMaster();
        }

        [TestMethod]
        public void Page_Load_DoesNotThrowException()
        {
            try
            {
                _mainMaster.Page_Load(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Assert.Fail("Page_Load threw an exception: " + ex.Message);
            }
        }
    }
}
