using Senai.Gufi.WebApi.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Interfaces
{
    interface ITiposUsuarioRepository
    {
        List<TipoUsuario> Listar();

        void Cadastrar(TipoUsuario novoTipoInstituicao);

        void Atualizar(int id, TipoUsuario tipoInstituicaoAtualizado);

        void Deletar(int id);

        TipoUsuario BuscarPorId(int id);

    }
}
