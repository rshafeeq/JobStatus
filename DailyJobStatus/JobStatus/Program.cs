using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace JobStatus
{
    internal class Program
    {
        private static void Main()
        {
            ValidateData();
            CheckJobStatusBart();
           CheckJobStatusRc();
            CheckJobStatusRcLogs();
            Environment.Exit(0);

            //test

        }

        /// <summary>
        /// 
        /// </summary>
        public static void CheckJobStatusBart()
        {
            var ds = GetJobsDell990();
            var sb = new StringBuilder();
            for (var i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                switch (ds.Tables[0].Rows[i]["name"].ToString())
                {
                    case "BARTDTSRPT":
                        if (ds.Tables[0].Rows[i]["last_run_outcome"].ToString() == "0")
                        {
                            var date = ds.Tables[0].Rows[i]["last_run_date"].ToString();
                            var date2 = date.Insert(4, "/");
                            var time1 = ds.Tables[0].Rows[i]["last_run_time"].ToString();
                            var time2 = time1.Insert(2, ":");
                            sb.Append(ds.Tables[0].Rows[i]["name"] + " Job Failed at " + date2.Insert(7, "/") + " - " +
                                      time2.Insert(5, ":") + "\n\n");
                        }
                        break;
                    case "BARTListOFVal":

                        if (ds.Tables[0].Rows[i]["last_run_outcome"].ToString() == "0")
                        {
                            var date = ds.Tables[0].Rows[i]["last_run_date"].ToString();
                            var date2 = date.Insert(4, "/");
                            var time1 = ds.Tables[0].Rows[i]["last_run_time"].ToString();
                            var time2 = time1.Insert(2, ":");
                            sb.Append(ds.Tables[0].Rows[i]["name"] + " Job Failed at " + date2.Insert(7, "/") + " - " +
                                      time2.Insert(5, ":") + "\n\n");
                        }
                        break;
                }
            }
            if (sb.Length > 0)
            {
                SendMail("raashids@gtechv.com", sb.ToString(), "Bart", "raashid.khan@gmail.com");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        //public static void CheckJobStatusItems()
        //{
        //    var ds = GetJobsDell493();
        //    StringBuilder sb = new StringBuilder();
        //    for (var i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        //    {

        //        switch (ds.Tables[0].Rows[i]["name"].ToString())
        //        {
        //            case "01_Create_Item_Files_CRT":
        //                if (ds.Tables[0].Rows[i]["last_run_outcome"].ToString() == "0")
        //                {
        //                    var date = ds.Tables[0].Rows[i]["last_run_date"].ToString();
        //                    var date2 = date.Insert(4, "/");
        //                    var time1 = ds.Tables[0].Rows[i]["last_run_time"].ToString();
        //                    var time2 = time1.Insert(2, ":");
        //                    sb.Append(ds.Tables[0].Rows[i]["name"] + " Job Failed at " + date2.Insert(7, "/") + " - " +
        //                              time2.Insert(5, ":") + "\n\n");

        //                }
        //                break;
        //            case "01_Create_Item_Files_GMC":
        //                if (ds.Tables[0].Rows[i]["last_run_outcome"].ToString() == "0")
        //                {
        //                    var date = ds.Tables[0].Rows[i]["last_run_date"].ToString();
        //                    var date2 = date.Insert(4, "/");
        //                    var time1 = ds.Tables[0].Rows[i]["last_run_time"].ToString();
        //                    var time2 = time1.Insert(2, ":");
        //                    sb.Append(ds.Tables[0].Rows[i]["name"] + " Job Failed at " + date2.Insert(7, "/") + " - " +
        //                              time2.Insert(5, ":") + "\n");
        //                }
        //                break;

        //            case "01_Create_Item_Files_PG":
        //                if (ds.Tables[0].Rows[i]["last_run_outcome"].ToString() == "0")
        //                {
        //                    var date = ds.Tables[0].Rows[i]["last_run_date"].ToString();
        //                    var date2 = date.Insert(4, "/");
        //                    var time1 = ds.Tables[0].Rows[i]["last_run_time"].ToString();
        //                    var time2 = time1.Insert(2, ":");
        //                    sb.Append(ds.Tables[0].Rows[i]["name"] + " Job Failed at " + date2.Insert(7, "/") + " - " +
        //                              time2.Insert(5, ":") + "\n\n");
        //                }
        //                break;
        //        }
        //    }
        //    if (sb.Length > 0)
        //    {
        //        SendMail("raashids@gtechv.com", sb.ToString(), "Items Creation", "raashid.khan@gmail.com");
        //    }
        //}
        public static void CheckJobStatusRc()
        {
            var ds = GetJobsDell494();
            StringBuilder sb = new StringBuilder();
            for (var i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {

                switch (ds.Tables[0].Rows[i]["name"].ToString())
                {
                    case "RobertoCavalli":
                        if (ds.Tables[0].Rows[i]["last_run_outcome"].ToString() == "0")
                        {
                            var date = ds.Tables[0].Rows[i]["last_run_date"].ToString();
                            var date2 = date.Insert(4, "/");
                            var time1 = ds.Tables[0].Rows[i]["last_run_time"].ToString();
                            var time2 = time1.Insert(2, ":");
                            sb.Append(ds.Tables[0].Rows[i]["name"] + " Job Failed at " + date2.Insert(7, "/") + " - " +
                                      time2.Insert(5, ":") + "\n\n");

                        }
                        break;
                  
                }
            }
            if (sb.Length > 0)
            {
                SendMail("raashids@gtechv.com", sb.ToString(), "Roberto Cavalli Job Failed", "raashid.khan@gmail.com");
            }
        }

        public static void CheckJobStatusRcLogs()
        {
            var sb = new StringBuilder();
            var ds = GetJobsDell494Logs();
            if (Convert.ToDateTime(ds.Tables[0].Rows[0]["Period"]).ToString("yyyy-MM-dd") != DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"))
            {
                 sb.Append( " Job Failed at Invalid Period Date \n\n");
            }
            if (ds.Tables[0].Rows[0]["IsStock"].ToString() != "True")
            {
                  sb.Append("IsStock is not available \n\n");
            }
            if (ds.Tables[0].Rows[0]["IsCreateCSV"].ToString() != "True")
            {
                   sb.Append("Creation of CSV Failed CSV  \n\n");
            }
            if (ds.Tables[0].Rows[0]["IsUpload"].ToString() != "True")
            {
                sb.Append("IsUpload Failed \n\n");   
            }
            if (FileExistsOnFtp() == false)
            {
                sb.Append("File Not Uploaded on Suppliers FTP \n\n");  
            }
            if (sb.Length > 0)
            {
                SendMail("raashids@gtechv.com", sb.ToString(), "Roberto Cavalli Job Failed", "raashid.khan@gmail.com");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataSet GetJobsDell990()
        {
            const string connectionStringDell990 =
                "Data Source=Dell990;Initial Catalog=Analysis002;User ID=sa;Password=sherif1; Timeout=200";
            var con = new SqlConnection(connectionStringDell990);
            var daGetAll = new SqlDataAdapter("msdb.dbo.sp_help_job ", con)
                           {
                               SelectCommand =
                               {
                                   CommandType = CommandType.StoredProcedure
                               }
                           };
            var dsGetAll = new DataSet();
            try
            {
                con.Open();
                daGetAll.Fill(dsGetAll);
            }
            finally
            {
                con.Close();
                daGetAll.Dispose();
            }
            return dsGetAll;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataSet GetJobsDell493()
        {
            const string connectionStringDell990 =
                "Data Source=Dell493;Initial Catalog=JDER;User ID=sa;Password=sherif1; Timeout=200";
            var con = new SqlConnection(connectionStringDell990);
            var daGetAll = new SqlDataAdapter("msdb.dbo.sp_help_job ", con)
                           {
                               SelectCommand =
                               {
                                   CommandType = CommandType.StoredProcedure
                               }
                           };
            var dsGetAll = new DataSet();
            try
            {
                con.Open();
                daGetAll.Fill(dsGetAll);
            }
            finally
            {
                con.Close();
                daGetAll.Dispose();
            }
            return dsGetAll;
        }
        public static DataSet GetJobsDell494()
        {
            const string connectionStringDell990 =
                "Data Source=Dell494;Initial Catalog=RobertoCavalli;User ID=sa;Password=sherif1; Timeout=200";
            var con = new SqlConnection(connectionStringDell990);
            var daGetAll = new SqlDataAdapter("msdb.dbo.sp_help_job ", con)
            {
                SelectCommand =
                {
                    CommandType = CommandType.StoredProcedure
                }
            };
            var dsGetAll = new DataSet();
            try
            {
                con.Open();
                daGetAll.Fill(dsGetAll);
            }
            finally
            {
                con.Close();
                daGetAll.Dispose();
            }
            return dsGetAll;
        }
        public static DataSet GetJobsDell494Logs()
        {
            const string connectionStringDell990 =
                "Data Source=Dell494;Initial Catalog=RobertoCavalli;User ID=sa;Password=sherif1; Timeout=200";
            var con = new SqlConnection(connectionStringDell990);
            const string sql = "SELECT MAX(convert(date,[Period],112))as Period ,[IsStock],[IsCreateCSV],[IsUpload] " +
                               "FROM [RobertoCavalli].[dbo].[RCSchLog] group by [IsStock],[IsCreateCSV],[IsUpload]"; 
            var daGetAll = new SqlDataAdapter(sql, con)
            {
                SelectCommand =
                {
                    CommandType = CommandType.Text
                }
            };
            var dsGetAll = new DataSet();
            try
            {
                con.Open();
                daGetAll.Fill(dsGetAll);
            }
            finally
            {
                con.Close();
                daGetAll.Dispose();
            }
            return dsGetAll;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toAdd"></param>
        /// <param name="jobstatus"></param>
        /// <param name="subject"></param>
        /// <param name="cc"></param>
        public static void SendMail(string toAdd, String jobstatus, String subject, string cc)
        {
            var to = new MailAddress(toAdd);
            var copy = new MailAddress(cc);
            var from = new MailAddress("raashids@sara.com.sa");
            var mail = new MailMessage(from, to) {Subject = subject , Body = jobstatus};
            mail.CC.Add(copy);
            var smtp = new SmtpClient
                       {
                           Host = "outlook.office365.com",
                           Port = 587,
                           Credentials = new NetworkCredential("raashids@sara.com.sa", "sara@4578"),
                           EnableSsl = true
                       };

            smtp.Send(mail);
        }

        public static bool FileExistsOnFtp()
        {
            var request = (FtpWebRequest)WebRequest.Create("ftp://78.7.74.160/EXPORT/071875-" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + ".csv");
            request.Credentials = new NetworkCredential("071875", "Franchisee071875");
            request.Method = WebRequestMethods.Ftp.GetFileSize;
            var status=true;
            try
            {
                var response = (FtpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode ==
                    FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    status=false;
                        
                }
            }
            return status;
        }

        public static void ValidateData()
        {
            DataSet ds = GetSalesDataMaxDate();
            var sb = new StringBuilder();
            var sb1 = new StringBuilder();
            var sb2 = new StringBuilder();
            var subject = "";
            for (var i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                switch (ds.Tables[0].Rows[i]["Location"].ToString())
                {
                    case "Jeddah":
                        if (int.Parse(Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToString("yyMMdd")) <=
                            int.Parse(DateTime.Now.AddDays(-2).ToString("yyMMdd")))
                        {
                            if (int.Parse(Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToString("yyMMdd")) <=
                                int.Parse(DateTime.Now.AddDays(-4).ToString("yyMMdd")))
                            {
                                subject = "Need Attention for Store No " + ds.Tables[0].Rows[i]["STORE"];
                                sb.Append("************************************Need Attention***********************************************"+"\n");
                                sb.Append("Store:" + ds.Tables[0].Rows[i]["STORE"] + " Data did not appear from " +
                                          Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToString("dd/MM/yy") +
                                          "\n --> | Store Name:" + ds.Tables[0].Rows[i]["StoreName"] +
                                          "| Store IPAddress:" + ds.Tables[0].Rows[i]["StoreIP"] + " | Store IP Phone:" +
                                          ds.Tables[0].Rows[i]["IpPhone"] + "\n");
                                sb.Append("************************************************************************************************"+"\n");
                                sb1.Append("************************************Need Attention***********************************************"+"\n");
                                sb1.Append("Store:" + ds.Tables[0].Rows[i]["STORE"] + " Data did not appear from " +
                                          Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToString("dd/MM/yy") +
                                          "\n --> | Store Name:" + ds.Tables[0].Rows[i]["StoreName"] +
                                          "| Store IPAddress:" + ds.Tables[0].Rows[i]["StoreIP"] + " | Store IP Phone:" +
                                          ds.Tables[0].Rows[i]["IpPhone"] + "\n");
                                sb1.Append("************************************************************************************************"+"\n");
                            }
                            else
                            {
                                sb.Append("Store:" + ds.Tables[0].Rows[i]["STORE"] + " Data did not appear from " +
                                          Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToString("dd/MM/yy") +
                                          "\n --> | Store Name:" + ds.Tables[0].Rows[i]["StoreName"] +
                                          "| Store IPAddress:" + ds.Tables[0].Rows[i]["StoreIP"] + " | Store IP Phone:" +
                                          ds.Tables[0].Rows[i]["IpPhone"] + "\n");
                                sb.Append("_________________________________________________________________________________________________" + "\n");
                                sb1.Append("Store:" + ds.Tables[0].Rows[i]["STORE"] + " Data did not appear from " +
                                         Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToString("dd/MM/yy") +
                                         "\n --> | Store Name:" + ds.Tables[0].Rows[i]["StoreName"] +
                                         "| Store IPAddress:" + ds.Tables[0].Rows[i]["StoreIP"] + " | Store IP Phone:" +
                                         ds.Tables[0].Rows[i]["IpPhone"] + "\n");
                                sb1.Append("_________________________________________________________________________________________________" + "\n");
                               
                            }
                        }
                        break;
                    case "Riyadh":
                        if (int.Parse(Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToString("yyMMdd")) <=
                            int.Parse(DateTime.Now.AddDays(-2).ToString("yyMMdd")))
                        {
                            if (int.Parse(Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToString("yyMMdd")) <=
                                int.Parse(DateTime.Now.AddDays(-4).ToString("yyMMdd")))
                            {
                                subject = "Need Attention for Store No " + ds.Tables[0].Rows[i]["STORE"];
                                sb.Append("************************************Need Attention***********************************************"+"\n");
                                sb.Append("Store:" + ds.Tables[0].Rows[i]["STORE"] + " Data did not appear from " +
                                          Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToString("dd/MM/yy") +
                                          "\n --> | Store Name:" + ds.Tables[0].Rows[i]["StoreName"] +
                                          "| Store IPAddress:" + ds.Tables[0].Rows[i]["StoreIP"] + " | Store IP Phone:" +
                                          ds.Tables[0].Rows[i]["IpPhone"] + "\n");
                                sb.Append("************************************************************************************************"+"\n");
                                sb2.Append("************************************Need Attention***********************************************"+"\n");
                                sb2.Append("Store:" + ds.Tables[0].Rows[i]["STORE"] + " Data did not appear from " +
                                          Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToString("dd/MM/yy") +
                                          "\n --> | Store Name:" + ds.Tables[0].Rows[i]["StoreName"] +
                                          "| Store IPAddress:" + ds.Tables[0].Rows[i]["StoreIP"] + " | Store IP Phone:" +
                                          ds.Tables[0].Rows[i]["IpPhone"] + "\n");
                                sb2.Append("************************************************************************************************"+"\n");
                            }
                            else
                            {
                                sb.Append("Store:" + ds.Tables[0].Rows[i]["STORE"] + " Data did not appear from " +
                                          Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToString("dd/MM/yy") +
                                          "\n --> | Store Name:" + ds.Tables[0].Rows[i]["StoreName"] +
                                          "| Store IPAddress:" + ds.Tables[0].Rows[i]["StoreIP"] + " | Store IP Phone:" +
                                          ds.Tables[0].Rows[i]["IpPhone"] + "\n");
                                sb.Append("_________________________________________________________________________________________________" + "\n");
                               
                                sb2.Append("Store:" + ds.Tables[0].Rows[i]["STORE"] + " Data did not appear from " +
                                         Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToString("dd/MM/yy") +
                                         "\n --> | Store Name:" + ds.Tables[0].Rows[i]["StoreName"] +
                                         "| Store IPAddress:" + ds.Tables[0].Rows[i]["StoreIP"] + " | Store IP Phone:" +
                                         ds.Tables[0].Rows[i]["IpPhone"] + "\n");
                                sb2.Append("_________________________________________________________________________________________________" + "\n");
                               
                            }
                        }
                        break;
                    default:
                        if (int.Parse(Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToString("yyMMdd")) <=
                            int.Parse(DateTime.Now.AddDays(-2).ToString("yyMMdd")))
                        {
                            if (int.Parse(Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToString("yyMMdd")) <=
                                int.Parse(DateTime.Now.AddDays(-4).ToString("yyMMdd")))
                            {
                                subject = "Need Attention for Store No " + ds.Tables[0].Rows[i]["STORE"];
                                sb.Append("************************************Need Attention***********************************************"+"\n");
                                sb.Append("Store:" + ds.Tables[0].Rows[i]["STORE"] + " Data did not appear from " +
                                          Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToString("dd/MM/yy") +
                                          "\n --> | Store Name:" + ds.Tables[0].Rows[i]["StoreName"] +
                                          "| Store IPAddress:" + ds.Tables[0].Rows[i]["StoreIP"] + " | Store IP Phone:" +
                                          ds.Tables[0].Rows[i]["IpPhone"] + "\n");
                                sb.Append("************************************************************************************************"+"\n");
                            }
                            else
                            {
                                sb.Append("Store:" + ds.Tables[0].Rows[i]["STORE"] + " Data did not appear from " +
                                          Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]).ToString("dd/MM/yy") +
                                          "\n --> | Store Name:" + ds.Tables[0].Rows[i]["StoreName"] +
                                          "| Store IPAddress:" + ds.Tables[0].Rows[i]["StoreIP"] + " | Store IP Phone:" +
                                          ds.Tables[0].Rows[i]["IpPhone"] + "\n");
                                sb.Append("_________________________________________________________________________________________________" + "\n");
                               
                            }
                        }
                        break;
                }
            }
            if (sb1.Length > 0)
            {
               SendMail("mukram@sara.com.sa", sb1.ToString(), subject+" Sales Update Report ", "raashids@gtechv.com");
            }
            if (sb2.Length > 0)
            {
                SendMail("raashid.khan@gmail.com", sb2.ToString(), subject + " Sales Update Report  ", "raashidshafeeq@hotmail.com");
            }
            if (sb.Length > 0)
            {
                SendMail("raashids@gtechv.com", sb.ToString(), subject + " Sales Update Report ", "raashidshafeeq@hotmail.com");
            }
        }
        public static DataSet GetSalesDataMaxDate()
        {
            const string connectionStringDell493 =
                "Data Source=Dell493;Initial Catalog=JDER;User ID=sa;Password=sherif1; Timeout=200";
            var con = new SqlConnection(connectionStringDell493);
            const string sql = "  SELECT  Max(convert(date,IDC.DDATE)) Date,IDC.STORE,ST.StoreName,ST.StoreIP,ST.[IpPhone],ST.Location FROM IDCALL IDC " +
                               "left outer join StoreDetails ST on IDC.Store=ST.StoreNo " +
                               "where Store in (35,	65,	20,	44,	11,	34,	66,	38,	69,	50,	58,	60,	62,	90,	91,	04,	05,	06,	07,	85,	86,	32 " +
                               ",	37,	98,	03,	03,	22,	25,	78,	82,	52,	03,	13,	30,	47,	54,	71,	72,	04,	53,	21,	29,	93,	101,	99,	05,	07,1003 )" +
                               "group by IDC.[STORE], ST.StoreName, ST.StoreIP, ST.[IpPhone],ST.Location  order by store";
            var daGetAll = new SqlDataAdapter(sql, con)
            {
                SelectCommand =
                {
                    CommandTimeout = 0,
                    CommandType = CommandType.Text
                    
                }
            };
            var dsGetAll = new DataSet();
            try
            {
                con.Open();
                daGetAll.Fill(dsGetAll);
            }
            finally
            {
                con.Close();
                daGetAll.Dispose();
            }
            return dsGetAll;
        }
    }
}