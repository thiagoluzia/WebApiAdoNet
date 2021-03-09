
namespace WF_ConsumindoAPI
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBuscarPorId = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnInserir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCarregarGrid = new System.Windows.Forms.Button();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.Inserir = new System.Windows.Forms.GroupBox();
            this.txtMelhoreResultado = new System.Windows.Forms.TextBox();
            this.txtNomeSelecao = new System.Windows.Forms.TextBox();
            this.txtContinente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumeroParticipacoes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLimparDGV = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.Inserir.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscarPorId
            // 
            this.btnBuscarPorId.Location = new System.Drawing.Point(6, 54);
            this.btnBuscarPorId.Name = "btnBuscarPorId";
            this.btnBuscarPorId.Size = new System.Drawing.Size(121, 23);
            this.btnBuscarPorId.TabIndex = 2;
            this.btnBuscarPorId.Text = "Buscar Por Id";
            this.btnBuscarPorId.UseVisualStyleBackColor = true;
            this.btnBuscarPorId.Click += new System.EventHandler(this.btnBuscarPorId_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(6, 26);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(121, 20);
            this.txtBuscar.TabIndex = 3;
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(124, 142);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(121, 23);
            this.btnInserir.TabIndex = 4;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscarPorId);
            this.groupBox1.Controls.Add(this.txtBuscar);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 100);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar Por ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCarregarGrid);
            this.groupBox2.Controls.Add(this.dgvDados);
            this.groupBox2.Location = new System.Drawing.Point(12, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(664, 224);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Carregrar Todos";
            // 
            // btnCarregarGrid
            // 
            this.btnCarregarGrid.Location = new System.Drawing.Point(6, 19);
            this.btnCarregarGrid.Name = "btnCarregarGrid";
            this.btnCarregarGrid.Size = new System.Drawing.Size(96, 33);
            this.btnCarregarGrid.TabIndex = 16;
            this.btnCarregarGrid.Text = "Carregar Grid";
            this.btnCarregarGrid.UseVisualStyleBackColor = true;
            this.btnCarregarGrid.Click += new System.EventHandler(this.btnCarregarGrid_Click);
            // 
            // dgvDados
            // 
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Location = new System.Drawing.Point(6, 58);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(652, 160);
            this.dgvDados.TabIndex = 15;
            // 
            // Inserir
            // 
            this.Inserir.Controls.Add(this.txtMelhoreResultado);
            this.Inserir.Controls.Add(this.label1);
            this.Inserir.Controls.Add(this.txtNomeSelecao);
            this.Inserir.Controls.Add(this.btnInserir);
            this.Inserir.Controls.Add(this.label2);
            this.Inserir.Controls.Add(this.txtContinente);
            this.Inserir.Controls.Add(this.label3);
            this.Inserir.Controls.Add(this.label4);
            this.Inserir.Controls.Add(this.txtNumeroParticipacoes);
            this.Inserir.Location = new System.Drawing.Point(158, 13);
            this.Inserir.Name = "Inserir";
            this.Inserir.Size = new System.Drawing.Size(273, 184);
            this.Inserir.TabIndex = 14;
            this.Inserir.TabStop = false;
            this.Inserir.Text = "Inserir";
            // 
            // txtMelhoreResultado
            // 
            this.txtMelhoreResultado.Location = new System.Drawing.Point(124, 107);
            this.txtMelhoreResultado.Name = "txtMelhoreResultado";
            this.txtMelhoreResultado.Size = new System.Drawing.Size(121, 20);
            this.txtMelhoreResultado.TabIndex = 18;
            // 
            // txtNomeSelecao
            // 
            this.txtNomeSelecao.Location = new System.Drawing.Point(124, 29);
            this.txtNomeSelecao.Name = "txtNomeSelecao";
            this.txtNomeSelecao.Size = new System.Drawing.Size(121, 20);
            this.txtNomeSelecao.TabIndex = 15;
            // 
            // txtContinente
            // 
            this.txtContinente.Location = new System.Drawing.Point(124, 55);
            this.txtContinente.Name = "txtContinente";
            this.txtContinente.Size = new System.Drawing.Size(121, 20);
            this.txtContinente.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Melhor Resultado";
            // 
            // txtNumeroParticipacoes
            // 
            this.txtNumeroParticipacoes.Location = new System.Drawing.Point(124, 81);
            this.txtNumeroParticipacoes.Name = "txtNumeroParticipacoes";
            this.txtNumeroParticipacoes.Size = new System.Drawing.Size(121, 20);
            this.txtNumeroParticipacoes.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Numero Participações";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Nome Selecao";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Continente";
            // 
            // btnLimparDGV
            // 
            this.btnLimparDGV.Location = new System.Drawing.Point(580, 165);
            this.btnLimparDGV.Name = "btnLimparDGV";
            this.btnLimparDGV.Size = new System.Drawing.Size(96, 23);
            this.btnLimparDGV.TabIndex = 17;
            this.btnLimparDGV.Text = "Limpar DGV";
            this.btnLimparDGV.UseVisualStyleBackColor = true;
            this.btnLimparDGV.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 439);
            this.Controls.Add(this.btnLimparDGV);
            this.Controls.Add(this.Inserir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.Inserir.ResumeLayout(false);
            this.Inserir.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBuscarPorId;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCarregarGrid;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.GroupBox Inserir;
        private System.Windows.Forms.TextBox txtMelhoreResultado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomeSelecao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContinente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumeroParticipacoes;
        private System.Windows.Forms.Button btnLimparDGV;
    }
}

