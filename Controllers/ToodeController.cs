using Microsoft.AspNetCore.Mvc;
using web2.Models;

namespace web2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToodeController : ControllerBase
    {
        private static Toode _toode = new Toode(1, "Koola", 1.5, true);
        // GET: toode
        [HttpGet]
        public Toode GetToode()
        {
            return _toode;
        }
        // GET: toode/suurenda-hinda
        [HttpGet("suurenda-hinda")]
        public Toode SuurendaHinda()
        {
            _toode.Price = _toode.Price + 1;
            return _toode;
        }
        // GET: toode/activechange
        [HttpGet("active")]
        public Toode ChangeActive()
        {
            if (_toode.IsActive==true)
            {
                _toode.IsActive = false;
            }
            else
            {
                _toode.IsActive = true;
            }
            return _toode;
        }
        // GET: toode/newname
        [HttpGet("newname/{name}")]
        public Toode ChangeName(string name)
        {
            _toode.Name = name;
            return _toode;
        }
        // GET: toode/newprice
        [HttpGet("newprice/{price}")]
        public Toode ChangePrice(double price)
        {
            _toode.Price *= price;
            return _toode;
        }
    }
}
