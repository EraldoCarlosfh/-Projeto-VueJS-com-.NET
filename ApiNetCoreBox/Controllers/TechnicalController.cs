using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using ApiNetCoreBox.Data;
using ApiNetCoreBox.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiNetCoreBox.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicalController : ControllerBase
    {
        private readonly IRepository _repo;

        public TechnicalController(IRepository repo)
        {
            _repo = repo;
        }



        ///<summary>
        ///Obter todos os técnicos!
        ///</summary>
        ///<response code="200">A lista de técnicos foi obtida com sucesso</response>
        ///<response code="500">error ao obter lista de técnicos</response>
        [ProducesResponseType(typeof(List<Technical>), 200)]
        [HttpGet]// GET: api/Technical
        public async Task<IActionResult> Get()
        {
            try
            {
                var technicals = await _repo.GetAllTechnicals(true);

                return Ok(technicals);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET: api/Technical/5
        [HttpGet("{id}", Name = "GetTechnical")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var technical = await _repo.GetTechnicalById(id, true);

                return Ok(technical);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // POST: api/Technical
        [HttpPost]
        public async Task<IActionResult> Post(Technical model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangeAsync())
                {
                    return Ok("Cadastrado com Sucesso");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Error ao Não Salvou");
        }

        // PUT: api/Technical/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Technical model)
        {  

            try
            {
                var technical = await _repo.GetTechnicalById(id, true);
                if (technical != null)
                {
                   foreach (var stack in technical.Stacks)
                   {
                       model.Stacks.Append(stack);
                   }

                   _repo.Update(model);
 
                    if (await _repo.SaveChangeAsync())
                        return Ok("Alterado com Sucesso");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest($"Não Deletado!");
        }

        // DELETE: api/Technical/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                
                var technical = await _repo.GetTechnicalById(id, true);
                var stack = await _repo.GetStackById(id);
                if (technical != null)
                {                                  
                    _repo.Delete(stack);                    
                    if (await _repo.SaveChangeAsync()){

                     technical = await _repo.GetTechnicalById(id, true);
                     _repo.Delete(technical);

                     if (await _repo.SaveChangeAsync()) {                    
                        return Ok("Deletado com Sucesso");
                         
                     } 
                }
                
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest($"Não Deletado!");
        }
    }
}