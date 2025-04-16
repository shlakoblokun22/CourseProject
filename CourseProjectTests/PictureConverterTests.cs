using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Tests
{
    [TestClass()]
    public class PictureConverterTests
    {
        [TestMethod()]
        public void ConvertTest()
        {
            var converter = new PictureConverter();

            // 1. Убедимся, что исходный файл существует
            string sourceImagePath = @"C:\Users\boenk\OneDrive\Рабочий стол\к2\CourseProjectTests\images\Parasitized.png";
            if (!File.Exists(sourceImagePath))
            {
                Assert.Fail("Исходный файл не найден: " + sourceImagePath);
                return;
            }

            // 2. Конвертируем изображение
            var inputs = converter.Convert(sourceImagePath);

            // 3. Подготовим путь для сохранения (латинские символы + имя файла)
            string outputDirectory = @"C:\Users\boenk\source\repos\CourseProject\Output";
            string outputFileName = "converted_image.png"; // Имя файла без русских символов
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            // 4. Создадим папку, если её нет
            Directory.CreateDirectory(outputDirectory);

            // 5. Сохраним изображение (с обработкой ошибок)
            try
            {
                converter.Save(outputPath, inputs); // Передаём полный путь, а не только папку
               
            }
            catch (Exception ex)
            {
                Assert.Fail("Ошибка при сохранении: " + ex.Message);
            }
        }
    }
}