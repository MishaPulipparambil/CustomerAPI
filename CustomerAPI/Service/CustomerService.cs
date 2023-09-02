using AutoMapper;
using CustomerAPI.Models;
using CustomerAPI.Repository.Interface;
using CustomerAPI.Service.Interface;

namespace CustomerAPI.Service
{
    /// <summary>
    /// I haven't added all the functionalities. There is a Generic repository for adding/ Updating and Deleting the entities.
    /// And custom functions we need to specify in each repository.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressInfoRepository _addressInfoRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IAddressInfoRepository addressInfoRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _addressInfoRepository = addressInfoRepository;
            _mapper = mapper;
        }
        public async Task<Customer> AddCustomer(CustomerDto customer)
        {
            var customerEntity = _mapper.Map<Customer>(customer);
            if (customerEntity.Id == Guid.Empty)
            {
                customerEntity.Id = Guid.NewGuid();
            }
            if (customer.IsMailingAddressSame)
            {
                if (customerEntity.BillingAddress != null && customerEntity.BillingAddress.Id == Guid.Empty)
                {
                    customerEntity.BillingAddress.Id = Guid.NewGuid();
                    customerEntity.BillingAddressId = customerEntity.BillingAddress.Id;
                    customerEntity.MailingAddressId = customerEntity.BillingAddress.Id;



                    customerEntity.BillingAddress.State = null;
                    customerEntity.MailingAddress = null;
                }
            }
            else
            {
                if (customerEntity.BillingAddress != null && customerEntity.BillingAddress.Id == Guid.Empty)
                {
                    customerEntity.BillingAddress.Id = Guid.NewGuid();
                    customerEntity.BillingAddressId = customerEntity.BillingAddress.Id;

                    customerEntity.BillingAddress.State = null;
                }
                if (customerEntity.MailingAddress != null && customerEntity.MailingAddress.Id == Guid.Empty)
                {
                    customerEntity.MailingAddress.Id = Guid.NewGuid();
                    customerEntity.MailingAddressId = customerEntity.MailingAddress.Id;
                    customerEntity.MailingAddress.State = null;
                }
            }


            return await _customerRepository.Add(customerEntity); ;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _customerRepository.GetAll(); 
        }
    }
}
