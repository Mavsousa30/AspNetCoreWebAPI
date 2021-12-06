using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        public readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllProfessores(true));
        }

        // GET api/<ProfessorController>/5
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var Professor = _repo.GetProfessorById(id, false);
            if (Professor == null) return BadRequest("Professor não encontrado");
            return Ok(Professor);
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public IActionResult Post(Professor Professor)
        {
            _repo.Add(Professor);
            _repo.SaveChanges();
            return Ok(Professor);
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor Professor)
        {
            var pro = _repo.GetProfessorById(id);
            if (pro == null) return BadRequest("Professor não encontrado");
            _repo.Update(Professor);
            _repo.SaveChanges();
            return Ok(Professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor Professor)
        {
            var pro = _repo.GetProfessorById(id);
            if (pro == null) return BadRequest("Professor não encontrado");
            _repo.Update(Professor);
            _repo.SaveChanges();
            return Ok(Professor);
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Professor = _repo.GetProfessorById(id);
            if (Professor == null) return BadRequest("Professor não encontrado");
            _repo.Delete(Professor);
            _repo.SaveChanges();
            return Ok(Professor);
        }
    }
}
