using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net;
using Gma.QrCodeNet.Encoding;
using System.Drawing.Imaging;
using Gma.QrCodeNet;
using Gma.QrCodeNet.Encoding.Windows.Render;
using ZXing;
using ZXing.Common;
using System.Drawing;

namespace GeradorAreaInventario
{
    public partial class gerador : Form
    {
        //caminho para o banco de dados principal string publica para evitar repeticao
        public static string connString = "Data Source=inventarios.db;Version=3;";

        public gerador()
        {
            InitializeComponent();
        }

        private void btnSalvarArea_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        
                            string sql = "INSERT INTO area (codigo, descricao) VALUES (@codigo, @descricao);";
                            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                            {
                                string codigo = txbCodArea.Text.Trim();
                                string descricao = txbNomeArea.Text.Trim();

                                cmd.Parameters.AddWithValue("@codigo", codigo);
                                cmd.Parameters.AddWithValue("@descricao", descricao);
                                cmd.ExecuteNonQuery();
                            }
                         transaction.Commit();
                        MessageBox.Show("Área salva.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListaAreas();
                        CarregarAreasNoComboBox();
                        }
                    }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar área: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnListarAreas_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    conn.Open();

                    // Defina a sua query SQL
                    string sql = "SELECT codigo, descricao FROM area;";

