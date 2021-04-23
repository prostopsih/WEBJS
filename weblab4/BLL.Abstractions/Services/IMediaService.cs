using BLL.Abstractions.DTO.Media;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstractions.Services
{
    public interface IMediaService
    {
        public Task<int> Save(IFormFile formFile);
        public Task<MediaDTO> Get(int id);
        Task<string> GetCloudPath(string path);
    }
}
