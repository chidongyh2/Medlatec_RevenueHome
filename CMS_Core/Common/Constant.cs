using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Common
{
    public class Constant
    {
        public static string Token = "MedCOm20190401";

        public static string ChangePasswordSuccess = "Thay đổi passowrd thành công";
        public static string ChangePasswordError = "Thay đổi passowrd không thành công";
        public static string NoFindAccount = "Không tìm thấy thông tin tài khoản";
        public static string Error = "Có lỗi xẩy ra";

        public static string StatusLoginOK = "OK";
        public static string StatusLoginNOK = "NOK";

        public static int TextBox = 1;
        public static int TextArea = 2;
        public static int CheckBox = 3;
        public static int CheckBoxList = 4;
        public static int intRadioButtonList = 5;
        public static int intSelect = 6;
        public static int intLiteral = 7;
        public static int intFileUpload = 8;


        public static int TypeDataString = 1;
        public static int TypeDataNumber = 2;
        public static int TypeDataDate = 3;
        public static int TypeDataBool = 4;

        public static int typeORAForeign = -2;  //ORA-02292: ou tried to DELETE a record from a parent table (as referenced by a foreign key), but a record in the child table exists.
        public static string nameORAForeign = "ORA-02292:";

    }
}
