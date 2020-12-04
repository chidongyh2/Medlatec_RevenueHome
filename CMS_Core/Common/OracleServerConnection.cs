using CMS_Core.Entity;
using CMS_Core.Implementtion;
using Dapper.Oracle;
using log4net;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;


namespace CMS_Core.Common
{
    public class OracleServerConnection<AnyType>
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");


        /// <summary>
        /// Lấy danh sách object theo procedure gọi vào với các biến theo thứ thự nhập vào trên procedure
        /// </summary>         
        /// <returns></returns>    
        public List<AnyType> SelectQueryCommand(string spName, params object[] values)
        {
            ///Thực hiện stored (values là danh sách các biến theo thứ tự) trả về bảng
            if (string.IsNullOrEmpty(spName))
                throw new ArgumentException("Không đưa tên stored");

            List<ALL_ARGUMENTS> dataPARAMETERS = null;

            //Lấy thông tin trường bảng trong mencache
            //MemcacheConnection mencache = new MemcacheConnection();
            //dataPARAMETERS = (List<ALL_ARGUMENTS>)mencache.getMemcacheByKey("ALL_ARGUMENTS" + spName);
            if (dataPARAMETERS == null)
            {
                if (HttpContext.Current.Session["ALL_ARGUMENTS" + spName] != null)
                {
                    dataPARAMETERS = (List<ALL_ARGUMENTS>)HttpContext.Current.Session["ALL_ARGUMENTS" + spName];
                }
                else
                {
                    ImpALL_ARGUMENTS impALL_ARGUMENTS = new ImpALL_ARGUMENTS();

                    dataPARAMETERS = impALL_ARGUMENTS.GetALL_ARGUMENTSByProcedure(spName);
                    HttpContext.Current.Session["ALL_ARGUMENTS" + spName] = dataPARAMETERS;
                }
            }

            try
            {
                var connection = new OracleConnection(Common.getConnStrOracle());
                using (var con = connection)
                {
                    var parm = new OracleDynamicParameters();
                    int countPara = 0;

                    if (values != null && values.Length > 0)
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            parm.Add(dataPARAMETERS[i].argument_name, values[i]);
                        }

                        countPara = values.Length;
                    }

                    if (dataPARAMETERS != null)
                    {
                        if (dataPARAMETERS.Count > 0)
                        {
                            for (int i = countPara; i < dataPARAMETERS.Count; i++)
                            {
                                if (dataPARAMETERS[i].data_type.Equals("REF CURSOR"))
                                {
                                    parm.Add(dataPARAMETERS[i].argument_name, dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                                }
                            }
                        }
                    }


                    using (var mul = con.QueryMultiple(spName, parm, commandType: CommandType.StoredProcedure))
                    {
                        var data = mul.Read<AnyType>().ToList();
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                logError.Info("SelectQueryCommand: " + ex.ToString());
                return null;
            }
        }


        /// <summary>
        /// Lấy danh sách object theo procedure gọi vào với các biến theo thứ thự nhập vào trên procedure
        /// </summary>         
        /// <returns></returns>    
        public ListDashboard_Index SelectDashboard_IndexQueryCommand(string spName, params object[] values)
        {
            ///Thực hiện stored (values là danh sách các biến theo thứ tự) trả về bảng
            if (string.IsNullOrEmpty(spName))
                throw new ArgumentException("Không đưa tên stored");



            List<ALL_ARGUMENTS> dataPARAMETERS = null;

            //Lấy thông tin trường bảng trong mencache
            //MemcacheConnection mencache = new MemcacheConnection();
            //dataPARAMETERS = (List<ALL_ARGUMENTS>)mencache.getMemcacheByKey("ALL_ARGUMENTS" + spName);
            if (dataPARAMETERS == null)
            {
                if (HttpContext.Current.Session["ALL_ARGUMENTS" + spName] != null)
                {
                    dataPARAMETERS = (List<ALL_ARGUMENTS>)HttpContext.Current.Session["ALL_ARGUMENTS" + spName];
                }
                else
                {
                    ImpALL_ARGUMENTS impALL_ARGUMENTS = new ImpALL_ARGUMENTS();

                    dataPARAMETERS = impALL_ARGUMENTS.GetALL_ARGUMENTSByProcedure(spName);
                    HttpContext.Current.Session["ALL_ARGUMENTS" + spName] = dataPARAMETERS;
                }
            }

            try
            {
                var connection = new OracleConnection(Common.getConnStrOracle());
                using (var con = connection)
                {
                    var parm = new OracleDynamicParameters();
                    int countPara = 0;

                    if (values != null && values.Length > 0)
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            parm.Add(dataPARAMETERS[i].argument_name, values[i]);
                        }

                        countPara = values.Length;
                    }

                    if (dataPARAMETERS != null)
                    {
                        if (dataPARAMETERS.Count > 0)
                        {
                            for (int i = countPara; i < dataPARAMETERS.Count; i++)
                            {
                                if (dataPARAMETERS[i].data_type.Equals("REF CURSOR"))
                                {
                                    parm.Add(dataPARAMETERS[i].argument_name, dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                                }
                            }
                        }
                    }


                    using (var mul = con.QueryMultiple(spName, parm, commandType: CommandType.StoredProcedure))
                    {
                        var datas = new ListDashboard_Index();

                        datas.Revenue = mul.Read<Dashboard_Index>().ToList();
                        datas.PatienInfos = mul.Read<Dashboard_Index>().ToList();
                        datas.RevenueMedicine = mul.Read<Dashboard_Index>().ToList();
                        datas.Prescriptions = mul.Read<Dashboard_Index>().ToList();


                        return datas;
                    }
                }
            }
            catch (Exception ex)
            {
                logError.Info("SelectQueryCommand: " + ex.ToString());
                return null;
            }
        }


