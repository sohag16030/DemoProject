using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookApplication.DTO.EndUserDTO
{
    public class EndUserLandingPagination
    {
        public List<GetEndUserLandingDTO> data { get; set; }
        public long currentPage { get; set; }
        public long totalCount { get; set; }
        public long pageSize { get; set; }
    }
}
