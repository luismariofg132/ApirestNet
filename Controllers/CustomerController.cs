using Microsoft.AspNetCore.Mvc;
using ApirestNet.Dtos;
using ApirestNet.Repositories;

namespace ApirestNet.Controllers
{
    // Atributo, solo est clase se ve alterada por este atributo
    [ApiController]
    // Definir las rutas
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {

        private readonly CustomerDatabaseContext _customerdatabasecontext;

        public CustomerController(CustomerDatabaseContext customerdatabasecontext)
        {
            _customerdatabasecontext = customerdatabasecontext;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        public async Task<IActionResult> GetCustomer(long id)
        {
            CustomerEntity result = await _customerdatabasecontext.GetCustomer(id);
            return new OkObjectResult(result.ToDto());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CustomerDto>))]
        public async Task<List<CustomerDto>> GetCustomers()
        {
            var result = _customerdatabasecontext.customers.Select(c => c.ToDto()).ToList();

            return new OkObjectResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteCustomer(long id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateCustomerDto))]
        public async Task<IActionResult> PostCustomer(CreateCustomerDto customer)
        {
            CustomerEntity result = await _customerdatabasecontext.Add(customer);
            return new CreatedResult($"https://localhost:7254/api/customer/{result.Id}", null);
        }

        [HttpPut("{id}")]
        public async Task<CustomerDto> PutCustomer(long id)
        {
            throw new NotImplementedException();
        }
    }
}
