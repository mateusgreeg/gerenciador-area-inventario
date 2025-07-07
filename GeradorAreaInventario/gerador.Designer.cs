namespace GeradorAreaInventario
{
    partial class gerador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gerador));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbCadArea = new System.Windows.Forms.TabPage();
            this.btnDeletarAreaSelec = new System.Windows.Forms.Button();
            this.btnListarAreas = new System.Windows.Forms.Button();
            this.dtgArea = new System.Windows.Forms.DataGridView();
            this.btnSalvarArea = new System.Windows.Forms.Button();
            this.txbCodArea = new System.Windows.Forms.TextBox();
            this.txbNomeArea = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSubAreaCad = new System.Windows.Forms.TabPage();
            this.btnDeletarSubAreaSelec = new System.Windows.Forms.Button();
            this.btnListarSubAreas = new System.Windows.Forms.Button();
            this.txbDescAreaCadSubArea = new System.Windows.Forms.TextBox();
            this.txbCodConsultaArea = new System.Windows.Forms.TextBox();
            this.lblSeletorArea = new System.Windows.Forms.Label();
            this.dtgSubArea = new System.Windows.Forms.DataGridView();
            this.btnSalvarSubArea = new System.Windows.Forms.Button();
            this.txbCodSubArea = new System.Windows.Forms.TextBox();
            this.txbNomeSubArea = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPDF = new System.Windows.Forms.TabPage();
            this.ckbSubAreas = new System.Windows.Forms.CheckedListBox();
            this.cbxTipoCodigo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGerarPDF2 = new System.Windows.Forms.Button();
            this.txbError = new System.Windows.Forms.TextBox();
            this.btnDesmarcar = new System.Windows.Forms.Button();
            this.cbxAreaPDF = new System.Windows.Forms.ComboBox();
            this.cbxCodArea = new System.Windows.Forms.ComboBox();
            this.btnBuscarSubAreasPDF = new System.Windows.Forms.Button();
            this.cbxTipoFolha = new System.Windows.Forms.ComboBox();
            this.btnSelecionarTodasSubAreas = new System.Windows.Forms.Button();
            this.ckbRecontagem = new System.Windows.Forms.CheckBox();
            this.ckbAssinaturaPDF = new System.Windows.Forms.CheckBox();
            this.btnGerarPDF = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tbCadArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgArea)).BeginInit();
            this.tbSubAreaCad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSubArea)).BeginInit();
            this.tbPDF.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbCadArea);
            this.tabControl1.Controls.Add(this.tbSubAreaCad);
            this.tabControl1.Controls.Add(this.tbPDF);
            this.tabControl1.Location = new System.Drawing.Point(2, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(598, 486);
            this.tabControl1.TabIndex = 0;
            // 
            // tbCadArea
            // 
            this.tbCadArea.Controls.Add(this.btnDeletarAreaSelec);
            this.tbCadArea.Controls.Add(this.btnListarAreas);
            this.tbCadArea.Controls.Add(this.dtgArea);
            this.tbCadArea.Controls.Add(this.btnSalvarArea);
            this.tbCadArea.Controls.Add(this.txbCodArea);
            this.tbCadArea.Controls.Add(this.txbNomeArea);
            this.tbCadArea.Controls.Add(this.label2);
            this.tbCadArea.Controls.Add(this.label1);
            this.tbCadArea.Location = new System.Drawing.Point(4, 25);
            this.tbCadArea.Name = "tbCadArea";
            this.tbCadArea.Padding = new System.Windows.Forms.Padding(3);
            this.tbCadArea.Size = new System.Drawing.Size(590, 457);
            this.tbCadArea.TabIndex = 0;
            this.tbCadArea.Text = "Cad. Area";
            this.tbCadArea.UseVisualStyleBackColor = true;
            // 
            // btnDeletarAreaSelec
            // 
            this.btnDeletarAreaSelec.Location = new System.Drawing.Point(475, 62);
            this.btnDeletarAreaSelec.Name = "btnDeletarAreaSelec";
            this.btnDeletarAreaSelec.Size = new System.Drawing.Size(109, 25);
            this.btnDeletarAreaSelec.TabIndex = 17;
            this.btnDeletarAreaSelec.Text = "Deletar Area";
            this.btnDeletarAreaSelec.UseVisualStyleBackColor = true;
            this.btnDeletarAreaSelec.Click += new System.EventHandler(this.btnDeletarAreaSelec_Click);
            // 
            // btnListarAreas
            // 
            this.btnListarAreas.Location = new System.Drawing.Point(475, 36);
            this.btnListarAreas.Name = "btnListarAreas";
            this.btnListarAreas.Size = new System.Drawing.Size(109, 25);
            this.btnListarAreas.TabIndex = 16;
            this.btnListarAreas.Text = "Listar Areas";
            this.btnListarAreas.UseVisualStyleBackColor = true;
            this.btnListarAreas.Click += new System.EventHandler(this.btnListarAreas_Click);
            // 
            // dtgArea
            // 
            this.dtgArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgArea.Location = new System.Drawing.Point(4, 93);
            this.dtgArea.Name = "dtgArea";
            this.dtgArea.RowTemplate.Height = 24;
            this.dtgArea.Size = new System.Drawing.Size(581, 360);
            this.dtgArea.TabIndex = 5;
            // 
            // btnSalvarArea
            // 
            this.btnSalvarArea.Location = new System.Drawing.Point(475, 10);
            this.btnSalvarArea.Name = "btnSalvarArea";
            this.btnSalvarArea.Size = new System.Drawing.Size(109, 25);
            this.btnSalvarArea.TabIndex = 4;
            this.btnSalvarArea.Text = "Salvar";
            this.btnSalvarArea.UseVisualStyleBackColor = true;
            this.btnSalvarArea.Click += new System.EventHandler(this.btnSalvarArea_Click);
            // 
            // txbCodArea
            // 
            this.txbCodArea.Location = new System.Drawing.Point(98, 39);
            this.txbCodArea.Name = "txbCodArea";
            this.txbCodArea.Size = new System.Drawing.Size(107, 22);
            this.txbCodArea.TabIndex = 3;
            // 
            // txbNomeArea
            // 
            this.txbNomeArea.Location = new System.Drawing.Point(98, 12);
            this.txbNomeArea.MaxLength = 16;
            this.txbNomeArea.Name = "txbNomeArea";
            this.txbNomeArea.Size = new System.Drawing.Size(367, 22);
            this.txbNomeArea.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Codigo area :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome area :";
            // 
            // tbSubAreaCad
            // 
            this.tbSubAreaCad.Controls.Add(this.btnDeletarSubAreaSelec);
            this.tbSubAreaCad.Controls.Add(this.btnListarSubAreas);
            this.tbSubAreaCad.Controls.Add(this.txbDescAreaCadSubArea);
            this.tbSubAreaCad.Controls.Add(this.txbCodConsultaArea);
            this.tbSubAreaCad.Controls.Add(this.lblSeletorArea);
            this.tbSubAreaCad.Controls.Add(this.dtgSubArea);
            this.tbSubAreaCad.Controls.Add(this.btnSalvarSubArea);
            this.tbSubAreaCad.Controls.Add(this.txbCodSubArea);
            this.tbSubAreaCad.Controls.Add(this.txbNomeSubArea);
            this.tbSubAreaCad.Controls.Add(this.label3);
            this.tbSubAreaCad.Controls.Add(this.label4);
            this.tbSubAreaCad.Location = new System.Drawing.Point(4, 25);
            this.tbSubAreaCad.Name = "tbSubAreaCad";
            this.tbSubAreaCad.Padding = new System.Windows.Forms.Padding(3);
            this.tbSubAreaCad.Size = new System.Drawing.Size(590, 457);
            this.tbSubAreaCad.TabIndex = 1;
            this.tbSubAreaCad.Text = "SubArea Cad.";
            this.tbSubAreaCad.UseVisualStyleBackColor = true;
            // 
            // btnDeletarSubAreaSelec
            // 
            this.btnDeletarSubAreaSelec.Location = new System.Drawing.Point(461, 64);
            this.btnDeletarSubAreaSelec.Name = "btnDeletarSubAreaSelec";
            this.btnDeletarSubAreaSelec.Size = new System.Drawing.Size(123, 25);
            this.btnDeletarSubAreaSelec.TabIndex = 15;
            this.btnDeletarSubAreaSelec.Text = "Deletar";
            this.btnDeletarSubAreaSelec.UseVisualStyleBackColor = true;
            this.btnDeletarSubAreaSelec.Click += new System.EventHandler(this.btnDeletarSubAreaSelec_Click);
            // 
            // btnListarSubAreas
            // 
            this.btnListarSubAreas.Location = new System.Drawing.Point(461, 37);
            this.btnListarSubAreas.Name = "btnListarSubAreas";
            this.btnListarSubAreas.Size = new System.Drawing.Size(123, 25);
            this.btnListarSubAreas.TabIndex = 14;
            this.btnListarSubAreas.Text = "Listar SubAreas";
            this.btnListarSubAreas.UseVisualStyleBackColor = true;
            this.btnListarSubAreas.Click += new System.EventHandler(this.btnListarSubAreas_Click);
            // 
            // txbDescAreaCadSubArea
            // 
            this.txbDescAreaCadSubArea.Location = new System.Drawing.Point(129, 13);
            this.txbDescAreaCadSubArea.Name = "txbDescAreaCadSubArea";
            this.txbDescAreaCadSubArea.Size = new System.Drawing.Size(326, 22);
            this.txbDescAreaCadSubArea.TabIndex = 13;
            // 
            // txbCodConsultaArea
            // 
            this.txbCodConsultaArea.Location = new System.Drawing.Point(65, 13);
            this.txbCodConsultaArea.Name = "txbCodConsultaArea";
            this.txbCodConsultaArea.Size = new System.Drawing.Size(60, 22);
            this.txbCodConsultaArea.TabIndex = 12;
            this.txbCodConsultaArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbCodConsultaArea_KeyDown);
            // 
            // lblSeletorArea
            // 
            this.lblSeletorArea.AutoSize = true;
            this.lblSeletorArea.Location = new System.Drawing.Point(20, 15);
            this.lblSeletorArea.Name = "lblSeletorArea";
            this.lblSeletorArea.Size = new System.Drawing.Size(46, 17);
            this.lblSeletorArea.TabIndex = 11;
            this.lblSeletorArea.Text = "Area :";
            // 
            // dtgSubArea
            // 
            this.dtgSubArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSubArea.Location = new System.Drawing.Point(3, 98);
            this.dtgSubArea.Name = "dtgSubArea";
            this.dtgSubArea.RowTemplate.Height = 24;
            this.dtgSubArea.Size = new System.Drawing.Size(581, 353);
            this.dtgSubArea.TabIndex = 10;
            // 
            // btnSalvarSubArea
            // 
            this.btnSalvarSubArea.Location = new System.Drawing.Point(461, 12);
            this.btnSalvarSubArea.Name = "btnSalvarSubArea";
            this.btnSalvarSubArea.Size = new System.Drawing.Size(123, 25);
            this.btnSalvarSubArea.TabIndex = 9;
            this.btnSalvarSubArea.Text = "Salvar";
            this.btnSalvarSubArea.UseVisualStyleBackColor = true;
            this.btnSalvarSubArea.Click += new System.EventHandler(this.btnSalvarSubArea_Click);
            // 
            // txbCodSubArea
            // 
            this.txbCodSubArea.Location = new System.Drawing.Point(129, 65);
            this.txbCodSubArea.Name = "txbCodSubArea";
            this.txbCodSubArea.Size = new System.Drawing.Size(107, 22);
            this.txbCodSubArea.TabIndex = 8;
            // 
            // txbNomeSubArea
            // 
            this.txbNomeSubArea.Location = new System.Drawing.Point(129, 40);
            this.txbNomeSubArea.MaxLength = 15;
            this.txbNomeSubArea.Name = "txbNomeSubArea";
            this.txbNomeSubArea.Size = new System.Drawing.Size(326, 22);
            this.txbNomeSubArea.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Codigo SubArea :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nome SubArea :";
            // 
            // tbPDF
            // 
            this.tbPDF.Controls.Add(this.ckbSubAreas);
            this.tbPDF.Controls.Add(this.cbxTipoCodigo);
            this.tbPDF.Controls.Add(this.label7);
            this.tbPDF.Controls.Add(this.btnGerarPDF2);
            this.tbPDF.Controls.Add(this.txbError);
            this.tbPDF.Controls.Add(this.btnDesmarcar);
            this.tbPDF.Controls.Add(this.cbxAreaPDF);
            this.tbPDF.Controls.Add(this.cbxCodArea);
            this.tbPDF.Controls.Add(this.btnBuscarSubAreasPDF);
            this.tbPDF.Controls.Add(this.cbxTipoFolha);
            this.tbPDF.Controls.Add(this.btnSelecionarTodasSubAreas);
            this.tbPDF.Controls.Add(this.ckbRecontagem);
            this.tbPDF.Controls.Add(this.ckbAssinaturaPDF);
            this.tbPDF.Controls.Add(this.btnGerarPDF);
            this.tbPDF.Controls.Add(this.label5);
            this.tbPDF.Controls.Add(this.label6);
            this.tbPDF.Location = new System.Drawing.Point(4, 25);
            this.tbPDF.Name = "tbPDF";
            this.tbPDF.Size = new System.Drawing.Size(590, 457);
            this.tbPDF.TabIndex = 2;
            this.tbPDF.Text = "Gerar PDF";
            this.tbPDF.UseVisualStyleBackColor = true;
            // 
            // ckbSubAreas
            // 
            this.ckbSubAreas.FormattingEnabled = true;
            this.ckbSubAreas.Location = new System.Drawing.Point(8, 97);
            this.ckbSubAreas.Name = "ckbSubAreas";
            this.ckbSubAreas.Size = new System.Drawing.Size(573, 225);
            this.ckbSubAreas.TabIndex = 0;
            // 
            // cbxTipoCodigo
            // 
            this.cbxTipoCodigo.FormattingEnabled = true;
            this.cbxTipoCodigo.Items.AddRange(new object[] {
            "QR Code 2D",
            "Code 128 1D"});
            this.cbxTipoCodigo.Location = new System.Drawing.Point(95, 67);
            this.cbxTipoCodigo.Name = "cbxTipoCodigo";
            this.cbxTipoCodigo.Size = new System.Drawing.Size(174, 24);
            this.cbxTipoCodigo.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Tipo codigo :";
            // 
            // btnGerarPDF2
            // 
            this.btnGerarPDF2.Location = new System.Drawing.Point(468, 31);
            this.btnGerarPDF2.Name = "btnGerarPDF2";
            this.btnGerarPDF2.Size = new System.Drawing.Size(113, 25);
            this.btnGerarPDF2.TabIndex = 13;
            this.btnGerarPDF2.Text = "Etiqueta PDF";
            this.btnGerarPDF2.UseVisualStyleBackColor = true;
            this.btnGerarPDF2.Click += new System.EventHandler(this.btnGerarPDF2_Click);
            // 
            // txbError
            // 
            this.txbError.BackColor = System.Drawing.SystemColors.Info;
            this.txbError.Location = new System.Drawing.Point(8, 328);
            this.txbError.Multiline = true;
            this.txbError.Name = "txbError";
            this.txbError.Size = new System.Drawing.Size(263, 116);
            this.txbError.TabIndex = 12;
            // 
            // btnDesmarcar
            // 
            this.btnDesmarcar.Location = new System.Drawing.Point(335, 31);
            this.btnDesmarcar.Name = "btnDesmarcar";
            this.btnDesmarcar.Size = new System.Drawing.Size(130, 25);
            this.btnDesmarcar.TabIndex = 11;
            this.btnDesmarcar.Text = "Desmarcar todos";
            this.btnDesmarcar.UseVisualStyleBackColor = true;
            this.btnDesmarcar.Click += new System.EventHandler(this.btnDesmarcar_Click);
            // 
            // cbxAreaPDF
            // 
            this.cbxAreaPDF.FormattingEnabled = true;
            this.cbxAreaPDF.Location = new System.Drawing.Point(95, 6);
            this.cbxAreaPDF.Name = "cbxAreaPDF";
            this.cbxAreaPDF.Size = new System.Drawing.Size(234, 24);
            this.cbxAreaPDF.TabIndex = 2;
            this.cbxAreaPDF.SelectedIndexChanged += new System.EventHandler(this.cbxAreas_SelectedIndexChanged);
            // 
            // cbxCodArea
            // 
            this.cbxCodArea.FormattingEnabled = true;
            this.cbxCodArea.Location = new System.Drawing.Point(95, 6);
            this.cbxCodArea.Name = "cbxCodArea";
            this.cbxCodArea.Size = new System.Drawing.Size(81, 24);
            this.cbxCodArea.TabIndex = 10;
            // 
            // btnBuscarSubAreasPDF
            // 
            this.btnBuscarSubAreasPDF.Location = new System.Drawing.Point(468, 4);
            this.btnBuscarSubAreasPDF.Name = "btnBuscarSubAreasPDF";
            this.btnBuscarSubAreasPDF.Size = new System.Drawing.Size(113, 25);
            this.btnBuscarSubAreasPDF.TabIndex = 9;
            this.btnBuscarSubAreasPDF.Text = "Listar";
            this.btnBuscarSubAreasPDF.UseVisualStyleBackColor = true;
            this.btnBuscarSubAreasPDF.Click += new System.EventHandler(this.btnBuscarSubAreasPDF_Click);
            // 
            // cbxTipoFolha
            // 
            this.cbxTipoFolha.FormattingEnabled = true;
            this.cbxTipoFolha.Items.AddRange(new object[] {
            "A4 - A6 Vertical",
            "A4 - A6 Horizontal"});
            this.cbxTipoFolha.Location = new System.Drawing.Point(95, 36);
            this.cbxTipoFolha.Name = "cbxTipoFolha";
            this.cbxTipoFolha.Size = new System.Drawing.Size(174, 24);
            this.cbxTipoFolha.TabIndex = 6;
            // 
            // btnSelecionarTodasSubAreas
            // 
            this.btnSelecionarTodasSubAreas.Location = new System.Drawing.Point(335, 4);
            this.btnSelecionarTodasSubAreas.Name = "btnSelecionarTodasSubAreas";
            this.btnSelecionarTodasSubAreas.Size = new System.Drawing.Size(130, 25);
            this.btnSelecionarTodasSubAreas.TabIndex = 5;
            this.btnSelecionarTodasSubAreas.Text = "Selecionar todos";
            this.btnSelecionarTodasSubAreas.UseVisualStyleBackColor = true;
            this.btnSelecionarTodasSubAreas.Click += new System.EventHandler(this.btnSelecionarTodasSubAreas_Click);
            // 
            // ckbRecontagem
            // 
            this.ckbRecontagem.AutoSize = true;
            this.ckbRecontagem.Location = new System.Drawing.Point(335, 70);
            this.ckbRecontagem.Name = "ckbRecontagem";
            this.ckbRecontagem.Size = new System.Drawing.Size(110, 21);
            this.ckbRecontagem.TabIndex = 4;
            this.ckbRecontagem.Text = "Recontagem";
            this.ckbRecontagem.UseVisualStyleBackColor = true;
            // 
            // ckbAssinaturaPDF
            // 
            this.ckbAssinaturaPDF.AutoSize = true;
            this.ckbAssinaturaPDF.Location = new System.Drawing.Point(451, 70);
            this.ckbAssinaturaPDF.Name = "ckbAssinaturaPDF";
            this.ckbAssinaturaPDF.Size = new System.Drawing.Size(97, 21);
            this.ckbAssinaturaPDF.TabIndex = 3;
            this.ckbAssinaturaPDF.Text = "Assinatura";
            this.ckbAssinaturaPDF.UseVisualStyleBackColor = true;
            // 
            // btnGerarPDF
            // 
            this.btnGerarPDF.Location = new System.Drawing.Point(468, 416);
            this.btnGerarPDF.Name = "btnGerarPDF";
            this.btnGerarPDF.Size = new System.Drawing.Size(113, 25);
            this.btnGerarPDF.TabIndex = 1;
            this.btnGerarPDF.Text = "Gerar PDF";
            this.btnGerarPDF.UseVisualStyleBackColor = true;
            this.btnGerarPDF.Visible = false;
            this.btnGerarPDF.Click += new System.EventHandler(this.btnGerarPDF_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Areas :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Tipo Folha :";
            // 
            // gerador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 494);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "gerador";
            this.Text = "Endereçamento de inventários.";
            this.Load += new System.EventHandler(this.gerador_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbCadArea.ResumeLayout(false);
            this.tbCadArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgArea)).EndInit();
            this.tbSubAreaCad.ResumeLayout(false);
            this.tbSubAreaCad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSubArea)).EndInit();
            this.tbPDF.ResumeLayout(false);
            this.tbPDF.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbCadArea;
        private System.Windows.Forms.DataGridView dtgArea;
        private System.Windows.Forms.Button btnSalvarArea;
        private System.Windows.Forms.TextBox txbCodArea;
        private System.Windows.Forms.TextBox txbNomeArea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tbSubAreaCad;
        private System.Windows.Forms.Button btnSalvarSubArea;
        private System.Windows.Forms.TextBox txbCodSubArea;
        private System.Windows.Forms.TextBox txbNomeSubArea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDeletarAreaSelec;
        private System.Windows.Forms.Button btnListarAreas;
        private System.Windows.Forms.Button btnDeletarSubAreaSelec;
        private System.Windows.Forms.Button btnListarSubAreas;
        private System.Windows.Forms.TextBox txbDescAreaCadSubArea;
        private System.Windows.Forms.TextBox txbCodConsultaArea;
        private System.Windows.Forms.Label lblSeletorArea;
        private System.Windows.Forms.DataGridView dtgSubArea;
        private System.Windows.Forms.TabPage tbPDF;
        private System.Windows.Forms.CheckedListBox ckbSubAreas;
        private System.Windows.Forms.Button btnSelecionarTodasSubAreas;
        private System.Windows.Forms.CheckBox ckbRecontagem;
        private System.Windows.Forms.CheckBox ckbAssinaturaPDF;
        private System.Windows.Forms.ComboBox cbxAreaPDF;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBuscarSubAreasPDF;
        private System.Windows.Forms.ComboBox cbxCodArea;
        private System.Windows.Forms.Button btnDesmarcar;
        private System.Windows.Forms.Button btnGerarPDF2;
        private System.Windows.Forms.ComboBox cbxTipoCodigo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxTipoFolha;
        private System.Windows.Forms.Button btnGerarPDF;
        private System.Windows.Forms.TextBox txbError;

    }
}

