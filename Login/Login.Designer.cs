namespace Login
{
    partial class telaLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(telaLogin));
            this.lbl_usuario = new System.Windows.Forms.Label();
            this.tb_usuario = new System.Windows.Forms.TextBox();
            this.lbl_senha = new System.Windows.Forms.Label();
            this.tb_senha = new System.Windows.Forms.TextBox();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.bt_entrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_usuario
            // 
            this.lbl_usuario.AutoSize = true;
            this.lbl_usuario.Location = new System.Drawing.Point(18, 15);
            this.lbl_usuario.Name = "lbl_usuario";
            this.lbl_usuario.Size = new System.Drawing.Size(43, 13);
            this.lbl_usuario.TabIndex = 0;
            this.lbl_usuario.Text = "Usuário";
            // 
            // tb_usuario
            // 
            this.tb_usuario.Location = new System.Drawing.Point(21, 32);
            this.tb_usuario.Name = "tb_usuario";
            this.tb_usuario.Size = new System.Drawing.Size(192, 20);
            this.tb_usuario.TabIndex = 1;
            // 
            // lbl_senha
            // 
            this.lbl_senha.AutoSize = true;
            this.lbl_senha.Location = new System.Drawing.Point(18, 66);
            this.lbl_senha.Name = "lbl_senha";
            this.lbl_senha.Size = new System.Drawing.Size(38, 13);
            this.lbl_senha.TabIndex = 2;
            this.lbl_senha.Text = "Senha";
            // 
            // tb_senha
            // 
            this.tb_senha.Location = new System.Drawing.Point(21, 86);
            this.tb_senha.Name = "tb_senha";
            this.tb_senha.PasswordChar = '•';
            this.tb_senha.Size = new System.Drawing.Size(192, 20);
            this.tb_senha.TabIndex = 3;
            // 
            // bt_cancel
            // 
            this.bt_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bt_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_cancel.Location = new System.Drawing.Point(52, 124);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_cancel.TabIndex = 5;
            this.bt_cancel.Text = "Cancelar";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // bt_entrar
            // 
            this.bt_entrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_entrar.Location = new System.Drawing.Point(138, 124);
            this.bt_entrar.Name = "bt_entrar";
            this.bt_entrar.Size = new System.Drawing.Size(75, 23);
            this.bt_entrar.TabIndex = 4;
            this.bt_entrar.Text = "Entrar";
            this.bt_entrar.UseVisualStyleBackColor = true;
            this.bt_entrar.Click += new System.EventHandler(this.bt_entrar_Click);
            // 
            // telaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 165);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.bt_entrar);
            this.Controls.Add(this.tb_senha);
            this.Controls.Add(this.lbl_senha);
            this.Controls.Add(this.tb_usuario);
            this.Controls.Add(this.lbl_usuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "telaLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_usuario;
        private System.Windows.Forms.TextBox tb_usuario;
        private System.Windows.Forms.Label lbl_senha;
        private System.Windows.Forms.TextBox tb_senha;
        private System.Windows.Forms.Button bt_entrar;
        private System.Windows.Forms.Button bt_cancel;
    }
}

