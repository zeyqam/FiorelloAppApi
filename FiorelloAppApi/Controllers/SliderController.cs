using AutoMapper;
using FiorelloAppApi.Data;
using FiorelloAppApi.DTOs;
using FiorelloAppApi.Helpers.Extensions;
using FiorelloAppApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloAppApi.Controllers
{
    
    public class SliderController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;


        public SliderController(AppDbContext context,IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;

        }
        [HttpGet]
       public async Task<IActionResult> GetAll() => Ok(_mapper.Map<List<SliderDto>>(await _context.Sliders.AsNoTracking().ToListAsync()));

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SliderCreateDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            foreach (var item in request.Images)
            {
                if (!item.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Images", " input can accept only image format");
                    return BadRequest(ModelState);
                }
                if (!item.CheckFileSize(1000))
                {
                    ModelState.AddModelError("Images", " Image size must be max 200kb ");
                    return BadRequest(ModelState);
                }
            }
            
            foreach (var item in request.Images)
            {
                string fileName = Guid.NewGuid().ToString() + "-" + item.FileName;

                //string path = _env.GenerateFilePath("img", fileName);
                //await item.SaveFileLocalAsync(path);

                await _context.Sliders.AddAsync(new Slider { Image = fileName });
                await _context.SaveChangesAsync();

            }

            return CreatedAtAction(nameof(GetAll), new { }, null);
        }
    }
}
