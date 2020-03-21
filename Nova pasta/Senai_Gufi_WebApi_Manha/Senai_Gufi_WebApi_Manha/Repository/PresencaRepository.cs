using Senai_Gufi_WebApi_Manha.Domains;
using Senai_Gufi_WebApi_Manha.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Gufi_WebApi_Manha.Repository
{
    public class PresencaRepository : IPresencaRepository
    {
        GufiContext ctx = new GufiContext();

        public void Convidar(Presenca novoConvidado)
        {
            novoConvidado = new Presenca() { IdUsuario = novoConvidado.IdUsuario, IdEvento = novoConvidado.IdEvento, Situacao = "Aguardando" };

            ctx.Presenca.Add(novoConvidado);

            ctx.SaveChanges();
        }

        public void InscricaoEvento(Presenca novaPresenca)
        {
            novaPresenca = new Presenca() { IdUsuario = novaPresenca.IdUsuario, IdEvento = novaPresenca.IdEvento };

            ctx.Presenca.Add(novaPresenca);

            ctx.SaveChanges();
        }

        public List<Presenca> Listar()
        {
            return ctx.Presenca.ToList();
        }

        public List<Presenca> ListarMeusEventos(int id)
        {
            return ctx.Presenca.ToList().FindAll(me => me.IdEvento == id);
        }

        public void Situacao(Presenca statusSituacao)
        {
            statusSituacao = new Presenca() { Situacao = statusSituacao.Situacao };

            ctx.Presenca.Update(statusSituacao);

            ctx.SaveChanges();
        }
    }
}
