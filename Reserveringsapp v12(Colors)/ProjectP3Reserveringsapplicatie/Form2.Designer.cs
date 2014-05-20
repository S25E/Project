namespace ProjectP3Reserveringsapplicatie
{
    partial class Form2
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
            this.listBoxOverzicht = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonWijzig = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxHBWoonplaats = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxHBPostcode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxHBAdres = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxHBEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxHBTel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxHBReserveringsnummer = new System.Windows.Forms.TextBox();
            this.textBoxHBNaam = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbBBNaam = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxBBTel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonVerwijder = new System.Windows.Forms.Button();
            this.buttonPlaats = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxOverzicht
            // 
            this.listBoxOverzicht.FormattingEnabled = true;
            this.listBoxOverzicht.Location = new System.Drawing.Point(348, 53);
            this.listBoxOverzicht.Name = "listBoxOverzicht";
            this.listBoxOverzicht.Size = new System.Drawing.Size(600, 498);
            this.listBoxOverzicht.TabIndex = 0;
            this.listBoxOverzicht.SelectedIndexChanged += new System.EventHandler(this.listBoxOverzicht_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(348, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reserveringen:";
            // 
            // buttonWijzig
            // 
            this.buttonWijzig.Location = new System.Drawing.Point(348, 626);
            this.buttonWijzig.Name = "buttonWijzig";
            this.buttonWijzig.Size = new System.Drawing.Size(143, 41);
            this.buttonWijzig.TabIndex = 12;
            this.buttonWijzig.Text = "Reservering wijzigen";
            this.buttonWijzig.UseVisualStyleBackColor = true;
            this.buttonWijzig.Click += new System.EventHandler(this.buttonWijzig_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Naam:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxHBWoonplaats);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.textBoxHBPostcode);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBoxHBAdres);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBoxHBEmail);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxHBTel);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxHBReserveringsnummer);
            this.groupBox1.Controls.Add(this.textBoxHBNaam);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 214);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hoofdboeker";
            // 
            // textBoxHBWoonplaats
            // 
            this.textBoxHBWoonplaats.Location = new System.Drawing.Point(127, 96);
            this.textBoxHBWoonplaats.Name = "textBoxHBWoonplaats";
            this.textBoxHBWoonplaats.ReadOnly = true;
            this.textBoxHBWoonplaats.Size = new System.Drawing.Size(132, 20);
            this.textBoxHBWoonplaats.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Woonplaats:";
            // 
            // textBoxHBPostcode
            // 
            this.textBoxHBPostcode.Location = new System.Drawing.Point(127, 70);
            this.textBoxHBPostcode.Name = "textBoxHBPostcode";
            this.textBoxHBPostcode.ReadOnly = true;
            this.textBoxHBPostcode.Size = new System.Drawing.Size(132, 20);
            this.textBoxHBPostcode.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Postcode:";
            // 
            // textBoxHBAdres
            // 
            this.textBoxHBAdres.Location = new System.Drawing.Point(127, 44);
            this.textBoxHBAdres.Name = "textBoxHBAdres";
            this.textBoxHBAdres.ReadOnly = true;
            this.textBoxHBAdres.Size = new System.Drawing.Size(132, 20);
            this.textBoxHBAdres.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Adres:";
            // 
            // textBoxHBEmail
            // 
            this.textBoxHBEmail.Location = new System.Drawing.Point(127, 122);
            this.textBoxHBEmail.Name = "textBoxHBEmail";
            this.textBoxHBEmail.ReadOnly = true;
            this.textBoxHBEmail.Size = new System.Drawing.Size(132, 20);
            this.textBoxHBEmail.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "E-mail:";
            // 
            // textBoxHBTel
            // 
            this.textBoxHBTel.Location = new System.Drawing.Point(127, 148);
            this.textBoxHBTel.Name = "textBoxHBTel";
            this.textBoxHBTel.ReadOnly = true;
            this.textBoxHBTel.Size = new System.Drawing.Size(132, 20);
            this.textBoxHBTel.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Telefoonnummer:";
            // 
            // textBoxHBReserveringsnummer
            // 
            this.textBoxHBReserveringsnummer.Location = new System.Drawing.Point(127, 174);
            this.textBoxHBReserveringsnummer.Name = "textBoxHBReserveringsnummer";
            this.textBoxHBReserveringsnummer.ReadOnly = true;
            this.textBoxHBReserveringsnummer.Size = new System.Drawing.Size(132, 20);
            this.textBoxHBReserveringsnummer.TabIndex = 16;
            // 
            // textBoxHBNaam
            // 
            this.textBoxHBNaam.Location = new System.Drawing.Point(127, 18);
            this.textBoxHBNaam.Name = "textBoxHBNaam";
            this.textBoxHBNaam.ReadOnly = true;
            this.textBoxHBNaam.Size = new System.Drawing.Size(132, 20);
            this.textBoxHBNaam.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Reserveringsnummer:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Naam:";
            // 
            // cbBBNaam
            // 
            this.cbBBNaam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBBNaam.FormattingEnabled = true;
            this.cbBBNaam.Location = new System.Drawing.Point(127, 26);
            this.cbBBNaam.Name = "cbBBNaam";
            this.cbBBNaam.Size = new System.Drawing.Size(132, 21);
            this.cbBBNaam.TabIndex = 16;
            this.cbBBNaam.SelectedIndexChanged += new System.EventHandler(this.cbBBNaam_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxBBTel);
            this.groupBox2.Controls.Add(this.cbBBNaam);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 285);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 94);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bijboeker";
            // 
            // textBoxBBTel
            // 
            this.textBoxBBTel.Location = new System.Drawing.Point(127, 57);
            this.textBoxBBTel.Name = "textBoxBBTel";
            this.textBoxBBTel.ReadOnly = true;
            this.textBoxBBTel.Size = new System.Drawing.Size(132, 20);
            this.textBoxBBTel.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Telefoonnummer:";
            // 
            // buttonVerwijder
            // 
            this.buttonVerwijder.Location = new System.Drawing.Point(12, 626);
            this.buttonVerwijder.Name = "buttonVerwijder";
            this.buttonVerwijder.Size = new System.Drawing.Size(143, 41);
            this.buttonVerwijder.TabIndex = 18;
            this.buttonVerwijder.Text = "Reservering verwijderen";
            this.buttonVerwijder.UseVisualStyleBackColor = true;
            this.buttonVerwijder.Click += new System.EventHandler(this.buttonVerwijder_Click);
            // 
            // buttonPlaats
            // 
            this.buttonPlaats.Location = new System.Drawing.Point(805, 626);
            this.buttonPlaats.Name = "buttonPlaats";
            this.buttonPlaats.Size = new System.Drawing.Size(143, 41);
            this.buttonPlaats.TabIndex = 19;
            this.buttonPlaats.Text = "Reservering plaatsen";
            this.buttonPlaats.UseVisualStyleBackColor = true;
            this.buttonPlaats.Click += new System.EventHandler(this.buttonPlaats_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 679);
            this.Controls.Add(this.buttonPlaats);
            this.Controls.Add(this.buttonVerwijder);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonWijzig);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxOverzicht);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Overzicht Reserveringen";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxOverzicht;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonWijzig;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxHBReserveringsnummer;
        private System.Windows.Forms.TextBox textBoxHBNaam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbBBNaam;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxHBEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxHBTel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxBBTel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonVerwijder;
        private System.Windows.Forms.Button buttonPlaats;
        private System.Windows.Forms.TextBox textBoxHBWoonplaats;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxHBPostcode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxHBAdres;
        private System.Windows.Forms.Label label9;
    }
}