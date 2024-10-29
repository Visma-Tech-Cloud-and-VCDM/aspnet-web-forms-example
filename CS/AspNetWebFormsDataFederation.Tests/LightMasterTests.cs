using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AspNetWebFormsDataFederation.Tests
{
    [TestClass]
    public class LightMasterTests
    {
        private LightMaster _lightMaster;

        [TestInitialize]
        public void Setup()
        {
            _lightMaster = new LightMaster();
        }

        [TestMethod]
        public void Page_Load_DoesNotThrowException()
        {
            try
            {
                _lightMaster.Page_Load(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Assert.Fail("Page_Load threw an exception: " + ex.Message);
            }
        }
    }
}
