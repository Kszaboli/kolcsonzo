﻿using autokolcsonzo.Models;
using autokolcsonzo.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace autokolcsonzo.Controllers
{
    [Route("api/Rents")]
    [ApiController]
    public class RentController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Rent> Post(CreateRentDto createRentDto)
        {
            using (var context = new KolcsonzoContext())
            {
                var Rent = new Rent()
                {
                    Id = Guid.NewGuid().ToString(),
                    CustomerId = createRentDto.Customer_id,
                    CarId = createRentDto.Car_id,
                    Start = DateTime.Now,
                    End = DateTime.UtcNow,
                };
                if (createRentDto.Customer_id != null)
                {
                    context.Add(Rent);
                    context.SaveChanges();
                    return StatusCode(201, Rent);
                }
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult<Rent> GetAll()
        {
            using (var context = new KolcsonzoContext())
            {
                return Ok(context.Rents.ToList());
            }
        }

        [HttpGet("Id")]
        public ActionResult<Rent> GetById(string id)
        {
            using (var ctx = new KolcsonzoContext())
            {
                var Rent = ctx.Rents.FirstOrDefault(x => x.Id == id);

                if (Rent != null)
                {
                    return Ok(Rent);
                }
                return NotFound();
            }
        }

        [HttpPut]
        public ActionResult<Rent> Put(string id, UpdateRentDto updateRentDto)
        {
            using (var ctx = new KolcsonzoContext())
            {
                var existingRent = ctx.Rents.FirstOrDefault(x => x.Id == id);

                if (existingRent != null)
                {
                    existingRent.End = updateRentDto.End;
                    ctx.SaveChanges();
                    return Ok("Rent data updated.");
                }
                return NotFound();
            }
        }

        [HttpDelete]
        public ActionResult<Rent> Delete(string id)
        {
            using (var ctx = new KolcsonzoContext())
            {
                var delRent = ctx.Rents.FirstOrDefault(y => y.Id == id);

                if (delRent != null)
                {
                    ctx.Remove(delRent);
                    ctx.SaveChanges();
                    return Ok("Rent deleted.");
                }
                return NotFound();
            }
        }
    }
}
