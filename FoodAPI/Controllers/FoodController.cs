using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodAPI.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        // GET: api/Food
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Food/5
        [HttpGet("SaveScanned/{user}/{barcode}/{product}/{calories}/{percent}", Name = "SaveScanned")]
        public string SaveScanned(string user, string barcode, string product, string calories, string percent)
        {
            Console.WriteLine($"Received: {user}-{barcode}-{product}-{calories}-{percent}");
            try
            {
                var fc = new foodcount();
                fc.UserID = user;
                fc.Barcode = barcode;
                fc.DateTime = DateTime.Now.ToString();
                fc.Calories = calories;
                fc.Product = product;
                fc.Percent = percent;

                MongoClient dbClient = new MongoClient("mongodb://admin:Tuesday9dave@cidb.co.uk");

                var database = dbClient.GetDatabase("foodapi");
                var collection = database.GetCollection<foodcount>("FoodCount");
                collection.InsertOne(fc);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return $"barcode {barcode}";
        }

        // GET: api/Food/5
        [HttpGet("GetToday/{user}", Name = "GetToday")]
        public string GetToday(string user)
        {
            Console.WriteLine($"Received: {user}");
            try
            {
                var fc = new foodcount();
                fc.UserID = user;        
                fc.DateTime = DateTime.Now.ToString();        

                MongoClient dbClient = new MongoClient("mongodb://admin:Tuesday9dave@cidb.co.uk");

                var database = dbClient.GetDatabase("foodapi");
                var collection = database.GetCollection<foodcount>("FoodCount");
                var id = "1";
                //var allToday = collection.Find(x => x.UserID == id && x.DateTime).ToList();


                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return $"user {user}";
        }


        // GET: api/Food/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Food
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Food/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
