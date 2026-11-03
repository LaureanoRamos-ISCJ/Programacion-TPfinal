using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPIntegrador
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        Random id_prov = new Random();
        int id_provisional;
        bool id_repetido;

        private void button1_Click(object sender, EventArgs e)
        {
            if(userName.Text=="" || password.Text == "" || comboBox1.Text=="") 
            {
                MessageBox.Show("Uno o más campos están en blanco");
            }
            else if(passwordConfirm.Text!=password.Text)
            {
                MessageBox.Show("La contraseña y su confirmación no coinciden");
            }
            else
            {
                if(BaseDeDatos.usuariosDB.Count>=500)
                    throw new InvalidOperationException("Ya no pueden generarse usuarios nuevos");
                do
                {
                    id_repetido = false;
                    id_provisional = id_prov.Next(500);
                    foreach (Usuarios u in BaseDeDatos.usuariosDB)
                    {
                        if (u.Id == id_provisional)
                        {
                            id_repetido = true;
                            break;
                        }
                    }
                }
                while (id_repetido);
                
                Usuarios usuario = new Usuarios(userName.Text, passwordConfirm.Text, comboBox1.Text, id_provisional);
                BaseDeDatos.usuariosDB.Add(usuario);
                BaseDeDatos.Guardar();
                MessageBox.Show("Usuario creado exitosamente. Su ID para iniciar sesión es " + id_provisional);

                Form1 abrirForm = new Form1();
                abrirForm.Show();
                this.Hide();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form1 abrirForm = new Form1();
            abrirForm.Show();
            this.Hide();
        }
    }
}
