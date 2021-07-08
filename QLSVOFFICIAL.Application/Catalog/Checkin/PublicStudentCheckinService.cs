using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLSVOFFICIAL.ViewModels.Catalog.Checkin;
using QLSVOFFICIAL.ViewModels.Common;
using QLSVOFFICIAL.Data.EF;

namespace QLSVOFFICIAL.Application.Catalog.Checkin
{
    public class PublicStudentCheckinService : IPublicStudentCheckinService
    {
        private readonly QLSVContext _context;
        public PublicStudentCheckinService(QLSVContext context)
        {
            _context = context;
        }

        public async Task<List<StudentCheckinViewModel>> GetAll()
        {
            var query = from st in _context.StudentCheckins
                        join s in _context.Students on st.IdStudent equals s.IdStudent
                        join us in _context.Users on st.IdUser equals us.IdUser
                        join ck in _context.Checkins on st.IdCheckin equals ck.IdCheckin
                        select new { st.IdCheckin, s.StudentCode, st.CheckIn, st.CheckOut, us.FullName };

            var data = await query.Select(x => new StudentCheckinViewModel()
                   {
                       IdCheckin = x.IdCheckin,
                       IdStudent = int.Parse(x.StudentCode),
                       CheckIn = x.CheckIn,
                       CheckOut = x.CheckOut,
                       IdUser = int.Parse(x.FullName),
                   }).ToListAsync();
            return data;
        }

        public async Task<PagedResult<StudentCheckinViewModel>> GetAllByCheckinId(GetPublicStudentCheckinPagingRequest request)
        {
            //1. Select join
            var query = from st in _context.StudentCheckins
                        join s in _context.Students on st.IdStudent equals s.IdStudent
                        join us in _context.Users on st.IdUser equals us.IdUser
                        join ck in _context.Checkins on st.IdCheckin equals ck.IdCheckin
                        select new { st.IdCheckin, s.StudentCode, st.CheckIn, st.CheckOut, us.FullName };
            //2. Filter
            if (request.CheckinId.HasValue && request.CheckinId.Value > 0) //HasValue phải bằng true
            {
                query = query.Where(x => x.IdCheckin == request.CheckinId);
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
    }
}
