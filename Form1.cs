using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPIntegrador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BaseDeDatos.Cargar();
        }

        int id_prov;
        bool idNumerico;

        private void label2_Click(object sender, EventArgs e)
        {
            SignUp abrirForm = new SignUp();
            abrirForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(campo_id.Text =="" || campo_password.Text == "")
            {
                MessageBox.Show("El ID o la contraseña están en blanco");
            }
            else
            {
                idNumerico=int.TryParse(campo_id.Text, out id_prov);
                if(idNumerico==false)
                    MessageBox.Show("El ID no está en formato correcto");
                else
                {
                    if (BaseDeDatos.usuariosDB.Count() == 0)
                        MessageBox.Show("No hay usuarios registrados");
                    else
                    {

                        bool encontrado = false;

                        foreach (Usuarios u in BaseDeDatos.usuariosDB)
                        {
                            if (u.Id == id_prov && u.Contraseña == campo_password.Text)
                            {
                                encontrado = true;
                                SesionIniciada abrirForm = new SesionIniciada(u);
                                abrirForm.Show();
                                this.Hide();
                                break;
                            }
                        }

                        if (!encontrado)
                        {
                            MessageBox.Show("El ID o la contraseña son incorrectos.");
                        }
                        
                    }

                }
                 
            }
        }
    }
}
