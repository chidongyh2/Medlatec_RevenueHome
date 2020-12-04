using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_SERVICE_GROUP_CATE
    {
        /// <summary>
        /// Chèn dữ liệu dịch vụ vào nhóm dịch vụ
        /// </summary>      
        /// <param name="_GROUP_CATE">Input insert</param>
        /// <returns></returns>        
        string InsertCMS_SERVICE_GROUP_CATE(CMS_SERVICE_GROUP_CATE _GROUP_CATE );


        /// <summary>
        /// Chèn dữ  theo lô dịch vụ vào nhóm dịch vụ
        /// </summary>      
        /// <param name="p_groupid">ID nhóm dịch vụ</param>
        /// <param name="p_ListServiceID"> list ID dịch vụ (Ví dụ 1,2,3)</param>
        /// <param name="PARTNERID">ID đối tác</param>
        /// 
        /// <returns></returns>        
        string InsertListCMS_SERVICE_GROUP_CATE(int p_groupid, string p_ListServiceID,int VISIT_PATIENT, int PARTNERID);



        /// <summary>
        /// xóa dữ liệu dịch vụ vào nhóm dịch vụ
        /// </summary>      
        /// <param name="_GROUP_CATE">Input delete</param>
        /// <returns></returns>        
        string DeleteCMS_SERVICE_GROUP_CATE(CMS_SERVICE_GROUP_CATE _GROUP_CATE);


        /// <summary>
        /// Xóa dữ liệu theo lô dịch vụ vào nhóm dịch vụ
        /// </summary>      
        /// <param name="p_groupid">ID nhóm dịch vụ</param>
        /// <param name="p_ListServiceID"> list ID dịch vụ (Ví dụ 1,2,3)</param>
        /// <param name="PARTNERID">ID đối tác</param>
        /// 
        /// <returns></returns>        
        /// 
        string DeleteCMS_SERVICE_GROUP_CATE(int p_groupid, string p_ListServiceID, int PARTNERID);


    }
}
