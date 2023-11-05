using ComplexTypeDemo.Entities;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ComplexTypeDemo.Services;

public class MyService : ITransientDependency
{
    private readonly IRepository<Customer, Guid> _customerRepository;

    public MyService(IRepository<Customer, Guid> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task DemoAsync()
    {
        var customers = await _customerRepository.GetListAsync(
            c => c.BusinessAddress.PostCode == "12345"
        );
    }
}