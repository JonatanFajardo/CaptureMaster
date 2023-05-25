using CaptureMaster.Dtos;
using CaptureMaster.Services;
using System.Diagnostics;

namespace CaptureMaster.Forms
{
    public partial class Principal : Form
    {
        public List<ImageProperties> _imagesPropertie = new List<ImageProperties>();
        public Principal()
        {
            InitializeComponent();
            // Configurar las columnas del DataGridView
            //dataGridView1.Columns.Add("Nombre", "Nombre");
            //dataGridView1.Columns.Add("FechaCaptura", "Fecha de Captura");
            //dataGridView1.Columns.Add("Direccion", "Dirección");

        }
        private string sourceFolderPath;
        private string destinationFolderPath;

        private void button1_Click(object sender, EventArgs e)
        {
            // Crear una instancia del FolderBrowserDialog
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            // Mostrar el cuadro de diálogo y obtener el resultado
            DialogResult result = folderBrowserDialog.ShowDialog();

            // Verificar si el usuario seleccionó una carpeta
            if (result == DialogResult.OK)
            {
                // Obtener la ruta de la carpeta seleccionada
                string selectedFolderPath = folderBrowserDialog.SelectedPath;
                txtSeleccionarOrigen.Text = selectedFolderPath;
                sourceFolderPath = selectedFolderPath;

            }

        }

        private async void btnGenerar_Click(object sender, EventArgs e)
        {
            if (destinationFolderPath == null && sourceFolderPath == null)
            {
                MessageBox.Show("Ocurrio un problema con las rutas.");
                return;
            }

            // Mostrar la barra de progreso
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            dataGridView1.Columns.Add("Direccion", "Dirección");
            dataGridView1.Columns.Add("FechaCaptura", "Fecha de Captura");
            dataGridView1.Columns.Add("Nombre", "Nombre");

            ImageProcessorService processor = new ImageProcessorService();
            await processor.GroupCopyImagesByDate(sourceFolderPath, destinationFolderPath, progressBar1);
            _imagesPropertie = processor.imagesPropertie;
            dataGridView1.DataSource = _imagesPropertie;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            MessageBox.Show("Imágenes copiadas correctamente.");
        }

        private void btnSeleccionarDestino_Click(object sender, EventArgs e)
        {
            // Crear una instancia del FolderBrowserDialog
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            // Mostrar el cuadro de diálogo y obtener el resultado
            DialogResult result = folderBrowserDialog.ShowDialog();

            // Verificar si el usuario seleccionó una carpeta
            if (result == DialogResult.OK)
            {
                // Obtener la ruta de la carpeta seleccionada
                string selectedFolderPath = folderBrowserDialog.SelectedPath;
                txtSeleccionarDestino.Text = selectedFolderPath;
                destinationFolderPath = selectedFolderPath;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Ruta de la imagen
            string imagePath = @"C:Users/Jonna/Pictures/Trabajos Soldadura-51xY+k27mhL._AC_SL1500_ - copia.jpg";

            // Ruta de la imagen

            try
            {
                // Comando para cambiar etiquetas utilizando ExifTool
                string exifToolCommand = $"-Keywords='etiqueta1,etiqueta2,etiqueta3' \"{imagePath}\"";

                // Ejecuta ExifTool como proceso externo
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "exiftool"; // Asegúrate de tener ExifTool instalado y disponible en el PATH del sistema
                startInfo.Arguments = exifToolCommand;
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;

                using (Process process = Process.Start(startInfo))
                {
                    process.WaitForExit();
                    Console.WriteLine("Etiquetas cambiadas correctamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cambiar etiquetas: " + ex.Message);
            }


        }
    }
}
