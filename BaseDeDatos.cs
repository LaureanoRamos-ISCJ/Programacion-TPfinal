using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TPIntegrador
{
    public static class BaseDeDatos
    {
        public static List<Usuarios> usuariosDB { get; set; } = new List<Usuarios>();
        private static string ruta = "usuarios.txt";
        


        public static void Guardar()
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(ruta, false))
                {
                    foreach (Usuarios u in usuariosDB)
                    {
                        escritor.WriteLine(u.Nombre + ";" + u.Contraseña + ";" + u.Nivel + ";" + u.Id);
                    }
                }
            }
            catch
            {
                MessageBox.Show("No se encontró el archivo o los datos del mismo están dañados");
            }

        }



        public static void Cargar()
        {
            try
            {
                usuariosDB.Clear();

                using (StreamReader lector = new StreamReader(ruta))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null) 
                    {
                        if (string.IsNullOrWhiteSpace(linea)) continue;

                        string[] datos = linea.Split(';');

                        Usuarios u = new Usuarios (datos[0], datos[1], datos[2], int.Parse(datos[3]));
                        usuariosDB.Add(u);
                    }
                }
            }
            catch
            {
                MessageBox.Show("No se encontró el archivo o los datos del mismo están dañados");
            }
           
        }



    }
}
