using AnaliseXMLNFeCTe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AnaliseXMLNFeCte
{
    public partial class Form1 : Form
    {


        private Dictionary<string, Color> m_tagColors;
    
        public Form1()
        {
            InitializeComponent();
            m_tagColors = Colors.Load();

            treeViewArquivos.AfterSelect += treeViewArquivos_AfterSelect;
            chkShowValues.CheckedChanged += chkShowValues_CheckedChanged;

            btnDeleteSelected.Click += btnDeleteSelected_Click;
            treeViewArquivos.KeyDown += treeViewArquivos_KeyDown;

            cbOrderBy.Items.Add("Quantity Desc");
            cbOrderBy.Items.Add("Quantity Asc");
            cbOrderBy.Items.Add("Name A-Z");
            cbOrderBy.Items.Add("Name Z-A");
            cbOrderBy.Items.Add("First Appearance");
            cbOrderBy.Items.Add("Tag Length");

            cbOrderBy.SelectedIndex = 0;

            cbOrderBy.SelectedIndexChanged += cbOrderBy_SelectedIndexChanged;

            btnCopySelection.Click += btnCopySelection_Click;
            treeViewArquivos.KeyDown += treeViewCopy_KeyDown;
            treeViewDetalhes.KeyDown += treeViewCopy_KeyDown;

            btnCopyXmlSelection.Click += btnCopyXmlSelection_Click;
            treeViewArquivos.KeyDown += treeViewCopyXml_KeyDown;
            treeViewDetalhes.KeyDown += treeViewCopyXml_KeyDown;

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }


        private void addfolder_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Selecione uma pasta contendo XMLs";
                dialog.CheckFileExists = false;
                dialog.CheckPathExists = true;
                dialog.FileName = "Selecionar esta pasta";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                string caminhoPasta = Path.GetDirectoryName(dialog.FileName);

                if (string.IsNullOrEmpty(caminhoPasta))
                    return;

                // evita pasta duplicada
                foreach (TreeNode node in treeViewArquivos.Nodes)
                {
                    if (node.Tag != null && node.Tag.ToString() == caminhoPasta)
                    {
                        MessageBox.Show(
                            "Pasta já adicionada.",
                            "Aviso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        return;
                    }
                }

                TreeNode pastaNode = new TreeNode(Path.GetFileName(caminhoPasta));
                pastaNode.Tag = caminhoPasta;

                string[] arquivosXml = Directory.GetFiles(
                    caminhoPasta,
                    "*.xml",
                    SearchOption.TopDirectoryOnly);

                foreach (string arquivo in arquivosXml)
                {
                    string tipoArquivo = detectarTipoXml(arquivo);

                    TreeNode arquivoNode = new TreeNode(
                        string.Format(
                            "{0} [{1}]",
                            Path.GetFileName(arquivo),
                            tipoArquivo));

                    arquivoNode.Tag = arquivo;

                    if (tipoArquivo == "NFe")
                        arquivoNode.BackColor = Color.LightBlue;
                    else if (tipoArquivo == "CTe")
                        arquivoNode.BackColor = Color.LightGreen;
                    else if (tipoArquivo == "Erro")
                        arquivoNode.BackColor = Color.LightCoral;
                    else
                        arquivoNode.BackColor = Color.LightYellow;

                    // pré-estrutura colapsada
                    adicionarEstruturaXml(arquivoNode, arquivo);

                    pastaNode.Nodes.Add(arquivoNode);
                }

                treeViewArquivos.Nodes.Add(pastaNode);
                pastaNode.Collapse();
            }
        }
        //---------------------------------------------------------------------
        private string detectarTipoXml(string caminhoArquivo)
        {
            try
            {
                XDocument doc = XDocument.Load(caminhoArquivo);

                bool isNFe = doc
                    .Descendants()
                    .Any(x => x.Name.LocalName == "NFe");

                if (isNFe)
                    return "NFe";

                bool isCTe = doc
                    .Descendants()
                    .Any(x => x.Name.LocalName == "CTe");

                if (isCTe)
                    return "CTe";
            }
            catch
            {
                return "Erro";
            }

            return "Desconhecido";
        }

        //---------------------------------------------------------------------
        private void adicionarEstruturaXml(TreeNode parentNode, string caminhoArquivo)
        {
            try
            {
                XDocument doc = XDocument.Load(caminhoArquivo);

                if (doc.Root == null)
                    return;

                TreeNode rootNode = criarNodeXml(doc.Root);

                parentNode.Nodes.Add(rootNode);
            }
            catch
            {
                parentNode.Nodes.Add(
                    new TreeNode("Erro ao ler XML"));
            }
        }



        private void chkShowValues_CheckedChanged(object sender, EventArgs e)
        {
            foreach (TreeNode pastaNode in treeViewArquivos.Nodes)
            {
                foreach (TreeNode arquivoNode in pastaNode.Nodes)
                {
                    string caminhoArquivo = arquivoNode.Tag as string;

                    if (string.IsNullOrEmpty(caminhoArquivo))
                        continue;

                    arquivoNode.Nodes.Clear();
                    adicionarEstruturaXml(arquivoNode, caminhoArquivo);
                }
            }
        }

        private void treeViewArquivos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode arquivoNode = obterArquivoNode(e.Node);

            if (arquivoNode == null)
                return;

            string caminhoArquivo = arquivoNode.Tag as string;

            if (string.IsNullOrEmpty(caminhoArquivo))
                return;

            treeViewDetalhes.Nodes.Clear();

            try
            {
                XDocument doc = XDocument.Load(caminhoArquivo);

                if (doc.Root == null)
                    return;

                XElement elementoSelecionado = e.Node.Tag as XElement;

                if (elementoSelecionado == null)
                    elementoSelecionado = doc.Root;

                TreeNode detalheNode = criarNodeXml(elementoSelecionado);

                preencherEstatisticas(elementoSelecionado);

                treeViewDetalhes.Nodes.Add(detalheNode);
                detalheNode.ExpandAll();
                detalheNode.EnsureVisible();
                treeViewDetalhes.SelectedNode = detalheNode;
            }
            catch
            {
                treeViewDetalhes.Nodes.Add("Erro ao ler XML");
            }
        }

        private TreeNode obterArquivoNode(TreeNode node)
        {
            while (node != null)
            {
                string caminho = node.Tag as string;

                if (!string.IsNullOrEmpty(caminho) && File.Exists(caminho))
                    return node;

                node = node.Parent;
            }

            return null;
        }

        private TreeNode criarNodeXml(XElement element)
        {
            string textoNode = element.Name.LocalName;

            if (chkShowValues.Checked && !element.HasElements)
            {
                textoNode = string.Format(
                    "{0}: {1}",
                    element.Name.LocalName,
                    element.Value);
            }

            TreeNode node = new TreeNode(textoNode);
            node.Tag = element;

            colorirNodeXml(node, element);

            foreach (XElement child in element.Elements())
                node.Nodes.Add(criarNodeXml(child));

            return node;
        }


        private void adicionarElementosXml(XElement element, TreeNode parentNode)
        {
            foreach (XElement child in element.Elements())
            {
                TreeNode childNode = criarNodeXml(child);

                parentNode.Nodes.Add(childNode);

                childNode.Collapse();
            }
        }

        private void colorirNodeXml(
             TreeNode node,
             XElement element)
        {
            string tag = element.Name.LocalName;

            if (m_tagColors.ContainsKey(tag))
            {
                node.BackColor = m_tagColors[tag];
                return;
            }

            node.BackColor = Color.White;
        }

        private bool isTagNFe(string tag)
        {
            string[] tagsNFe =
            {
                "infNFe", "ide", "emit", "dest", "det", "prod",
                "imposto", "ICMS", "IPI", "PIS", "COFINS",
                "total", "ICMSTot", "transp", "cobr", "pag",
                "infAdic", "protNFe", "infProt"
            };

            return tagsNFe.Contains(tag);
        }

        private bool isTagCTe(string tag)
        {
            string[] tagsCTe =
            {
                "infCte", "ide", "compl", "emit", "rem", "exped",
                "receb", "dest", "vPrest", "Comp", "imp",
                "ICMS", "infCTeNorm", "infCarga", "infQ",
                "infDoc", "infNFe", "infModal", "rodo",
                "infRespTec", "protCTe", "infProt"
            };

            return tagsCTe.Contains(tag);
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            deletarNodeSelecionado();
        }

        private void treeViewArquivos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                deletarNodeSelecionado();
                e.Handled = true;
            }
        }

        private void deletarNodeSelecionado()
        {
            TreeNode node = treeViewArquivos.SelectedNode;

            if (node == null)
                return;

            string mensagem = node.Parent == null
                ? "Remove this folder and all XMLs from scope?"
                : "Remove this XML/item from scope?";

            DialogResult result = MessageBox.Show(
                mensagem,
                "Confirm remove",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            node.Remove();

            treeViewDetalhes.Nodes.Clear();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void preencherEstatisticas(XElement element)
        {
            if (element == null)
            {
                statsRichTextBox.Clear();
                return;
            }

            var rankingTags = element
                .DescendantsAndSelf()
                .Select((x, index) => new
                {
                    Element = x,
                    Index = index
                })
                .GroupBy(x => x.Element.Name.LocalName)
                .Select(g => new
                {
                    Tag = g.Key,
                    Quantidade = g.Count(),
                    FirstIndex = g.Min(x => x.Index),
                    Tamanho = g.Key.Length
                });

            switch (cbOrderBy.SelectedItem?.ToString())
            {
                case "Quantity Asc":
                    rankingTags = rankingTags
                        .OrderBy(x => x.Quantidade)
                        .ThenBy(x => x.Tag);
                    break;

                case "Name A-Z":
                    rankingTags = rankingTags
                        .OrderBy(x => x.Tag);
                    break;

                case "Name Z-A":
                    rankingTags = rankingTags
                        .OrderByDescending(x => x.Tag);
                    break;

                case "First Appearance":
                    rankingTags = rankingTags
                        .OrderBy(x => x.FirstIndex);
                    break;

                case "Tag Length":
                    rankingTags = rankingTags
                        .OrderByDescending(x => x.Tamanho)
                        .ThenBy(x => x.Tag);
                    break;

                default:
                    rankingTags = rankingTags
                        .OrderByDescending(x => x.Quantidade)
                        .ThenBy(x => x.Tag);
                    break;
            }

            var listaFinal = rankingTags.ToList();

            StringBuilder texto = new StringBuilder();

            int larguraDisponivel =
                statsRichTextBox.ClientSize.Width - 20;

            int larguraLinhaAtual = 0;

            using (Graphics graphics = statsRichTextBox.CreateGraphics())
            {
                foreach (var item in listaFinal)
                {
                    string textoItem =
                        string.Format(
                            "[{0}] {1} / ",
                            item.Quantidade,
                            item.Tag);

                    Size tamanhoTexto =
                        TextRenderer.MeasureText(
                            graphics,
                            textoItem,
                            statsRichTextBox.Font,
                            new Size(int.MaxValue, int.MaxValue),
                            TextFormatFlags.NoPadding);

                    if (larguraLinhaAtual + tamanhoTexto.Width > larguraDisponivel)
                    {
                        texto.AppendLine();
                        larguraLinhaAtual = 0;
                    }

                    texto.Append(textoItem);

                    larguraLinhaAtual += tamanhoTexto.Width;
                }
            }

            statsRichTextBox.Text = texto.ToString();
        }


        private void cbOrderBy_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            TreeNode node = treeViewArquivos.SelectedNode;

            if (node == null)
                return;

            TreeNode arquivoNode = obterArquivoNode(node);

            if (arquivoNode == null)
                return;

            string caminhoArquivo = arquivoNode.Tag as string;

            if (string.IsNullOrEmpty(caminhoArquivo))
                return;

            try
            {
                XDocument doc = XDocument.Load(caminhoArquivo);

                XElement element = node.Tag as XElement;

                if (element == null)
                    element = doc.Root;

                preencherEstatisticas(element);
            }
            catch
            {
                statsRichTextBox.Text = "Erro ao ler XML.";
            }
        }

        private void btnCopySelection_Click(object sender, EventArgs e)
        {
            copiarNodeSelecionado();
        }

        private void treeViewCopy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                copiarNodeSelecionado();
                e.Handled = true;
            }
        }

        private void copiarNodeSelecionado()
        {
            TreeNode node = null;

            if (treeViewDetalhes.Focused)
                node = treeViewDetalhes.SelectedNode;
            else
                node = treeViewArquivos.SelectedNode;

            if (node == null)
                return;

            StringBuilder texto = new StringBuilder();

            montarTextoNode(node, texto, 0);

            Clipboard.SetText(texto.ToString());
        }

        private void montarTextoNode(TreeNode node, StringBuilder texto, int nivel)
        {
            texto.AppendLine(
                string.Format(
                    "{0}{1}",
                    new string('\t', nivel),
                    node.Text));

            foreach (TreeNode child in node.Nodes)
                montarTextoNode(child, texto, nivel + 1);
        }

        private void btnCopyXmlSelection_Click(object sender, EventArgs e)
        {
            copiarXmlSelecionado();
        }

        private void treeViewCopyXml_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.C)
            {
                copiarXmlSelecionado();
                e.Handled = true;
            }
        }

        private void copiarXmlSelecionado()
        {
            TreeNode node = null;

            if (treeViewDetalhes.Focused)
                node = treeViewDetalhes.SelectedNode;
            else
                node = treeViewArquivos.SelectedNode;

            if (node == null)
                return;

            XElement element = node.Tag as XElement;

            if (element == null)
            {
                TreeNode arquivoNode = obterArquivoNode(node);

                if (arquivoNode == null)
                    return;

                string caminhoArquivo = arquivoNode.Tag as string;

                if (string.IsNullOrEmpty(caminhoArquivo))
                    return;

                try
                {
                    XDocument doc = XDocument.Load(caminhoArquivo);

                    if (doc.Root == null)
                        return;

                    element = doc.Root;
                }
                catch
                {
                    MessageBox.Show("Erro ao copiar XML.");
                    return;
                }
            }

            Clipboard.SetText(element.ToString());
        }


       

    }


}
