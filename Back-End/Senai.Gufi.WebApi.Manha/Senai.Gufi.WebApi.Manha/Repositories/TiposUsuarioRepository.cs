using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        GufiContext ctx = new GufiContext();

        public void Atualizar(int id, TipoUsuario tipoInstituicaoAtualizado)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(id);

            tipoUsuarioBuscado.IdTipoUsuario = tipoInstituicaoAtualizado.IdTipoUsuario;

            ctx.TipoUsuario.Update(tipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuario.FirstOrDefault(tu => tu.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario novoTipoInstituicao)
        {
            ctx.TipoUsuario.Add(novoTipoInstituicao);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.TipoUsuario.Remove(BuscarPorId(id));

            ctx.SaveChanges();


        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuario.ToList();
        }
    }
}
