namespace GeneradorC
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbServidores = new System.Windows.Forms.ComboBox();
            this.cmbBasesDeDatos = new System.Windows.Forms.ComboBox();
            this.cmbTablas = new System.Windows.Forms.ComboBox();
            this.dgvColumnas = new System.Windows.Forms.DataGridView();
            this.chkSeguridadIntegrada = new System.Windows.Forms.CheckBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.btnGenerarCodigo = new System.Windows.Forms.Button();
            this.txtDirectorioEntrada = new System.Windows.Forms.TextBox();
            this.txtDirectorioSalida = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEsquema = new System.Windows.Forms.TextBox();
            this.btnDirectorioEntrada = new System.Windows.Forms.Button();
            this.btnDirectorioSalida = new System.Windows.Forms.Button();
            this.txtTabla = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtValor2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtValor1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumnas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbServidores
            // 
            this.cmbServidores.FormattingEnabled = true;
            this.cmbServidores.Location = new System.Drawing.Point(109, 14);
            this.cmbServidores.Margin = new System.Windows.Forms.Padding(4);
            this.cmbServidores.Name = "cmbServidores";
            this.cmbServidores.Size = new System.Drawing.Size(248, 24);
            this.cmbServidores.TabIndex = 1;
            this.cmbServidores.SelectedIndexChanged += new System.EventHandler(this.cmbServidores_SelectedIndexChanged);
            this.cmbServidores.Leave += new System.EventHandler(this.cmbServidores_Leave);
            // 
            // cmbBasesDeDatos
            // 
            this.cmbBasesDeDatos.FormattingEnabled = true;
            this.cmbBasesDeDatos.Location = new System.Drawing.Point(109, 67);
            this.cmbBasesDeDatos.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBasesDeDatos.Name = "cmbBasesDeDatos";
            this.cmbBasesDeDatos.Size = new System.Drawing.Size(248, 24);
            this.cmbBasesDeDatos.TabIndex = 2;
            this.cmbBasesDeDatos.SelectedIndexChanged += new System.EventHandler(this.cmbBasesDeDatos_SelectedIndexChanged);
            // 
            // cmbTablas
            // 
            this.cmbTablas.FormattingEnabled = true;
            this.cmbTablas.Location = new System.Drawing.Point(109, 105);
            this.cmbTablas.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTablas.Name = "cmbTablas";
            this.cmbTablas.Size = new System.Drawing.Size(248, 24);
            this.cmbTablas.TabIndex = 3;
            this.cmbTablas.SelectedIndexChanged += new System.EventHandler(this.cmbTablas_SelectedIndexChanged);
            // 
            // dgvColumnas
            // 
            this.dgvColumnas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvColumnas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumnas.Location = new System.Drawing.Point(17, 260);
            this.dgvColumnas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvColumnas.Name = "dgvColumnas";
            this.dgvColumnas.RowHeadersWidth = 51;
            this.dgvColumnas.Size = new System.Drawing.Size(1145, 379);
            this.dgvColumnas.TabIndex = 4;
            // 
            // chkSeguridadIntegrada
            // 
            this.chkSeguridadIntegrada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSeguridadIntegrada.AutoSize = true;
            this.chkSeguridadIntegrada.Checked = true;
            this.chkSeguridadIntegrada.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSeguridadIntegrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSeguridadIntegrada.Location = new System.Drawing.Point(421, 15);
            this.chkSeguridadIntegrada.Margin = new System.Windows.Forms.Padding(4);
            this.chkSeguridadIntegrada.Name = "chkSeguridadIntegrada";
            this.chkSeguridadIntegrada.Size = new System.Drawing.Size(178, 21);
            this.chkSeguridadIntegrada.TabIndex = 5;
            this.chkSeguridadIntegrada.Text = "Seguridad Integrada";
            this.chkSeguridadIntegrada.UseVisualStyleBackColor = true;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtUsuario.Location = new System.Drawing.Point(612, 13);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(207, 22);
            this.txtUsuario.TabIndex = 6;
            this.txtUsuario.Text = "sa";
            // 
            // txtPwd
            // 
            this.txtPwd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPwd.Location = new System.Drawing.Point(840, 13);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(4);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(207, 22);
            this.txtPwd.TabIndex = 7;
            this.txtPwd.Text = "";
            // 
            // btnGenerarCodigo
            // 
            this.btnGenerarCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarCodigo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarCodigo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnGenerarCodigo.Location = new System.Drawing.Point(928, 647);
            this.btnGenerarCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerarCodigo.Name = "btnGenerarCodigo";
            this.btnGenerarCodigo.Size = new System.Drawing.Size(235, 39);
            this.btnGenerarCodigo.TabIndex = 0;
            this.btnGenerarCodigo.Text = "GENERAR CODIGO";
            this.btnGenerarCodigo.UseVisualStyleBackColor = true;
            this.btnGenerarCodigo.Click += new System.EventHandler(this.btnGenerarCodigo_Click);
            // 
            // txtDirectorioEntrada
            // 
            this.txtDirectorioEntrada.Location = new System.Drawing.Point(649, 67);
            this.txtDirectorioEntrada.Margin = new System.Windows.Forms.Padding(4);
            this.txtDirectorioEntrada.Name = "txtDirectorioEntrada";
            this.txtDirectorioEntrada.Size = new System.Drawing.Size(412, 22);
            this.txtDirectorioEntrada.TabIndex = 8;
            this.txtDirectorioEntrada.Text = "C:\\Generator\\entrada\\";
            // 
            // txtDirectorioSalida
            // 
            this.txtDirectorioSalida.Location = new System.Drawing.Point(649, 107);
            this.txtDirectorioSalida.Margin = new System.Windows.Forms.Padding(4);
            this.txtDirectorioSalida.Multiline = true;
            this.txtDirectorioSalida.Name = "txtDirectorioSalida";
            this.txtDirectorioSalida.Size = new System.Drawing.Size(412, 24);
            this.txtDirectorioSalida.TabIndex = 9;
            this.txtDirectorioSalida.Text = "C:\\Generator\\salida\\";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(375, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ruta de entrada de archivos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(387, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ruta de salida de archivos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Servidor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 67);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "BD:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 105);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tabla:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 58);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 18);
            this.label6.TabIndex = 16;
            this.label6.Text = "Esquema:";
            // 
            // txtEsquema
            // 
            this.txtEsquema.Location = new System.Drawing.Point(111, 54);
            this.txtEsquema.Margin = new System.Windows.Forms.Padding(4);
            this.txtEsquema.Name = "txtEsquema";
            this.txtEsquema.Size = new System.Drawing.Size(248, 22);
            this.txtEsquema.TabIndex = 17;
            // 
            // btnDirectorioEntrada
            // 
            this.btnDirectorioEntrada.Location = new System.Drawing.Point(1071, 63);
            this.btnDirectorioEntrada.Margin = new System.Windows.Forms.Padding(4);
            this.btnDirectorioEntrada.Name = "btnDirectorioEntrada";
            this.btnDirectorioEntrada.Size = new System.Drawing.Size(45, 28);
            this.btnDirectorioEntrada.TabIndex = 18;
            this.btnDirectorioEntrada.Text = "...";
            this.btnDirectorioEntrada.UseVisualStyleBackColor = true;
            this.btnDirectorioEntrada.Click += new System.EventHandler(this.btnDirectorioEntrada_Click);
            // 
            // btnDirectorioSalida
            // 
            this.btnDirectorioSalida.Location = new System.Drawing.Point(1071, 105);
            this.btnDirectorioSalida.Margin = new System.Windows.Forms.Padding(4);
            this.btnDirectorioSalida.Name = "btnDirectorioSalida";
            this.btnDirectorioSalida.Size = new System.Drawing.Size(45, 28);
            this.btnDirectorioSalida.TabIndex = 19;
            this.btnDirectorioSalida.Text = "...";
            this.btnDirectorioSalida.UseVisualStyleBackColor = true;
            this.btnDirectorioSalida.Click += new System.EventHandler(this.btnDirectorioSalida_Click);
            // 
            // txtTabla
            // 
            this.txtTabla.Location = new System.Drawing.Point(111, 26);
            this.txtTabla.Margin = new System.Windows.Forms.Padding(4);
            this.txtTabla.Name = "txtTabla";
            this.txtTabla.Size = new System.Drawing.Size(457, 22);
            this.txtTabla.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 30);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 18);
            this.label7.TabIndex = 20;
            this.label7.Text = "Tabla:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtValor2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtValor1);
            this.groupBox1.Controls.Add(this.txtTabla);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtEsquema);
            this.groupBox1.Location = new System.Drawing.Point(20, 152);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1143, 95);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Campos para reemplazar";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(625, 62);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 18);
            this.label9.TabIndex = 24;
            this.label9.Text = "valor2:";
            // 
            // txtValor2
            // 
            this.txtValor2.Location = new System.Drawing.Point(728, 58);
            this.txtValor2.Margin = new System.Windows.Forms.Padding(4);
            this.txtValor2.Name = "txtValor2";
            this.txtValor2.Size = new System.Drawing.Size(248, 22);
            this.txtValor2.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(625, 27);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 18);
            this.label8.TabIndex = 22;
            this.label8.Text = "valor1:";
            // 
            // txtValor1
            // 
            this.txtValor1.Location = new System.Drawing.Point(728, 23);
            this.txtValor1.Margin = new System.Windows.Forms.Padding(4);
            this.txtValor1.Name = "txtValor1";
            this.txtValor1.Size = new System.Drawing.Size(248, 22);
            this.txtValor1.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 690);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDirectorioSalida);
            this.Controls.Add(this.btnDirectorioEntrada);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDirectorioSalida);
            this.Controls.Add(this.txtDirectorioEntrada);
            this.Controls.Add(this.btnGenerarCodigo);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.chkSeguridadIntegrada);
            this.Controls.Add(this.dgvColumnas);
            this.Controls.Add(this.cmbTablas);
            this.Controls.Add(this.cmbBasesDeDatos);
            this.Controls.Add(this.cmbServidores);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Generador C | FFH | Presione F1 para lista de comandos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumnas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbServidores;
        private System.Windows.Forms.ComboBox cmbBasesDeDatos;
        private System.Windows.Forms.ComboBox cmbTablas;
        private System.Windows.Forms.DataGridView dgvColumnas;
        private System.Windows.Forms.CheckBox chkSeguridadIntegrada;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button btnGenerarCodigo;
        private System.Windows.Forms.TextBox txtDirectorioEntrada;
        private System.Windows.Forms.TextBox txtDirectorioSalida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEsquema;
        private System.Windows.Forms.Button btnDirectorioEntrada;
        private System.Windows.Forms.Button btnDirectorioSalida;
        private System.Windows.Forms.TextBox txtTabla;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtValor1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtValor2;
    }
}

