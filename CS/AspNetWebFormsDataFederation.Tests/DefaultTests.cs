using System;
using System.Web.Hosting;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.DataFederation;
using DevExpress.DataAccess.Excel;
using DevExpress.DataAccess.Json;
using DevExpress.DataAccess.Sql;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AspNetWebFormsDataFederation.Tests
{
    [TestClass]
    public class DefaultTests
    {
        private Default _defaultPage;
        private Mock<ASPxDashboard> _mockDashboard;

        [TestInitialize]
        public void Setup()
        {
            _defaultPage = new Default();
            _mockDashboard = new Mock<ASPxDashboard>();
            _defaultPage.ASPxDashboard1 = _mockDashboard.Object;
        }

        [TestMethod]
        public void Page_Load_SetsDashboardStorage()
        {
            _defaultPage.Page_Load(null, EventArgs.Empty);

            _mockDashboard.Verify(d => d.SetDashboardStorage(It.IsAny<DashboardFileStorage>()), Times.Once);
        }

        [TestMethod]
        public void ASPxDashboard1_ConfigureDataConnection_SetsExcelConnectionParameters()
        {
            var mockEventArgs = new Mock<ConfigureDataConnectionWebEventArgs>("excelSales", new ExcelDataSourceConnectionParameters());
            _defaultPage.ASPxDashboard1_ConfigureDataConnection(null, mockEventArgs.Object);

            var excelParams = mockEventArgs.Object.ConnectionParameters as ExcelDataSourceConnectionParameters;
            Assert.IsNotNull(excelParams);
            Assert.AreEqual(HostingEnvironment.MapPath(@"~/App_Data/SalesPerson.xlsx"), excelParams.FileName);
        }

        [TestMethod]
        public void ASPxDashboard1_ConfigureDataConnection_SetsJsonConnectionParameters()
        {
            var mockEventArgs = new Mock<ConfigureDataConnectionWebEventArgs>("jsonCategories", new JsonSourceConnectionParameters());
            _defaultPage.ASPxDashboard1_ConfigureDataConnection(null, mockEventArgs.Object);

            var jsonParams = mockEventArgs.Object.ConnectionParameters as JsonSourceConnectionParameters;
            Assert.IsNotNull(jsonParams);
            Assert.AreEqual(HostingEnvironment.MapPath(@"~/App_Data/Categories.json"), ((UriJsonSource)jsonParams.JsonSource).Uri);
        }

        [TestMethod]
        public void DataLoading_SetsData()
        {
            var mockEventArgs = new Mock<DataLoadingWebEventArgs>("odsInvoices");
            _defaultPage.DataLoading(null, mockEventArgs.Object);

            Assert.IsNotNull(mockEventArgs.Object.Data);
        }

        [TestMethod]
        public void CreateFederatedDataSource_ReturnsValidDataSource()
        {
            var sqlDataSource = new DashboardSqlDataSource("SQL Data Source", "NWindConnectionString");
            var excelDataSource = new DashboardExcelDataSource("Excel Data Source");
            var objectDataSource = new DashboardObjectDataSource("Object Data Source");
            var jsonDataSource = new DashboardJsonDataSource("JSON Data Source");

            var result = Default.CreateFederatedDataSource(sqlDataSource, excelDataSource, objectDataSource, jsonDataSource);

            Assert.IsNotNull(result);
            Assert.AreEqual("Federated Data Source", result.Name);
        }
    }
}
