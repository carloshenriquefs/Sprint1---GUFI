using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        GufiContext ctx = new GufiContext();

        public void Atualizar(int id, Instituicao instituicaoAtualizado)
        {
            Instituicao instituicaoBuscada = ctx.Instituicao.Find(id);

            instituicaoBuscada.IdInstituicao = instituicaoAtualizado.IdInstituicao;

            ctx.Instituicao.Update(instituicaoBuscada);

            ctx.SaveChanges();
        }

        public Instituicao BuscarPorId(int id)
        {
            return ctx.Instituicao.FirstOrDefault(i => i.IdInstituicao == id);
        }

        public void Cadastrar(Instituicao novaInstituicao)
        {
            ctx.Instituicao.Add(novaInstituicao);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Instituicao.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Instituicao> Listar()
        {
            return ctx.Instituicao.ToList();
        }
    }
}
