using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.BaseDeDatos;
using MVC.DTOs;
using MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly DataBaseContext contexto;
        private readonly IMapper mapper;

        public PeliculasController(DataBaseContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<PeliculaDTO> List()
        {
            //contexto.Peliculas.Include(p => p.Genero).Select(p => mapper.Map<PeliculaDTO>(p)).ToList();
            return contexto.Peliculas.Include(p => p.Genero).ProjectTo<PeliculaDTO>(mapper.ConfigurationProvider).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<PeliculaDTO> Get(int id)
        {
            var pelicula = contexto.Peliculas.Include(p => p.Genero).ProjectTo<ClienteDTO>(mapper.ConfigurationProvider).SingleOrDefault(c => c.Id == id);
            //if (cliente == null)
            //    throw new HttpResponseException();
            if (pelicula == null)
                return NoContent();

            return Ok(pelicula);
        }

        [HttpPost]
        public ActionResult<PeliculaDTO> Crear(PeliculaDTO peliculaDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(peliculaDTO);

            var pelicula = mapper.Map<Pelicula>(peliculaDTO);
            contexto.Peliculas.Add(pelicula);
            contexto.SaveChanges();
            peliculaDTO.Id = pelicula.Id;
            return Created(Request.Path.Value + "/" + peliculaDTO.Id, peliculaDTO);
        }

        [HttpPut]
        public ActionResult<PeliculaDTO> Actualizar(int id, PeliculaDTO pelicula)
        {
            //if (!ModelState.IsValid)
            //    throw BadRequest<Cliente>(cliente);
            if (!ModelState.IsValid)
                return BadRequest(pelicula);

            var peliculaInDB = contexto.Peliculas.SingleOrDefault(c => c.Id == id);
            //if (clienteInDB == null)
            //    throw new HttpResponseException();
            if (peliculaInDB == null)
                return NoContent();

            mapper.Map(pelicula, peliculaInDB);

            contexto.SaveChanges();
            return Ok(pelicula);
        }

        [HttpDelete("{id}")]
        public ActionResult Borrar(int id)
        {
            var peliculaInDB = contexto.Peliculas.SingleOrDefault(c => c.Id == id);
            //if (clienteInDB == null)
            //    throw new HttpResponseException();
            if (peliculaInDB == null)
                return NoContent();

            contexto.Peliculas.Remove(peliculaInDB);
            contexto.SaveChanges();
            return Ok();
        }
    }    
}
