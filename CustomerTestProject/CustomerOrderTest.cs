using AutoMapper;
using CustomerAPI.Models;
using CustomerAPI.Repository;
using CustomerAPI.Repository.Interface;
using CustomerAPI.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace CustomerTestProject
{
    /// <summary>
    /// I have added some sample unit test. In Usual scenarios I used to add a lot of unit tests which include negative tests too.
    /// </summary>
    public class CustomerOrderTest
    {
        IMapper _mapper;
        MapperConfiguration _config;
        [SetUp]
        public void Setup()
        {
        }
       

       
        [Test]
        public async Task GetAllOrderForCustomer()
        {
             


            var mockSet = new Mock<DbSet<CustomerOrderInfo>>();
            var data = CreateCustomerOrderInfos().AsQueryable();

            mockSet.As<IQueryable<CustomerOrderInfo>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<CustomerOrderInfo>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<CustomerOrderInfo>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<CustomerOrderInfo>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<AcmeCorpContext>();
            mockContext.Setup(m => m.CustomerOrderInfos).Returns(mockSet.Object);        

            var customerOrderInfoRepository = new CustomerOrderInfoRepository(mockContext.Object);          

            var result = customerOrderInfoRepository.GetAllOrderForCustomer(new Guid("1D423933-E8CD-467C-A081-1E380B7EB830"));
            NUnit.Framework.Assert.AreEqual(1,result.Count());
            NUnit.Framework.Assert.Pass();
        }

        [Test]
        public async Task GetAllOrderForCustomerService()
        {
            _config = new MapperConfiguration(cfg => cfg.AddMaps(new[] {
        "CustomerAPI"
    }));

            _mapper = _config.CreateMapper();

            var mockSet = new Mock<DbSet<CustomerOrderInfo>>();
            var data = CreateCustomerOrderInfos().AsQueryable();

            mockSet.As<IQueryable<CustomerOrderInfo>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<CustomerOrderInfo>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<CustomerOrderInfo>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<CustomerOrderInfo>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<AcmeCorpContext>();
            mockContext.Setup(m => m.CustomerOrderInfos).Returns(mockSet.Object);

            var customerOrderInfoRepository = new CustomerOrderInfoRepository(mockContext.Object);

            CustomerRepository customerRepository = new CustomerRepository(mockContext.Object); 

            var CustomerOrderInfoService = new CustomerOrderInfoService(customerOrderInfoRepository, customerRepository, _mapper);

            var result = CustomerOrderInfoService.GetAllOrderForCustomer(new Guid("1D423933-E8CD-467C-A081-1E380B7EB830"));
            NUnit.Framework.Assert.AreEqual(1, result.Count());
            Assert.AreEqual(120, result.FirstOrDefault().ProductCost);
            NUnit.Framework.Assert.Pass();
        }

        private List<CustomerOrderInfo> CreateCustomerOrderInfos()
        {
            List<CustomerOrderInfo> customerOrderInfos = new List<CustomerOrderInfo>();

            CustomerOrderInfo customerOrderInfo1 = new CustomerOrderInfo();
            customerOrderInfo1.Id = new Guid("1D423933-E8CD-467C-A081-1E380B7EB830");
            customerOrderInfo1.CustomerId = new Guid("1D423933-E8CD-467C-A081-1E380B7EB830");
            customerOrderInfo1.ProductId = new Guid("DBF67717-63A8-44F0-BB38-BD31ADE4827A");
            customerOrderInfo1.Count = 2;

            customerOrderInfo1.Customer = new Customer()
            {
                Id = new Guid("1D423933-E8CD-467C-A081-1E380B7EB830"),
                FirstName = "Kayla",
                LastName = "S"
            };
            customerOrderInfo1.Product = new Product()
            {
                Id = new Guid("DBF67717-63A8-44F0-BB38-BD31ADE4827A"),
                Name = "BiCycle",
                Cost = 120
            };

            customerOrderInfos.Add(customerOrderInfo1);

            CustomerOrderInfo customerOrderInfo2 = new CustomerOrderInfo();
            customerOrderInfo2.Id = Guid.NewGuid();
            customerOrderInfo2.CustomerId = new Guid("DBF67717-63A8-44F0-BB38-BD31ADE4827A");
            customerOrderInfo2.ProductId = new Guid("DBF67717-63A8-44F0-BB38-BD31ADE4827A");
            customerOrderInfo2.Count = 2;

            customerOrderInfos.Add(customerOrderInfo2);

            return customerOrderInfos;
        }       
    }
}
