using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace SafeView.Customers
{
    public static class CustomerValidationConstants
    {
        public const string InvalidInput = "Input is invalid.";
        public const string InvalidName = "Name is invalid.";
        public const string InvalidPhoneNumber = "Phone number is invalid.";
        public const string InvalidWhatsappNumber = "Whatsapp number is invalid.";
        public const string InvalidLocation = "Location is invalid.";
    }

    public class CustomerManager : DomainService
    {
        private readonly IRepository<Customer, Guid> _customerRepository;

        public CustomerManager(IRepository<Customer, Guid> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        private void CustomerValidation(Customer inputFromUser)
        {

            if (inputFromUser == null)
            {
                throw new BusinessException(nameof(inputFromUser), CustomerValidationConstants.InvalidInput);

            }
            if (string.IsNullOrEmpty(inputFromUser.Name))
            {
                throw new BusinessException(nameof(inputFromUser), CustomerValidationConstants.InvalidName);

            }
            if (string.IsNullOrEmpty(inputFromUser.PhoneNumber) || inputFromUser.PhoneNumber.Length == 0 || inputFromUser.PhoneNumber.Length < 10)
            {
                throw new BusinessException(nameof(inputFromUser), CustomerValidationConstants.InvalidPhoneNumber);

            }
            if ((string.IsNullOrEmpty(inputFromUser.WhatsAppNumber) || inputFromUser.WhatsAppNumber.Length == 0 || inputFromUser.WhatsAppNumber.Length < 10))
            {
                throw new BusinessException(nameof(inputFromUser), CustomerValidationConstants.InvalidPhoneNumber);

            }
            if (string.IsNullOrEmpty(inputFromUser.Location))
            {
                throw new BusinessException(nameof(inputFromUser), CustomerValidationConstants.InvalidLocation);

            }
        }

        public async Task<Customer> CreateAsync(Customer inputFromUser)
        {

            CustomerValidation(inputFromUser);
            GuidGenerator.Create();
            return await _customerRepository.InsertAsync(inputFromUser);
        }

        public async Task<Customer> UpdateAsync(Customer inputFromUser)
        {

            CustomerValidation(inputFromUser);
            return await _customerRepository.UpdateAsync(inputFromUser);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            var result = await _customerRepository.GetListAsync();

            if (result == null)
            {
                throw new BusinessException(nameof(result), "Result is null.");
            }
            return result;
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            var result = await _customerRepository.GetAsync(id);

            if (result == null)
            {
                throw new BusinessException(nameof(result), "Result is null.");
            }
            return result;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        public async Task<int> GetCustomersCountAsync()
        {
            return await _customerRepository.CountAsync();
        }
    }
}
