using Senai.Gufi.WebApi.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Interfaces
{
    interface IPresencaRepository
    {
        List<Presenca> Listar();

        void Situacao(Presenca statusSituacao);

        void Convidar(Presenca usuario);

        void InscricaoEvento(Presenca novaPresenca);

        //Presenca BuscarPorId(int id);
    }
}
