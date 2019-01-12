using EC.PromotionService.Models;
using Microsoft.Win32;
using System.IO;

namespace EC.PromotionService
{
    public class PromotionService : IPromotionService
    {
        public Promotion GetPromotionImage()
        {
            Promotion promotion;

            using (var fileStream = File.OpenRead(@"D:\ElectronicCard\ElectronicCard\EC.PromotionService\Images\clinic.jpg"))
            {
                var result = new byte[fileStream.Length];

                fileStream.Read(result, 0, result.Length);

                var classes = Registry.ClassesRoot;

                var fileClass = classes.OpenSubKey(Path.GetExtension(fileStream.Name));

                promotion = new Promotion
                {
                    Image = result,
                    TypeImage = fileClass.GetValue("Content type").ToString()
                };
            }

            return promotion;
        }
    }
}
