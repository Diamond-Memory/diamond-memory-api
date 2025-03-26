using Microsoft.AspNetCore.Mvc;
using diamond.memory.Domain.Catalog;
using diamond.memory.Data;


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

        // public IActionResult GetItems()
        // {
        //     var items = new List<Item>(){
        //         new Item("Shirt", "Ohio State Shirt", "Nike", 29.99m),
        //         new Item("Shorts", "Ohio State Pants", "Adidas", 44.99m),
        //     };
        //     return Ok(items);
        // }

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
            //_db.Set<Item>().AsNoTracking();
            if(id != item.Id){
                return BadRequest();
            }
            if(_db.Items.Find(id) == null){
                return NotFound();
            }
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return Ok(item);
            //return NoContent();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _db.Items.Removed(item);
            _db.SaveChanges();
            return Ok();
            //return NoContent();
        }
    }

}
