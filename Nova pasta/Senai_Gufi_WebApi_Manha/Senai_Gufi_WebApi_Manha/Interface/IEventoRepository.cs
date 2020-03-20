using Senai_Gufi_WebApi_Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Gufi_WebApi_Manha.Interface
{
    interface IEventoRepository
    {
        List<Evento> Listar();

        Evento BuscarPorId(int id);

        void Cadastrar(Evento novoEvento);

        void Atualizar(int id, Evento eventoAtualizado);

        void Deletar(int id);
    }
}
