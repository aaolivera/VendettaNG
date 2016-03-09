using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Usuario : ObjetoEjecutable
    {
        public virtual string Email { get; set; }

        private ICollection<Edificio> _edificios;
        public virtual ICollection<Edificio> Edificios { get { return _edificios ?? (_edificios = new List<Edificio>()); } }

        public virtual ICollection<Amistad> Amigos { get; set; }

        public virtual Familia Familia { get; set; }

        public override void Ejecutar()
        {
            foreach (var i in Edificios)
            {
                i.Ejecutar();
            }
        }
    }
}
