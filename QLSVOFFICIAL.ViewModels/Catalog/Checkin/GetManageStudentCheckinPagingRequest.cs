using QLSVOFFICIAL.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSVOFFICIAL.ViewModels.Catalog.Checkin
{
    public class GetManageStudentCheckinPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> CheckinIds { get; set; }
    }
}
