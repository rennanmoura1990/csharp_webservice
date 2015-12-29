namespace LojaCliente
{
    partial class CadastroCliente
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
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.txtLogradouro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.BotaoCadastrar = new System.Windows.Forms.Button();
            this.BotaoAlterar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtValidaLogradouro = new System.Windows.Forms.TextBox();
            this.txtValidaEmail = new System.Windows.Forms.TextBox();
            this.txtValidaTelefone = new System.Windows.Forms.TextBox();
            this.txtValidaRG = new System.Windows.Forms.TextBox();
            this.txtValidaCPF = new System.Windows.Forms.TextBox();
            this.txtValidaNome = new System.Windows.Forms.TextBox();
            this.txtRG = new System.Windows.Forms.TextBox();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.BotaoGeraID = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIDCliente = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(174, 38);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(227, 20);
            this.txtNome.TabIndex = 2;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(174, 116);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(227, 20);
            this.txtTelefone.TabIndex = 5;
            this.txtTelefone.TextChanged += new System.EventHandler(this.txtTelefone_TextChanged);
            // 
            // txtLogradouro
            // 
            this.txtLogradouro.Location = new System.Drawing.Point(174, 142);
            this.txtLogradouro.Name = "txtLogradouro";
            this.txtLogradouro.Size = new System.Drawing.Size(227, 20);
            this.txtLogradouro.TabIndex = 6;
            this.txtLogradouro.TextChanged += new System.EventHandler(this.txtLogradouro_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "CPF";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "RG";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Telefone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "Logradouro";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(174, 168);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(227, 20);
            this.txtEmail.TabIndex = 7;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // BotaoCadastrar
            // 
            this.BotaoCadastrar.Location = new System.Drawing.Point(12, 243);
            this.BotaoCadastrar.Name = "BotaoCadastrar";
            this.BotaoCadastrar.Size = new System.Drawing.Size(75, 23);
            this.BotaoCadastrar.TabIndex = 8;
            this.BotaoCadastrar.Text = "Cadastrar";
            this.BotaoCadastrar.UseVisualStyleBackColor = true;
            this.BotaoCadastrar.Click += new System.EventHandler(this.BotaoCadastrar_Click);
            // 
            // BotaoAlterar
            // 
            this.BotaoAlterar.Location = new System.Drawing.Point(93, 243);
            this.BotaoAlterar.Name = "BotaoAlterar";
            this.BotaoAlterar.Size = new System.Drawing.Size(75, 23);
            this.BotaoAlterar.TabIndex = 9;
            this.BotaoAlterar.Text = "Alterar";
            this.BotaoAlterar.UseVisualStyleBackColor = true;
            this.BotaoAlterar.Click += new System.EventHandler(this.BotaoAlterar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(780, 298);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtValidaLogradouro);
            this.tabPage1.Controls.Add(this.txtValidaEmail);
            this.tabPage1.Controls.Add(this.txtValidaTelefone);
            this.tabPage1.Controls.Add(this.txtValidaRG);
            this.tabPage1.Controls.Add(this.txtValidaCPF);
            this.tabPage1.Controls.Add(this.txtValidaNome);
            this.tabPage1.Controls.Add(this.txtRG);
            this.tabPage1.Controls.Add(this.txtCPF);
            this.tabPage1.Controls.Add(this.BotaoGeraID);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtIDCliente);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtNome);
            this.tabPage1.Controls.Add(this.BotaoAlterar);
            this.tabPage1.Controls.Add(this.txtTelefone);
            this.tabPage1.Controls.Add(this.BotaoCadastrar);
            this.tabPage1.Controls.Add(this.txtLogradouro);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtEmail);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(772, 272);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cadastro";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtValidaLogradouro
            // 
            this.txtValidaLogradouro.BackColor = System.Drawing.Color.Yellow;
            this.txtValidaLogradouro.Enabled = false;
            this.txtValidaLogradouro.Location = new System.Drawing.Point(407, 142);
            this.txtValidaLogradouro.Name = "txtValidaLogradouro";
            this.txtValidaLogradouro.Size = new System.Drawing.Size(23, 20);
            this.txtValidaLogradouro.TabIndex = 27;
            // 
            // txtValidaEmail
            // 
            this.txtValidaEmail.BackColor = System.Drawing.Color.Yellow;
            this.txtValidaEmail.Enabled = false;
            this.txtValidaEmail.Location = new System.Drawing.Point(407, 168);
            this.txtValidaEmail.Name = "txtValidaEmail";
            this.txtValidaEmail.Size = new System.Drawing.Size(23, 20);
            this.txtValidaEmail.TabIndex = 26;
            // 
            // txtValidaTelefone
            // 
            this.txtValidaTelefone.BackColor = System.Drawing.Color.Yellow;
            this.txtValidaTelefone.Enabled = false;
            this.txtValidaTelefone.Location = new System.Drawing.Point(407, 116);
            this.txtValidaTelefone.Name = "txtValidaTelefone";
            this.txtValidaTelefone.Size = new System.Drawing.Size(23, 20);
            this.txtValidaTelefone.TabIndex = 24;
            // 
            // txtValidaRG
            // 
            this.txtValidaRG.BackColor = System.Drawing.Color.Yellow;
            this.txtValidaRG.Enabled = false;
            this.txtValidaRG.Location = new System.Drawing.Point(407, 90);
            this.txtValidaRG.Name = "txtValidaRG";
            this.txtValidaRG.Size = new System.Drawing.Size(23, 20);
            this.txtValidaRG.TabIndex = 23;
            // 
            // txtValidaCPF
            // 
            this.txtValidaCPF.BackColor = System.Drawing.Color.Yellow;
            this.txtValidaCPF.Enabled = false;
            this.txtValidaCPF.Location = new System.Drawing.Point(407, 64);
            this.txtValidaCPF.Name = "txtValidaCPF";
            this.txtValidaCPF.Size = new System.Drawing.Size(23, 20);
            this.txtValidaCPF.TabIndex = 22;
            // 
            // txtValidaNome
            // 
            this.txtValidaNome.BackColor = System.Drawing.Color.Yellow;
            this.txtValidaNome.Enabled = false;
            this.txtValidaNome.Location = new System.Drawing.Point(407, 38);
            this.txtValidaNome.Name = "txtValidaNome";
            this.txtValidaNome.Size = new System.Drawing.Size(23, 20);
            this.txtValidaNome.TabIndex = 21;
            // 
            // txtRG
            // 
            this.txtRG.Location = new System.Drawing.Point(174, 90);
            this.txtRG.Name = "txtRG";
            this.txtRG.Size = new System.Drawing.Size(227, 20);
            this.txtRG.TabIndex = 4;
            this.txtRG.TextChanged += new System.EventHandler(this.txtRG_TextChanged);
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(174, 64);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(227, 20);
            this.txtCPF.TabIndex = 3;
            this.txtCPF.TextChanged += new System.EventHandler(this.txtCPF_TextChanged);
            // 
            // BotaoGeraID
            // 
            this.BotaoGeraID.Location = new System.Drawing.Point(295, 10);
            this.BotaoGeraID.Name = "BotaoGeraID";
            this.BotaoGeraID.Size = new System.Drawing.Size(135, 23);
            this.BotaoGeraID.TabIndex = 1;
            this.BotaoGeraID.Text = "Gerar ID";
            this.BotaoGeraID.UseVisualStyleBackColor = true;
            this.BotaoGeraID.Click += new System.EventHandler(this.BotaoGeraID_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "ID";
            // 
            // txtIDCliente
            // 
            this.txtIDCliente.Location = new System.Drawing.Point(174, 12);
            this.txtIDCliente.Name = "txtIDCliente";
            this.txtIDCliente.ReadOnly = true;
            this.txtIDCliente.Size = new System.Drawing.Size(115, 20);
            this.txtIDCliente.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(772, 272);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Busca";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 316);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(776, 186);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 83);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(760, 186);
            this.dataGridView2.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 25);
            this.label8.TabIndex = 8;
            this.label8.Text = "Nome";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(84, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(227, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // CadastroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 514);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CadastroCliente";
            this.Text = "CadastroCliente";
            this.Load += new System.EventHandler(this.CadastroCliente_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.TextBox txtLogradouro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button BotaoCadastrar;
        private System.Windows.Forms.Button BotaoAlterar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button BotaoGeraID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIDCliente;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.TextBox txtRG;
        private System.Windows.Forms.TextBox txtValidaEmail;
        private System.Windows.Forms.TextBox txtValidaTelefone;
        private System.Windows.Forms.TextBox txtValidaRG;
        private System.Windows.Forms.TextBox txtValidaCPF;
        private System.Windows.Forms.TextBox txtValidaNome;
        private System.Windows.Forms.TextBox txtValidaLogradouro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}