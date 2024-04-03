namespace Dziennik_Klasy
{
    partial class Main
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.tbnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvStudentsDiary = new System.Windows.Forms.DataGridView();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentsDiary)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAdd.Location = new System.Drawing.Point(39, 44);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(143, 34);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Dodaj";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.DarkOrange;
            this.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEdit.Location = new System.Drawing.Point(221, 44);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(143, 34);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edytuj";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // tbnDelete
            // 
            this.tbnDelete.BackColor = System.Drawing.Color.DarkRed;
            this.tbnDelete.Location = new System.Drawing.Point(396, 44);
            this.tbnDelete.Name = "tbnDelete";
            this.tbnDelete.Size = new System.Drawing.Size(143, 34);
            this.tbnDelete.TabIndex = 2;
            this.tbnDelete.Text = "Usuń";
            this.tbnDelete.UseVisualStyleBackColor = false;
            this.tbnDelete.Click += new System.EventHandler(this.tbnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnRefresh.Location = new System.Drawing.Point(563, 44);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(143, 34);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Odśwież";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvStudentsDiary
            // 
            this.dgvStudentsDiary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStudentsDiary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudentsDiary.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudentsDiary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentsDiary.Location = new System.Drawing.Point(105, 125);
            this.dgvStudentsDiary.Name = "dgvStudentsDiary";
            this.dgvStudentsDiary.RowHeadersVisible = false;
            this.dgvStudentsDiary.RowHeadersWidth = 62;
            this.dgvStudentsDiary.RowTemplate.Height = 28;
            this.dgvStudentsDiary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudentsDiary.Size = new System.Drawing.Size(1147, 687);
            this.dgvStudentsDiary.TabIndex = 4;
            // 
            // cbGroup
            // 
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.Location = new System.Drawing.Point(807, 48);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(220, 28);
            this.cbGroup.TabIndex = 5;
            this.cbGroup.Text = "wybierz";
            
            this.cbGroup.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1363, 901);
            this.Controls.Add(this.cbGroup);
            this.Controls.Add(this.dgvStudentsDiary);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tbnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "     Dziennik Klasy";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentsDiary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button tbnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvStudentsDiary;
        private System.Windows.Forms.ComboBox cbGroup;
    }
}

