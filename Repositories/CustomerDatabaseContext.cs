using ApirestNet.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ApirestNet.Repositories
{
    public class CustomerDatabaseContext : DbContext
    {

        public CustomerDatabaseContext(DbContextOptions<CustomerDatabaseContext> options) 
            : base(options)
        {

        }

        public DbSet<CustomerEntity> customers { get; set; }

        public async Task<CustomerEntity> GetCustomer(long id)
        {
            return await customers.FirstAsync(x => x.Id == id);
        }

        public async Task<CustomerEntity> Add(CreateCustomerDto customerDto)
        {

            CustomerEntity entity = new CustomerEntity()
            {
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Email = customerDto.Email,
                Phone = customerDto.Phone
            };
            
            
            EntityEntry<CustomerEntity> response = await customers.AddAsync(entity);
            await SaveChangesAsync();
            return await GetCustomer(response.Entity.Id );
        }
    }
}

    public class CustomerEntity
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public CustomerDto ToDto()
        {
            return new CustomerDto()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Phone = Phone,
                Id = Id
            };
        }
    }

