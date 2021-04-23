using AutoMapper;
using BLL.Abstractions.DTO.Media;
using BLL.Abstractions.Exceptions;
using BLL.Abstractions.Helpers;
using BLL.Abstractions.Infrastructure;
using BLL.Abstractions.Services;
using BLL.Infrastructure;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MediaService : ServiceBase, IMediaService
    {
        private readonly IUnit _unit;
        private readonly IMapper _mapper;
        private readonly Cloudinary _cloudinary;

        public MediaService(IUnit unit, IMapper mapper, Cloudinary cloudinary)
        {
            _unit = unit;
            _mapper = mapper;
            _cloudinary = cloudinary;
        }

        public async Task<MediaDTO> Get(int id)
        {
            var media = await _unit.MediaRepository.GetAsync(id);

            ValidateEntity(media);

            return _mapper.Map<MediaDTO>(media);
        }

        public async Task<int> Save(IFormFile formFile)
        {
            using (var stream = formFile.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(formFile.FileName, stream),
                    Overwrite = true
                };

                var uploadResult = _cloudinary.Upload(uploadParams);
                var resId = await _unit.MediaRepository.CreateAsync(new DAL.Abstractions.Models.Media { ImageUrl = uploadResult.Url.AbsoluteUri });

                if ((resId ?? 0) == 0)
                    throw new OperationCanceledException();

                return resId.Value;
            }
        }

        public async Task<string> GetCloudPath(string path)
        {
            var fullPath = $"{SettingsHolder.CloudinaryPath}{path}";
            if (await _unit.MediaRepository.Contains(fullPath))
                return fullPath;

            throw new NotFoundException();
        }
    }
}
