using Senai_Gufi_WebApi_Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Gufi_WebApi_Manha.Interface
{
    interface ITipoEventoRepository
    {
        List<TipoEvento> Listar();

        TipoEvento BuscarPorId(int id);

        void Cadastrar(TipoEvento novoTipoEvento);

        void Deletar(int id);

        void Atualizar(int id, TipoEvento eventoAtualizado);
    }
}
