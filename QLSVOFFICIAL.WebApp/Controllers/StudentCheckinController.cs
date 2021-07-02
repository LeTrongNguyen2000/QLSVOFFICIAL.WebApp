using Microsoft.AspNetCore.Mvc;
using QLSVOFFICIAL.Application.Catalog.Checkin;
using QLSVOFFICIAL.ViewModels.Catalog.Checkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSVOFFICIAL.BackendApi1.Controllers
{
    //Khi Một controller được khởi tạo thì nó sẽ gọi constructor
    public class StudentCheckinController : Controller
    {
        private readonly IPublicStudentCheckinService _pucblicStudentCheckinService;
        private readonly IManageStudentCheckinService _manageStudentCheckinService;

        public StudentCheckinController(IPublicStudentCheckinService publicStudentCheckinService,
                                        IManageStudentCheckinService manageStudentCheckinService)
        {
            _pucblicStudentCheckinService = publicStudentCheckinService;
            _manageStudentCheckinService = manageStudentCheckinService;
        }
        //http://localhost:port/product
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var studentcheckins = await _pucblicStudentCheckinService.GetAll();
            return Ok(studentcheckins);
        }
        //http://localhost:port/product/public-paging
        [HttpGet("public-paging")]
        public async Task<IActionResult> Get([FromQuery]GetPublicStudentCheckinPagingRequest request) //[FromQuery]: tất cả những tham số truyền từ SQL đều lấy từ query rá
        {
            var studentcheckins = await _pucblicStudentCheckinService.GetAllByCheckinId(request);
            return Ok(studentcheckins);
        }
        //http://localhost:port/product/id
        [HttpGet("{StudentCheckinId}/{CheckinId}")]
        public async Task<IActionResult> GetById(int StudentCheckinId, string CheckinId)
        {
            var studentcheckins = await _manageStudentCheckinService.GetById(StudentCheckinId, int.Parse(CheckinId));
            if (studentcheckins == null)
                return BadRequest("Không tìm thấy sinh viên");
            return Ok(studentcheckins);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm]StudentCheckinCreateRequest request)
        {
            var IdStudent = await _manageStudentCheckinService.Create(request);
            if (IdStudent == 0)
                return BadRequest();

            var studentCheckin = await _manageStudentCheckinService.GetById(IdStudent, request.IdCheckin);

            return CreatedAtAction(nameof(GetById), new { id = IdStudent }, studentCheckin);
            //Trả về một action GetById
        }
        [HttpPut("")]
        public async Task<IActionResult> Update([FromForm] StudentCheckinUpdateRequest request)
        {
            var affectedResult = await _manageStudentCheckinService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{StudentId}")]
        public async Task<IActionResult> Delete(int StudentId)
        {
            var affectedResult = await _manageStudentCheckinService.Delete(StudentId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        
    }
}
