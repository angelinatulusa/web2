﻿using Microsoft.AspNetCore.Mvc;
using web2.Models;

namespace web2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TootedController : ControllerBase
    {
        private static List<Toode> _tooted = new()
        {
            new Toode(1,"Koola", 1.5, true),
            new Toode(2,"Fanta", 1.0, false),
            new Toode(3,"Sprite", 1.7, true),
            new Toode(4,"Vichy", 2.0, true),
            new Toode(5,"Vitamin well", 2.5, true)
        };

        // GET https://localhost:7146/tooted
        [HttpGet]
        public List<Toode> Get()
        {
            return _tooted;
        }

        // DELETE https://localhost:7146/tooted/kustuta/0
        [HttpDelete("kustuta/{index}")]
        public List<Toode> Delete(int index)
        {
            _tooted.RemoveAt(index);
            return _tooted;
        }

        [HttpDelete("kustuta2/{index}")]
        public string Delete2(int index)
        {
            _tooted.RemoveAt(index);
            return "Kustutatud!";
        }

        // POST https://localhost:7146/tooted/lisa/1/Coca/1.5/true
        [HttpPost("lisa/{id}/{nimi}/{hind}/{aktiivne}")]
        public List<Toode> Add(int id, string nimi, double hind, bool aktiivne)
        {
            Toode toode = new Toode(id, nimi, hind, aktiivne);
            _tooted.Add(toode);
            return _tooted;
        }

        [HttpPost("lisa2")]
        public List<Toode> Add2(int id, string nimi, double hind, bool aktiivne)
        {
            Toode toode = new Toode(id, nimi, hind, aktiivne);
            _tooted.Add(toode);
            return _tooted;
        }

        // PATCH https://localhost:7146/tooted/hind-dollaritesse/1.5
        [HttpPatch("hind-dollaritesse/{kurss}")]
        public List<Toode> UpdatePrices(double kurss)
        {
            for (int i = 0; i < _tooted.Count; i++)
            {
                _tooted[i].Price = _tooted[i].Price * kurss;
            }
            return _tooted;
        }
        [HttpPost("lisa")]
        public List<Toode> Add([FromBody] Toode toode)
        {
            _tooted.Add(toode);
            return _tooted;
        }
    }
    //[Route("api/[controller]")]
    //[ApiController]
    //public class TootedController : ControllerBase
    //{
    //    private static List<Toode> _tooted = new()
    //    {
    //    new Toode(1,"Koola", 1.5, true),
    //    new Toode(2,"Fanta", 1.0, false),
    //    new Toode(3,"Sprite", 1.7, true),
    //    new Toode(4,"Vichy", 2.0, true),
    //    new Toode(5,"Vitamin well", 2.5, true)
    //    };
    //    //tooted
    //    [HttpGet]
    //    public List<Toode> Get()
    //    {
    //        return _tooted;
    //    }
    //    // tooted/kustuta/0
    //    [HttpGet("kustuta/{index}")]
    //    public List<Toode> Delete(int index)
    //    {
    //        _tooted.RemoveAt(index);
    //        return _tooted;
    //    }
    //    [HttpGet("kustuta2/{index}")]
    //    public string Delete2(int index)
    //    {
    //        _tooted.RemoveAt(index);
    //        return "oli kustutatud!";
    //    }
    //    [HttpGet("lisa/{id}/{nimi}/{hind}/{aktiivne}")]
    //    public List<Toode> Add(int id, string nimi, double hind, bool aktiivne)
    //    {
    //        Toode toode = new Toode(id, nimi, hind, aktiivne);
    //        _tooted.Add(toode);
    //        return _tooted;
    //    }
    //    [HttpGet("lisa")] // GET /tooted/lisa?id=1&nimi=Koola&hind=1.5&aktiivne=true
    //    public List<Toode> Add2([FromQuery] int id, [FromQuery] string nimi, [FromQuery] double hind, [FromQuery] bool aktiivne)
    //    {
    //        Toode toode = new Toode(id, nimi, hind, aktiivne);
    //        _tooted.Add(toode);
    //        return _tooted;
    //    }
    //    [HttpGet("hind-dollaritesse/{kurss}")] // GET /tooted/hind-dollaritesse/1.5
    //    public List<Toode> Dollaritesse(double kurss)
    //    {
    //        for (int i = 0; i < _tooted.Count; i++)
    //        {
    //            _tooted[i].Price = _tooted[i].Price * kurss;
    //        }
    //        return _tooted;
    //    }
    //    // või foreachina:
    //    [HttpGet("hind-dollaritesse2/{kurss}")] // GET /tooted/hind-dollaritesse2/1.5
    //    public List<Toode> Dollaritesse2(double kurss)
    //    {
    //        foreach (var t in _tooted)
    //        {
    //            t.Price = t.Price * kurss;
    //        }
    //        return _tooted;
    //    }
    //    [HttpGet("kustuta3")]
    //    public string DeleteAll()
    //    {
    //        _tooted.Clear();
    //        return "Kõik tooted oli kustutatud";
    //    }
    //}
}
