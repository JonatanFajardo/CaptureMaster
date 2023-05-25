using CaptureMaster;
namespace CaptureMaster.Forms
{
    partial class Principal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            txtSeleccionarOrigen = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtSeleccionarDestino = new TextBox();
            btnSeleccionarDestino = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            btnGenerar = new Button();
            dataGridView1 = new DataGridView();
            progressBar1 = new ProgressBar();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(478, 46);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Seleccionar carpeta";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtSeleccionarOrigen
            // 
            txtSeleccionarOrigen.Location = new Point(37, 47);
            txtSeleccionarOrigen.Name = "txtSeleccionarOrigen";
            txtSeleccionarOrigen.Size = new Size(435, 23);
            txtSeleccionarOrigen.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 23);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 2;
            label1.Text = "Carpeta Origen";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 88);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 5;
            label2.Text = "Carpeta Destino";
            // 
            // txtSeleccionarDestino
            // 
            txtSeleccionarDestino.Location = new Point(37, 112);
            txtSeleccionarDestino.Name = "txtSeleccionarDestino";
            txtSeleccionarDestino.Size = new Size(435, 23);
            txtSeleccionarDestino.TabIndex = 4;
            // 
            // btnSeleccionarDestino
            // 
            btnSeleccionarDestino.Location = new Point(478, 111);
            btnSeleccionarDestino.Name = "btnSeleccionarDestino";
            btnSeleccionarDestino.Size = new Size(75, 23);
            btnSeleccionarDestino.TabIndex = 3;
            btnSeleccionarDestino.Text = "Seleccionar carpeta";
            btnSeleccionarDestino.UseVisualStyleBackColor = true;
            btnSeleccionarDestino.Click += btnSeleccionarDestino_Click;
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(405, 159);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(148, 23);
            btnGenerar.TabIndex = 6;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(37, 202);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(516, 265);
            dataGridView1.TabIndex = 7;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(172, 80);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(240, 23);
            progressBar1.TabIndex = 8;
            // 
            // button2
            // 
            button2.Location = new Point(256, 150);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 9;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(590, 500);
            Controls.Add(button2);
            Controls.Add(progressBar1);
            Controls.Add(dataGridView1);
            Controls.Add(btnGenerar);
            Controls.Add(label2);
            Controls.Add(txtSeleccionarDestino);
            Controls.Add(btnSeleccionarDestino);
            Controls.Add(label1);
            Controls.Add(txtSeleccionarOrigen);
            Controls.Add(button1);
            Name = "Principal";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox txtSeleccionarOrigen;
        private Label label1;
        private Label label2;
        private TextBox txtSeleccionarDestino;
        private Button btnSeleccionarDestino;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button btnGenerar;
        private DataGridView dataGridView1;
        private ProgressBar progressBar1;
        private Button button2;
    }
}
