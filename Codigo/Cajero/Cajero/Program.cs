using System;
using System.Collections.Generic;
using System.IO;
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

        public class MetodosCajero
        {
            public void retirar(Cuentas cuenta, double cantidad)
            {
                DateTime fecha = DateTime.Now;
                if (cantidad <= cuenta.saldo && cantidad >= 10 && cantidad <= 2400000)
                {
                    //Hago que el texto se guarde en un documento de texto sin borrar los datos ya escritos
                    using (StreamWriter fact = new StreamWriter("C:\\Users\\Fasire\\Desktop\\Factura.txt", true))
                    {
                        fact.WriteLine("----------------------------------------------");
                        fact.WriteLine("|Factura - CUENTA: {0}", cuenta);
                        fact.WriteLine("----------------------------------------------");
                        fact.WriteLine("COMPROBANTE DE cantidad");
                        fact.WriteLine("----------------------------------------------");
                        fact.WriteLine("|Fecha y hora: {0}", fecha);
                        fact.WriteLine("----------------------------------------------");
                        fact.WriteLine("Saldo actual: ${0}", cuenta.saldo);
                        fact.WriteLine("----------------------------------------------");
                        fact.WriteLine("|Monto retirado: ${0}", cantidad);
                        fact.WriteLine("----------------------------------------------");
                        cuenta.saldo -= cantidad;
                        fact.WriteLine("|Saldo restante: ${0}", cuenta.saldo);
                        fact.WriteLine("----------------------------------------------");
                        fact.WriteLine("|¡Gracias por utilizar nuestros servicios!");
                        fact.WriteLine("----------------------------------------------");
                        fact.WriteLine("");
                        fact.WriteLine("");
                    }
                }
                else
                {
                    using (StreamWriter fact = new StreamWriter("C:\\Users\\Fasire\\Desktop\\Factura.txt", true))
                    {
                        //cantidad se menor a 10.000
                        if (cantidad < 10)
                        {
                            fact.WriteLine("--------------------------------------------------");
                            fact.WriteLine("Factura - CUENTA: {0}", cuenta.NumeroCuenta);
                            fact.WriteLine("--------------------------------------------------");
                            fact.WriteLine("|Fecha y hora: {0}", fecha);
                            fact.WriteLine("--------------------------------------------------");
                            fact.WriteLine("|El minimo de cantidad es de $10");
                            fact.WriteLine("--------------------------------------------------");
                            fact.WriteLine("");
                            fact.WriteLine("");

                            //cantidad sea mayor a el saldo
                        }
                        else if (cantidad > cuenta.saldo)
                        {
                            fact.WriteLine("--------------------------------------------------");
                            fact.WriteLine("Factura - CUENTA: {0}", cuenta.NumeroCuenta);
                            fact.WriteLine("--------------------------------------------------");
                            fact.WriteLine("|Fecha y hora: {0}", fecha);
                            fact.WriteLine("--------------------------------------------------");
                            fact.WriteLine("|Saldo insuficiente");
                            fact.WriteLine("--------------------------------------------------");
                            fact.WriteLine("");
                            fact.WriteLine("");

                            //cantidad mayor a 2.400.000
                        }
                        else if (cantidad > 2400000)
                        {
                            fact.WriteLine("--------------------------------------------------");
                            fact.WriteLine("Factura - CUENTA: {0}", cuenta.NumeroCuenta);
                            fact.WriteLine("--------------------------------------------------");
                            fact.WriteLine("|Fecha y hora: {0}", fecha);
                            fact.WriteLine("--------------------------------------------------");
                            fact.WriteLine("|El maximo de cantidad es de $2.400.000");
                            fact.WriteLine("--------------------------------------------------");
                            fact.WriteLine("");
                            fact.WriteLine("");
                        }
                    }
                }

            }

            public void consigna(Cuentas cuenta)
            {
                //Cantidad a consignar y fecha
                Console.WriteLine("Digite la cantidad a consignar: ");
                int consignar = int.Parse(Console.ReadLine());
                DateTime fecha = DateTime.Now;
                Console.Clear();

                //Verifico que consignar sea mayor a 10.000
                if (consignar >= 10)
                {
                    using (StreamWriter fact = new StreamWriter("C:\\Users\\Fasire\\Desktop\\Factura.txt", true))
                    {
                        fact.WriteLine("----------------------------------------------");
                        fact.WriteLine("|Numero de cuenta: {0}", cuenta.NumeroCuenta);
                        fact.WriteLine("----------------------------------------------");
                        fact.WriteLine("COMPROBANTE DE CONSIGNACION");
                        fact.WriteLine("----------------------------------------------");
                        fact.WriteLine("|Fecha y hora: {0}", fecha);
                        fact.WriteLine("----------------------------------------------");
                        fact.WriteLine("Saldo actual: ${0}", cuenta.saldo);
                        fact.WriteLine("----------------------------------------------");
                        fact.WriteLine("|Monto a consignar: ${0}", consignar);
                        fact.WriteLine("----------------------------------------------");
                        cuenta.saldo += consignar;
                        fact.WriteLine("|Total saldo: ${0}", cuenta.saldo);
                        fact.WriteLine("----------------------------------------------");
                        fact.WriteLine("|¡Gracias por utilizar nuestros servicios!");
                        fact.WriteLine("----------------------------------------------");
                        fact.WriteLine("");
                        fact.WriteLine("");
                    }

                }
                else
                {
                    using (StreamWriter fact = new StreamWriter("C:\\Users\\Fasire\\Desktop\\Factura.txt", true))
                    {
                        fact.WriteLine("-----------------------------------------------------------");
                        fact.WriteLine("|Numero de cuenta: {0}", cuenta.NumeroCuenta);
                        fact.WriteLine("-----------------------------------------------------------");
                        fact.WriteLine("|Fecha y hora: {0}", fecha);
                        fact.WriteLine("-----------------------------------------------------------");
                        fact.WriteLine("|La cantidad a consignar debe ser mayor o igual 10.000");
                        fact.WriteLine("-----------------------------------------------------------");
                        fact.WriteLine("");
                        fact.WriteLine("");
                    }
                }
            }

            public void transferi(Cuentas cuenta, List<Cuentas> cuentas)
            {
                //datos de transferencia - ctransferir y cantidad
                //fecha y una variable sw
                Console.WriteLine("Digite el numero de cuenta a transeferir");
                int cuentat = int.Parse(Console.ReadLine());

                DateTime fecha = DateTime.Now;

                for (int i = 0; i < cuentas.Count; i++)
                {
                    Console.WriteLine("Digite la cantidad a transeferir");
                    double cantidaa = double.Parse(Console.ReadLine());
                    if (cuentas[i].NumeroCuenta == cuenta.NumeroCuenta)
                    {

                        if (cantidaa >= 10 && cantidaa <= cuenta.saldo)
                        {
                            using (StreamWriter fact = new StreamWriter("C:\\Users\\Fasire\\Desktop\\Factura.txt", true))
                            {
                                fact.WriteLine("----------------------------------------------");
                                fact.WriteLine("|Numero de cuenta: {0}", cuenta.NumeroCuenta);
                                fact.WriteLine("----------------------------------------------");
                                fact.WriteLine("COMPROBANTE DE TRANSFERENCIA");
                                fact.WriteLine("----------------------------------------------");
                                fact.WriteLine("|Fecha y hora: {0}", fecha);
                                fact.WriteLine("----------------------------------------------");
                                fact.WriteLine("Saldo actual: ${0}", cuenta.saldo);
                                fact.WriteLine("----------------------------------------------");
                                fact.WriteLine("|Monto a Transferir: ${0}", cantidaa);
                                fact.WriteLine("----------------------------------------------");
                                fact.WriteLine("|Transferir a: {0}", cuentat);
                                fact.WriteLine("----------------------------------------------");
                                cuenta.saldo -= cantidaa;
                                cuentas[i].saldo += cantidaa;
                                fact.WriteLine("|Total saldo: ${0}", cuenta.saldo);
                                fact.WriteLine("----------------------------------------------");
                                fact.WriteLine("|¡Gracias por utilizar nuestros servicios!");
                                fact.WriteLine("----------------------------------------------");
                                fact.WriteLine("");
                                fact.WriteLine("");
                            }

                        }
                        else
                        {
                            using (StreamWriter fact = new StreamWriter("C:\\Users\\Fasire\\Desktop\\Factura.txt", true))
                            {
                                if (cantidaa < 10)
                                {
                                    fact.WriteLine("--------------------------------------------------");
                                    fact.WriteLine("|Numero de cuenta: {0}", cuenta.NumeroCuenta);
                                    fact.WriteLine("--------------------------------------------------");
                                    fact.WriteLine("|Fecha y hora: {0}", fecha);
                                    fact.WriteLine("--------------------------------------------------");
                                    fact.WriteLine("|El monto minimo es de $10");
                                    fact.WriteLine("--------------------------------------------------");
                                    fact.WriteLine("");
                                    fact.WriteLine("");
                                }
                                else if (cantidaa > cuenta.saldo)
                                {
                                    fact.WriteLine("--------------------------------------------------");
                                    fact.WriteLine("|Numero de cuenta: {0}", cuenta.NumeroCuenta);
                                    fact.WriteLine("--------------------------------------------------");
                                    fact.WriteLine("|Fecha y hora: {0}", fecha);
                                    fact.WriteLine("--------------------------------------------------");
                                    fact.WriteLine("|Saldo insuficiente");
                                    fact.WriteLine("--------------------------------------------------");
                                    fact.WriteLine("");
                                    fact.WriteLine("");
                                }

                            }

                        }
                    }
                }
            }

        }
    }
}
