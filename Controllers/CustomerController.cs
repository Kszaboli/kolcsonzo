using autokolcsonzo.Models;
using autokolcsonzo.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace autokolcsonzo.Controllers
{
    [Route("api/Customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Customer> Post(CreateCustomerDto createCustomerDto)
        {
            using (var context = new KolcsonzoContext())
            {
                var customer = new Customer()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = createCustomerDto.Name,
                    Email = createCustomerDto.Email,
                };
                if (createCustomerDto.Email != null)
                {
                    if (!createCustomerDto.Email.Contains('@'))
                    {
                        context.Add(customer);
                        context.SaveChanges();
                        return StatusCode(201, customer);
                    }
                    return BadRequest("Az email formátuma nem jó.");
                }
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult<Customer> GetAll()
        {
            using (var context = new KolcsonzoContext())
            {
                return Ok(context.Customers.ToList());
            }
        }

        [HttpGet]
        public ActionResult<Customer> GetById(string id)
        {
            using (var  ctx = new KolcsonzoContext())
            {
                var customer = ctx.Customers.FirstOrDefault(x => x.Id == id);

                if (customer != null)
                {
                    return Ok(customer);
                }
                return NotFound();
            }
        }

        [HttpPut]
        public ActionResult<Customer> Put(string id, UpdateCustomerDto updateCustomerDto)
        {
            using (var ctx = new KolcsonzoContext())
            {
                var existingCustomer = ctx.Customers.FirstOrDefault(x => x.Id == id);

                if (existingCustomer != null)
                {
                    existingCustomer.Name = updateCustomerDto.Name;
                    ctx.SaveChanges();
                    return Ok("Customer data updated.");
                }
                return NotFound();
            }
        }

        [HttpDelete]
        public ActionResult<Customer> Delete(string id)
        {
            using (var ctx = new KolcsonzoContext())
            {
                var delCustomer = ctx.Customers.FirstOrDefault(y => y.Id == id);

                if (delCustomer!=null)
                {
                    ctx.Remove(delCustomer);
                    ctx.SaveChanges();                   
                    return Ok("Customer deleted.");
                }
                return NotFound(); 
            }
        }
    }
}
