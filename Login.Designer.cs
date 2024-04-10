
namespace Sistema
{
    partial class Login
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
            this.tUsuario = new System.Windows.Forms.TextBox();
            this.tClave = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bEntrar = new System.Windows.Forms.Button();
            this.bRegistrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // tUsuario
            // 
            this.tUsuario.Location = new System.Drawing.Point(183, 92);
            this.tUsuario.Name = "tUsuario";
            this.tUsuario.Size = new System.Drawing.Size(100, 20);
            this.tUsuario.TabIndex = 1;
            // 
            // tClave
            // 
            this.tClave.Location = new System.Drawing.Point(183, 144);
            this.tClave.Name = "tClave";
            this.tClave.PasswordChar = '*';
            this.tClave.Size = new System.Drawing.Size(100, 20);
            this.tClave.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Clave";
            // 
            // bEntrar
            // 
            this.bEntrar.Location = new System.Drawing.Point(196, 196);
            this.bEntrar.Name = "bEntrar";
            this.bEntrar.Size = new System.Drawing.Size(75, 23);
            this.bEntrar.TabIndex = 4;
            this.bEntrar.Text = "Entrar";
            this.bEntrar.UseVisualStyleBackColor = true;
            this.bEntrar.Click += new System.EventHandler(this.bEntrar_Click);
            // 
            // bRegistrar
            // 
            this.bRegistrar.Location = new System.Drawing.Point(196, 248);
            this.bRegistrar.Name = "bRegistrar";
            this.bRegistrar.Size = new System.Drawing.Size(75, 23);
            this.bRegistrar.TabIndex = 5;
            this.bRegistrar.Text = "Registrar";
            this.bRegistrar.UseVisualStyleBackColor = true;
            this.bRegistrar.Click += new System.EventHandler(this.bRegistrar_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 304);
            this.Controls.Add(this.bRegistrar);
            this.Controls.Add(this.bEntrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tClave);
            this.Controls.Add(this.tUsuario);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tUsuario;
        private System.Windows.Forms.TextBox tClave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bEntrar;
        private System.Windows.Forms.Button bRegistrar;
    }
}