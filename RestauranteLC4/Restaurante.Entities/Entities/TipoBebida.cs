using System.Collections.Generic;

namespace Restaurante.Entities
{
    public class TipoBebida
    {
        public int TipoBebidaId {get;set;}
        public string Nombre { get; set; }

        public List<Bebida> Bebidas { get; set; }

        public TipoBebida()
        {
            Bebidas = new List<Bebida>();
        }
    }
}