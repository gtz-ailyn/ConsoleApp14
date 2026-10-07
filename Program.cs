using System;

namespace MinimizacionDieta
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OPTIMIZACION DE DIETA - MINIMIZACION (3.4-9)");
            Console.WriteLine();

            // Puntos esquina evaluados:
            // P1 = (14/11, 32/11) => (1.27, 2.91)
            // P2 = (160/43, 90/43) => (3.72, 2.09)
            // P3 = (0, 8)
            // P4 = (0, 30)

            double[] x1= { 14.0 / 11.0, 160.0 / 43.0, 0.0, 0.0 };
            double[] x2= { 32.0 / 11.0, 90.0 / 43.0, 8.0, 30.0 };
            string[] nombres= {"P1 (14/11, 32/11)", "P2 (160/43, 90/43)", "P3 (0, 8)", "P4 (0, 30)"};

            double costoMinimo= double.MaxValue;
            double mejorX1= 0;
            double mejorX2= 0;

            Console.WriteLine("EVALUACION DE PUNTOS ESQUINA:\n");

            for (int i= 0; i < x1.Length; i++)
            {
                double resX1= x1[i];
                double papaX2= x2[i];

                bool carb= (5 * resX1 + 15 * papaX2) >= 49.99;
                bool prot= (20 * resX1 + 5 * papaX2) >= 39.99;
                bool gras= (15 * resX1 + 2 * papaX2) <= 60.01;

                if (carb && prot && gras)
                {
                    double z= 4 * resX1 + 2 * papaX2;

                    Console.WriteLine($"Punto {i + 1} - {nombres[i]}:");
                    Console.WriteLine($"Res (x1)= {resX1:F2} porciones");
                    Console.WriteLine($"Papa (x2)= {papaX2:F2} porciones");
                    Console.WriteLine($"Costo Z= ${z:F2}\n");

                    if (z < costoMinimo)
                    {
                        costoMinimo= z;
                        mejorX1= resX1;
                        mejorX2= papaX2;
                    }
                }
            }
            Console.WriteLine("RESULTADO");
            Console.WriteLine($"Costo minimo diario: ${costoMinimo:F2}");
            Console.WriteLine($"Porciones de Res (x1): {mejorX1:F2} (14/11)");
            Console.WriteLine($"Porciones de Papa (x2): {mejorX2:F2} (32/11)");

            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }
    }
}