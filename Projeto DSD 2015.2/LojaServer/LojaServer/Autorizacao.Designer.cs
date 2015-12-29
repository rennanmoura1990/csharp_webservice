namespace LojaServer
{
    partial class Autorizacao
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">verdade se for necessário descartar os recursos gerenciados; caso contrário, falso.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte do Designer - não modifique
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxpedidos = new System.Windows.Forms.ListBox();
            this.BotaoAutoriza = new System.Windows.Forms.Button();
            this.BotaoDesautoriza = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxpedidos
            // 
            this.listBoxpedidos.FormattingEnabled = true;
            this.listBoxpedidos.Location = new System.Drawing.Point(13, 13);
            this.listBoxpedidos.Name = "listBoxpedidos";
            this.listBoxpedidos.Size = new System.Drawing.Size(599, 368);
            this.listBoxpedidos.TabIndex = 0;
            // 
            // BotaoAutoriza
            // 
            this.BotaoAutoriza.Location = new System.Drawing.Point(13, 399);
            this.BotaoAutoriza.Name = "BotaoAutoriza";
            this.BotaoAutoriza.Size = new System.Drawing.Size(75, 23);
            this.BotaoAutoriza.TabIndex = 1;
            this.BotaoAutoriza.Text = "Autoriza";
            this.BotaoAutoriza.UseVisualStyleBackColor = true;
            this.BotaoAutoriza.Click += new System.EventHandler(this.BotaoAutoriza_Click);
            // 
            // BotaoDesautoriza
            // 
            this.BotaoDesautoriza.Location = new System.Drawing.Point(94, 399);
            this.BotaoDesautoriza.Name = "BotaoDesautoriza";
            this.BotaoDesautoriza.Size = new System.Drawing.Size(75, 23);
            this.BotaoDesautoriza.TabIndex = 2;
            this.BotaoDesautoriza.Text = "Desautoriza";
            this.BotaoDesautoriza.UseVisualStyleBackColor = true;
            this.BotaoDesautoriza.Click += new System.EventHandler(this.BotaoDesautoriza_Click);
            // 
            // Autorizacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.BotaoDesautoriza);
            this.Controls.Add(this.BotaoAutoriza);
            this.Controls.Add(this.listBoxpedidos);
            this.Name = "Autorizacao";
            this.Text = "Tela de Autorização";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Autorizacao_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxpedidos;
        private System.Windows.Forms.Button BotaoAutoriza;
        private System.Windows.Forms.Button BotaoDesautoriza;
    }
}

