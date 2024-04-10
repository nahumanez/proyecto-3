
namespace Sistema
{
    partial class MenuPrincipal
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
            this.bProveedores = new System.Windows.Forms.Button();
            this.bClientes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bUsuarios = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bProveedores
            // 
            this.bProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bProveedores.Location = new System.Drawing.Point(120, 226);
            this.bProveedores.Name = "bProveedores";
            this.bProveedores.Size = new System.Drawing.Size(119, 54);
            this.bProveedores.TabIndex = 0;
            this.bProveedores.Text = "Proveedores";
            this.bProveedores.UseVisualStyleBackColor = true;
            this.bProveedores.Click += new System.EventHandler(this.bProveedores_Click);
            // 
            // bClientes
            // 
            this.bClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bClientes.Location = new System.Drawing.Point(120, 166);
            this.bClientes.Name = "bClientes";
            this.bClientes.Size = new System.Drawing.Size(119, 54);
            this.bClientes.TabIndex = 1;
            this.bClientes.Text = "Clientes";
            this.bClientes.UseVisualStyleBackColor = true;
            this.bClientes.Click += new System.EventHandler(this.bClientes_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bienvenido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Elije la opcion deseada";
            // 
            // bUsuarios
            // 
            this.bUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bUsuarios.Location = new System.Drawing.Point(120, 287);
            this.bUsuarios.Name = "bUsuarios";
            this.bUsuarios.Size = new System.Drawing.Size(119, 49);
            this.bUsuarios.TabIndex = 4;
            this.bUsuarios.Text = "Usuarios";
            this.bUsuarios.UseVisualStyleBackColor = true;
            this.bUsuarios.Click += new System.EventHandler(this.bUsuarios_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(362, 369);
            this.Controls.Add(this.bUsuarios);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bClientes);
            this.Controls.Add(this.bProveedores);
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button bProveedores;
        internal System.Windows.Forms.Button bClientes;
        private System.Windows.Forms.Button bUsuarios;
    }
}