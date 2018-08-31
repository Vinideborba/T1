namespace CaixaEletronico
{
    partial class CadastroDeConta
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
            this.Nome = new System.Windows.Forms.TextBox();
            this.Numero = new System.Windows.Forms.TextBox();
            this.botaoCadastro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Nome
            // 
            this.Nome.Location = new System.Drawing.Point(21, 23);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(192, 20);
            this.Nome.TabIndex = 0;
            this.Nome.Text = "Nome";
            // 
            // Numero
            // 
            this.Numero.Location = new System.Drawing.Point(81, 60);
            this.Numero.Name = "Numero";
            this.Numero.Size = new System.Drawing.Size(58, 20);
            this.Numero.TabIndex = 2;
            this.Numero.Text = "Numero";
            // 
            // botaoCadastro
            // 
            this.botaoCadastro.Location = new System.Drawing.Point(81, 99);
            this.botaoCadastro.Name = "botaoCadastro";
            this.botaoCadastro.Size = new System.Drawing.Size(58, 23);
            this.botaoCadastro.TabIndex = 3;
            this.botaoCadastro.Text = "Cadastro";
            this.botaoCadastro.UseVisualStyleBackColor = true;
            this.botaoCadastro.Click += new System.EventHandler(this.botaoCadastro_Click);
            // 
            // CadastroDeConta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 166);
            this.Controls.Add(this.botaoCadastro);
            this.Controls.Add(this.Numero);
            this.Controls.Add(this.Nome);
            this.Name = "CadastroDeConta";
            this.Text = "CadastroDeConta";
            this.Load += new System.EventHandler(this.CadastroDeConta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Nome;
        private System.Windows.Forms.TextBox Numero;
        private System.Windows.Forms.Button botaoCadastro;
    }
}