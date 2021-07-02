using QLSVOFFICIAL.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSVOFFICIAL.ViewModels.Catalog.Checkin
{
    public class GetPublicStudentCheckinPagingRequest : PagingRequestBase
    {
        public int? CheckinId { get; set; }
    }
}
