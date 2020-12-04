using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSLIS.Common
{
    public class Constant
    {

        //Define action
        public static int ActionChangePasswordOK = 1;
        public static int ActionChangePasswordNOK = 2;
        public static int ActionInsertOK = 3;
        public static int ActionInsertNOK = 4;
        public static int ActionUpdateOK = 5;
        public static int ActionUpdateNOK = 6;
        public static int ActionDeleteOK = 7;
        public static int ActionDeleteNOK = 8;
        public static int ActionPublicOK = 9;
        public static int ActionPublicNOK = 10;
        public static int ActionExport = 11;
        public static int ActionAccept = 12;

        public static string ChangePasswordSuccess = "Thay đổi password thành công";
        public static string ChangePasswordError = "Thay đổi password không thành công";
        public static string NoFindAccount = "Không tìm thấy thông tin tài khoản";
        public static string Error = "Có lỗi xẩy ra";

        public static string StatusLoginOK = "OK";
        public static string StatusLoginNOK = "NOK";


        public static int TypeStatusPending = 1;
        public static int TypeStatusPublic = 2;
        public static int TypeStatusDelete = 0;
        public static int TypeStatusAll = -1;


        public static int Images_TypeNone = 1;
        public static int Images_TypeFB = 2;

        public static int typeSuccsess = 1;
        public static int typeWarning = 2;
        public static int typeError = 3;


        public static int typeORAForeign = -2;  //ORA-02292: ou tried to DELETE a record from a parent table (as referenced by a foreign key), but a record in the child table exists.
        public static string nameORAForeign = "ORA-02292:";

        public static int typeServiceSA = 141;
        public static int typeServiceNS = 142;
        public static int typeServiceXN = 143;
        public static int typeServiceXQ = 144;
        public static int typeServicePK = 145;
        public static int typeServiceTT = 146;
    }
}