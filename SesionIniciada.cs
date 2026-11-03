using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TPIntegrador
{
    public partial class SesionIniciada : Form
    {
        private Usuarios usuarioActivo;
        public SesionIniciada(Usuarios activo)
        {
            InitializeComponent();
            usuarioActivo = activo;
            label1.Text = "¡Hola de nuevo, " + activo.Nombre + "!";
            label2.Text = "Tu nivel es: " + activo.Nivel;

            User_Normal.Visible = false;
            Operator.Visible= false;
            Admin.Visible= false;
            label3.Visible = false;
            label4.Visible= false;

            switch (activo.Nivel)
            {
                case "Usuario":
                    User_Normal.Visible = true;
                    break;

                case "Operador":
                    User_Normal.Visible = true;
                    Operator.Visible = true;
                    break;

                case "Administrador":
                    User_Normal.Visible = true;
                    Operator.Visible = true;
                    Admin.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    break;
            }

        }

        private void User_Normal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mis datos: \n " +
                "Nombre: " + usuarioActivo.Nombre + "\n" +
                "Contraseña: " + usuarioActivo.Contraseña + "\n" +
                "ID: " + usuarioActivo.Id + "\n" +
                "Nivel: " + usuarioActivo.Nivel);
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            string datos="";
            foreach (Usuarios u in BaseDeDatos.usuariosDB)
            {
                datos += "Nombre: " + u.Nombre + "\n" +
                "Contraseña: " + u.Contraseña + "\n" +
                "ID: " + u.Id + "\n" +
                "Nivel: " + u.Nivel + "\n \n";
            }
            MessageBox.Show("Lista de todos los usuarios registrados: \n \n" + datos);
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            string ruta = "usuarios.txt";
            Process abrirBloc = Process.Start("notepad.exe", ruta);
            abrirBloc.WaitForExit();
            BaseDeDatos.usuariosDB.Clear();
            BaseDeDatos.Cargar();

            MessageBox.Show("Cambios realizados con éxito");
        }
    }
}
