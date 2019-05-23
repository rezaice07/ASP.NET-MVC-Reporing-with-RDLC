using ASPNETMVCReporting.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETMVCReporting.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ExportOrderHistory(string reportingType)
        {
            var orderHistories = new List<OrderHistoryModel>();

            using (var db = new APSNETReportingContext())
            {
                var sqlCommand = $"Order_GetOrderListing";

                orderHistories = db.Database.SqlQuery<OrderHistoryModel>(sqlCommand).ToList();
            }

            string format = "pdf";
            string type = "view";

            if (reportingType == "DownloadPdf" || reportingType == "DownloadWord" || reportingType == "DownloadExcel")
            {
                type = "download";
                if (reportingType == "DownloadWord")
                {
                    format = "word";
                }
                else if (reportingType == "DownloadExcel")
                {
                    format = "excel";
                }
            }

            return Report(orderHistories, format, type);
        }

        #region reporting

        public ActionResult Report(List<OrderHistoryModel> orderHistories, string format = "pdf", string type = "view")
        {            
            ReportDataSource reportDataSource = new ReportDataSource();

            reportDataSource.Name = "OrderHistoryInformation";
            reportDataSource.Value = orderHistories;
            string reportPath = "";
            reportPath = @"~/Reporting/OrderHistoryReport.rdlc";
            string reportName = "OrderHistoryInformation_" + DateTime.UtcNow.AddHours(6).ToShortDateString() + "_" + DateTime.UtcNow.AddHours(6).ToShortTimeString();

            string reportTitle = "";
            reportTitle = "Order History Reporting";
            return ReportGenerator(reportDataSource, format, reportPath, reportTitle, reportName, type);
        }

        public ActionResult ReportGenerator(ReportDataSource reportDataSource, string format, string reportPath, string reportTitle, string reportName, string type = "view")
        {          
            format = format.Trim().ToLower();
            if (string.IsNullOrEmpty(format))
            {
                format = "pdf";
            }
            else if (format != "pdf" && format != "word" && format != "excel")
            {
                format = "pdf";
            }
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath(reportPath);
            localReport.DataSources.Add(reportDataSource);

            ReportParameter reportTitleParam = new ReportParameter("ReportTitle", reportTitle);
            
            localReport.SetParameters(new ReportParameter[] {              
                reportTitleParam
            });

            string reportType = format; //"Image";            
            string mimeType;
            string encoding;
            string fileNameExtension;
            //The DeviceInfo settings should be changed based on the reportType            
            //http://msdn2.microsoft.com/en-us/library/ms155397.aspx   

            string deviceInfo = "<DeviceInfo>" +
               "  <OutputFormat>PDF</OutputFormat>" +
               "  <PageWidth>8.27in</PageWidth>" +
               "  <PageHeight>11.69in</PageHeight>" +
               "  <MarginTop>0.25in</MarginTop>" +
               "  <MarginLeft>0.75in</MarginLeft>" +
               "  <MarginRight>0.25in</MarginRight>" +
               "  <MarginBottom>0.25in</MarginBottom>" +
               "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            //Render the report            
            renderedBytes = localReport.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

            if (format == "pdf")
            {
                if (type == "view")
                {
                    return File(renderedBytes, mimeType);
                }
                else
                {
                    reportName = reportName + ".pdf";
                    return File(renderedBytes, mimeType, reportName);
                }
            }
            else if (format == "word")
            {
                if (type == "view")
                {
                    return File(renderedBytes, mimeType);
                }
                else
                {
                    reportName = reportName + ".doc";
                    return File(renderedBytes, mimeType, reportName);
                }
            }
            else
            {
                reportName = reportName + ".xls";
                return File(renderedBytes, mimeType, reportName);
            }
        }

        #endregion
    }
}