using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_ROOM_CLINIC : IRepository<CMS_ROOM_CLINIC>
    {
        /// <summary>
        /// Lấy các mẫu nhập dữ liệu theo nhóm dịch vụ
        /// </summary>      
        /// <param name="GROUP_SERVICEID">Tên ĐỐI TÁC</param>        
        /// <returns></returns>        
        List<CMS_ROOM_CLINIC> GetCMS_ROOM_CLINICByGroupService(int GROUP_SERVICEID, int PARTNERID);


        /// <summary>
        /// Lấy các mẫu nhập dữ liệu theo  dịch vụ
        /// </summary>      
        /// <param name="SERVICEID">Tên ĐỐI TÁC</param>        
        /// <returns></returns>        
        List<CMS_ROOM_CLINIC> GetCMS_ROOM_CLINICBySERVICEID(int SERVICEID, int PARTNERID);

        /// <summary>
        /// Lấy các mẫu nhập dữ liệu theo  dịch vụ
        /// </summary>      
        /// <param name="SERVICEID">Tên ĐỐI TÁC</param>        
        /// <returns></returns>        
        List<CMS_ROOM_CLINIC> GetCMS_ROOM_CLINICByDEPARTMENTID(int DEPARTMENTID, int PARTNERID);


        CMS_ROOM_CLINIC GetName(string RoomName, int PARTNERID);

    }
}
