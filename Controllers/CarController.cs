using autokolcsonzo.Models;
using autokolcsonzo.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace autokolcsonzo.Controllers
{
    [Route("api/Cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Car> Post(CreateCarDto createCarDto)
        {
            using (var context = new KolcsonzoContext())
            {
                var car = new Car()
                {
                    Id = Guid.NewGuid().ToString(),
                    Marka = createCarDto.Marka,
                    Model = createCarDto.Model,
                    Evjarat = createCarDto.Evjarat,
                };
                if (createCarDto.Marka != null)
                {                  
                        context.Add(car);
                        context.SaveChanges();
                        return StatusCode(201, car);
                }
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult<Car> GetAll()
        {
            using (var context = new KolcsonzoContext())
            {
                return Ok(context.Cars.ToList());
            }
        }

        [HttpGet("Id")]
        public ActionResult<Car> GetById(string id)
        {
            using (var ctx = new KolcsonzoContext())
            {
                var car = ctx.Cars.FirstOrDefault(x => x.Id == id);

                if (car != null)
                {
                    return Ok(car);
                }
                return NotFound();
            }
        }

        [HttpPut]
        public ActionResult<Car> Put(string id, UpdateCarDto updateCarDto)
        {
            using (var ctx = new KolcsonzoContext())
            {
                var existingCar = ctx.Cars.FirstOrDefault(x => x.Id == id);

                if (existingCar != null)
                {
                    existingCar.Model = updateCarDto.Model;
                    existingCar.Evjarat = updateCarDto.Evjarat;
                    ctx.SaveChanges();
                    return Ok("Car data updated.");
                }
                return NotFound();
            }
        }

        [HttpDelete]
        public ActionResult<Car> Delete(string id)
        {
            using (var ctx = new KolcsonzoContext())
            {
                var delCar = ctx.Cars.FirstOrDefault(y => y.Id == id);

                if (delCar != null)
                {
                    ctx.Remove(delCar);
                    ctx.SaveChanges();
                    return Ok("Car deleted.");
                }
                return NotFound();
            }
        }
    }
}
