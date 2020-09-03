using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CoronaStat.API.Data;
using CoronaStat.API.Dtos;
using CoronaStat.API.Helpers;
using CoronaStat.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CoronaStat.API.Controllers
{
    
    [Produces("application/json")]
    [Route("api/Photos")]

    public class PhotosController : ControllerBase
    {
        private IPhotoRepository _photoRepository;
        private IMapper _mapper;
        private IOptions<CloudinarySettings> _cloudinaryConfig;

        private Cloudinary _cloudinary;

        public ActionResult GetPhotosBy()
        {
            var photo = _photoRepository.GetPhotosBy();
            var photoToReturn = _mapper.Map<List<PhotoForDto>>(photo);
            return Ok(photoToReturn);
        }
        // GET api/details/5
        [HttpGet("{id}")]
        public ActionResult GetPhoto(int id)
        {
            var photo = _photoRepository.GetPhoto(id);
            var photoToReturn = _mapper.Map<List<PhotoForDto>>(photo);
            return Ok(photoToReturn);

        }

        public PhotosController(IPhotoRepository photoRepository, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _photoRepository = photoRepository;
            _mapper = mapper;
            _cloudinaryConfig = cloudinaryConfig;

            Account account = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret);

            _cloudinary = new Cloudinary(account);
        }

       
        [HttpPost]
        [Route("add")]
        public ActionResult AddPhotoForCity([FromForm]PhotoForCreationDto photoForCreationDto)
        {
            /*
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (currentUserId == null)
            {
                return Unauthorized();
            }
            */
            var file = photoForCreationDto.File;

            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.Name, stream)
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            //photoForCreationDto.Url = uploadResult.Uri.ToString(); // Uri KULLANILMIYOR 
            photoForCreationDto.Url = uploadResult.Url.ToString();
            photoForCreationDto.PublicId = uploadResult.PublicId;

            var photo = _mapper.Map<Photo>(photoForCreationDto);

            _photoRepository.Add(photo);
            _photoRepository.SaveAll();
            return Ok(photo);

        }

        [HttpGet("{id}", Name = "GetPhoto")]
        public ActionResult GetPhotos(int id)
        {
            var photoFromDb = _photoRepository.GetPhoto(id);
            var photo = _mapper.Map<PhotoForReturnDto>(photoFromDb);

            return Ok(photo);
        }
    }
}