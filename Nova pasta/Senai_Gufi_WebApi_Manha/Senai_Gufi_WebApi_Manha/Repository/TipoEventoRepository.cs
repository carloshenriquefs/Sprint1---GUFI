using Senai_Gufi_WebApi_Manha.Domains;
using Senai_Gufi_WebApi_Manha.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Gufi_WebApi_Manha.Repository
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        GufiContext ctx = new GufiContext();

        public void Atualizar(int id, TipoEvento eventoAtualizado)
        {
            TipoEvento tipoEventoBuscado = ctx.TipoEvento.Find(id);

            tipoEventoBuscado.IdTipoEvento = eventoAtualizado.IdTipoEvento;
            tipoEventoBuscado.TituloTipoEvento = eventoAtualizado.TituloTipoEvento;

            ctx.TipoEvento.Update(tipoEventoBuscado);

            ctx.SaveChanges();

        }

        public TipoEvento BuscarPorId(int id)
        {
            return ctx.TipoEvento.FirstOrDefault(te => te.IdTipoEvento == id);
        }

        public void Cadastrar(TipoEvento novoTipoEvento)
        {
            ctx.TipoEvento.Add(novoTipoEvento);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.TipoEvento.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<TipoEvento> Listar()
        {
            return ctx.TipoEvento.ToList();
        }
    }
}
