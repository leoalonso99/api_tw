using System.Collections.Generic;
using System.Threading.Tasks;
using api_tw.Models;
using api_tw.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace api_tw.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    public class CategoriaController : ControllerBase
    {
        CategoriaRepositorio repositorio = new CategoriaRepositorio();


        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            try
            {
                return await repositorio.Get();
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            try
            {
                return await repositorio.Get(id);
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        [HttpPost]

        public async Task<ActionResult<Categoria>> Post(Categoria categoria)
        {
            try
            {
                return await repositorio.Post(categoria);
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Categoria>> Put(int id, Categoria categoria)
        {
            if (id != categoria.IdCategoria)
            {
                return BadRequest();
            }
            try
            {
                await repositorio.Put(categoria);
            }
            catch (System.Exception)
            {
                var cat = repositorio.Get(id);
                if (cat == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return categoria;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            var buscaId = await repositorio.Get(id);
            if (buscaId == null)
            {
                return NotFound();             
            }
            await repositorio.Delete(buscaId);
            return buscaId;

        }


    }
}