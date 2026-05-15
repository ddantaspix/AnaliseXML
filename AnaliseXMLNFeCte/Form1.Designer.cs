namespace AnaliseXMLNFeCte
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.addfolder = new System.Windows.Forms.Button();
            this.treeViewArquivos = new System.Windows.Forms.TreeView();
            this.chkShowValues = new System.Windows.Forms.CheckBox();
            this.treeViewDetalhes = new System.Windows.Forms.TreeView();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.cbOrderBy = new System.Windows.Forms.ComboBox();
            this.btnCopySelection = new System.Windows.Forms.Button();
            this.btnCopyXmlSelection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // addfolder
            // 
            this.addfolder.Location = new System.Drawing.Point(22, 12);
            this.addfolder.Name = "addfolder";
            this.addfolder.Size = new System.Drawing.Size(88, 23);
            this.addfolder.TabIndex = 0;
            this.addfolder.Text = "Adicionar pasta";
            this.addfolder.UseVisualStyleBackColor = true;
            this.addfolder.Click += new System.EventHandler(this.addfolder_Click);
            // 
            // treeViewArquivos
            // 
            this.treeViewArquivos.Location = new System.Drawing.Point(22, 64);
            this.treeViewArquivos.Name = "treeViewArquivos";
            this.treeViewArquivos.Size = new System.Drawing.Size(359, 374);
            this.treeViewArquivos.TabIndex = 1;
            // 
            // chkShowValues
            // 
            this.chkShowValues.AutoSize = true;
            this.chkShowValues.Checked = true;
            this.chkShowValues.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowValues.Location = new System.Drawing.Point(22, 41);
            this.chkShowValues.Name = "chkShowValues";
            this.chkShowValues.Size = new System.Drawing.Size(88, 17);
            this.chkShowValues.TabIndex = 2;
            this.chkShowValues.Text = "Show Values";
            this.chkShowValues.UseVisualStyleBackColor = true;
            // 
            // treeViewDetalhes
            // 
            this.treeViewDetalhes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewDetalhes.Location = new System.Drawing.Point(387, 64);
            this.treeViewDetalhes.Name = "treeViewDetalhes";
            this.treeViewDetalhes.Size = new System.Drawing.Size(468, 374);
            this.treeViewDetalhes.TabIndex = 3;
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(116, 12);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(112, 23);
            this.btnDeleteSelected.TabIndex = 4;
            this.btnDeleteSelected.Text = "Deletar Selecionado";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // statsRichTextBox
            // 
            this.statsRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statsRichTextBox.Location = new System.Drawing.Point(22, 444);
            this.statsRichTextBox.Name = "statsRichTextBox";
            this.statsRichTextBox.Size = new System.Drawing.Size(833, 96);
            this.statsRichTextBox.TabIndex = 7;
            this.statsRichTextBox.Text = "";
            // 
            // cbOrderBy
            // 
            this.cbOrderBy.FormattingEnabled = true;
            this.cbOrderBy.Location = new System.Drawing.Point(22, 546);
            this.cbOrderBy.Name = "cbOrderBy";
            this.cbOrderBy.Size = new System.Drawing.Size(185, 21);
            this.cbOrderBy.TabIndex = 8;
            this.cbOrderBy.Text = "Order by";
            // 
            // btnCopySelection
            // 
            this.btnCopySelection.Location = new System.Drawing.Point(234, 12);
            this.btnCopySelection.Name = "btnCopySelection";
            this.btnCopySelection.Size = new System.Drawing.Size(94, 23);
            this.btnCopySelection.TabIndex = 9;
            this.btnCopySelection.Text = "Copiar Seleção";
            this.btnCopySelection.UseVisualStyleBackColor = true;
            // 
            // btnCopyXmlSelection
            // 
            this.btnCopyXmlSelection.Location = new System.Drawing.Point(335, 13);
            this.btnCopyXmlSelection.Name = "btnCopyXmlSelection";
            this.btnCopyXmlSelection.Size = new System.Drawing.Size(127, 23);
            this.btnCopyXmlSelection.TabIndex = 10;
            this.btnCopyXmlSelection.Text = " XML - Copiar Seleção";
            this.btnCopyXmlSelection.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 574);
            this.Controls.Add(this.btnCopyXmlSelection);
            this.Controls.Add(this.btnCopySelection);
            this.Controls.Add(this.cbOrderBy);
            this.Controls.Add(this.statsRichTextBox);
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.treeViewDetalhes);
            this.Controls.Add(this.chkShowValues);
            this.Controls.Add(this.treeViewArquivos);
            this.Controls.Add(this.addfolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Analise de XML - ddantas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button addfolder;
        private System.Windows.Forms.TreeView treeViewArquivos;
        private System.Windows.Forms.CheckBox chkShowValues;
        private System.Windows.Forms.TreeView treeViewDetalhes;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.RichTextBox statsRichTextBox;
        private System.Windows.Forms.ComboBox cbOrderBy;
        private System.Windows.Forms.Button btnCopySelection;
        private System.Windows.Forms.Button btnCopyXmlSelection;
    }
}

