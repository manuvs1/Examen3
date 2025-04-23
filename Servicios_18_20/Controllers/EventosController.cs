using Servicios_18_20.Clases;
using Servicios_18_20.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Servicios_18_20.Controllers
{
    [RoutePrefix("api/Eventos")]
    [Authorize]

    public class EventosController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Evento> ConsultarTodos()
        {
            clsEvento evento = new clsEvento();
            return evento.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Evento ConsultarXId(int idEventos)
        {
            clsEvento evento = new clsEvento();
            return evento.ConsultarPorId(idEventos);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Evento nuevoEvento)
        {
            clsEvento evento = new clsEvento();
            evento.evento = nuevoEvento;
            return evento.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Evento eventoActualizado)
        {
            clsEvento evento = new clsEvento();
            evento.evento = eventoActualizado;
            return evento.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idEventos)
        {
            clsEvento evento = new clsEvento();
            return evento.Eliminar(idEventos);
        }

        [HttpGet]
        [Route("ConsultarPorTipo")]
        public List<Evento> ConsultarPorTipo(string tipoEvento)
        {
            clsEvento evento = new clsEvento();
            return evento.ConsultarPorTipo(tipoEvento);
        }

        [HttpGet]
        [Route("ConsultarPorNombre")]
        public List<Evento> ConsultarPorNombre(string nombreEvento)
        {
            clsEvento evento = new clsEvento();
            return evento.ConsultarPorNombre(nombreEvento);
        }

        [HttpGet]
        [Route("ConsultarPorFecha")]
        public List<Evento> ConsultarPorFecha(DateTime fecha)
        {
            clsEvento evento = new clsEvento();
            return evento.ConsultarPorFecha(fecha);
        }
    }
}

