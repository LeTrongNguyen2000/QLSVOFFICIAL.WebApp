using System;
using System.Collections.Generic;
using System.Text;

namespace QLSVOFFICIAL.ViewModels.Catalog.Checkin
{
    public class StudentCheckinUpdateRequest
    {
        public int IdStudent { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int IdUser { get; set; }
    }
}
