namespace GUI
{
    partial class FrmMascota
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
            this.lstMascotas = new System.Windows.Forms.ListBox();
            this.cbPropietarios = new System.Windows.Forms.ComboBox();
            this.cbRazas = new System.Windows.Forms.ComboBox();
            this.cbEspecies = new System.Windows.Forms.ComboBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstMascotas
            // 
            this.lstMascotas.FormattingEnabled = true;
            this.lstMascotas.Location = new System.Drawing.Point(50, 141);
            this.lstMascotas.Name = "lstMascotas";
            this.lstMascotas.Size = new System.Drawing.Size(460, 342);
            this.lstMascotas.TabIndex = 0;
            // 
            // cbPropietarios
            // 
            this.cbPropietarios.FormattingEnabled = true;
            this.cbPropietarios.Location = new System.Drawing.Point(50, 74);
            this.cbPropietarios.Name = "cbPropietarios";
            this.cbPropietarios.Size = new System.Drawing.Size(121, 21);
            this.cbPropietarios.TabIndex = 1;
            this.cbPropietarios.Text = "Propietarios";
            // 
            // cbRazas
            // 
            this.cbRazas.FormattingEnabled = true;
            this.cbRazas.Location = new System.Drawing.Point(356, 74);
            this.cbRazas.Name = "cbRazas";
            this.cbRazas.Size = new System.Drawing.Size(121, 21);
            this.cbRazas.TabIndex = 2;
            this.cbRazas.Text = "Raza";
            // 
            // cbEspecies
            // 
            this.cbEspecies.FormattingEnabled = true;
            this.cbEspecies.Location = new System.Drawing.Point(202, 74);
            this.cbEspecies.Name = "cbEspecies";
            this.cbEspecies.Size = new System.Drawing.Size(121, 21);
            this.cbEspecies.TabIndex = 3;
            this.cbEspecies.Text = "Especie";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(66, 31);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 4;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(249, 31);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(410, 31);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(100, 20);
            this.txtEdad.TabIndex = 6;
            this.txtEdad.TextChanged += new System.EventHandler(this.txtEdad_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Edad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nombre";
            // 
            // FrmMascota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 612);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEdad);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.cbEspecies);
            this.Controls.Add(this.cbRazas);
            this.Controls.Add(this.cbPropietarios);
            this.Controls.Add(this.lstMascotas);
            this.Name = "FrmMascota";
            this.Text = "FrmMascota";
            this.Load += new System.EventHandler(this.FrmMascota_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstMascotas;
        private System.Windows.Forms.ComboBox cbPropietarios;
        private System.Windows.Forms.ComboBox cbRazas;
        private System.Windows.Forms.ComboBox cbEspecies;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}