using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class menu
    {
        private enemigo enemigo;
        private jugador jugador;
        private bool menus;
        private bool iniciarjuego;
        private bool turnojugador;
        

        public void ejecutarcodigo()
        {
            StartMenu();
        }

        private void StartMenu()
        {
            int select;
            menus = true;
            while (menus)
            {
                Console.WriteLine("Elija la opción");
                Console.WriteLine("1. Registrarse");
                Console.WriteLine("2. Empezar juego");
                Console.WriteLine("3. Salir");

                select = int.Parse(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        CreatePlayer();
                        break;
                    case 2:
                        StartGame();
                        break;
                    case 3:
                        menus = false;
                        break;
                    default:
                        Console.WriteLine("Elección incorrecta");
                        break;
                }
            }
        }
        private void CreatePlayer()
        {
            string name = PlayerName();
            float health = PlayerHealth();
            float damage = PlayerDamage();

            jugador= new jugador(name, health, damage);
        }
        private string PlayerName()
        {
            string name;
            Console.WriteLine("Introduzca tu nombre");
            name = Console.ReadLine();
            Console.WriteLine($"Registrado, hola {name}");
            return name;
        }
        private float PlayerDamage()
        {
            int damage = 0;
            bool repeatLoop = true;
            while (repeatLoop)
            {
                Console.WriteLine("El daño que quiera hacer");
                damage = int.Parse(Console.ReadLine());
                Console.WriteLine($"Tu daño total es {damage}");
                if (damage <= 100)
                {
                    repeatLoop = false;
                    Console.WriteLine("Muy bien.");
                }

                else if (damage == 0) Console.WriteLine("No puedes poner 0, intente de nuevo.");

                else Console.WriteLine("El valor es muy grande. Máx 100. Intente de nuevo");

            }
            return damage;
        }
        private float PlayerHealth()
        {
            int health = 0;
            bool repeatLoop = true;
            while (repeatLoop)
            {
                Console.WriteLine("Ponga su vida máxima");
                health = int.Parse(Console.ReadLine());
                Console.WriteLine($"Tu vida máxima es {health}");
                if (health <= 100)
                {
                    repeatLoop = false;
                    Console.WriteLine("Muy bien. prosiga.");
                }
                else if (health == 0) Console.WriteLine("No puedes poner 0, intente de nuevo");

                else Console.WriteLine("El valor es muy grande, máx 100, intente de nuevo");
            }
            return health;
        }
        private void StartGame()
        {
            iniciarjuego = true;
            enemigo = new enemigo();
            while (iniciarjuego)
            {
                menus = false;
                enemigo.vidaenemigo (100);
                enemigo.Daño = 20;

                int n;

                Console.WriteLine("Elija las opciones contra el enemigo");
                Console.WriteLine("Enemigo: 100 HP - 20 DMG");
                Console.WriteLine("1. Atacar | 2. Esquivar");
                turnojugador = true;
                
                n = int.Parse(Console.ReadLine());

                if (turnojugador)
                {
                    switch (n)
                    {
                        case 1:
                            enemigo.vidaenemigo(jugador.Damage);
                            Console.WriteLine($"Atacaste {jugador.Damage}");
                            turnojugador = false;
                            
                            break;
                        case 2:
                            Console.WriteLine("Esquivaste");
                            turnojugador = false;
                            
                            break;
                        default:
                            Console.WriteLine("Valor incorrecto");
                            break;
                    }
                }
                else if (!turnojugador)
                {
                     jugador.PlayerHealth(enemigo.Daño, true);
                     Console.WriteLine($"Recibiste {enemigo.Daño} por parte del enemigo");
                     turnojugador = true;
                }

                if (jugador.Dead)
                {
                    int b;
                    Console.WriteLine("Perdiste");
                    Console.WriteLine("1. Volver al menú");
                    b = int.Parse(Console.ReadLine());

                    switch (b)
                    {
                        case 1:
                            iniciarjuego = false;
                            menus = true;
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }

                }
                else if (enemigo.Vida <= 0)
                {
                    int v;
                    Console.WriteLine("Ganaste");
                    Console.WriteLine("1. Volver al menú");
                    v = int.Parse(Console.ReadLine());

                    switch (v)
                    {
                        case 1:
                            iniciarjuego = false;
                            menus = true;
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }
                }
            }
        }
    }
}