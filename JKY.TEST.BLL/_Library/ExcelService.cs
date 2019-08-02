using System;
using System.Linq;
using System.Collections.Generic;
using Yaohuasoft.Framework.DAL;
using Yaohuasoft.Framework.Library;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO;
using System.Web;
using System.Data;
using org.in2bits.MyXls;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;


namespace Yaohuasoft.Framework.BLL
{

    public class ExcelService
    {


        static public void DownloadExcel(DataTable table)
        {

            string fileName = YaohuaID.NewID() + ".xls";
            string filePath = SystemConfig.RootPath + "/_DownloadExcel/"
                + DateTime.Now.Date2String(YaohuaDateFormat.YYYY_MM_DD) + "/";

            MemoryStream ms = RenderToExcel(table);
            FileDownloadService.MemoryStream2Client(ms, HttpContext.Current, "数据导出.xls");
        }

        public static MemoryStream RenderToExcel(DataTable table)
        {
            MemoryStream ms = new MemoryStream();

            IWorkbook workbook = new HSSFWorkbook();

            ISheet sheet = workbook.CreateSheet();

            IRow headerRow = sheet.CreateRow(0);

            // handling header.
            foreach (DataColumn column in table.Columns)
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.Caption);//If Caption not set, returns the ColumnName value

            // handling value.
            int rowIndex = 1;

            foreach (DataRow row in table.Rows)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);

                foreach (DataColumn column in table.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                }

                rowIndex++;
            }

            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;


            return ms;
        }






        static public void DownloadExcel4File(DataTable table)
        {
            XlsDocument xls = new XlsDocument();
            int rowIndex = 1;
            int colIndex = 0;
            xls.FileName = YaohuaID.NewID();
            string fileName = xls.FileName;
            string filePath = SystemConfig.RootPath + "/_DownloadExcel/" + DateTime.Now.Date2String(YaohuaDateFormat.YYYY_MM_DD) + "/";
            YaohuaDirectory.Create(filePath);

            Worksheet sheet = xls.Workbook.Worksheets.Add("最新报表");//状态栏标题名称  
            Cells cells = sheet.Cells;
            foreach (DataColumn col in table.Columns)
            {
                colIndex++;
                //sheet.Cells.AddValueCell(1,colIndex,col.ColumnName);//添加XLS标题行  

                Cell cell = cells.Add(1, colIndex, col.ColumnName.ToString());//转换为数字型  
                cell.Font.Bold = true;  //字体为粗体              

                //cell.Font.FontFamily = FontFamilies.Roman; //字体  
            }
            foreach (DataRow row in table.Rows)
            {
                rowIndex++;
                colIndex = 0;
                foreach (DataColumn col in table.Columns)
                {
                    colIndex++;
                    //sheet.Cells.AddValueCell(rowIndex, colIndex, row[col.ColumnName].ToString());//将数据添加到xls表格里  
                    Cell cell = cells.Add(rowIndex, colIndex, row[col.ColumnName].ToString());//转换为数字型  
                    //如果你数据库里的数据都是数字的话 最好转换一下，不然导入到Excel里是以字符串形式显示。  
                    //cell.Font.FontFamily = FontFamilies.Roman; //字体  
                    //cell.Font.Bold = true;  //字体为粗体              
                }
            }
            xls.Save(filePath, true);

            /////////////////////////

            FileDownloadService.DownloadFile2Client(fileName, filePath,
                "数据导出.xls", HttpContext.Current);

        }







    }


}