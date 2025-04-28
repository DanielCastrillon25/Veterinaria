namespace GUI
{
    partial class FrmConsultaMascotasPorPropietario
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
            this.lblNombrePropietario = new System.Windows.Forms.Label();
            this.lblCedula = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.dgvMascotas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMascotas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombrePropietario
            // 
            this.lblNombrePropietario.AutoSize = true;
            this.lblNombrePropietario.Location = new System.Drawing.Point(40, 92);
            this.lblNombrePropietario.Name = "lblNombrePropietario";
            this.lblNombrePropietario.Size = new System.Drawing.Size(44, 13);
            this.lblNombrePropietario.TabIndex = 0;
            this.lblNombrePropietario.Text = "Nombre";
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Location = new System.Drawing.Point(40, 121);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(40, 13);
            this.lblCedula.TabIndex = 1;
            this.lblCedula.Text = "Cedula";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(40, 146);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblTelefono.TabIndex = 2;
            this.lblTelefono.Text = "Telefono";
            // 
            // dgvMascotas
            // 
            this.dgvMascotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMascotas.Location = new System.Drawing.Point(43, 202);
            this.dgvMascotas.Name = "dgvMascotas";
            this.dgvMascotas.Size = new System.Drawing.Size(661, 215);
            this.dgvMascotas.TabIndex = 3;
            // 
            // FrmConsultaMascotasPorPropietario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvMascotas);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblCedula);
            this.Controls.Add(this.lblNombrePropietario);
            this.Name = "FrmConsultaMascotasPorPropietario";
            this.Text = "FrmConsultaMascotasPorPropietario";
            this.Load += new System.EventHandler(this.FrmConsultaMascotasPorPropietario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMascotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombrePropietario;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.DataGridView dgvMascotas;
    }
}