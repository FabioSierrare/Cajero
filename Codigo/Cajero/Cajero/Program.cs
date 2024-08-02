using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cajero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Cuentas> ObjCuenta = new List<Cuentas>();

            ObjCuenta.Add(new Cuentas());
            ObjCuenta[0].NumeroCuenta = 1000;
            ObjCuenta[0].pin = 1234;
            ObjCuenta[0].saldo = 200;


            ObjCuenta.Add(new Cuentas());
            ObjCuenta[1].NumeroCuenta = 1001;
            ObjCuenta[1].pin = 0000;
            ObjCuenta[1].saldo = 1200;

            ObjCuenta.Add(new Cuentas());
            ObjCuenta[2].NumeroCuenta = 1002;
            ObjCuenta[2].pin = 4321;
            ObjCuenta[2].saldo = 452;

            int b = 0;
            while (b != -1)
            {
                b = 1;
                Console.Clear();

                Console.WriteLine("Digite el numero de cuentas");
                int cverificar = int.Parse(Console.ReadLine());

                for (int i = 0; i < ObjCuenta.Count; i++)
                {
                    if (ObjCuenta[i].NumeroCuenta == cverificar)
                    {
                        Console.Clear();
                        Console.WriteLine("Digite Pin");
                        int pin = int.Parse(Console.ReadLine());


                        while (ObjCuenta[i].pin != pin && pin != 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Pin incorrecto vuelva a digitarlo o escriba 0 para salir");
                            pin = int.Parse(Console.ReadLine());
                            Console.WriteLine(ObjCuenta.Count);
                        }

                        if (pin == ObjCuenta[i].pin)
                        {
                            int x = 0;
                            while (x != 5)
                            {
                                Console.WriteLine("Digite la opciones n");
                                int op = int.Parse(Console.ReadLine());

                                switch (op)
                                {
                                    case 1:
                                        break;
                                    case 2:
                                        break;
                                    case 3:
                                        break;
                                    case 4:
                                        break;
                                    case 5:
                                        break;

                                }
                                b = 1;
                            }
                        }
                    }
                }
                if (b == 0)
                {
                    Console.WriteLine("Cuenta no iniciada");
                }
                Console.ReadKey();
            }
        }

        public class Cuentas
        {
            public int NumeroCuenta { get; set; }
            public int pin { get; set; }
            public double saldo { get; set; }
        }
    }
}
