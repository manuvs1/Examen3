using Servicios_18_20.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Servicios_18_20.Clases
{
    public class clsEvento
    {
        private EventosEntities dbEventos = new EventosEntities(); // Objeto para gestionar los datos con la base de datos
        public Evento evento { get; set; } // Objeto tipo Evento para gestionar el CRUD

        public string Insertar()
        {
            try
            {
                dbEventos.Eventos.Add(evento);
                dbEventos.SaveChanges();
                return "Evento insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el evento: " + ex.Message + " --- " + ex.InnerException?.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                Evento ev = ConsultarPorId(evento.idEventos);
                if (ev == null)
                {
                    return "Evento no existe";
                }
                dbEventos.Eventos.AddOrUpdate(evento);
                dbEventos.SaveChanges();
                return "Evento actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar el evento: " + ex.Message;
            }
        }

        public Evento ConsultarPorId(int id)
        {
            return dbEventos.Eventos.FirstOrDefault(e => e.idEventos == id);
        }

        public string Eliminar(int idEventos)
        {
            try
            {
                Evento ev = ConsultarPorId(idEventos);
                if (ev == null)
                {
                    return "Evento no existe";
                }
                dbEventos.Eventos.Remove(ev);
                dbEventos.SaveChanges();
                return "Evento eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el evento: " + ex.Message;
            }
        }

        public List<Evento> ConsultarTodos()
        {
            return dbEventos.Eventos
                .OrderBy(e => e.FechaEvento)
                .ToList();
        }

        public List<Evento> ConsultarPorTipo(string tipoEvento)
        {
            return dbEventos.Eventos
                .Where(e => e.TipoEvento.Contains(tipoEvento))
                .OrderBy(e => e.FechaEvento)
                .ToList();
        }

        public List<Evento> ConsultarPorNombre(string nombreEvento)
        {
            return dbEventos.Eventos
                .Where(e => e.NombreEvento.Contains(nombreEvento))
                .OrderBy(e => e.FechaEvento)
                .ToList();
        }

        public List<Evento> ConsultarPorFecha(DateTime fecha)
        {
            return dbEventos.Eventos
                .Where(e => e.FechaEvento == fecha)
                .OrderBy(e => e.NombreEvento)
                .ToList();
        }
    }
}
