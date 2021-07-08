using QLSVOFFICIAL.ViewModels.Catalog.Checkin;
using QLSVOFFICIAL.ViewModels.Common;
using System.Threading.Tasks;

namespace QLSVOFFICIAL.Application.Catalog.Checkin
{
    //interface nhằm quản lí các DB của table sinh viên điểm danh
    //Nhằm triền khai DI (Dependency Injection)
    //Interface này dành riêng cho admin
    public interface IManageStudentCheckinService
    {
        Task<int> Create(StudentCheckinCreateRequest request);

        Task<int> Update(StudentCheckinUpdateRequest request);

        Task<int> Delete(int StudentCheckinId);

        Task<StudentCheckinViewModel> GetById(int CheckinId, int StudentCheckinId);

        Task<PagedResult<StudentCheckinViewModel>> GetAllPaging(GetManageStudentCheckinPagingRequest request);
    }
}
