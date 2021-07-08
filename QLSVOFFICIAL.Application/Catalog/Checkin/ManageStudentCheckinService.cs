using Microsoft.EntityFrameworkCore;
using QLSVOFFICIAL.Data.EF;
using QLSVOFFICIAL.Data.Models;
using QLSVOFFICIAL.Utilities.Exceptions;
using QLSVOFFICIAL.ViewModels.Catalog.Checkin;
using QLSVOFFICIAL.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSVOFFICIAL.Application.Catalog.Checkin
{
    public class ManageStudentCheckinService : IManageStudentCheckinService
    {
        private readonly QLSVContext _context;
        public ManageStudentCheckinService(QLSVContext context)
        {
            _context = context;
        }

        public async Task<int> Create(StudentCheckinCreateRequest request)
        {
            var checkinstudent = new StudentCheckin()
            {
                IdCheckin = request.IdCheckin,
                IdStudent = request.IdStudent,
                CheckIn = DateTime.Now,
                CheckOut = request.CheckOut,    
                IdUser = request.IdUser
            };
            _context.StudentCheckins.Add(checkinstudent);
            await _context.SaveChangesAsync(); // nó trả về kết quả của hoạt động ngay lập tức mà không bị đình chỉ phương pháp kèm theo
            return checkinstudent.IdStudent;
        }

        public async Task<int> Delete(int IdStudent)
        {
            var studentcheckin = await _context.StudentCheckins.FindAsync(IdStudent);
            if (studentcheckin == null) throw new QLSVOFFICIALException($"Không tìm thấy sinh viên điểm danh cần xóa: {IdStudent}");

            _context.StudentCheckins.Remove(studentcheckin);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<StudentCheckinViewModel>> GetAllPaging(GetManageStudentCheckinPagingRequest request)
        {
            //1. Select join
            var query = from st in _context.StudentCheckins
                        join s in _context.Students on st.IdStudent equals s.IdStudent
                        join us in _context.Users on st.IdUser equals us.IdUser
                        join ck in _context.Checkins on st.IdCheckin equals ck.IdCheckin
                        select new { ck.IdCheckin, s.StudentCode, st.CheckIn, st.CheckOut, us.FullName };
            //2. Filter
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.StudentCode.Contains(request.Keyword));
            }
            if (request.CheckinIds.Count > 0)
            {
                query = query.Where(x => request.CheckinIds.Contains(x.IdCheckin));
            }
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                    .Take(request.PageSize)
                    .Select(x => new StudentCheckinViewModel()
                    {
                        IdCheckin = x.IdCheckin,
                        IdStudent = int.Parse(x.StudentCode),
                        CheckIn = x.CheckIn,
                        CheckOut = x.CheckOut,
                        IdUser = int.Parse(x.FullName),
                    }).ToListAsync();
            //4. Select and projection
            var pagedResult = new PagedResult<StudentCheckinViewModel>()
            {
                TotalRecord = totalRow,
                Items = data,
            };
            return pagedResult;
        }

        public async Task<StudentCheckinViewModel> GetById(int CheckinId, int StudentCheckinId)
        {
            var studentCheckin = await _context.StudentCheckins.FindAsync(CheckinId, StudentCheckinId);

            var studentCheckinViewModel = new StudentCheckinViewModel()
            {
                IdCheckin = studentCheckin.IdCheckin, // checkin !=null ? checkin.IdCheckin : null
                IdStudent = studentCheckin.IdStudent,
                CheckIn = studentCheckin.CheckIn,
                CheckOut = studentCheckin.CheckOut,
                IdUser = studentCheckin.IdUser
            };
            return studentCheckinViewModel;
        }

        public async Task<int> Update(StudentCheckinUpdateRequest request)
        {
            var studentcheckin = await _context.StudentCheckins.FindAsync(request.IdStudent);
            if(studentcheckin == null) throw new QLSVOFFICIALException($"Không tìm thấy sinh viên điểm danh cần xóa: {request.IdStudent}");

            studentcheckin.IdStudent = request.IdStudent;
            studentcheckin.CheckIn = request.CheckIn;
            studentcheckin.CheckOut = request.CheckOut;
            studentcheckin.IdUser = request.IdUser;
            return await _context.SaveChangesAsync();
        }
    }
}
