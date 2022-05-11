using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.BaseDeDatos;
using MVC.DTOs;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly DataBaseContext contexto;
        private readonly IMapper mapper;

        public ClientesController(IMapper mapper)
        {
            contexto = new DataBaseContext();
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ClienteDTO> List()
        {
            contexto.Clientes.Include(c => c.TipoMembresia).Select(c => mapper.Map<ClienteDTO>(c)).ToList();
            return contexto.Clientes.ProjectTo<ClienteDTO>(mapper.ConfigurationProvider).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ClienteDTO> Get(int id)
        {
            var cliente = contexto.Clientes.ProjectTo<ClienteDTO>(mapper.ConfigurationProvider).SingleOrDefault(c => c.Id == id);
            //if (cliente == null)
            //    throw new HttpResponseException();
            if (cliente == null)
                return NoContent();

            return Ok(cliente);
        }

        [HttpPost]
        public ActionResult<ClienteDTO> CrearCliente(ClienteDTO clienteDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(clienteDTO);

            var cliente = mapper.Map<Cliente>(clienteDTO);
            contexto.Clientes.Add(cliente);
            contexto.SaveChanges();
            clienteDTO.Id = cliente.Id;
            return Created(Request.Path.Value + "/" + clienteDTO.Id,clienteDTO);
        }

        [HttpPut]
        public ActionResult<ClienteDTO> ActualizarCliente(int id, ClienteDTO cliente)
        {
            //if (!ModelState.IsValid)
            //    throw BadRequest<Cliente>(cliente);
            if (!ModelState.IsValid)
                return BadRequest(cliente);

            var clienteInDB = contexto.Clientes.SingleOrDefault(c => c.Id == id);
            //if (clienteInDB == null)
            //    throw new HttpResponseException();
            if (clienteInDB == null)
                return NoContent();

            mapper.Map(cliente, clienteInDB);

            contexto.SaveChanges();
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public ActionResult BorrarCliente(int id)
        {
            var clienteInDB = contexto.Clientes.SingleOrDefault(c => c.Id == id);
            //if (clienteInDB == null)
            //    throw new HttpResponseException();
            if (clienteInDB == null)
                return NoContent();

            contexto.Clientes.Remove(clienteInDB);
            contexto.SaveChanges();
            return Ok();
        }
    }
}
