using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class jugador
    {
        private string nombre;
        private float vida;
        private float daño;
        private bool muerte;

        public string Name { get { return nombre; } }
        public float Damage { get { return daño; } }
        public bool Dead { get { return muerte; } }

        public jugador(string nombre, float vida, float daño)
        {
            this.nombre = nombre;
            this.vida = vida;
            this.daño = daño;
        }

        public void PlayerHealth(float daño, bool golpe)
        {
            if (golpe)
            {
                vida -= daño;

                if (vida == 0) muerte = true;
            }
        }
        public string Data()
        {
            return $"{nombre} - {vida} - {daño}";
        }
    }
}    
