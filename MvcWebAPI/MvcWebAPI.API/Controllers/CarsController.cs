using MvcWebAPI.API.Attributes.Exception;
using MvcWebAPI.DataAccess;
using MvcWebAPI.DataAccess.dbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace MvcWebAPI.API.Controllers
{
    public class CarsController : ApiController
    {
        CarDAL carDal = new CarDAL();

        [Authorize]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Cars>))]
        public IHttpActionResult GetAll()
        {
            var cars = carDal.GetAllCars();
            return Ok(cars);
        }
        
        [ResponseType(typeof(Cars))]
        public IHttpActionResult GetById(int id)
        {
            var car = carDal.GetById(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [ResponseType(typeof(Cars))]
        [HttpPost]
        public IHttpActionResult Create(Cars model)
        {
            if (ModelState.IsValid)
            {
                var createCar = carDal.Create(model);
                return CreatedAtRoute("DefaultApi", new { id = createCar.Id }, createCar);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [ResponseType(typeof(Cars))]
        [HttpPut]
        public IHttpActionResult Update(int id, Cars model)
        {
            if (carDal.IsCar(id) == false)
            {
                return NotFound();
            }
            else if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(carDal.Update(id, model));
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            carDal.Delete(id);
            return Ok();
        }
    }
}
