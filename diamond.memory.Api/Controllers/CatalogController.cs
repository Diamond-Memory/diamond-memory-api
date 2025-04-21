using Microsoft.AspNetCore.Mvc;
using diamond.memory.Domain.Catalog;
using diamond.memory.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace diamond.memory.Api.Controllers
{
    [ApiController]
    [Route("/catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly StoreContext _db;

        public CatalogController(StoreContext db)
        {
            _db = db;
        }

        [HttpGet]

        public IActionResult GetItems()
        {
            return Ok(_db.Items);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
                var item = _db.Items.Find(id);
                if(item == null){
                    return NotFound();
                }
                return Ok(item);
        }

        [HttpPost]
        public IActionResult Post(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();
            return Created($"/catalog/{item.Id}", item);
        }

        [HttpPost("{id}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            var item = _db.Items.Find(id);
            if (item = null)
            {
              return NotFound();  
            }
        
            item.AddRating(rating);
            _db.SaveChanges();

            return Ok(item);
        }

                [HttpPut("{id:int}")]
        public IActionResult PutItem(int id, [FromBody] Item item)
        {
            
            if(id != item.Id){
                return BadRequest();
            }
            if(_db.Items.Find(id) == null){
                return NotFound();
            }
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return Ok(item);
           
        }
        [HttpDelete("{id:int}")]
        [Authorize("delete:catalog")]
        public IActionResult DeleteItem(int id)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _db.Items.Remove(item);
            _db.SaveChanges();
            return Ok();
           
        }
    }

}
