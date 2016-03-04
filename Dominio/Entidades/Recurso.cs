﻿using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Recurso : IIdentificable
    {
        [Key]
        public int Id { get; set; }

        public virtual Material Material { get; set; }

        public virtual Edificio Edificio { get; set; }
    }
}
