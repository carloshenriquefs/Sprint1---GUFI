using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        GufiContext ctx = new GufiContext();

        public void Atualizar(int id, Presenca presencaAtualizado)
        {
            Presenca presencaBuscada = ctx.Presenca.Find(id);

            presencaBuscada.IdPresenca = presencaAtualizado.IdPresenca;

            ctx.Presenca.Update(presencaBuscada);

            ctx.SaveChanges();
        }

        public List<Presenca> Listar()
        {
            return ctx.Presenca.ToList();
        }

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

        public void Situacao(Presenca statusSituacao)
        {
            statusSituacao = new Presenca() { Situacao = statusSituacao.Situacao};

            ctx.Presenca.Update(statusSituacao);

            ctx.SaveChanges();
        }
    }
}