        /// <summary>
        /// Lấy danh sách object theo procedure gọi vào với các biến theo thứ thự nhập vào trên procedure
        /// </summary>         
        /// <returns></returns>    
        public CMS_Core.Models.MedicalExaminationViewModel SelectPatientInfoAllQueryCommand(string spName, params object[] values)
        {
            ///Thực hiện stored (values là danh sách các biến theo thứ tự) trả về bảng
            if (string.IsNullOrEmpty(spName))
                throw new ArgumentException("Không đưa tên stored");



            List<ALL_ARGUMENTS> dataPARAMETERS = null;



            if (dataPARAMETERS == null)
            {
                if (HttpContext.Current.Session["ALL_ARGUMENTS" + spName] != null)
                {
                    dataPARAMETERS = (List<ALL_ARGUMENTS>)HttpContext.Current.Session["ALL_ARGUMENTS" + spName];
                }
                else
                {
                    ImpALL_ARGUMENTS impALL_ARGUMENTS = new ImpALL_ARGUMENTS();

                    dataPARAMETERS = impALL_ARGUMENTS.GetALL_ARGUMENTSByProcedure(spName);
                    HttpContext.Current.Session["ALL_ARGUMENTS" + spName] = dataPARAMETERS;
                }
            }

            try
            {
                var connection = new OracleConnection(Common.getConnStrOracle());
                using (var con = connection)
                {
                    var parm = new OracleDynamicParameters();
                    int countPara = 0;

                    if (values != null && values.Length > 0)
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            parm.Add(dataPARAMETERS[i].argument_name, values[i]);
                        }

                        countPara = values.Length;
                    }

                    if (dataPARAMETERS != null)
                    {
                        if (dataPARAMETERS.Count > 0)
                        {
                            for (int i = countPara; i < dataPARAMETERS.Count; i++)
                            {
                                if (dataPARAMETERS[i].data_type.Equals("REF CURSOR"))
                                {
                                    parm.Add(dataPARAMETERS[i].argument_name, dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                                }
                            }
                        }
                    }


                    using (var mul = con.QueryMultiple(spName, parm, commandType: CommandType.StoredProcedure))
                    {
                        var datas = new CMS_Core.Models.MedicalExaminationViewModel();
                        List<CMS_PATIENT> patients = mul.Read<CMS_PATIENT>().ToList();
                        if (patients != null)
                        {
                            if (patients.Count > 0)
                            {
                                datas.PATIENT = patients[0];
                                List<CMS_PATIENTINFO> _PATIENTINFOS = mul.Read<CMS_PATIENTINFO>().ToList();
                                if (_PATIENTINFOS != null)
                                {
                                    if (_PATIENTINFOS.Count > 0)
                                    {
                                        datas.PATIENTINFO = _PATIENTINFOS[0];
                                        datas.CMS_PATIENT_SERVICES = mul.Read<CMS_PATIENT_SERVICE>().ToList();
                                        datas.HISTORIES = mul.Read<CMS_PATIENT_HISTORY>().ToList();
                                        datas.ALLERGGYS = mul.Read<CMS_PATIENT_ALLERGY>().ToList();
                                        datas.PATIENTS = mul.Read<CMS_PATIENT>().ToList();
                                        datas.CMS_PATIENT_SERVICE_RESULTS = mul.Read<CMS_PATIENT_SERVICE_RESULT>().ToList();
                                        datas.CMS_PATIENT_PRESCRIPTIONS = mul.Read<CMS_PATIENT_PRESCRIPTION>().ToList();
                                        datas.PATIENT_IMAGES = mul.Read<CMS_PATIENT_IMAGES>().ToList();
                                    }
                                }

                            }
                        }




                        return datas;
                    }
                }
            }
            catch (Exception ex)
            {
                logError.Info("SelectQueryCommand: " + ex.ToString());
                return null;
            }
        }




        /// <summary>
        /// Lấy danh sách object theo procedure gọi vào với các biến theo thứ thự nhập vào trên procedure
        /// </summary>         
        /// <returns></returns>    
        public CMS_Core.Models.PatientAddViewModel SelectCreateOrderByIDQueryCommand(string spName, params object[] values)
        {
            ///Thực hiện stored (values là danh sách các biến theo thứ tự) trả về bảng
            if (string.IsNullOrEmpty(spName))
                throw new ArgumentException("Không đưa tên stored");



            List<ALL_ARGUMENTS> dataPARAMETERS = null;



            if (dataPARAMETERS == null)
            {
                if (HttpContext.Current.Session["ALL_ARGUMENTS" + spName] != null)
                {
                    dataPARAMETERS = (List<ALL_ARGUMENTS>)HttpContext.Current.Session["ALL_ARGUMENTS" + spName];
                }
                else
                {
                    ImpALL_ARGUMENTS impALL_ARGUMENTS = new ImpALL_ARGUMENTS();

                    dataPARAMETERS = impALL_ARGUMENTS.GetALL_ARGUMENTSByProcedure(spName);
                    HttpContext.Current.Session["ALL_ARGUMENTS" + spName] = dataPARAMETERS;
                }
            }

            try
            {
                var connection = new OracleConnection(Common.getConnStrOracle());
                using (var con = connection)
                {
                    var parm = new OracleDynamicParameters();
                    int countPara = 0;

                    if (values != null && values.Length > 0)
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            parm.Add(dataPARAMETERS[i].argument_name, values[i]);
                        }

                        countPara = values.Length;
                    }

                    if (dataPARAMETERS != null)
                    {
                        if (dataPARAMETERS.Count > 0)
                        {
                            for (int i = countPara; i < dataPARAMETERS.Count; i++)
                            {
                                if (dataPARAMETERS[i].data_type.Equals("REF CURSOR"))
                                {
                                    parm.Add(dataPARAMETERS[i].argument_name, dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                                }
                            }
                        }
                    }


                    using (var mul = con.QueryMultiple(spName, parm, commandType: CommandType.StoredProcedure))
                    {
                        var datas = new CMS_Core.Models.PatientAddViewModel();
                        List<CMS_PATIENTINFO> _PATIENTINFOS = mul.Read<CMS_PATIENTINFO>().ToList();

                        if (_PATIENTINFOS != null)
                        {
                            if (_PATIENTINFOS.Count > 0)
                            {
                                datas.PATIENTINFO = _PATIENTINFOS[0];
                                datas.HISTORIES = mul.Read<CMS_PATIENT_HISTORY>().ToList();
                                datas.ALLERGGYS = mul.Read<CMS_PATIENT_ALLERGY>().ToList();
                                datas.PATIENTS = mul.Read<CMS_PATIENT>().ToList();
                            }
                        }




                        return datas;
                    }
                }
            }
            catch (Exception ex)
            {
                logError.Info("SelectQueryCommand: " + ex.ToString());
                return null;
            }
        }



        /// <summary>
        /// Lấy danh sách object theo procedure gọi vào với các biến theo thứ thự nhập vào trên procedure
        /// </summary>         
        /// <returns></returns>    
        public CMS_Core.Models.PatientAddViewModel SelectCreateOrderBySIDQueryCommand(string spName, params object[] values)
        {
            ///Thực hiện stored (values là danh sách các biến theo thứ tự) trả về bảng
            if (string.IsNullOrEmpty(spName))
                throw new ArgumentException("Không đưa tên stored");



            List<ALL_ARGUMENTS> dataPARAMETERS = null;



            if (dataPARAMETERS == null)
            {
                if (HttpContext.Current.Session["ALL_ARGUMENTS" + spName] != null)
                {
                    dataPARAMETERS = (List<ALL_ARGUMENTS>)HttpContext.Current.Session["ALL_ARGUMENTS" + spName];
                }
                else
                {
                    ImpALL_ARGUMENTS impALL_ARGUMENTS = new ImpALL_ARGUMENTS();

                    dataPARAMETERS = impALL_ARGUMENTS.GetALL_ARGUMENTSByProcedure(spName);
                    HttpContext.Current.Session["ALL_ARGUMENTS" + spName] = dataPARAMETERS;
                }
            }

            try
            {
                var connection = new OracleConnection(Common.getConnStrOracle());
                using (var con = connection)
                {
                    var parm = new OracleDynamicParameters();
                    int countPara = 0;

                    if (values != null && values.Length > 0)
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            parm.Add(dataPARAMETERS[i].argument_name, values[i]);
                        }

                        countPara = values.Length;
                    }

                    if (dataPARAMETERS != null)
                    {
                        if (dataPARAMETERS.Count > 0)
                        {
                            for (int i = countPara; i < dataPARAMETERS.Count; i++)
                            {
                                if (dataPARAMETERS[i].data_type.Equals("REF CURSOR"))
                                {
                                    parm.Add(dataPARAMETERS[i].argument_name, dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                                }
                            }
                        }
                    }


                    using (var mul = con.QueryMultiple(spName, parm, commandType: CommandType.StoredProcedure))
                    {
                        var datas = new CMS_Core.Models.PatientAddViewModel();
                        List<CMS_PATIENT> patients = mul.Read<CMS_PATIENT>().ToList();

                        // List<CMS_PATIENTINFO> _PATIENTINFOS = mul.Read<CMS_PATIENTINFO>().ToList();

                        if (patients != null)
                        {
                            if (patients.Count > 0)
                            {
                                datas.PATIENT = patients[0];
                                List<CMS_PATIENTINFO> _PATIENTINFOS = mul.Read<CMS_PATIENTINFO>().ToList();
                                if (_PATIENTINFOS != null)
                                {
                                    if (_PATIENTINFOS.Count > 0)
                                    {
                                        datas.PATIENTINFO = _PATIENTINFOS[0];
                                    }
                                }

                                datas.HISTORIES = mul.Read<CMS_PATIENT_HISTORY>().ToList();
                                datas.ALLERGGYS = mul.Read<CMS_PATIENT_ALLERGY>().ToList();
                                datas.PATIENTS = mul.Read<CMS_PATIENT>().ToList();
                                datas.SERVICES = mul.Read<CMS_SERVICE>().ToList();
                            }
                        }




                        return datas;
                    }
                }
            }
            catch (Exception ex)
            {
                logError.Info("SelectQueryCommand: " + ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách object theo câu lệnh sql gọi vào
        /// </summary>         
        /// <returns></returns>    

        public List<AnyType> SelectQuery(string command)
        {
            ///Thực hiện stored (values là danh sách các biến theo thứ tự) trả về bảng
            if (string.IsNullOrEmpty(command))
                throw new ArgumentException("Không đưa câu lệnh vào");
            try
            {
                var connection = new OracleConnection(Common.getConnStrOracle());
                using (var con = connection)
                {
                    using (var mul = con.QueryMultiple(command))
                    {
                        var data = mul.Read<AnyType>().ToList();
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                logError.Info("SelectQuery: " + ex.ToString());
                return null;
            }
        }


        /// <summary>
        /// Lấy danh sách object theo câu lệnh sql gọi vào
        /// </summary>         
        /// <returns></returns>    

     
     
      


        /// <summary>
        /// Chèn object vào theo procedure gọi vào với các biến theo thứ thự nhập vào trên procedure
        /// </summary>         
        /// <returns></returns>   
        public string ExecuteInsert(string spName, params object[] values)
        {
            ///Thực hiện store, values là các biến đưa vào stored theo thứ tự           
            if (string.IsNullOrEmpty(spName))
                throw new ArgumentException("Không đưa tên stored");

            List<ALL_ARGUMENTS> dataPARAMETERS = null;

            //Lấy thông tin trường bảng trong mencache
            // MemcacheConnection mencache = new MemcacheConnection();
            //  dataPARAMETERS = (List<ALL_ARGUMENTS>)mencache.getMemcacheByKey("ALL_ARGUMENTS" + spName);
            if (dataPARAMETERS == null)
            {
                if (HttpContext.Current.Session["ALL_ARGUMENTS" + spName] != null)
                {
                    dataPARAMETERS = (List<ALL_ARGUMENTS>)HttpContext.Current.Session["ALL_ARGUMENTS" + spName];
                }
                else
                {
                    ImpALL_ARGUMENTS impALL_ARGUMENTS = new ImpALL_ARGUMENTS();
                    dataPARAMETERS = impALL_ARGUMENTS.GetALL_ARGUMENTSByProcedure(spName);
                    HttpContext.Current.Session["ALL_ARGUMENTS" + spName] = dataPARAMETERS;
                }
            }

            string DATA_TYPE = string.Empty;
            string PARAMETER_NAME = string.Empty;

            try
            {
                var connection = new OracleConnection(Common.getConnStrOracle());
                using (var con = connection)
                {
                    var parm = new OracleDynamicParameters();
                    int indexPara = 0;
                    if (values != null && values.Length > 0)
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            if ("IN/OUT".Equals(dataPARAMETERS[indexPara].in_out))
                            {
                                DATA_TYPE = dataPARAMETERS[indexPara].data_type;
                                PARAMETER_NAME = dataPARAMETERS[indexPara].argument_name;
                                parm.Add(PARAMETER_NAME, dbType: OracleMappingType.Int64, direction: ParameterDirection.Output);
                                indexPara = indexPara + 1;
                                parm.Add(dataPARAMETERS[indexPara].argument_name, values[i]);
                            }
                            else if ("OUT".Equals(dataPARAMETERS[indexPara].in_out))
                            {
                                DATA_TYPE = dataPARAMETERS[indexPara].data_type;
                                PARAMETER_NAME = dataPARAMETERS[indexPara].argument_name;
                                parm.Add(PARAMETER_NAME, dbType: OracleMappingType.Int64, direction: ParameterDirection.Output);
                                indexPara = indexPara + 1;
                                parm.Add(dataPARAMETERS[indexPara].argument_name, values[i]);
                            }
                            else
                            {
                                parm.Add(dataPARAMETERS[indexPara].argument_name, values[i]);
                            }
                            indexPara = indexPara + 1;
                        }
                    }

                    int result = 0;

                    result = con.Execute(spName, parm, commandType: CommandType.StoredProcedure);
                    if (string.IsNullOrEmpty(PARAMETER_NAME))
                    {
                        return result.ToString();
                    }
                    else
                    {
                        string clientId = string.Empty;
                        clientId = parm.GetParameter(PARAMETER_NAME).Value.ToString();
                        return clientId.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                logError.Info("ExecuteInsert: " + ex.ToString());
                return string.Empty;
            }
        }


        public string ExecuteNonQuery(string spName, params object[] values)
        {
            ///Thực hiện store, values là các biến đưa vào stored theo thứ tự           
            if (string.IsNullOrEmpty(spName))
                throw new ArgumentException("Không đưa tên stored");

            List<ALL_ARGUMENTS> dataPARAMETERS = null;

            //Lấy thông tin trường bảng trong mencache
            // MemcacheConnection mencache = new MemcacheConnection();
            //  dataPARAMETERS = (List<ALL_ARGUMENTS>)mencache.getMemcacheByKey("ALL_ARGUMENTS" + spName);
            if (dataPARAMETERS == null)
            {
                if (HttpContext.Current.Session["ALL_ARGUMENTS" + spName] != null)
                {
                    dataPARAMETERS = (List<ALL_ARGUMENTS>)HttpContext.Current.Session["ALL_ARGUMENTS" + spName];
                }
                else
                {
                    ImpALL_ARGUMENTS impALL_ARGUMENTS = new ImpALL_ARGUMENTS();
                    dataPARAMETERS = impALL_ARGUMENTS.GetALL_ARGUMENTSByProcedure(spName);
                    HttpContext.Current.Session["ALL_ARGUMENTS" + spName] = dataPARAMETERS;
                }
            }


            string DATA_TYPE = string.Empty;
            string PARAMETER_NAME = string.Empty;

            try
            {
                var connection = new OracleConnection(Common.getConnStrOracle());
                using (var con = connection)
                {
                    var parm = new OracleDynamicParameters();
                    if (values != null && values.Length > 0)
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            parm.Add(dataPARAMETERS[i].argument_name, values[i]);
                        }
                    }

                    int result = 0;
                    result = con.Execute(spName, parm, commandType: CommandType.StoredProcedure);
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                logError.Info("ExecuteNonQuery: " + ex.ToString());

                // check lỗi trả về đưa ra cảnh báo
                try
                {
                    if (ex.Message.ToString().IndexOf(CMS_Core.Common.Constant.nameORAForeign) != -1)
                    {
                        return CMS_Core.Common.Constant.typeORAForeign.ToString();
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                catch { return string.Empty; }

            }
        }


        public object ExecuteScalar(string spName, params object[] values)
        {
            object value = DBNull.Value;

            ///Thực hiện store, values là các biến đưa vào stored theo thứ tự           
            if (string.IsNullOrEmpty(spName))
                throw new ArgumentException("Không đưa tên stored");

            List<ALL_ARGUMENTS> dataPARAMETERS = null;

            //Lấy thông tin trường bảng trong mencache
            // MemcacheConnection mencache = new MemcacheConnection();
            //  dataPARAMETERS = (List<ALL_ARGUMENTS>)mencache.getMemcacheByKey("ALL_ARGUMENTS" + spName);
            if (dataPARAMETERS == null)
            {
                if (HttpContext.Current.Session["ALL_ARGUMENTS" + spName] != null)
                {
                    dataPARAMETERS = (List<ALL_ARGUMENTS>)HttpContext.Current.Session["ALL_ARGUMENTS" + spName];
                }
                else
                {
                    ImpALL_ARGUMENTS impALL_ARGUMENTS = new ImpALL_ARGUMENTS();
                    dataPARAMETERS = impALL_ARGUMENTS.GetALL_ARGUMENTSByProcedure(spName);
                    HttpContext.Current.Session["ALL_ARGUMENTS" + spName] = dataPARAMETERS;
                }
            }

            string DATA_TYPE = string.Empty;
            string PARAMETER_NAME = string.Empty;

            try
            {
                var connection = new OracleConnection(Common.getConnStrOracle());
                using (var con = connection)
                {
                    var parm = new OracleDynamicParameters();
                    if (values != null && values.Length > 0)
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            parm.Add(dataPARAMETERS[i].argument_name, values[i]);
                        }
                    }
                    value = con.ExecuteScalar(spName, parm, commandType: CommandType.StoredProcedure);
                    return value;
                }
            }
            catch (Exception ex)
            {
                logError.Info("ExecuteScalar: " + ex.ToString());
                return null;
            }
        }


        public string ExecuteInsertEncrypt(string spName, string listColumn, params object[] values)
        {
            ///Thực hiện store, values là các biến đưa vào stored theo thứ tự           
            if (string.IsNullOrEmpty(spName))
                throw new ArgumentException("Không đưa tên stored");

            if (string.IsNullOrEmpty(listColumn))
                throw new ArgumentException("Không đưa danh sách cột mã hóa");


            List<ALL_ARGUMENTS> dataPARAMETERS = null;

            //Lấy thông tin trường bảng trong mencache
            MemcacheConnection mencache = new MemcacheConnection();
            dataPARAMETERS = (List<ALL_ARGUMENTS>)mencache.getMemcacheByKey("ALL_ARGUMENTS" + spName);
            if (dataPARAMETERS == null)
            {
                if (HttpContext.Current.Session["ALL_ARGUMENTS" + spName] != null)
                {
                    dataPARAMETERS = (List<ALL_ARGUMENTS>)HttpContext.Current.Session["ALL_ARGUMENTS" + spName];
                }
                else
                {
                    ImpALL_ARGUMENTS impALL_ARGUMENTS = new ImpALL_ARGUMENTS();

                    dataPARAMETERS = impALL_ARGUMENTS.GetALL_ARGUMENTSByProcedure(spName);
                    HttpContext.Current.Session["ALL_ARGUMENTS" + spName] = dataPARAMETERS;
                }
            }


            string DATA_TYPE = string.Empty;
            string PARAMETER_NAME = string.Empty;
            string KeyDecrypt = AES.CreateKey(9);


            try
            {
                var connection = new OracleConnection(Common.getConnStrOracle());
                using (var con = connection)
                {
                    var parm = new OracleDynamicParameters();
                    int indexPara = 0;
                    if (values != null && values.Length > 0)
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            if ("IN/OUT".Equals(dataPARAMETERS[indexPara].in_out))
                            {
                                DATA_TYPE = dataPARAMETERS[indexPara].data_type;
                                PARAMETER_NAME = dataPARAMETERS[indexPara].argument_name;
                                parm.Add(PARAMETER_NAME, dbType: OracleMappingType.Int64, direction: ParameterDirection.Output);
                                indexPara = indexPara + 1;

                                bool checkColumn = false;
                                string[] Columns = listColumn.Split(',');
                                foreach (string Column in Columns)
                                {
                                    if (dataPARAMETERS[indexPara].argument_name.Trim().ToLower().Equals(Column.Trim().ToLower()))
                                    {
                                        checkColumn = true;
                                        break;
                                    }
                                }
                                if (checkColumn)
                                {
                                    parm.Add(dataPARAMETERS[indexPara].argument_name, AES.EncryptString(values[i].ToString(), KeyDecrypt));
                                }
                                else
                                {
                                    parm.Add(dataPARAMETERS[indexPara].argument_name, values[i]);
                                }
                            }
                            else
                            {
                                string[] Columns = listColumn.Split(',');
                                bool checkColumn = false;
                                foreach (string Column in Columns)
                                {
                                    if (dataPARAMETERS[indexPara].argument_name.Trim().ToLower().Equals(Column.ToLower()))
                                    {
                                        checkColumn = true;
                                        break;
                                    }
                                }
                                if (checkColumn)
                                {
                                    parm.Add(dataPARAMETERS[indexPara].argument_name, AES.EncryptString(values[i].ToString(), KeyDecrypt));
                                }
                                else
                                {
                                    parm.Add(dataPARAMETERS[indexPara].argument_name, values[i]);
                                }

                            }
                            indexPara = indexPara + 1;
                        }

                        parm.Add("ListColumnDecrypt", listColumn);
                        parm.Add("KeyDecrypt", KeyDecrypt);

                    }

                    int result = 0;

                    result = con.Execute(spName, parm, commandType: CommandType.StoredProcedure);
                    if (string.IsNullOrEmpty(PARAMETER_NAME))
                    {
                        return result.ToString();
                    }
                    else
                    {
                        string clientId = string.Empty;
                        clientId = parm.GetParameter(PARAMETER_NAME).Value.ToString();
                        return clientId.ToString();
                    }
                }


            }
            catch (Exception ex)
            {
                logError.Info("ExecuteInsertEncrypt: " + ex.ToString());
                return string.Empty;
            }


        }


        public string ExecuteUpdateEncrypt(string spName, string listColumn, params object[] values)
        {
            ///Thực hiện store, values là các biến đưa vào stored theo thứ tự           
            if (string.IsNullOrEmpty(spName))
                throw new ArgumentException("Không đưa tên stored");
            if (string.IsNullOrEmpty(listColumn))
                throw new ArgumentException("Không đưa danh sách cột mã hóa");

            List<ALL_ARGUMENTS> dataPARAMETERS = null;

            //Lấy thông tin trường bảng trong mencache
            // MemcacheConnection mencache = new MemcacheConnection();
            //  dataPARAMETERS = (List<ALL_ARGUMENTS>)mencache.getMemcacheByKey("ALL_ARGUMENTS" + spName);
            if (dataPARAMETERS == null)
            {
                if (HttpContext.Current.Session["ALL_ARGUMENTS" + spName] != null)
                {
                    dataPARAMETERS = (List<ALL_ARGUMENTS>)HttpContext.Current.Session["ALL_ARGUMENTS" + spName];
                }
                else
                {
                    ImpALL_ARGUMENTS impALL_ARGUMENTS = new ImpALL_ARGUMENTS();
                    dataPARAMETERS = impALL_ARGUMENTS.GetALL_ARGUMENTSByProcedure(spName);
                    HttpContext.Current.Session["ALL_ARGUMENTS" + spName] = dataPARAMETERS;
                }
            }


            string DATA_TYPE = string.Empty;
            string PARAMETER_NAME = string.Empty;
            string KeyDecrypt = AES.CreateKey(9);

            try
            {
                var connection = new OracleConnection(Common.getConnStrOracle());
                using (var con = connection)
                {
                    var parm = new OracleDynamicParameters();
                    if (values != null && values.Length > 0)
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            string[] Columns = listColumn.Split(',');
                            bool checkColumn = false;
                            foreach (string Column in Columns)
                            {
                                if (dataPARAMETERS[i].argument_name.Trim().ToLower().Equals(Column.ToLower()))
                                {
                                    checkColumn = true;
                                    break;
                                }
                            }
                            if (checkColumn)
                            {
                                parm.Add(dataPARAMETERS[i].argument_name, AES.EncryptString(values[i].ToString(), KeyDecrypt));
                            }
                            else
                            {
                                parm.Add(dataPARAMETERS[i].argument_name, values[i]);
                            }
                        }
                    }

                    int result = 0;
                    result = con.Execute(spName, parm, commandType: CommandType.StoredProcedure);
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                logError.Info("ExecuteUpdate: " + ex.ToString());
                return string.Empty;
            }
        }



    }
}
