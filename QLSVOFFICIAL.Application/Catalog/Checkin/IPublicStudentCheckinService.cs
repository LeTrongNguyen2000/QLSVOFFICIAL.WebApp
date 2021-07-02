using QLSVOFFICIAL.ViewModels.Catalog.Checkin;
using QLSVOFFICIAL.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLSVOFFICIAL.Application.Catalog.Checkin
{
    //Interface này dành riêng cho user
    public interface IPublicStudentCheckinService
    {
        public Task<PagedResult<StudentCheckinViewModel>> GetAllByCheckinId(GetPublicStudentCheckinPagingRequest request);

        Task<List<StudentCheckinViewModel>> GetAll();
    }
}
