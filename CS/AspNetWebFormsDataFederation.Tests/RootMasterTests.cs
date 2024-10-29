using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AspNetWebFormsDataFederation.Tests
{
    [TestClass]
    public class RootMasterTests
    {
        private RootMaster _rootMaster;

        [TestInitialize]
        public void Setup()
        {
            _rootMaster = new RootMaster();
        }

        [TestMethod]
        public void Page_Load_DoesNotThrowException()
        {
            try
            {
                _rootMaster.Page_Load(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Assert.Fail("Page_Load threw an exception: " + ex.Message);
            }
        }
    }
}
