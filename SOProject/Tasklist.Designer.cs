
namespace SOProject
{
    partial class Btn_Detener
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
            this.components = new System.ComponentModel.Container();
            this.dgv_Proceso = new System.Windows.Forms.DataGridView();
            this.lbl_Contador = new System.Windows.Forms.Label();
            this.btnActualizar = new FontAwesome.Sharp.IconButton();
            this.btnDetener = new FontAwesome.Sharp.IconButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.NumProceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrioridadProceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemoriaFisica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemoriaVirtual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Proceso)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Proceso
            // 
            this.dgv_Proceso.AllowUserToAddRows = false;
            this.dgv_Proceso.AllowUserToDeleteRows = false;
            this.dgv_Proceso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Proceso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumProceso,
            this.Column1,
            this.PrioridadProceso,
            this.ID,
            this.MemoriaFisica,
            this.MemoriaVirtual});
            this.dgv_Proceso.Location = new System.Drawing.Point(21, 18);
            this.dgv_Proceso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_Proceso.Name = "dgv_Proceso";
            this.dgv_Proceso.ReadOnly = true;
            this.dgv_Proceso.RowHeadersWidth = 59;
            this.dgv_Proceso.RowTemplate.Height = 24;
            this.dgv_Proceso.Size = new System.Drawing.Size(1019, 421);
            this.dgv_Proceso.TabIndex = 19;
            this.dgv_Proceso.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_Proceso_MouseClick);
            // 
            // lbl_Contador
            // 
            this.lbl_Contador.AutoSize = true;
            this.lbl_Contador.Location = new System.Drawing.Point(18, 455);
            this.lbl_Contador.Name = "lbl_Contador";
            this.lbl_Contador.Size = new System.Drawing.Size(100, 16);
            this.lbl_Contador.TabIndex = 20;
            this.lbl_Contador.Text = "Label Contador";
            // 
            // btnActualizar
            // 
            this.btnActualizar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnActualizar.IconColor = System.Drawing.Color.Black;
            this.btnActualizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnActualizar.Location = new System.Drawing.Point(227, 455);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(130, 45);
            this.btnActualizar.TabIndex = 21;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnDetener
            // 
            this.btnDetener.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnDetener.IconColor = System.Drawing.Color.Black;
            this.btnDetener.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDetener.Location = new System.Drawing.Point(417, 455);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(176, 45);
            this.btnDetener.TabIndex = 22;
            this.btnDetener.Text = "Detener Proceso";
            this.btnDetener.UseVisualStyleBackColor = true;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // NumProceso
            // 
            this.NumProceso.HeaderText = "NumProceso";
            this.NumProceso.MinimumWidth = 7;
            this.NumProceso.Name = "NumProceso";
            this.NumProceso.ReadOnly = true;
            this.NumProceso.Width = 145;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Procesos";
            this.Column1.MinimumWidth = 7;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 175;
            // 
            // PrioridadProceso
            // 
            this.PrioridadProceso.HeaderText = "Prioridad Proceso";
            this.PrioridadProceso.MinimumWidth = 7;
            this.PrioridadProceso.Name = "PrioridadProceso";
            this.PrioridadProceso.ReadOnly = true;
            this.PrioridadProceso.Width = 175;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 7;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 145;
            // 
            // MemoriaFisica
            // 
            this.MemoriaFisica.HeaderText = "Memoria Física";
            this.MemoriaFisica.MinimumWidth = 7;
            this.MemoriaFisica.Name = "MemoriaFisica";
            this.MemoriaFisica.ReadOnly = true;
            this.MemoriaFisica.Width = 145;
            // 
            // MemoriaVirtual
            // 
            this.MemoriaVirtual.HeaderText = "Memoria Virtual";
            this.MemoriaVirtual.MinimumWidth = 7;
            this.MemoriaVirtual.Name = "MemoriaVirtual";
            this.MemoriaVirtual.ReadOnly = true;
            this.MemoriaVirtual.Width = 145;
            // 
            // Btn_Detener
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 565);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.lbl_Contador);
            this.Controls.Add(this.dgv_Proceso);
            this.Name = "Btn_Detener";
            this.Text = "tasklist";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Proceso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Proceso;
        private System.Windows.Forms.Label lbl_Contador;
        private FontAwesome.Sharp.IconButton btnActualizar;
        private FontAwesome.Sharp.IconButton btnDetener;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrioridadProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemoriaFisica;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemoriaVirtual;
    }
}