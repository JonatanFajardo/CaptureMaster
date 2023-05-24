using CaptureMaster.Dtos;
using System.Drawing.Imaging;
using System.Text;

namespace CaptureMaster.Helpers
{
    public class ImageProcessor
    {
        public List<ImageProperties> imagesPropertie = new List<ImageProperties>();
        int totalImages;
        int currentImageIndex = 0;

        public async Task GroupCopyImagesByDate(string sourceFolderPath, string destinationFolderPath, ProgressBar progressBar)
        {
            try
            {
                // Obtener la lista de archivos de imagen en la carpeta de origen
                string[] imageFiles = GetImageFiles(sourceFolderPath);

                // Obtener las propiedades de las imágenes de forma asíncrona
                List<ImageProperties> images = await Task.Run(() => GetImagePropertiesAsync(imageFiles, destinationFolderPath));
                imagesPropertie = images;

                // Agrupar las imágenes por fecha
                var groupedImages = images.GroupBy(i => new { i.FechaCaptura.Year, i.FechaCaptura.Month, i.FechaCaptura.Day });

                // Obtener el número total de imágenes para el cálculo del progreso
                totalImages = images.Count;
                progressBar.Maximum = totalImages;

                // Iterar sobre cada grupo de imágenes
                foreach (var group in groupedImages)
                {
                    DateTime groupDate = new DateTime(group.Key.Year, group.Key.Month, group.Key.Day);

                    // Obtener el nombre de la carpeta de sesión
                    string sessionFolderName = GetSessionFolderName(group.Key);

                    // Crear la carpeta de sesión en la carpeta de destino de forma asíncrona
                    string sessionFolderPath = await CreateFolderNoExistsAsync(destinationFolderPath, sessionFolderName);

                    // Copiar cada imagen del grupo a la carpeta de sesión de forma asíncrona
                    foreach (var image in group)
                    {
                        await CopyImageAsync(image.Direccion, sessionFolderPath);

                        // Actualizar la barra de progreso
                        currentImageIndex++;
                        int progressPercentage = (int)((float)currentImageIndex / totalImages * 100);
                        progressBar.Value = progressPercentage;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción de acuerdo a tus necesidades
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private async Task<List<ImageProperties>> GetImagePropertiesAsync(string[] imageFiles, string destinationFolderPath)
        {
            List<ImageProperties> images = new List<ImageProperties>();

            // Obtener las propiedades de cada imagen de forma asíncrona
            foreach (string imagePath in imageFiles)
            {
                DateTime creationDate = File.GetCreationTime(imagePath);

                using (Image image = Image.FromFile(imagePath))
                {
                    try
                    {
                        // Obtener la fecha de captura de la imagen de forma asíncrona
                        string dateTakenString = await GetDateTakenStringAsync(image);
                        DateTime fecha = ParseDateTakenString(dateTakenString);

                        // Agregar las propiedades de la imagen a la lista
                        images.Add(new ImageProperties()
                        {
                            Nombre = Path.GetFileName(imagePath),
                            Direccion = imagePath,
                            FechaCaptura = fecha
                        });
                    }
                    catch (Exception)
                    {
                        // Si ocurre un error al obtener las propiedades de la imagen, continuar con la siguiente
                        await CreateFolderNoExistsAsync(destinationFolderPath, "Unordered images");
                        await CopyImageAsync(imagePath, Path.Combine(destinationFolderPath, "Unordered images"));

                        //continue;
                    }
                }
            }

            return images;
        }

        private async Task<string> GetDateTakenStringAsync(Image image)
        {
            // Obtener la cadena que representa la fecha de captura de la imagen de forma asíncrona
            PropertyItem propItem = image.GetPropertyItem((int)EnumExifTag.DateTimeOriginal);
            byte[] propItemValue = propItem.Value;
            return await Task.Run(() => Encoding.UTF8.GetString(propItemValue).Trim().TrimEnd('\0'));
        }

        private async Task<string> CreateFolderNoExistsAsync(string DestinationFolderPath, string FolderName)
        {
            // Crear la carpeta de sesión en la carpeta de destino de forma asíncrona
            string sessionFolderPath = Path.Combine(DestinationFolderPath, FolderName);
            if (!Directory.Exists(sessionFolderPath))
            {
                await Task.Run(() => Directory.CreateDirectory(sessionFolderPath));
            }
            return sessionFolderPath;
        }

        private async Task CopyImageAsync(string sourceFilePath, string destinationFolderPath)
        {
            // Copiar una imagen desde la carpeta de origen a la carpeta de destino de forma asíncrona
            string destinationFilePath = Path.Combine(destinationFolderPath, Path.GetFileName(sourceFilePath));
            await Task.Run(() => File.Copy(sourceFilePath, destinationFilePath));
        }


        private string GetSessionFolderName(dynamic key)
        {
            // Obtener el nombre de la carpeta de sesión basado en la fecha del grupo de imágenes
            return $"{key.Day}_{key.Month}_{key.Year}";
        }
        private DateTime ParseDateTakenString(string dateTakenString)
        {
            string formato = "yyyy:MM:dd HH:mm:ss";
            DateTime fecha;

            if (DateTime.TryParseExact(dateTakenString, formato, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fecha))
            {
                return fecha;
            }

            // Si no se puede obtener la fecha de la imagen, lanzar una excepción
            throw new Exception("No se puede obtener la fecha de la imagen.");
        }
        private string[] GetImageFiles(string sourceFolderPath)
        {
            // Obtener todos los archivos de imagen en la carpeta de origen con la extensión "*.jpg"
            return Directory.GetFiles(sourceFolderPath);
        }

        public enum EnumExifTag
        {
            ImageWidth = 256,
            ImageHeight = 257,
            DateTimeOriginal = 36867,
            Make = 271,
            Model = 272,
            ExposureTime = 33434,
            FNumber = 33437,
            ExposureProgram = 34850,
            ISOSpeedRatings = 34855,
            FocalLength = 37386,
            GPSLatitude = 2,
            GPSLongitude = 4,
            GPSAltitude = 6
        }

    }
}
