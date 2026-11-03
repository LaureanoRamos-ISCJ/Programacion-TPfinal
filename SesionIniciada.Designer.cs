namespace TPIntegrador
{
    partial class SesionIniciada
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Operator = new System.Windows.Forms.Button();
            this.Admin = new System.Windows.Forms.Button();
            this.User_Normal = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(444, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "¡Hola de nuevo, Usuario!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(465, 152);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tu nivel es: Usuario";
            // 
            // Operator
            // 
            this.Operator.Location = new System.Drawing.Point(422, 330);
            this.Operator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Operator.Name = "Operator";
            this.Operator.Size = new System.Drawing.Size(277, 65);
            this.Operator.TabIndex = 2;
            this.Operator.Text = "Consultar lista de usuarios";
            this.Operator.UseVisualStyleBackColor = true;
            this.Operator.Click += new System.EventHandler(this.Operator_Click);
            // 
            // Admin
            // 
            this.Admin.Location = new System.Drawing.Point(422, 402);
            this.Admin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Admin.Name = "Admin";
            this.Admin.Size = new System.Drawing.Size(277, 65);
            this.Admin.TabIndex = 3;
            this.Admin.Text = "Modificar lista de usuarios";
            this.Admin.UseVisualStyleBackColor = true;
            this.Admin.Click += new System.EventHandler(this.Admin_Click);
            // 
            // User_Normal
            // 
            this.User_Normal.Location = new System.Drawing.Point(422, 260);
            this.User_Normal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.User_Normal.Name = "User_Normal";
            this.User_Normal.Size = new System.Drawing.Size(277, 65);
            this.User_Normal.TabIndex = 4;
            this.User_Normal.Text = "Ver mis datos";
            this.User_Normal.UseVisualStyleBackColor = true;
            this.User_Normal.Click += new System.EventHandler(this.User_Normal_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(389, 480);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(338, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Advertencia: Respete el formato dado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(359, 524);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(416, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "La secuencia es: Nombre;Contraseña;Nivel;ID";
            // 
            // SesionIniciada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 679);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.User_Normal);
            this.Controls.Add(this.Admin);
            this.Controls.Add(this.Operator);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SesionIniciada";
            this.Text = "SesionIniciada";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Operator;
        private System.Windows.Forms.Button Admin;
        private System.Windows.Forms.Button User_Normal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}