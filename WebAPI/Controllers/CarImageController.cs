using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImageController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(file, carImage);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }//sorun buraya yaz 
        //Arablara resim ekliyorum path i kendim veriyorum , postmande listelediğimiz zaman doğru olup olmadığını anlayabilmem için o resimin gittiğini nasıl anlarım
        //potmanda fotoğrafı görebilme imkanım varmı
        //bu arada veritabanında tüm yolu tutmuşşun çalısmaz bu onu düzeltelim evet bende pathle alakalı kısmı anlayamadım tmm ben birazdan anlatırım düzelteyimtmm
        //

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesByCarId(int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
