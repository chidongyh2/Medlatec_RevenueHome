using CMS_Core.Entity;
using CMS_Core.Implementtion;
using Dapper;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CMS_Core.Common
{
    public class SQLServerConnection<AnyType>
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public List<AnyType> SelectQueryCommand(string spName, params object[] values)
        {
            ///Thực hiện stored (values là danh sách các biến theo thứ tự) trả về bảng
            if (string.IsNullOrEmpty(spName))
                throw new ArgumentException("Không đưa tên stored");

            List<INFORMATION_SCHEMA_PARAMETERS> dataPARAMETERS = null;

            //Lấy thông tin trường bảng trong mencache
           
            if (dataPARAMETERS == null)
            {
                if (HttpContext.Current.Session["INFORMATION_SCHEMA_PARAMETERS" + spName] != null)
                {
                    dataPARAMETERS = (List<INFORMATION_SCHEMA_PARAMETERS>)HttpContext.Current.Session["INFORMATION_SCHEMA_PARAMETERS" + spName];
                }
                else
                {
                    ImpINFORMATION_SCHEMA_PARAMETERS impINFORMATION_SCHEMA_PARAMETERS = new ImpINFORMATION_SCHEMA_PARAMETERS();
                    dataPARAMETERS = impINFORMATION_SCHEMA_PARAMETERS.GetINFORMATION_SCHEMA_PARAMETERSByProcedure(spName);
                    HttpContext.Current.Session["INFORMATION_SCHEMA_PARAMETERS" + spName] = dataPARAMETERS;
                    
                }
            }

            try
            {
                var connection = new SqlConnection(Common.getConnectionString());
                using (var con = connection)
                {
                    var parm = new DynamicParameters();
                    if (values != null && values.Length > 0)
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            parm.Add(dataPARAMETERS[i].PARAMETER_NAME, values[i]);
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
                var connection = new SqlConnection(Common.getConnectionString());
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

        public string ExecuteInsert(string spName, params object[] values)
        {
            ///Thực hiện store, values là các biến đưa vào stored theo thứ tự           
            if (string.IsNullOrEmpty(spName))
                throw new ArgumentException("Không đưa tên stored");

            List<INFORMATION_SCHEMA_PARAMETERS> dataPARAMETERS = null;
            
           // dataPARAMETERS = (List<INFORMATION_SCHEMA_PARAMETERS>)mencache.getMemcacheByKey("INFORMATION_SCHEMA_PARAMETERS" + spName);
            if (dataPARAMETERS == null)
            {
                if (HttpContext.Current.Session["INFORMATION_SCHEMA_PARAMETERS" + spName] != null)
                {
                    dataPARAMETERS = (List<INFORMATION_SCHEMA_PARAMETERS>)HttpContext.Current.Session["INFORMATION_SCHEMA_PARAMETERS" + spName];
                }
                else
                {
                    ImpINFORMATION_SCHEMA_PARAMETERS impINFORMATION_SCHEMA_PARAMETERS = new ImpINFORMATION_SCHEMA_PARAMETERS();
                    dataPARAMETERS = impINFORMATION_SCHEMA_PARAMETERS.GetINFORMATION_SCHEMA_PARAMETERSByProcedure(spName);
                    HttpContext.Current.Session["INFORMATION_SCHEMA_PARAMETERS" + spName] = dataPARAMETERS;
                   // mencache.setMemcacheMinutesByKey("INFORMATION_SCHEMA_PARAMETERS" + spName, dataPARAMETERS);
                }
            }

            string DATA_TYPE = string.Empty;
            string PARAMETER_NAME = string.Empty;

            try
            {
                var connection = new SqlConnection(Common.getConnectionString());
                using (var con = connection)
                {
                    var parm = new DynamicParameters();
                    int indexPara = 0;
                    if (values != null && values.Length > 0)
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            if ("INOUT".Equals(dataPARAMETERS[indexPara].PARAMETER_MODE))
                            {
                                DATA_TYPE = dataPARAMETERS[indexPara].DATA_TYPE;
                                PARAMETER_NAME = dataPARAMETERS[indexPara].PARAMETER_NAME;
                                if ("bigint".Equals(DATA_TYPE))
                                {
                                    parm.Add(PARAMETER_NAME, dbType: DbType.Int64, direction: ParameterDirection.Output);
                                }
                                else
                                {
                                    parm.Add(PARAMETER_NAME, dbType: DbType.Int32, direction: ParameterDirection.Output);
                                }
                                indexPara = indexPara + 1;
                                parm.Add(dataPARAMETERS[indexPara].PARAMETER_NAME, values[i]);
                            }
                            else
                            {
                                parm.Add(dataPARAMETERS[indexPara].PARAMETER_NAME, values[i]);
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
                        string clientId = "";
                        if ("bigint".Equals(DATA_TYPE))
                        {
                            clientId = parm.Get<Int64>(PARAMETER_NAME).ToString();
                        }
                        else
                        {
                            clientId = parm.Get<int>(PARAMETER_NAME).ToString();
                        }

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


        public string ExecuteInsertEncrypt(string spName, string listColumn, params object[] values)
        {
            ///Thực hiện store, values là các biến đưa vào stored theo thứ tự           
            if (string.IsNullOrEmpty(spName))
                throw new ArgumentException("Không đưa tên stored");

            if (string.IsNullOrEmpty(listColumn))
                throw new ArgumentException("Không đưa danh sách cột mã hóa");


            List<INFORMATION_SCHEMA_PARAMETERS> dataPARAMETERS = null;
            
            if (dataPARAMETERS == null)
            {
                if (HttpContext.Current.Session["INFORMATION_SCHEMA_PARAMETERS" + spName] != null)
                {
                    dataPARAMETERS = (List<INFORMATION_SCHEMA_PARAMETERS>)HttpContext.Current.Session["INFORMATION_SCHEMA_PARAMETERS" + spName];
                }
                else
                {
                    ImpINFORMATION_SCHEMA_PARAMETERS impINFORMATION_SCHEMA_PARAMETERS = new ImpINFORMATION_SCHEMA_PARAMETERS();
                    dataPARAMETERS = impINFORMATION_SCHEMA_PARAMETERS.GetINFORMATION_SCHEMA_PARAMETERSByProcedure(spName);
                    HttpContext.Current.Session["INFORMATION_SCHEMA_PARAMETERS" + spName] = dataPARAMETERS;
                   
                }
            }

            string DATA_TYPE = string.Empty;
            string PARAMETER_NAME = string.Empty;
            string KeyDecrypt = AES.CreateKey(9);


            try
            {
                var connection = new SqlConnection(Common.getConnectionString());
                using (var con = connection)
                {
                    var parm = new DynamicParameters();
                    int indexPara = 0;
                    if (values != null && values.Length > 0)
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            if ("INOUT".Equals(dataPARAMETERS[indexPara].PARAMETER_MODE))
                            {
                                DATA_TYPE = dataPARAMETERS[indexPara].DATA_TYPE;
                                PARAMETER_NAME = dataPARAMETERS[indexPara].PARAMETER_NAME;
                                if ("bigint".Equals(DATA_TYPE))
                                {
                                    parm.Add(PARAMETER_NAME, dbType: DbType.Int64, direction: ParameterDirection.Output);
                                }
                                else
                                {
                                    parm.Add(PARAMETER_NAME, dbType: DbType.Int32, direction: ParameterDirection.Output);
                                }
                                indexPara = indexPara + 1;

                                bool checkColumn = false;
                                string[] Columns = listColumn.Split(',');
                                foreach (string Column in Columns)
                                {
                                    if (dataPARAMETERS[indexPara].PARAMETER_NAME.Trim().ToLower().Equals("@" + Column.Trim().ToLower()))
                                    {
                                        checkColumn = true;
                                        break;
                                    }
                                }
                                if (checkColumn)
                                {
                                    parm.Add(dataPARAMETERS[indexPara].PARAMETER_NAME, AES.EncryptString(values[i].ToString(), KeyDecrypt));
                                }
                                else
                                {
                                    parm.Add(dataPARAMETERS[indexPara].PARAMETER_NAME, values[i]);
                                }
                            }
                            else
                            {
                                string[] Columns = listColumn.Split(',');
                                bool checkColumn = false;
                                foreach (string Column in Columns)
                                {
                                    if (dataPARAMETERS[indexPara].PARAMETER_NAME.Trim().ToLower().Equals("@" + Column.ToLower()))
                                    {
                                        checkColumn = true;
                                        break;
                                    }
                                }
                                if (checkColumn)
                                {
                                    parm.Add(dataPARAMETERS[indexPara].PARAMETER_NAME, AES.EncryptString(values[i].ToString(), KeyDecrypt));
                                }
                                else
                                {
                                    parm.Add(dataPARAMETERS[indexPara].PARAMETER_NAME, values[i]);
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
                        string clientId = "";
                        if ("bigint".Equals(DATA_TYPE))
                        {
                            clientId = parm.Get<Int64>(PARAMETER_NAME).ToString();
                        }
                        else
                        {
                            clientId = parm.Get<int>(PARAMETER_NAME).ToString();
                        }

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

        public string ExecuteUpdateEncrypt(string spName, string listColumn, params object[] values)
        {
            ///Thực hiện store, values là các biến đưa vào stored theo thứ tự           
            if (string.IsNullOrEmpty(spName))
                throw new ArgumentException("Không đưa tên stored");
            if (string.IsNullOrEmpty(listColumn))
                throw new ArgumentException("Không đưa danh sách cột mã hóa");

            List<INFORMATION_SCHEMA_PARAMETERS> dataPARAMETERS = null;
           
            if (dataPARAMETERS == null)
            {
                if (HttpContext.Current.Session["INFORMATION_SCHEMA_PARAMETERS" + spName] != null)
                {
                    dataPARAMETERS = (List<INFORMATION_SCHEMA_PARAMETERS>)HttpContext.Current.Session["INFORMATION_SCHEMA_PARAMETERS" + spName];
                }
                else
                {
                    ImpINFORMATION_SCHEMA_PARAMETERS impINFORMATION_SCHEMA_PARAMETERS = new ImpINFORMATION_SCHEMA_PARAMETERS();
                    dataPARAMETERS = impINFORMATION_SCHEMA_PARAMETERS.GetINFORMATION_SCHEMA_PARAMETERSByProcedure(spName);
                    HttpContext.Current.Session["INFORMATION_SCHEMA_PARAMETERS" + spName] = dataPARAMETERS;
                   
                }
            }

            string DATA_TYPE = string.Empty;
            string PARAMETER_NAME = string.Empty;
            string KeyDecrypt = AES.CreateKey(9);

            try
            {
                var connection = new SqlConnection(Common.getConnectionString());
                using (var con = connection)
                {
                    var parm = new DynamicParameters();
                    if (values != null && values.Length > 0)
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            string[] Columns = listColumn.Split(',');
                            bool checkColumn = false;
                            foreach (string Column in Columns)
                            {
                                if (dataPARAMETERS[i].PARAMETER_NAME.Trim().ToLower().Equals("@" + Column.ToLower()))
                                {
                                    checkColumn = true;
                                    break;
                                }
                            }
                            if (checkColumn)
                            {
                                parm.Add(dataPARAMETERS[i].PARAMETER_NAME, AES.EncryptString(values[i].ToString(), KeyDecrypt));
                            }
                            else
                            {
                                parm.Add(dataPARAMETERS[i].PARAMETER_NAME, values[i]);
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

        public string ExecuteNonQuery(string spName, params object[] values)
        {
            ///Thực hiện store, values là các biến đưa vào stored theo thứ tự           
            if (string.IsNullOrEmpty(spName))
                throw new ArgumentException("Không đưa tên stored");

            List<INFORMATION_SCHEMA_PARAMETERS> dataPARAMETERS = null;
            //Lấy thông tin trường bảng trong mencache
            //MemcacheConnection mencache = new MemcacheConnection();
            //dataPARAMETERS = (List<INFORMATION_SCHEMA_PARAMETERS>)mencache.getMemcacheByKey("INFORMATION_SCHEMA_PARAMETERS" + spName);
            if (dataPARAMETERS == null)
            {
                if (HttpContext.Current.Session["INFORMATION_SCHEMA_PARAMETERS" + spName] != null)
                {
                    dataPARAMETERS = (List<INFORMATION_SCHEMA_PARAMETERS>)HttpContext.Current.Session["INFORMATION_SCHEMA_PARAMETERS" + spName];
                }
                else
                {
                    ImpINFORMATION_SCHEMA_PARAMETERS impINFORMATION_SCHEMA_PARAMETERS = new ImpINFORMATION_SCHEMA_PARAMETERS();
                    dataPARAMETERS = impINFORMATION_SCHEMA_PARAMETERS.GetINFORMATION_SCHEMA_PARAMETERSByProcedure(spName);
                    HttpContext.Current.Session["INFORMATION_SCHEMA_PARAMETERS" + spName] = dataPARAMETERS;
                   // mencache.setMemcacheMinutesByKey("INFORMATION_SCHEMA_PARAMETERS" + spName, dataPARAMETERS);
                }
            }

            string DATA_TYPE = string.Empty;
            string PARAMETER_NAME = string.Empty;

            try
            {
                var connection = new SqlConnection(Common.getConnectionString());
                using (var con = connection)
                {
                    var parm = new DynamicParameters();
                    if (values != null && values.Length > 0)
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            parm.Add(dataPARAMETERS[i].PARAMETER_NAME, values[i]);
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

        public object ExecuteScalar(string spName, params object[] values)
        {
            object value = DBNull.Value;

            ///Thực hiện store, values là các biến đưa vào stored theo thứ tự           
            if (string.IsNullOrEmpty(spName))
                throw new ArgumentException("Không đưa tên stored");

            List<INFORMATION_SCHEMA_PARAMETERS> dataPARAMETERS = null;
            //Lấy thông tin trường bảng trong mencache
            //MemcacheConnection mencache = new MemcacheConnection();
            //dataPARAMETERS = (List<INFORMATION_SCHEMA_PARAMETERS>)mencache.getMemcacheByKey("INFORMATION_SCHEMA_PARAMETERS" + spName);
            if (dataPARAMETERS == null)
            {
                if (HttpContext.Current.Session["INFORMATION_SCHEMA_PARAMETERS" + spName] != null)
                {
                    dataPARAMETERS = (List<INFORMATION_SCHEMA_PARAMETERS>)HttpContext.Current.Session["INFORMATION_SCHEMA_PARAMETERS" + spName];
                }
                else
                {
                    ImpINFORMATION_SCHEMA_PARAMETERS impINFORMATION_SCHEMA_PARAMETERS = new ImpINFORMATION_SCHEMA_PARAMETERS();
                    dataPARAMETERS = impINFORMATION_SCHEMA_PARAMETERS.GetINFORMATION_SCHEMA_PARAMETERSByProcedure(spName);
                    HttpContext.Current.Session["INFORMATION_SCHEMA_PARAMETERS" + spName] = dataPARAMETERS;
                  //  mencache.setMemcacheMinutesByKey("INFORMATION_SCHEMA_PARAMETERS" + spName, dataPARAMETERS);
                }
            }

            string DATA_TYPE = string.Empty;
            string PARAMETER_NAME = string.Empty;

            try
            {
                var connection = new SqlConnection(Common.getConnectionString());
                using (var con = connection)
                {
                    var parm = new DynamicParameters();
                    if (values != null && values.Length > 0)
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            parm.Add(dataPARAMETERS[i].PARAMETER_NAME, values[i]);
                        }
                    }
                    value = con.ExecuteScalar(spName, parm, commandType: CommandType.StoredProcedure);

                    

                    return value;
                }
            }
            catch (Exception ex)
            {
                logError.Info("ExecuteDelete: " + ex.ToString());
                return null;
            }
        }
    }
}
