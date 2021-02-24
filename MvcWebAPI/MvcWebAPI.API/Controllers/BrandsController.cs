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
    public class BrandsController : ApiController
    {
        BrandDAL brandDal = new BrandDAL();

        [HttpGet]
        [ResponseType(typeof(IEnumerable<Brands>))]
        public IHttpActionResult GetAll()
        {
            var brands = brandDal.GetAllBrands();
            return Ok(brands);
        }

        [ResponseType(typeof(Brands))]
        public IHttpActionResult GetById(int id)
        {
            var brand = brandDal.GetById(id);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }

        [ResponseType(typeof(Brands))]
        [HttpPost]
        public IHttpActionResult Create(Brands model)
        {
            if (ModelState.IsValid)
            {
                var createBrand = brandDal.Create(model);
                return CreatedAtRoute("DefaultApi", new { id = createBrand.Id }, createBrand);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [ResponseType(typeof(Brands))]
        [HttpPut]
        public IHttpActionResult Update(int id, Brands model)
        {

            if (brandDal.IsBrand(id) == false)
            {
                return NotFound();
            }
            else if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(brandDal.Update(id, model));
            }
        }

        [HttpDelete]
        public void IHttpActionResult(int id)
        {
            brandDal.Delete(id);
        }
    }
}
