using AutoMapper;
using CustomerAPI.DTO;
using CustomerAPI.Models;
using CustomerAPI.Repository.Interface;
using CustomerAPI.Service.Interface;

namespace CustomerAPI.Service
{
    /// <summary>
    /// I haven't added all the functionalities. There is a Generic repository for adding/ Updating and Deleting the entities.
    /// And custom functions we need to specify in each repository.
    /// </summary>
    public class CustomerOrderInfoService : ICustomerOrderInfoService
    {
        private readonly ICustomerOrderInfoRepository _customerOrderInfoRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerOrderInfoService(ICustomerOrderInfoRepository customerOrderInfoRepository, ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerOrderInfoRepository = customerOrderInfoRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<CustomerOrderInfo> CreateCustomerOrder(CustomerOrderDto customerOrderInfo)
        {
           if( customerOrderInfo.Id == Guid.Empty)
            {
                customerOrderInfo.Id = Guid.NewGuid();
            }
            var orderInfo = _mapper.Map<CustomerOrderInfo> (customerOrderInfo);
            orderInfo.Customer = null;
            orderInfo.Product = null;   
           return await _customerOrderInfoRepository.Add(orderInfo);
        }

        public IEnumerable<CustomerOrderDto> GetAllOrderForCustomer(Guid customerId)
        {
           var result =_customerOrderInfoRepository.GetAllOrderForCustomer(customerId); 
            return _mapper.Map<IEnumerable<CustomerOrderDto>>(result);
        }
    }
}
