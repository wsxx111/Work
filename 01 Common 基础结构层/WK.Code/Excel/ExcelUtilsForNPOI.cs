using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WK.Code.Excel
{
    class ExcelUtilsForNPOI
    {
        //表头样式
        public static HSSFCellStyle getTitleStytle(HSSFWorkbook book)
        {
            HSSFCellStyle cellstyle = (HSSFCellStyle)book.CreateCellStyle();
            //居中
            cellstyle.VerticalAlignment = VerticalAlignment.Center;
            cellstyle.Alignment = HorizontalAlignment.Center;
            //边框
            cellstyle.BorderBottom = BorderStyle.Thin;
            cellstyle.BorderLeft = BorderStyle.Thin;
            cellstyle.BorderRight = BorderStyle.Thin;
            cellstyle.BorderTop = BorderStyle.Thin;
            //背景颜色为绿色
            cellstyle.FillPattern = FillPattern.Squares;
            cellstyle.FillPattern = FillPattern.SolidForeground;
            cellstyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Yellow.Index;
            //字体
            HSSFFont font = (NPOI.HSSF.UserModel.HSSFFont)book.CreateFont();
            font.FontName = "宋体";
            font.FontHeightInPoints = 9;
            //font.Boldweight = 12 * 240;
            cellstyle.SetFont(font);
            return cellstyle;
        }
        //正常数据样式
        public static HSSFCellStyle getBodyStytle(HSSFWorkbook book)
        {
            HSSFCellStyle cellstyle = (HSSFCellStyle)book.CreateCellStyle();
            //居中
            cellstyle.VerticalAlignment = VerticalAlignment.Center;
            cellstyle.Alignment = HorizontalAlignment.Center;
            //边框
            cellstyle.BorderBottom = BorderStyle.Thin;
            cellstyle.BorderLeft = BorderStyle.Thin;
            cellstyle.BorderRight = BorderStyle.Thin;
            cellstyle.BorderTop = BorderStyle.Thin;
            //背景颜色为绿色
            cellstyle.FillPattern =  FillPattern.Squares;
            cellstyle.FillPattern = FillPattern.SolidForeground;
            cellstyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.White.Index;
            //字体
            HSSFFont font = (NPOI.HSSF.UserModel.HSSFFont)book.CreateFont();
            font.FontName = "宋体";
            font.FontHeightInPoints = 9;
            cellstyle.SetFont(font);
            //

            return cellstyle;
        }
        //其他数据样式
        public static HSSFCellStyle getOtherStytle(HSSFWorkbook book)
        {
            HSSFCellStyle cellstyle = (HSSFCellStyle)book.CreateCellStyle();
            //居中
            cellstyle.VerticalAlignment = VerticalAlignment.Center;
            cellstyle.Alignment = HorizontalAlignment.Center;
            //边框
            cellstyle.BorderBottom = BorderStyle.Thin;
            cellstyle.BorderLeft = BorderStyle.Thin;
            cellstyle.BorderRight = BorderStyle.Thin;
            cellstyle.BorderTop = BorderStyle.Thin;
            //背景颜色为绿色
            cellstyle.FillPattern = FillPattern.Squares;
            cellstyle.FillPattern = FillPattern.SolidForeground;
            cellstyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.White.Index;
            //字体
            HSSFFont font = (NPOI.HSSF.UserModel.HSSFFont)book.CreateFont();
            font.FontName = "宋体";
            font.FontHeightInPoints = 9;
            font.Color = (short)FontColor.Red;
            cellstyle.SetFont(font);
            //


            return cellstyle;
        }
        //条件样式
        public static HSSFCellStyle getConditionStytle(HSSFWorkbook book)
        {
            HSSFCellStyle cellstyle = (HSSFCellStyle)book.CreateCellStyle();
            //居中
            cellstyle.VerticalAlignment = VerticalAlignment.Center;
            cellstyle.Alignment = HorizontalAlignment.Center;
            //边框
            cellstyle.BorderBottom = BorderStyle.Thin;
            cellstyle.BorderLeft = BorderStyle.Thin;
            cellstyle.BorderRight = BorderStyle.Thin;
            cellstyle.BorderTop = BorderStyle.Thin;
            //背景颜色
            cellstyle.FillPattern = FillPattern.Squares;
            cellstyle.FillPattern = FillPattern.SolidForeground;
            cellstyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.White.Index;
            //字体
            HSSFFont font = (NPOI.HSSF.UserModel.HSSFFont)book.CreateFont();
            font.FontName = "宋体";
            font.FontHeightInPoints = 14;
            //font.Boldweight = 12 * 240;
            cellstyle.SetFont(font);
            return cellstyle;
        }
        //条件小字体
        public static HSSFCellStyle getConditionStytleSmallFont(HSSFWorkbook book)
        {
            HSSFCellStyle cellstyle = (HSSFCellStyle)book.CreateCellStyle();
            //居中
            cellstyle.VerticalAlignment = VerticalAlignment.Center;
            cellstyle.Alignment = HorizontalAlignment.Center;
            //边框
            cellstyle.BorderBottom = BorderStyle.Thin;
            cellstyle.BorderLeft = BorderStyle.Thin;
            cellstyle.BorderRight = BorderStyle.Thin;
            cellstyle.BorderTop = BorderStyle.Thin;
            //背景颜色
            cellstyle.FillPattern = FillPattern.Squares;
            cellstyle.FillPattern = FillPattern.SolidForeground;
            cellstyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.White.Index;
            //字体
            HSSFFont font = (NPOI.HSSF.UserModel.HSSFFont)book.CreateFont();
            font.FontName = "宋体";
            font.FontHeightInPoints = 10;
            //font.Boldweight = 12 * 240;
            cellstyle.SetFont(font);
            return cellstyle;
        }
        /// 合并单元格
        /// </summary>
        /// <param name="sheet">要合并单元格所在的sheet</param>
        /// <param name="rowstart">开始行的索引</param>
        /// <param name="rowend">结束行的索引</param>
        /// <param name="colstart">开始列的索引</param>
        /// <param name="colend">结束列的索引</param>
        public static void SetCellRangeAddress(ISheet sheet, int rowstart, int rowend, int colstart, int colend)
        {
            CellRangeAddress cellRangeAddress = new CellRangeAddress(rowstart, rowend, colstart, colend);
            sheet.AddMergedRegion(cellRangeAddress);
            //合并后的单元格添加边框
            ((HSSFSheet)sheet).SetEnclosedBorderOfRegion(cellRangeAddress, BorderStyle.Thin, NPOI.HSSF.Util.HSSFColor.Black.Index);

        }
        /// 合并单元格
        /// </summary>
        /// <param name="sheet">要合并单元格所在的sheet</param>
        /// <param name="indexs">要合并的单元格的集合</param>
        ///一般在整个表格建立完毕后调用
        public static void SetCellRangeAddress(ISheet sheet, int[][] indexs)
        {
            for (int i = 0; i < indexs.Length; i++)
            {
                CellRangeAddress cellRangeAddress = new CellRangeAddress(indexs[i][0], indexs[i][1], indexs[i][2], indexs[i][3]);
                sheet.AddMergedRegion(cellRangeAddress);
                //合并后的单元格添加边框
                ((HSSFSheet)sheet).SetEnclosedBorderOfRegion(cellRangeAddress, BorderStyle.Thin, NPOI.HSSF.Util.HSSFColor.Black.Index);
            }

        }
    }
}
