using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dominio.Consultas;
using Dominio.Dto;
using Dominio.Entidades;
using Repositorio;
using Servicios.Conversiones;
using Servicios.Models;
using System.Threading.Tasks;
using System.Threading;

namespace Servicios.Impl
{
    public class Servidor : IServidor
    {
        private readonly IRepositorio repositorio;
        private readonly IConversor conversor;
        private readonly Mundo mundo;
        private bool Started;

        public Servidor(IRepositorio repositorio, IConversor conversor)
        {
            this.repositorio = repositorio;
            this.conversor = conversor;
            mundo = Mundo.ObtenerMundo(repositorio);
        }

        public void Start()
        {
            Started = true;
            Task.Run(() => {
                while (Started)
                {
                    mundo.Ejecutar();
                    Thread.Sleep(1000);
                }
            });
        }
        public void Stop()
        {
            Started = false;
        }

    }
}