                    // Crie um DataAdapter para preencher um DataTable
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Atribua o DataTable como fonte de dados do DataGridView
                        dtgArea.DataSource = dt;
                        // Ajustar a largura das colunas automaticamente baseado no conteúdo
                        dtgArea.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                        // Alterar os títulos dos cabeçalhos das colunas
                        //dtgArea.Columns["id"].HeaderText = "ID";
                        dtgArea.Columns["codigo"].HeaderText = "Cod. Área";
                        dtgArea.Columns["descricao"].HeaderText = "Descrição";
                        dtgArea.Columns["descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao executar consulta: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeletarAreaSelec_Click(object sender, EventArgs e)
        {

            if (dtgArea.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma linha para deletar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Supondo seleção de linha completa
            var linhaSelecionada = dtgArea.SelectedRows[0];

            // Obter valor da célula da coluna "codigo" (substitua pelo nome correto)
            var codigoObj = linhaSelecionada.Cells["codigo"].Value;

            if (codigoObj == null)
            {
                MessageBox.Show("Código inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string codigo = codigoObj.ToString();

            var resultado = MessageBox.Show(string.Format("Tem certeza que deseja deletar o registro com código {0}?",codigo), 
                "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                string connStr = "Data Source=inventarios.db;Version=3;";
                using (var conn = new SQLiteConnection(connStr))
                {
                    try
                    {
                        conn.Open();
                        string sql = "DELETE FROM area WHERE codigo = @codigo";
                        using (var cmd = new SQLiteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@codigo", codigo);
                            int linhasAfetadas = cmd.ExecuteNonQuery();
    
                            if (linhasAfetadas > 0)
                            {
                                //MessageBox.Show("Registro deletado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Remover linha do DataGridView para refletir exclusão
                                dtgArea.Rows.Remove(linhaSelecionada);
                            }
                            else
                            {
                                //MessageBox.Show("Nenhum registro encontrado com o código informado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        string sql2 = "DELETE FROM subarea WHERE cod_area = @codigo";
                        using (var cmd2 = new SQLiteCommand(sql2, conn))
                        {
                            cmd2.Parameters.AddWithValue("@codigo", codigo);
                            int linhasAfetadas = cmd2.ExecuteNonQuery();

                            if (linhasAfetadas > 0)
                            {
                                MessageBox.Show("Registro deletado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CarregarAreasNoComboBox();
                                ckbSubAreas.Items.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Nenhum registro encontrado com o código informado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao deletar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


        }

        private void btnSalvarSubArea_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {

                        string sql = "INSERT INTO subarea (descricao, codigo, cod_area) VALUES (@descricao, @codigo, @cd_area);";
                        using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                        {
                            string codigo = txbCodSubArea.Text.Trim();
                            string descricao = txbNomeSubArea.Text.Trim();
                            string cd_area = txbCodConsultaArea.Text.Trim();

                            cmd.Parameters.AddWithValue("@codigo", codigo);
                            cmd.Parameters.AddWithValue("@descricao", descricao);
                            cmd.Parameters.AddWithValue("@cd_area", cd_area);
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        MessageBox.Show("Área salva.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarSubareasPorCodigoArea(txbCodConsultaArea.Text.Trim());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar área: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void ListaAreas()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    conn.Open();

                    // Defina a sua query SQL
                    string sql = "SELECT codigo, descricao FROM area;";

                    // Crie um DataAdapter para preencher um DataTable
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Atribua o DataTable como fonte de dados do DataGridView
                        dtgArea.DataSource = dt;
                        // Ajustar a largura das colunas automaticamente baseado no conteúdo
                        dtgArea.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                        // Alterar os títulos dos cabeçalhos das colunas
                        //dtgArea.Columns["id"].HeaderText = "ID";
                        dtgArea.Columns["codigo"].HeaderText = "Cod. Área";
                        dtgArea.Columns["descricao"].HeaderText = "Descrição";
                        dtgArea.Columns["descricao"].Width = 300;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao executar consulta: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void BuscarDescricaoAreaPorCodigo(string codigo)
        {
            string connectionString = "Data Source=inventarios.db;Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT descricao FROM area WHERE codigo = @codigo LIMIT 1;";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@codigo", codigo);
                        var resultado = cmd.ExecuteScalar();

                        if (resultado != null)
                        {
                            txbDescAreaCadSubArea.Text = resultado.ToString();
                        }
                        else
                        {
                            txbDescAreaCadSubArea.Text = "";
                            MessageBox.Show("Área não encontrada para o código informado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao buscar área: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txbCodConsultaArea_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla pressionada foi Enter
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.Handled = true; // evita o 'beep' de enter padrão
                string codigo = txbCodConsultaArea.Text.Trim();
                if (string.IsNullOrEmpty(codigo))
                {
                    MessageBox.Show("Digite um código válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                BuscarDescricaoAreaPorCodigo(codigo);
            }
        }

        private void btnListarSubAreas_Click(object sender, EventArgs e)
        {
            string codigoArea = txbCodConsultaArea.Text.Trim();

            if (string.IsNullOrEmpty(codigoArea))
            {
                MessageBox.Show("Digite o código da área.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListarSubareasPorCodigoArea(codigoArea);
        }


        private void ListarSubareasPorCodigoArea(string codigoArea)
        {
            string connectionString = "Data Source=inventarios.db;Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string sql = @"
                SELECT codigo , descricao FROM subarea WHERE cod_area = @codigoArea";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@codigoArea", codigoArea);

                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dtgSubArea.DataSource = dt;

                            // Opcional: Personalizar cabeçalhos
                            if (dtgSubArea.Columns["codigo"] != null)
                                dtgSubArea.Columns["codigo"].HeaderText = "Código Subárea";

                            if (dtgSubArea.Columns["descricao"] != null)
                                dtgSubArea.Columns["descricao"].HeaderText = "Descrição Subárea";

                            dtgSubArea.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                            dtgSubArea.Columns["descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao listar subáreas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeletarSubAreaSelec_Click(object sender, EventArgs e)
        {
            if (dtgSubArea.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma linha para deletar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Supondo seleção de linha completa
            var linhaSelecionada = dtgSubArea.SelectedRows[0];

            // Obter valor da célula da coluna "codigo" (substitua pelo nome correto)
            var codigoObj = linhaSelecionada.Cells["codigo"].Value;

            if (codigoObj == null)
            {
                MessageBox.Show("Código inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string codigo = codigoObj.ToString();
            string codArea = txbCodConsultaArea.Text.Trim();

            var resultado = MessageBox.Show(string.Format("Tem certeza que deseja deletar o registro com código {0}?", codigo),
                "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                string connStr = "Data Source=inventarios.db;Version=3;";
                using (var conn = new SQLiteConnection(connStr))
                {
                    try
                    {
                        conn.Open();
                        string sql = "DELETE FROM subarea WHERE codigo = @codigo AND cod_area = @codArea";
                        using (var cmd = new SQLiteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@codigo", codigo);
                            cmd.Parameters.AddWithValue("@codArea", codArea);
                            int linhasAfetadas = cmd.ExecuteNonQuery();

                            if (linhasAfetadas > 0)
                            {
                                ListarSubareasPorCodigoArea(txbCodConsultaArea.Text.Trim());
                                CarregarAreasNoComboBox();
                                ckbSubAreas.Items.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Nenhum registro encontrado com o código informado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao deletar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


        }

        private void gerador_Load(object sender, EventArgs e)
        {
            CarregarAreasNoComboBox();
            cbxTipoFolha.SelectedIndex = 0;
            cbxTipoCodigo.SelectedIndex = 0;
        }
        

        private void CarregarAreasNoComboBox()
        {
            string connectionString = "Data Source=inventarios.db;Version=3;";

            cbxAreaPDF.Items.Clear();
            cbxCodArea.Items.Clear();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT codigo, descricao FROM area;";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string descricao = reader["descricao"].ToString();
                                cbxAreaPDF.Items.Add(descricao);
                                string codigo = reader["codigo"].ToString();
                                cbxCodArea.Items.Add(codigo);
                            }
                        }
                    }

                    if (cbxAreaPDF.Items.Count > 0)
                    {
                        cbxAreaPDF.SelectedIndex = 0; // Seleciona o primeiro item automaticamente
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar áreas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuscarSubAreasPDF_Click(object sender, EventArgs e)
        {
            CarregarSubareasPorCodArea(cbxCodArea.SelectedItem.ToString());
        }

       private void CarregarSubareasPorCodArea(string cod_area)
        {
            ckbSubAreas.Items.Clear();

            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    conn.Open();
                    string sql = @"
                        SELECT codigo , descricao FROM subarea WHERE cod_area = @codArea
                    ";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@codArea", cod_area);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string codigoSubarea = reader["codigo"].ToString();
                                string descricaoSubarea = reader["descricao"].ToString();

                                // Adiciona o item ao CheckedListBox. Pode personalizar o texto conforme preferir
                                ckbSubAreas.Items.Add(descricaoSubarea);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar subáreas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbxAreas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxCodArea.SelectedIndex = cbxAreaPDF.SelectedIndex;
        }

        private void btnSelecionarTodasSubAreas_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ckbSubAreas.Items.Count; i++)
            {
                ckbSubAreas.SetItemChecked(i, true); 
            }
        }

        private void btnDesmarcar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ckbSubAreas.Items.Count; i++)
            {
                ckbSubAreas.SetItemChecked(i, false);
            }
        }


        private void GerarEtiquetaA4verticalCodigo2D()
        {
            // Configurações iniciais do PDF
            Document doc = new Document(PageSize.A4);
            string dataformatada = DateTime.Now.ToString("ddMMyyyy");
            string textoOriginal = cbxAreaPDF.SelectedItem.ToString();
            string areaNomeCap = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textoOriginal.ToLower());
            string caminhoPDF = Path.Combine(Application.StartupPath, string.Format("Etiqueta{0}{1}.pdf", areaNomeCap, dataformatada));

            using (FileStream fs = new FileStream(caminhoPDF, FileMode.Create))
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // Fonte Helvetica
                BaseFont helvetica = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);

                // Tamanho da página
                float paginaLargura = doc.PageSize.Width;
                float paginaAltura = doc.PageSize.Height;

                // Tamanho da etiqueta (1/4 de uma A4)
                float etiquetaLargura = paginaLargura / 2;
                float etiquetaAltura = paginaAltura / 2;

                // Obtem áreas selecionadas
                List<string> listaSubAreasSelecionadas = new List<string>();
                foreach (object item in ckbSubAreas.CheckedItems)
                {
                    listaSubAreasSelecionadas.Add(item.ToString());
                }

                for (int i = 0; i < listaSubAreasSelecionadas.Count; i++)
                {
                    string Subarea = listaSubAreasSelecionadas[i];
                    string Area = cbxAreaPDF.SelectedItem.ToString();
                    // Calcula posição (coluna e linha)
                    int coluna = i % 2;
                    int linha = (i / 2) % 2;

                    float x = coluna * etiquetaLargura;
                    float y = paginaAltura - ((linha + 1) * etiquetaAltura);

                    // Retângulo da etiqueta (opcional: borda)
                    iTextSharp.text.Rectangle rectEtiqueta = new iTextSharp.text.Rectangle(x, y, x + etiquetaLargura, y + etiquetaAltura);
                    rectEtiqueta.Border = iTextSharp.text.Rectangle.BOX;
                    rectEtiqueta.BorderWidth = 0.5f;
                    rectEtiqueta.BorderColor = BaseColor.GRAY;

                    PdfContentByte cb = writer.DirectContent;
                    cb.Rectangle(rectEtiqueta.Left, rectEtiqueta.Bottom, rectEtiqueta.Width, rectEtiqueta.Height);
                    cb.Stroke();

                    // Texto: Área e Subárea (você pode adaptar a lógica de subárea real)
                    //ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Aréa: " + cbxAreaPDF.SelectedItem.ToString()), x + 10, y + etiquetaAltura - 30, 0);
                    //ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Subárea: " + Subarea), x + 10, y + etiquetaAltura - 60, 0);
                    TituloTexto(writer, "SubÁrea: " + Subarea, x + 10, y + etiquetaAltura - 180, 0);
                    TituloTexto(writer, "Área: " + cbxAreaPDF.SelectedItem.ToString(), x + 10, y + etiquetaAltura - 30, 0);
                    // Texto fixo
                    //ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("CPD - PV14"), x + 10, y + etiquetaAltura - 90, 270);
                    TextoSimplesPeq(writer, "CPD - PV14", x + 10, y + etiquetaAltura - 300, 270);

                    // Campos de preenchimento manual
                    if (ckbRecontagem.Checked == true)
                    {
                        TextoSimples(writer, "Recontagem: ________________________", x + 10, y + 40, 0);
                        PdfContentByte caixinha2 = writer.DirectContent;
                        caixinha2.SetColorStroke(BaseColor.BLACK);
                        caixinha2.SetLineWidth(0.5f);
                        caixinha2.Rectangle(x + 250, y + 38, 15, 15); //OK
                        caixinha2.Stroke();
                    }
                    if (ckbAssinaturaPDF.Checked == true)
                    {
                        //ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Assinatura: ____________________"), x + 10, y + 20, 0);
                        TextoSimples(writer, "Assinatura: __________________________", x + 10, y + 20, 0);
                        PdfContentByte caixinha1 = writer.DirectContent;
                        caixinha1.SetColorStroke(BaseColor.BLACK);
                        caixinha1.SetLineWidth(0.5f);
                        caixinha1.Rectangle(x + 250, y + 18, 15, 15); //OK
                        caixinha1.Stroke();

                    }
                    
                    // QR Code
                    var encoder = new QrEncoder(ErrorCorrectionLevel.H);
                    QrCode qr;
                    encoder.TryEncode(Subarea, out qr);
                    var render = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two));
                    System.Drawing.Bitmap qrBitmap;
                    using (MemoryStream msQR = new MemoryStream())
                    {
                        render.WriteToStream(qr.Matrix, ImageFormat.Png, msQR);
                        qrBitmap = new System.Drawing.Bitmap(msQR);
                    }

                    // Converter QR para imagem do PDF
                    using (MemoryStream ms = new MemoryStream())
                    {
                        qrBitmap.Save(ms, ImageFormat.Png);
                        iTextSharp.text.Image qrImage = iTextSharp.text.Image.GetInstance(ms.ToArray());
                        qrImage.SetAbsolutePosition(x + etiquetaLargura - 290, y + 130);
                        qrImage.ScaleAbsolute(100, 100);
                        doc.Add(qrImage);
                    }

                    // QR Code
                    var encoder2 = new QrEncoder(ErrorCorrectionLevel.H);
                    QrCode qr2;
                    encoder.TryEncode(Area, out qr2);
                    var render2 = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two));
                    System.Drawing.Bitmap qrBitmap2;
                    using (MemoryStream msQR2 = new MemoryStream())
                    {
                        render2.WriteToStream(qr2.Matrix, ImageFormat.Png, msQR2);
                        qrBitmap2 = new System.Drawing.Bitmap(msQR2);
                    }

                    // Converter QR para imagem do PDF
                    using (MemoryStream ms2 = new MemoryStream())
                    {
                        qrBitmap2.Save(ms2, ImageFormat.Png);
                        iTextSharp.text.Image qrImage = iTextSharp.text.Image.GetInstance(ms2.ToArray());
                        qrImage.SetAbsolutePosition(x + etiquetaLargura - 290, y + 280);
                        qrImage.ScaleAbsolute(100, 100);
                        doc.Add(qrImage);
                    }

                    // Nova página a cada 4 etiquetas
                    if ((i + 1) % 4 == 0 && (i + 1) < listaSubAreasSelecionadas.Count)
                    {
                        doc.NewPage();
                    }
                }

                doc.Close();
            }

            MessageBox.Show("PDF gerado com sucesso!", "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Diagnostics.Process.Start(caminhoPDF);
        }

        private void GerarEtiquetaA4verticalCodigo1D()
        {
            // Configurações iniciais do PDF
            Document doc = new Document(PageSize.A4);
            string dataformatada = DateTime.Now.ToString("ddMMyyyy");
            string textoOriginal = cbxAreaPDF.SelectedItem.ToString();
            string areaNomeCap = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textoOriginal.ToLower());
            string caminhoPDF = Path.Combine(Application.StartupPath, string.Format("Etiqueta{0}{1}.pdf", areaNomeCap, dataformatada));

            using (FileStream fs = new FileStream(caminhoPDF, FileMode.Create))
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                BaseFont helvetica = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                float paginaLargura = doc.PageSize.Width;
                float paginaAltura = doc.PageSize.Height;
                float etiquetaLargura = paginaLargura / 2;
                float etiquetaAltura = paginaAltura / 2;

                List<string> listaSubAreasSelecionadas = new List<string>();
                foreach (object item in ckbSubAreas.CheckedItems)
                {
                    listaSubAreasSelecionadas.Add(item.ToString());
                }

                for (int i = 0; i < listaSubAreasSelecionadas.Count; i++)
                {
                    string Subarea = listaSubAreasSelecionadas[i];
                    string Area = cbxAreaPDF.SelectedItem.ToString();

                    int coluna = i % 2;
                    int linha = (i / 2) % 2;

                    float x = coluna * etiquetaLargura;
                    float y = paginaAltura - ((linha + 1) * etiquetaAltura);

                    iTextSharp.text.Rectangle rectEtiqueta = new iTextSharp.text.Rectangle(x, y, x + etiquetaLargura, y + etiquetaAltura);
                    rectEtiqueta.Border = iTextSharp.text.Rectangle.BOX;
                    rectEtiqueta.BorderWidth = 0.5f;
                    rectEtiqueta.BorderColor = BaseColor.GRAY;

                    PdfContentByte cb = writer.DirectContent;
                    cb.Rectangle(rectEtiqueta.Left, rectEtiqueta.Bottom, rectEtiqueta.Width, rectEtiqueta.Height);
                    cb.Stroke();

                    TituloTexto(writer, "SubÁrea: " + Subarea, x + 10, y + etiquetaAltura - 180, 0);
                    TituloTexto(writer, "Área: " + cbxAreaPDF.SelectedItem.ToString(), x + 10, y + etiquetaAltura - 30, 0);
                    TextoSimplesPeq(writer, "CPD - PV14", x + 10, y + etiquetaAltura - 300, 270);

                    if (ckbRecontagem.Checked == true)
                    {
                        TextoSimples(writer, "Recontagem: ________________________", x + 10, y + 40, 0);
                        PdfContentByte caixinha2 = writer.DirectContent;
                        caixinha2.SetColorStroke(BaseColor.BLACK);
                        caixinha2.SetLineWidth(0.5f);
                        caixinha2.Rectangle(x + 250, y + 38, 15, 15);
                        caixinha2.Stroke();
                    }

                    if (ckbAssinaturaPDF.Checked == true)
                    {
                        TextoSimples(writer, "Assinatura: __________________________", x + 10, y + 20, 0);
                        PdfContentByte caixinha1 = writer.DirectContent;
                        caixinha1.SetColorStroke(BaseColor.BLACK);
                        caixinha1.SetLineWidth(0.5f);
                        caixinha1.Rectangle(x + 250, y + 18, 15, 15);
                        caixinha1.Stroke();
                    }

                    // Código de barras da Subárea (parte inferior)
                    var writerBarcode1 = new ZXing.BarcodeWriter();
                    writerBarcode1.Format = ZXing.BarcodeFormat.CODE_128;
                    writerBarcode1.Options = new ZXing.Common.EncodingOptions
                    {
                        Width = 200,
                        Height = 60,
                        Margin = 2,
                        PureBarcode = true
                    };

                    System.Drawing.Bitmap barcodeBitmap1 = writerBarcode1.Write(Subarea);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        barcodeBitmap1.Save(ms, ImageFormat.Png);
                        iTextSharp.text.Image barcodeImage = iTextSharp.text.Image.GetInstance(ms.ToArray());
                        barcodeImage.SetAbsolutePosition(x + etiquetaLargura - 290, y + 130);
                        barcodeImage.ScaleAbsolute(200, 60);
                        doc.Add(barcodeImage);
                    }

                    // Código de barras da Área (parte superior)
                    var writerBarcode2 = new ZXing.BarcodeWriter();
                    writerBarcode2.Format = ZXing.BarcodeFormat.CODE_128;
                    writerBarcode2.Options = new ZXing.Common.EncodingOptions
                    {
                        Width = 200,
                        Height = 60,
                        Margin = 2,
                        PureBarcode = true
                    };

                    System.Drawing.Bitmap barcodeBitmap2 = writerBarcode2.Write(Area);
                    using (MemoryStream ms2 = new MemoryStream())
                    {
                        barcodeBitmap2.Save(ms2, ImageFormat.Png);
                        iTextSharp.text.Image barcodeImage2 = iTextSharp.text.Image.GetInstance(ms2.ToArray());
                        barcodeImage2.SetAbsolutePosition(x + etiquetaLargura - 290, y + 280);
                        barcodeImage2.ScaleAbsolute(200, 60);
                        doc.Add(barcodeImage2);
                    }

                    if ((i + 1) % 4 == 0 && (i + 1) < listaSubAreasSelecionadas.Count)
                    {
                        doc.NewPage();
                    }
                }

                doc.Close();
            }

            MessageBox.Show("PDF gerado com sucesso!", "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Diagnostics.Process.Start(caminhoPDF);
        }

        private void GerarEtiquetaA4horizontalCodigo1D()
        {
            // Configurações iniciais do PDF
            Document doc = new Document(PageSize.A4);
            string dataformatada = DateTime.Now.ToString("ddMMyyyy");
            string textoOriginal = cbxAreaPDF.SelectedItem.ToString();
            string areaNomeCap = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textoOriginal.ToLower());
            string caminhoPDF = Path.Combine(Application.StartupPath, string.Format("Etiqueta{0}{1}.pdf", areaNomeCap, dataformatada));

            using (FileStream fs = new FileStream(caminhoPDF, FileMode.Create))
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                BaseFont helvetica = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                float paginaLargura = doc.PageSize.Width;
                float paginaAltura = doc.PageSize.Height;
                float etiquetaLargura = paginaLargura / 2;
                float etiquetaAltura = paginaAltura / 2;

                List<string> listaSubAreasSelecionadas = new List<string>();
                foreach (object item in ckbSubAreas.CheckedItems)
                {
                    listaSubAreasSelecionadas.Add(item.ToString());
                }

                for (int i = 0; i < listaSubAreasSelecionadas.Count; i++)
                {
                    string Subarea = listaSubAreasSelecionadas[i];
                    string Area = cbxAreaPDF.SelectedItem.ToString();

                    int coluna = i % 2;
                    int linha = (i / 2) % 2;

                    float x = coluna * etiquetaLargura;
                    float y = paginaAltura - ((linha + 1) * etiquetaAltura);

                    iTextSharp.text.Rectangle rectEtiqueta = new iTextSharp.text.Rectangle(x, y, x + etiquetaLargura, y + etiquetaAltura);
                    rectEtiqueta.Border = iTextSharp.text.Rectangle.BOX;
                    rectEtiqueta.BorderWidth = 0.5f;
                    rectEtiqueta.BorderColor = BaseColor.GRAY;

                    PdfContentByte cb = writer.DirectContent;
                    cb.Rectangle(rectEtiqueta.Left, rectEtiqueta.Bottom, rectEtiqueta.Width, rectEtiqueta.Height);
                    cb.Stroke();

                    TituloTexto(writer, "Área: " + cbxAreaPDF.SelectedItem.ToString(), x + 270 , y + etiquetaAltura - 10, 270);
                    
                    TituloTexto(writer, "SubÁrea: " + Subarea, x + 170, y + etiquetaAltura - 10, 270);
                    
                    TextoSimplesPeq(writer, "CPD - PV14", x + 10, y + etiquetaAltura - 350, 270);

                    if (ckbRecontagem.Checked == true)
                    {
                        TextoSimples(writer, "Recontagem: ________________________", x + 50, y + 410, 270);
                        PdfContentByte caixinha2 = writer.DirectContent;
                        caixinha2.SetColorStroke(BaseColor.BLACK);
                        caixinha2.SetLineWidth(0.5f);
                        caixinha2.Rectangle(x + 48, y + 150, 15, 15);
                        caixinha2.Stroke();
                    }

                    if (ckbAssinaturaPDF.Checked == true)
                    {
                        TextoSimples(writer, "Assinatura: __________________________", x + 15, y + 410, 270);
                        PdfContentByte caixinha1 = writer.DirectContent;
                        caixinha1.SetColorStroke(BaseColor.BLACK);
                        caixinha1.SetLineWidth(0.5f);
                        caixinha1.Rectangle(x + 13, y + 150, 15, 15);
                        caixinha1.Stroke();
                    }

                    // Código de barras da Subárea (parte inferior)
                    var writerBarcode1 = new ZXing.BarcodeWriter();
                    writerBarcode1.Format = ZXing.BarcodeFormat.CODE_128;
                    writerBarcode1.Options = new ZXing.Common.EncodingOptions
                    {
                        Width = 200,
                        Height = 60,
                        Margin = 2,
                        PureBarcode = true
                    };

                    System.Drawing.Bitmap barcodeBitmap1 = writerBarcode1.Write(Subarea);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        barcodeBitmap1.Save(ms, ImageFormat.Png);
                        iTextSharp.text.Image barcodeImage = iTextSharp.text.Image.GetInstance(ms.ToArray());
                        barcodeImage.SetAbsolutePosition(x + etiquetaLargura - 200, y + 200);
                        barcodeImage.ScaleAbsolute(200, 60);
                        barcodeImage.RotationDegrees = 270;
                        doc.Add(barcodeImage);
                    }

                    // Código de barras da Área (parte superior)
                    var writerBarcode2 = new ZXing.BarcodeWriter();
                    writerBarcode2.Format = ZXing.BarcodeFormat.CODE_128;
                    writerBarcode2.Options = new ZXing.Common.EncodingOptions
                    {
                        Width = 200,
                        Height = 60,
                        Margin = 2,
                        PureBarcode = true
                    };

                    System.Drawing.Bitmap barcodeBitmap2 = writerBarcode2.Write(Area);
                    using (MemoryStream ms2 = new MemoryStream())
                    {
                        barcodeBitmap2.Save(ms2, ImageFormat.Png);
                        iTextSharp.text.Image barcodeImage2 = iTextSharp.text.Image.GetInstance(ms2.ToArray());
                        barcodeImage2.SetAbsolutePosition(x + etiquetaLargura - 100, y + 200);
                        barcodeImage2.ScaleAbsolute(200, 60);
                        barcodeImage2.RotationDegrees = 270;
                        doc.Add(barcodeImage2);
                    }

                    if ((i + 1) % 4 == 0 && (i + 1) < listaSubAreasSelecionadas.Count)
                    {
                        doc.NewPage();
                    }
                }

                doc.Close();
            }

            MessageBox.Show("PDF gerado com sucesso!", "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Diagnostics.Process.Start(caminhoPDF);
        }


        private void btnGerarPDF_Click(object sender, EventArgs e)
        {
            GerarEtiquetaA4horizontalCodigo1D();
        }

        private void TextoSimplesPeq(PdfWriter writer, string texto, float x, float y, float angulo = 0)
        {
            // Cria um PdfContentByte para desenhar no PDF
            PdfContentByte cb = writer.DirectContent;

            // Define a fonte
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.BeginText();
            cb.SetFontAndSize(bf, 8); // Define o tamanho da fonte

            // Se o ângulo for diferente de 0, rotaciona o texto
            if (angulo != 0)
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, texto, x, y, angulo);
            }
            else
            {
                cb.SetTextMatrix(x, y); // Define a posição (x, y)
                cb.ShowText(texto); // Adiciona o texto
            }

            cb.EndText();
        }

        private void TextoSimples(PdfWriter writer, string texto, float x, float y, float angulo = 0)
        {
            // Cria um PdfContentByte para desenhar no PDF
            PdfContentByte cb = writer.DirectContent;

            // Define a fonte
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.BeginText();
            cb.SetFontAndSize(bf, 12); // Define o tamanho da fonte

            // Se o ângulo for diferente de 0, rotaciona o texto
            if (angulo != 0)
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, texto, x, y, angulo);
            }
            else
            {
                cb.SetTextMatrix(x, y); // Define a posição (x, y)
                cb.ShowText(texto); // Adiciona o texto
            }

            cb.EndText();
        }

        private void TituloTexto(PdfWriter writer, string texto, float x, float y, float angulo = 0)
        {
            // Cria um PdfContentByte para desenhar no PDF
            PdfContentByte cb = writer.DirectContent;

            // Define a fonte
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.BeginText();
            cb.SetFontAndSize(bf, 20); // Define o tamanho da fonte

            // Se o ângulo for diferente de 0, rotaciona o texto
            if (angulo != 0)
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, texto, x, y, angulo);
            }
            else
            {
                cb.SetTextMatrix(x, y); // Define a posição (x, y)
                cb.ShowText(texto); // Adiciona o texto
            }

            cb.EndText();
        }

        private void btnGerarPDF2_Click(object sender, EventArgs e)
        {
            if (ckbSubAreas.Items.Count > 0)
            {
                if (cbxTipoCodigo.SelectedIndex == 0 && cbxTipoFolha.SelectedIndex == 0)
                {
                    GerarEtiquetaA4verticalCodigo2D();
                }
               
                if (cbxTipoCodigo.SelectedIndex == 1 && cbxTipoFolha.SelectedIndex == 0)
                {
                    GerarEtiquetaA4verticalCodigo1D();
                }

                if (cbxTipoCodigo.SelectedIndex == 1 && cbxTipoFolha.SelectedIndex == 1)
                {
                    GerarEtiquetaA4horizontalCodigo1D();
                }
                if (cbxTipoCodigo.SelectedIndex == 0 && cbxTipoFolha.SelectedIndex == 1)
                {
                    MessageBox.Show("disponivel em breve.");
                }
             }
            else
            {
                MessageBox.Show("Revise os parametros e tente novamente!");
            }
            
        }

      

    }
}
