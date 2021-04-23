using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weblab4.Model
{
    public class CreateFileModel
    {
        public IFormFile FormFile { get; set; }
    }
}
