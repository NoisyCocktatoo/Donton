using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donton.Common.Helpers
{
    public class ImageCompressor
    {
        public async Task CompressAndSaveImageAsync(IFormFile imageFile, string outputPath, int quality = 75)
        {
            using var imageStream = imageFile.OpenReadStream();
            using var image = Image.Load(imageStream);
            var encoder = new JpegEncoder
            {
                Quality = quality,
            };

            await Task.Run(() => image.Save(outputPath, encoder));
        }

    }
}
