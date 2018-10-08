﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    //http://localhost:5000/api/[controller]   
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
                   _context = context;     
        }
        
        
         // GET api/values
        [HttpGet]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult>  GetValues()
        {
            var values= await _context.Values.ToListAsync();        
            return Ok(values);
        }
       



        // GET api/values
        // [HttpGet] 
        // public ActionResult<IEnumerable<string>> Get()
        // {
        //     // throw new Exception();
        //     return new string[] { "value1", "value2" };
        // }

        // GET api/values/5
        [Authorize(Roles="Member")]
        [HttpGet("{id}")]
        public  async Task<IActionResult>  Get(int id)
        {            
            var value = await _context.Values.FirstOrDefaultAsync(x=> x.Id == id);
            // var value = _context.Values.Where(x => x.Id == id).FirstOrDefault();
            // return  (value != null)?  Ok(value) : Ok("No content found!");             
             return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}