using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    internal class enemigo
    {
        private float vida = 200;
        private float daño = 5;
        private bool muerte;
        public float Vida { get { return vida; } }

        public float Daño { get { return daño; } set { daño = value; } }
        public bool Muerte { get { return muerte; } }

        public void vidaenemigo(float daño)
        {
            vida -= daño;
            if (vida == 0) muerte = true;
        }
    }
}
