using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPIntegrador
{
    public class Usuarios
    {
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string Nivel { get; set; }
        public int Id { get; set; }



        public Usuarios(string nombre, string contraseña, string nivel, int id)
        {
            Nombre= nombre;
            Contraseña = contraseña;
            Nivel = nivel;
            Id = id;
        }
    }
}
