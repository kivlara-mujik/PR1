namespace Lab4PR
{
    partial class FormSendMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSendMail));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1To = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2Subject = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.labelAttachments = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonHTMLBody = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Introduceti datele necesare";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1To
            // 
            this.textBox1To.Location = new System.Drawing.Point(110, 66);
            this.textBox1To.MinimumSize = new System.Drawing.Size(4, 25);
            this.textBox1To.Name = "textBox1To";
            this.textBox1To.Size = new System.Drawing.Size(162, 20);
            this.textBox1To.TabIndex = 1;
            this.textBox1To.Text = "chiricaxander@gmail.com";
            this.textBox1To.TextChanged += new System.EventHandler(this.textBox1To_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(186, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "Trimite";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Catre";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Subiect";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox2Subject
            // 
            this.textBox2Subject.Location = new System.Drawing.Point(110, 97);
            this.textBox2Subject.MinimumSize = new System.Drawing.Size(4, 25);
            this.textBox2Subject.Name = "textBox2Subject";
            this.textBox2Subject.Size = new System.Drawing.Size(162, 20);
            this.textBox2Subject.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mesajul";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(110, 128);
            this.textBoxMessage.MinimumSize = new System.Drawing.Size(4, 25);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(162, 121);
            this.textBoxMessage.TabIndex = 6;
            // 
            // labelAttachments
            // 
            this.labelAttachments.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAttachments.Location = new System.Drawing.Point(12, 252);
            this.labelAttachments.Name = "labelAttachments";
            this.labelAttachments.Size = new System.Drawing.Size(162, 87);
            this.labelAttachments.TabIndex = 8;
            this.labelAttachments.Text = "Ataseaza careva fisiere fisiere la scrisoare";
            this.labelAttachments.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(186, 279);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 32);
            this.button2.TabIndex = 9;
            this.button2.Text = "Ataseaza";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonHTMLBody
            // 
            this.buttonHTMLBody.BackColor = System.Drawing.SystemColors.Control;
            this.buttonHTMLBody.FlatAppearance.BorderSize = 0;
            this.buttonHTMLBody.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonHTMLBody.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHTMLBody.Location = new System.Drawing.Point(217, 224);
            this.buttonHTMLBody.Name = "buttonHTMLBody";
            this.buttonHTMLBody.Size = new System.Drawing.Size(55, 25);
            this.buttonHTMLBody.TabIndex = 10;
            this.buttonHTMLBody.Text = "HTML";
            this.buttonHTMLBody.UseVisualStyleBackColor = false;
            this.buttonHTMLBody.Click += new System.EventHandler(this.buttonHTMLBody_Click);
            // 
            // FormSendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(284, 381);
            this.Controls.Add(this.buttonHTMLBody);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelAttachments);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2Subject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1To);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSendMail";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Chirica Alexandru PR4 ";
            this.Load += new System.EventHandler(this.FormSendMail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1To;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2Subject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Label labelAttachments;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonHTMLBody;
    }
}