﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DattingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Datting.API.Controllers
{
    [Authorize()]
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
        public async Task<IActionResult> GetValues()
        {
            var val = await _context.values.ToListAsync();
            return Ok(val);
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
             var val = _context.values.FirstOrDefaultAsync(x=>x.Id == id);
             return Ok(val);
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
