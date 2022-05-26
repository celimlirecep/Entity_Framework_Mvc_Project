using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Models.Entities
{
    public class ImageModel
    {
        public int ImageId { get; set; }
        public string FullName { get; set; }
        public string FileName { get; set; }
        public long Size { get; set; }
        public Product Product { get; set; }
        public IFormFile Imagefile { get; set; }


    }
}
