using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        GufiContext ctx = new GufiContext();

        public void Atualizar(int id, Evento eventosAtualizado)
        {
            Evento eventoBuscado = ctx.Evento.Find(id);

            eventoBuscado.IdEvento = eventosAtualizado.IdEvento;

            ctx.Evento.Update(eventoBuscado);

            ctx.SaveChanges();
        }

        public Evento BuscarPorId(int id)
        {
            return ctx.Evento.FirstOrDefault(e => e.IdEvento == id);
        }

        public void Cadastrar(Evento novoEvento)
        {
            ctx.Evento.Add(novoEvento);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Evento.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Evento> Listar()
        {
            return ctx.Evento.ToList();
        }
    }
}
