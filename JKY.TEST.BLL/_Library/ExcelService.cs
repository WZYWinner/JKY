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
            FileDownloadService.MemoryStream2Client(ms, HttpContext.Current, "���ݵ���.xls");
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

            Worksheet sheet = xls.Workbook.Worksheets.Add("���±���");//״̬����������  
            Cells cells = sheet.Cells;
            foreach (DataColumn col in table.Columns)
            {
                colIndex++;
                //sheet.Cells.AddValueCell(1,colIndex,col.ColumnName);//���XLS������  

                Cell cell = cells.Add(1, colIndex, col.ColumnName.ToString());//ת��Ϊ������  
                cell.Font.Bold = true;  //����Ϊ����              

                //cell.Font.FontFamily = FontFamilies.Roman; //����  
            }
            foreach (DataRow row in table.Rows)
            {
                rowIndex++;
                colIndex = 0;
                foreach (DataColumn col in table.Columns)
                {
                    colIndex++;
                    //sheet.Cells.AddValueCell(rowIndex, colIndex, row[col.ColumnName].ToString());//��������ӵ�xls�����  
                    Cell cell = cells.Add(rowIndex, colIndex, row[col.ColumnName].ToString());//ת��Ϊ������  
                    //��������ݿ�������ݶ������ֵĻ� ���ת��һ�£���Ȼ���뵽Excel�������ַ�����ʽ��ʾ��  
                    //cell.Font.FontFamily = FontFamilies.Roman; //����  
                    //cell.Font.Bold = true;  //����Ϊ����              
                }
            }
            xls.Save(filePath, true);

            /////////////////////////

            FileDownloadService.DownloadFile2Client(fileName, filePath,
                "���ݵ���.xls", HttpContext.Current);

        }







    }


}