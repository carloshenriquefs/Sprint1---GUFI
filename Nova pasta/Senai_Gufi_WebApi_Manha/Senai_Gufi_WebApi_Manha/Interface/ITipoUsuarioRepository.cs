using Senai_Gufi_WebApi_Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Gufi_WebApi_Manha.Interface
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();

       TipoUsuario BuscarPorId(int id);

        void Cadastrar(TipoUsuario novoTipoUsuario);

        void Atualizar(int id, TipoUsuario tipoUsuarioNovo);

        void Deletar(int id);
    }
}
