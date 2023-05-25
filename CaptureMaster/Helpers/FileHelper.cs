public static class FileHelper
{
    /// <summary>
    /// Crea un nuevo archivo en la ruta especificada con el contenido dado de forma asíncrona.
    /// </summary>
    /// <param name="path">Ruta del archivo a crear.</param>
    /// <param name="content">Contenido del archivo.</param>
    public static async Task CreateFileAsync(string path, string content)
    {
        try
        {
            if (File.Exists(path))
            {
                Console.WriteLine("El archivo ya existe. No se puede crear.");
                return;
            }

            using (StreamWriter writer = File.CreateText(path))
            {
                await writer.WriteAsync(content);
            }

            Console.WriteLine("Archivo creado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al crear el archivo: " + ex.Message);
        }
    }

    /// <summary>
    /// Sobrescribe el contenido de un archivo existente en la ruta especificada con el nuevo contenido dado de forma asíncrona.
    /// </summary>
    /// <param name="path">Ruta del archivo a sobrescribir.</param>
    /// <param name="content">Nuevo contenido del archivo.</param>
    public static async Task OverwriteFileAsync(string path, string content)
    {
        try
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("El archivo no existe. No se puede sobrescribir.");
                return;
            }

            using (StreamWriter writer = new StreamWriter(path, false))
            {
                await writer.WriteAsync(content);
            }

            Console.WriteLine("Archivo sobrescrito exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al sobrescribir el archivo: " + ex.Message);
        }
    }

    /// <summary>
    /// Elimina un archivo en la ruta especificada de forma asíncrona.
    /// </summary>
    /// <param name="path">Ruta del archivo a eliminar.</param>
    public static async Task DeleteFileAsync(string path)
    {
        try
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("El archivo no existe. No se puede eliminar.");
                return;
            }

            await Task.Run(() => File.Delete(path));

            Console.WriteLine("Archivo eliminado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al eliminar el archivo: " + ex.Message);
        }
    }

    /// <summary>
    /// Mueve un archivo de una ubicación de origen a una ubicación de destino de forma asíncrona.
    /// </summary>
    /// <param name="sourcePath">Ruta de origen del archivo.</param>
    /// <param name="destinationPath">Ruta de destino del archivo.</param>
    public static async Task MoveFileAsync(string sourcePath, string destinationPath)
    {
        try
        {
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("El archivo de origen no existe. No se puede mover.");
                return;
            }

            if (File.Exists(destinationPath))
            {
                Console.WriteLine("El archivo de destino ya existe. No se puede mover.");
                return;
            }

            await Task.Run(() => File.Move(sourcePath, destinationPath));

            Console.WriteLine("Archivo movido exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al mover el archivo: " + ex.Message);
        }
    }

    /// <summary>
    /// Copia un archivo de una ubicación de origen a una ubicación de destino de forma asíncrona.
    /// </summary>
    /// <param name="sourcePath">Ruta de origen del archivo.</param>
    /// <param name="destinationPath">Ruta de destino del archivo.</param>
    public static async Task CopyFileAsync(string sourcePath, string destinationPath)
    {
        try
        {
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("El archivo de origen no existe. No se puede copiar.");
                return;
            }

            if (File.Exists(destinationPath))
            {
                Console.WriteLine("El archivo de destino ya existe. No se puede copiar.");
                return;
            }

            await Task.Run(() => File.Copy(sourcePath, destinationPath));

            Console.WriteLine("Archivo copiado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al copiar el archivo: " + ex.Message);
        }
    }

    /// <summary>
    /// Lee el contenido de un archivo en la ruta especificada de forma asíncrona.
    /// </summary>
    /// <param name="path">Ruta del archivo a leer.</param>
    /// <returns>El contenido del archivo.</returns>
    public static async Task<string> ReadFileAsync(string path)
    {
        try
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("El archivo no existe. No se puede leer.");
                return string.Empty;
            }

            using (StreamReader reader = File.OpenText(path))
            {
                return await reader.ReadToEndAsync();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al leer el archivo: " + ex.Message);
            return string.Empty;
        }
    }

    public static string[] DirectoryGetFiles(string sourceFolderPath)
    {
        // Obtener todos los archivos de imagen en la carpeta de origen 
        return Directory.GetFiles(sourceFolderPath);
    }

}
