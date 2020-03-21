using Senai_Gufi_WebApi_Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Gufi_WebApi_Manha.Interface
{
    interface IPresencaRepository
    {
        List<Presenca> Listar();

        void Convidar(Presenca novoConvidado);

        void InscricaoEvento(Presenca novaPresenca);

        void Situacao(Presenca statusSituacao);

        List<Presenca> ListarMeusEventos(int id);

    }
}
