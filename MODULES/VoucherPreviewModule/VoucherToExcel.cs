using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Excel=Microsoft.Office.Interop.Excel;
namespace AccountingReportsManagement.MODULES.VoucherPreviewModule
{
    class VoucherToExcel
    {
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        string path = "";
        public VoucherToExcel(string path,int sheet) 
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
        }
        public void WriteToCell(int rowNumber,int colNumber,string content) 
        {
            rowNumber++;
            colNumber++;
            ws.Cells[rowNumber, colNumber].Value2 = content;
        }

        public void SaveAs(string path) 
        {
            wb.SaveAs(path);
        }
        public void Close() 
        {
            wb.Close();
        }

    }
}
