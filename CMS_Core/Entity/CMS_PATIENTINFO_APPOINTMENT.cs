using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_PATIENTINFO_APPOINTMENT : IValidatableObject
    {
        public Int64 PID { get; set; }
        public String PATIENTNAME { get; set; }
        //public Int16 SEX { get; set; }
        private Int16 _SEX;
        private String _SEXNAME;
        public Int16 SEX { get { return _SEX; } set { _SEX = value; } }
        public String sexname { get { return _SEXNAME; } set { _SEXNAME = value; } }

        public Int16? AGE { get; set; }
        public String ADDRESS { get; set; }
        public String PHONE { get; set; }
        public String PHONE1 { get; set; }
        public String SONHA { get; set; }
        public String HEM { get; set; }
        public String NGACH { get; set; }
        public String NGO { get; set; }
        public String STREET { get; set; }
        public String PRECINCT { get; set; }
        public Int16 DISTRICT { get; set; }
        public Int16 CITY { get; set; }
        public String EMAILADDRESS { get; set; }
        public String EMAILRESULT { get; set; }
        public String GHICHU { get; set; }
        public Int16 STATUS { get; set; }
        public DateTime CREATEDATE { get; set; }
        public Int16 CREATEBY { get; set; }
        public DateTime UPATEDATE { get; set; }
        public Int16 UPDATEBY { get; set; }
        public Int32 PARTNERID { get; set; }
        public String PCODE { get; set; }
        
        public String PATIENTIMAGE { get; set; }

        public String PATIENT_CODE { get; set; }

        public String PATIENTPATH { get; set; }



        private DateTime? _BIRTHDAY;
        public DateTime? BIRTHDAY { get { return _BIRTHDAY; } set { _BIRTHDAY = value; BIRTHDAYVIEW = _BIRTHDAY.HasValue ? _BIRTHDAY.Value.ToString("dd/MM/yyyy") : String.Empty; } }
         

        public String BIRTHDAYVIEW { get; set; }


        public Int16 RELATIONSHIP { get; set; }

        public String IDENTIFICATION { get; set; }
        public String IDENTIFICATION_ISSUED { get; set; }

        private DateTime? _IDENTIFICATION_DATE;

        public DateTime? IDENTIFICATION_DATE { get { return _IDENTIFICATION_DATE; } set { _IDENTIFICATION_DATE = value; IDENTIFICATION_DATEVIEW = _IDENTIFICATION_DATE.HasValue ? _IDENTIFICATION_DATE.Value.ToString("dd/MM/yyyy") : String.Empty; } }



     

        public String IDENTIFICATION_DATEVIEW { get; set; }


        public String PASSPORT { get; set; }
        public String PASSPORT_ISSUED { get; set; }

        private DateTime? _PASSPORT_DATE;

        public DateTime? PASSPORT_DATE { get { return _PASSPORT_DATE; } set { _PASSPORT_DATE = value; PASSPORT_DATEVIEW = _PASSPORT_DATE.HasValue ? _PASSPORT_DATE.Value.ToString("dd/MM/yyyy") : String.Empty; } }

         

        public String PASSPORT_DATEVIEW { get; set; }

        public String PARENTS_INFO { get; set; }

        public String INSURANCE_CARD { get; set; }
        public String INSURANCE_CARD_PLACE { get; set; }



        private DateTime? _INSURANCE_CARD_START;

        public DateTime? INSURANCE_CARD_START { get { return _INSURANCE_CARD_START; } set { _INSURANCE_CARD_START = value; INSURANCE_CARD_STARTVIEW = _INSURANCE_CARD_START.HasValue ? _INSURANCE_CARD_START.Value.ToString("dd/MM/yyyy") : String.Empty; } }

        public String INSURANCE_CARD_STARTVIEW { get; set; }


        private DateTime? _INSURANCE_CARD_END;

        public DateTime? INSURANCE_CARD_END { get { return _INSURANCE_CARD_END; } set { _INSURANCE_CARD_END = value; INSURANCE_CARD_ENDVIEW = _INSURANCE_CARD_END.HasValue ? _INSURANCE_CARD_END.Value.ToString("dd/MM/yyyy") : String.Empty; } }

        public String INSURANCE_CARD_ENDVIEW { get; set; }

        public String partnerid_Code { get; set; }

        public String REASON { get; set; }
        public int CHANNEL { get; set; }

        private DateTime _APPOINTMENT;
    
        public DateTime APPOINTMENT { get { return _APPOINTMENT; } set { _APPOINTMENT = value; APPOINTMENT_VIEW = _APPOINTMENT.ToString("dd/MM/yyyy hh:mm tt"); } }

        public String APPOINTMENT_VIEW { get; set; }

        public int DEPARTMENTSID { get; set; }
        public int? weight { get; set; }

        public Int64? PATIENTINFO_ID { get; set; }


        public string CHANNEL_NAME { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.PATIENTNAME))
            {
                results.Add(new ValidationResult("Mời nhập vào tên bệnh nhân"));
            }
            else if (this.PATIENTNAME.Length > 200)
            {
                results.Add(new ValidationResult("Tên bệnh nhân lớn hơn 200 ký tự"));
            }


            if (!string.IsNullOrWhiteSpace(this.BIRTHDAYVIEW))
            {
                //    results.Add(new ValidationResult("Mời bạn nhập ngày sinh"));
                //}
                //else
                //{
                DateTime dateTime = new DateTime();
                try
                {
                    dateTime = DateTime.ParseExact(BIRTHDAYVIEW.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));
                    BIRTHDAY = dateTime;
                    if (dateTime > DateTime.Now)
                    {
                        results.Add(new ValidationResult("Ngày sinh không được lớn hơn ngày hiện tại"));
                    }
                    if (dateTime.AddYears(120) < DateTime.Now)
                    {
                        results.Add(new ValidationResult("Ngày sinh không được nhỏ hơn 120 tuổi"));
                    }
                }
                catch
                {
                    results.Add(new ValidationResult("Dữ liệu ngày sinh không đúng định dạng"));
                }
            }


            


            if (!string.IsNullOrWhiteSpace(this.IDENTIFICATION))
            {
                if (this.IDENTIFICATION.Length > 15)
                {
                    results.Add(new ValidationResult("CMT không được lớn hơn 15 ký tự"));
                }

                if (string.IsNullOrWhiteSpace(IDENTIFICATION_DATEVIEW))
                {
                    results.Add(new ValidationResult("Mời bạn nhập ngày cấp CMT"));
                }

                if (string.IsNullOrWhiteSpace(IDENTIFICATION_ISSUED))
                {
                    results.Add(new ValidationResult("Mời bạn nhập nơi cấp CMT"));
                }
            }

            if (!string.IsNullOrWhiteSpace(this.IDENTIFICATION_DATEVIEW))
            {
                
                DateTime dateTime = new DateTime();
                try
                {
                    dateTime = DateTime.ParseExact(IDENTIFICATION_DATEVIEW.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));
                    IDENTIFICATION_DATE = dateTime;
                    if (dateTime > DateTime.Now)
                    {
                        results.Add(new ValidationResult("Ngày CMT không được lớn hơn ngày hiện tại"));
                    }
                    if (dateTime.AddYears(100) < DateTime.Now)
                    {
                        results.Add(new ValidationResult("Ngày CMT không được nhỏ hơn 100 năm"));
                    }
                }
                catch
                {
                    results.Add(new ValidationResult("Dữ liệu ngày CMT không đúng định dạng"));
                }

                if (string.IsNullOrWhiteSpace(IDENTIFICATION))
                {
                    results.Add(new ValidationResult("Mời bạn nhập số CMT"));
                }

                if (string.IsNullOrWhiteSpace(IDENTIFICATION_ISSUED))
                {
                    results.Add(new ValidationResult("Mời bạn nhập nơi cấp CMT"));
                }

            }

            if (!string.IsNullOrWhiteSpace(IDENTIFICATION_ISSUED))
            {
                if (this.IDENTIFICATION_ISSUED.Length > 15)
                {
                    results.Add(new ValidationResult("Nơi cấp CMT không được lớn hơn 100 ký tự"));
                }

                if (string.IsNullOrWhiteSpace(IDENTIFICATION))
                {
                    results.Add(new ValidationResult("Mời bạn nhập số CMT"));
                }

                if (string.IsNullOrWhiteSpace(IDENTIFICATION))
                {
                    results.Add(new ValidationResult("Mời bạn nhập số CMT"));
                }

            }




           




            if (!string.IsNullOrWhiteSpace(this.PASSPORT))
            {
                if (this.PASSPORT.Length > 15)
                {
                    results.Add(new ValidationResult("PASSPORT không được lớn hơn 15 ký tự"));
                }

                if (string.IsNullOrWhiteSpace(this.PASSPORT_DATEVIEW))
                {
                    results.Add(new ValidationResult("Mời bạn nhập ngày cấp Passport"));
                }

                if (string.IsNullOrWhiteSpace(this.PASSPORT_ISSUED))
                {
                    results.Add(new ValidationResult("Mời bạn nhập nơi cấp Passport"));
                }

            }



            if (!string.IsNullOrEmpty(this.PASSPORT_DATEVIEW))
            {
               
                DateTime dateTime = new DateTime();
                try
                {
                    dateTime = DateTime.ParseExact(PASSPORT_DATEVIEW.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));
                    PASSPORT_DATE = dateTime;
                    if (dateTime > DateTime.Now)
                    {
                        results.Add(new ValidationResult("Ngày PASSPORT không được lớn hơn ngày hiện tại"));
                    }
                    if (dateTime.AddYears(15) < DateTime.Now)
                    {
                        results.Add(new ValidationResult("Ngày PASSPORT không được nhỏ hơn 15 năm"));
                    }
                }
                catch
                {
                    results.Add(new ValidationResult("Dữ liệu ngày CMT không đúng định dạng"));
                }


                if (string.IsNullOrWhiteSpace(this.PASSPORT))
                {
                    results.Add(new ValidationResult("Mời bạn nhập số Passport"));
                }

                if (string.IsNullOrWhiteSpace(this.PASSPORT_ISSUED))
                {
                    results.Add(new ValidationResult("Mời bạn nhập nơi cấp Passport"));
                }

            }

            if (!string.IsNullOrWhiteSpace(this.PASSPORT_ISSUED))
            {
                if (this.PASSPORT_ISSUED.Length > 15)
                {
                    results.Add(new ValidationResult("Nơi cấp PASSPORT không được lớn hơn 100 ký tự"));
                }

                if (string.IsNullOrWhiteSpace(this.PASSPORT))
                {
                    results.Add(new ValidationResult("Mời bạn nhập số Passport"));
                }

                if (string.IsNullOrWhiteSpace(this.PASSPORT_DATEVIEW))
                {
                    results.Add(new ValidationResult("Mời bạn nhập ngày cấp Passport"));
                }

            }



            if (!string.IsNullOrEmpty(this.INSURANCE_CARD))
            {
                if (this.INSURANCE_CARD.Length > 25)
                {
                    results.Add(new ValidationResult("BHYT không được lớn hơn 25 ký tự"));
                }

                if (this.INSURANCE_CARD.Length < 10)
                {
                    results.Add(new ValidationResult("BHYT không được nhỏ hơn 10 ký tự"));
                }


                if (string.IsNullOrWhiteSpace(this.INSURANCE_CARD_STARTVIEW))
                {
                    results.Add(new ValidationResult("Mời bạn nhập thời gian bắt đầu sử dụng BHYT"));
                }

                if (string.IsNullOrWhiteSpace(this.INSURANCE_CARD_ENDVIEW))
                {
                    results.Add(new ValidationResult("Mời bạn nhập thời gian kết thúc sử dụng BHYT"));
                }

               

                if (string.IsNullOrWhiteSpace(this.INSURANCE_CARD_PLACE))
                {
                    results.Add(new ValidationResult("Mời bạn nhập nơi cấp BHYT"));
                }
            }



            if (!string.IsNullOrEmpty(this.INSURANCE_CARD_STARTVIEW))
            {
               
                DateTime dateTime = new DateTime();
                try
                {
                    dateTime = DateTime.ParseExact(INSURANCE_CARD_STARTVIEW.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));
                    INSURANCE_CARD_START = dateTime;
                    if (dateTime > DateTime.Now)
                    {
                        results.Add(new ValidationResult("Ngày bắt đầu BHYT không được lớn hơn ngày hiện tại"));
                    }
                    if (dateTime.AddYears(20) < DateTime.Now)
                    {
                        results.Add(new ValidationResult("Ngày bắt đầu BHYT không được nhỏ hơn 20 năm"));
                    }
                }
                catch
                {
                    results.Add(new ValidationResult("Dữ liệu ngày bắt đầu BHYT không đúng định dạng"));
                }

                if (string.IsNullOrWhiteSpace(this.INSURANCE_CARD))
                {
                    results.Add(new ValidationResult("Mời bạn nhập số BHYT"));
                }

                if (string.IsNullOrWhiteSpace(this.INSURANCE_CARD_ENDVIEW))
                {
                    results.Add(new ValidationResult("Mời bạn nhập thời gian kết thúc sử dụng BHYT"));
                }

              

                if (string.IsNullOrWhiteSpace(this.INSURANCE_CARD_PLACE))
                {
                    results.Add(new ValidationResult("Mời bạn nhập nơi cấp BHYT"));
                }

            }


            if (!string.IsNullOrEmpty(this.INSURANCE_CARD_ENDVIEW))
            {
                
                DateTime dateTime = new DateTime();
                try
                {
                    dateTime = DateTime.ParseExact(INSURANCE_CARD_ENDVIEW.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));
                    _INSURANCE_CARD_END = dateTime;
                    if (dateTime < DateTime.Now.AddDays(-1))
                    {
                        results.Add(new ValidationResult("Ngày kết thúc BHYT không được nhỏ hơn ngày hiện tại"));
                    }
                    if (dateTime.AddYears(-20) > DateTime.Now)
                    {
                        results.Add(new ValidationResult("Ngày kết thúc BHYT không được lơn hơn 20 năm"));
                    }
                }
                catch
                {
                    results.Add(new ValidationResult("Dữ liệu ngày kết thúc BHYT không đúng định dạng"));
                }

                if (string.IsNullOrWhiteSpace(this.INSURANCE_CARD))
                {
                    results.Add(new ValidationResult("Mời bạn nhập số BHYT"));
                }

                if (string.IsNullOrWhiteSpace(this.INSURANCE_CARD_STARTVIEW))
                {
                    results.Add(new ValidationResult("Mời bạn nhập thời gian bắt đầu sử dụng BHYT"));
                }

            

                if (string.IsNullOrWhiteSpace(this.INSURANCE_CARD_PLACE))
                {
                    results.Add(new ValidationResult("Mời bạn nhập nơi cấp BHYT"));
                }

            }

            if (!string.IsNullOrEmpty(this.INSURANCE_CARD_PLACE))
            {
                if (this.INSURANCE_CARD_PLACE.Length > 100)
                {
                    results.Add(new ValidationResult("Nơi đăng ký BHYT không được lớn hơn 100 ký tự"));
                }

                if (string.IsNullOrWhiteSpace(this.INSURANCE_CARD))
                {
                    results.Add(new ValidationResult("Mời bạn nhập số BHYT"));
                }

                if (string.IsNullOrWhiteSpace(this.INSURANCE_CARD_STARTVIEW))
                {
                    results.Add(new ValidationResult("Mời bạn nhập thời gian bắt đầu sử dụng BHYT"));
                }

               

            }


            if (!string.IsNullOrEmpty(this.APPOINTMENT_VIEW))
            {
               
                DateTime dateTime = new DateTime();
                try
                {
                    dateTime = DateTime.ParseExact(APPOINTMENT_VIEW.Trim(), "dd/MM/yyyy HH:mm:ss", new CultureInfo("en-US"));       
                    if((dateTime - DateTime.Today).TotalDays < 1)
                    {
                        results.Add(new ValidationResult("Thời gian đặt lịch phải lớn hơn ngày hiện tại 1 ngày"));
                    } else
                    {
                        _APPOINTMENT = dateTime;
                    }                                                                                 
                }
                catch
                {
                    results.Add(new ValidationResult("Dữ liệu ngày đặt lịch không đúng định dạng"));
                }
            }else
            {
                results.Add(new ValidationResult("Mời bạn chọn ngày đặt lịch"));
            }



          


            if (!string.IsNullOrEmpty(this.ADDRESS))
            {
                if (this.ADDRESS.Length > 500)
                {
                    results.Add(new ValidationResult("Địa chỉ không được dài quá 500 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.PHONE))
            {
                if (this.PHONE.Length > 30)
                {
                    results.Add(new ValidationResult("Số điện thoại không được dài quá 30 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.PHONE1))
            {
                if (this.PHONE1.Length > 30)
                {
                    results.Add(new ValidationResult("Số điện thoại không được dài quá 30 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.SONHA))
            {
                if (this.SONHA.Length > 200)
                {
                    results.Add(new ValidationResult("Số nhà không được dài quá 200 ký tự"));
                }
            }




            if (!string.IsNullOrEmpty(this.PARENTS_INFO))
            {
                if (this.PARENTS_INFO.Length > 200)
                {
                    results.Add(new ValidationResult("Thông tin phụ huynh không được dài quá 200 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.IDENTIFICATION))
            {
                if (this.IDENTIFICATION.Length > 50)
                {
                    results.Add(new ValidationResult("Chứng minh thư không được dài quá 50 ký tự"));
                }
            }
            if (!string.IsNullOrEmpty(this.IDENTIFICATION_ISSUED))
            {
                if (this.IDENTIFICATION_ISSUED.Length > 100)
                {
                    results.Add(new ValidationResult("Nơi cấp chứng minh thư không được dài quá 100 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.PASSPORT))
            {
                if (this.PASSPORT.Length > 50)
                {
                    results.Add(new ValidationResult("PASSPORT không được dài quá 50 ký tự"));
                }
            }
            if (!string.IsNullOrEmpty(this.PASSPORT_ISSUED))
            {
                if (this.PASSPORT_ISSUED.Length > 100)
                {
                    results.Add(new ValidationResult("Nơi cấp PASSPORT không được dài quá 100 ký tự"));
                }
            }


            if (AGE < 0)
            {
                results.Add(new ValidationResult("Tuổi bệnh nhân không được nhỏ hơn 0"));
            }
            if (AGE > 120)
            {
                results.Add(new ValidationResult("Tuổi bệnh nhân không được lớn hơn 120"));
            }
            if (CHANNEL == 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn kênh đặt lịch!"));
            }

           

            return results;
        }

    }
}
