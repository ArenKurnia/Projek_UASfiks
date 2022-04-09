using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Services
{
    public class FileService
    {
        IWebHostEnvironment _alat;
        public FileService(IWebHostEnvironment e)
        {
            _alat = e;
        }

        public async Task<string> SimpanFile(IFormFile Image)
        {
            string namaFolder = "namaFoldernya";

            if (Image == null)
            {
                return string.Empty;
            }

            var savepath = Path.Combine(_alat.WebRootPath, namaFolder);

            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);
            }

            var namaFilenya = Image.FileName;
            var alamatFilenya = Path.Combine(savepath, namaFilenya);

            using (var stream = new FileStream(alamatFilenya, FileMode.Create))
            {
                await Image.CopyToAsync(stream);
            }

            return Path.Combine("/" + namaFolder + "/", namaFilenya);
        }
    }
}
