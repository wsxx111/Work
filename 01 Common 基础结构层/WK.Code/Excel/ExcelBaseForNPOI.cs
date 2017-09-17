using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WK.Code.Excel
{
    public class ExcelBaseForNPOI
    {
        /// <summary>
        /// Excel生成
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="wbName">导出的Excel的名称</param>
        /// <param name="condition">拼接好的筛选条件</param>
        /// <param name="title">表头数组string[]</param>
        /// <param name="data">要导出的字段的数组</param>
        /// <param name="dataList">要导出的实体数据List<T></param>
        /// <param name="colWidth">列的宽度的数组int[]</param>
        /// <param name="flag">是否含有序号列flag</param>
        public static void excelExport<T>(string wbName, string condition, string[] title, string[] fields, IList<T> dataList, int[] colWidth, bool flag)
        {
            HSSFWorkbook book = new HSSFWorkbook();
            HSSFSheet sheet = book.CreateSheet(wbName) as HSSFSheet;
            // HSSFCellStyle conditionStyle = ExcelUtils.getConditionStytle(book);//条件样式
            HSSFCellStyle titleStyle = ExcelUtilsForNPOI.getTitleStytle(book);//表头样式
            HSSFCellStyle bodyStyle = ExcelUtilsForNPOI.getBodyStytle(book);//数据样式
            //填充条件
            //  ExcelCommonUtils.createCondition(sheet, 0, title.Length - 1, condition, conditionStyle);
            //填充表头
            ExcelBaseForNPOI.createTitle(sheet, 0, title, titleStyle);
            //填充数据
            ExcelBaseForNPOI.setBodyValue(sheet, 1, dataList, fields, bodyStyle, flag);
            for (int i = 0; i < colWidth.Length; i++)
            {
                sheet.SetColumnWidth(i, colWidth[i] * 256);
            }
            MemoryStream mes = new MemoryStream();
            book.Write(mes);
            System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.xls", string.IsNullOrEmpty(wbName) ? "" : "ex-file"));
            System.Web.HttpContext.Current.Response.BinaryWrite(mes.ToArray());
        }


        /// <summary>
        /// 创建excel的筛选条件 （动态的）
        /// </summary>
        /// <param name="sheet">excel中的sheet页</param>
        /// <param name="row">第几行插入筛选条件</param>
        /// <param name="lscol"></param>
        /// <param name="condition">筛选条件</param>
        /// <param name="style">样式</param>
        public static void createCondition(HSSFSheet sheet, int row, int lscol, string condition, HSSFCellStyle style)
        {
            HSSFRow hsshRow = sheet.CreateRow(row) as HSSFRow;
            hsshRow.Height = 2 * 256;

            for (int i = 0; i < lscol; i++)
            {

                HSSFCell cell = hsshRow.CreateCell(i) as HSSFCell;
                cell.CellStyle = style;

                if (i == 0)
                {
                    HSSFRichTextString richString;
                    if (condition == null)
                    {
                        richString = new HSSFRichTextString("");
                    }
                    else
                    {
                        richString = new HSSFRichTextString(condition);
                    }

                    cell.SetCellValue(richString);
                }
                else
                {
                    cell.SetCellValue("");
                }

            }
            ExcelUtilsForNPOI.SetCellRangeAddress(sheet, row, row, 0, lscol);
        }

        public static void createConditionH(HSSFSheet sheet, int row, int lscol, string condition, HSSFCellStyle style, int height)
        {
            HSSFRow hsshRow = sheet.CreateRow(row) as HSSFRow;
            hsshRow.Height = (short)(height * 256);

            for (int i = 0; i < lscol; i++)
            {

                HSSFCell cell = hsshRow.CreateCell(i) as HSSFCell;
                cell.CellStyle = style;

                if (i == 0)
                {
                    HSSFRichTextString richString;
                    if (condition == null)
                    {
                        richString = new HSSFRichTextString("");
                    }
                    else
                    {
                        richString = new HSSFRichTextString(condition);
                    }

                    cell.SetCellValue(richString);
                }
                else
                {
                    cell.SetCellValue("");
                }

            }
            ExcelUtilsForNPOI.SetCellRangeAddress(sheet, row, row, 0, lscol);
        }



        /// <summary>
        /// 创建excel的表头 （动态的）
        /// </summary>
        /// <param name="sheet"> excel中的sheet页</param>
        /// <param name="row">第几行插入表头</param>
        /// <param name="titles">表头的内容</param>
        /// <param name="style">表头的样式</param>
        public static void createTitle(HSSFSheet sheet, int row, String[] titles, HSSFCellStyle style)
        {
            HSSFRow hsshRow = sheet.CreateRow(row) as HSSFRow;
            hsshRow.Height = 500;

            for (int i = 0; i < titles.Length; i++)
            {
                HSSFCell cell = hsshRow.CreateCell(i) as HSSFCell;
                cell.CellStyle = style;

                String textValue = "";
                if (titles[i] != null)
                {
                    textValue = titles[i].ToString();
                }
                HSSFRichTextString richString = new HSSFRichTextString(textValue);
                cell.SetCellValue(richString);
            }
            freezePane(sheet, 1, row + 1);
        }

        public static void createTitle(HSSFSheet sheet, int row, List<string> titles, HSSFCellStyle style)
        {
            HSSFRow hsshRow = sheet.CreateRow(row) as HSSFRow;
            hsshRow.Height = 500;

            for (int i = 0; i < titles.Count; i++)
            {
                HSSFCell cell = hsshRow.CreateCell(i) as HSSFCell;
                cell.CellStyle = style;

                String textValue = "";
                if (titles[i] != null)
                {
                    textValue = titles[i].ToString();
                }
                HSSFRichTextString richString = new HSSFRichTextString(textValue);
                cell.SetCellValue(richString);
            }
            freezePane(sheet, 1, row + 1);
        }


        /// <summary>
        /// 设置主体数据  
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sheet">excel中的sheet页</param>
        /// <param name="row">在第几行插入数据主体</param>
        /// <param name="dataList">数据的list 泛型 T表示对应的Entity 例如 PolicyDetailsShowDto</param>
        /// <param name="fields">  要显示Dto中的变量数组，按照顺序填写</param>
        /// <param name="style">单元格的样式</param>
        /// <param name="serialFlag">是否需要序号</param>
        public static void setBodyValue<T>(HSSFSheet sheet, int row, IList<T> dataList, String[] fields, HSSFCellStyle style, bool serialFlag)
        {

            try
            {
                if (dataList == null)
                {
                    HSSFRow hssfRow = sheet.CreateRow(row) as HSSFRow;

                    HSSFCell cells = hssfRow.CreateCell(0) as HSSFCell;
                    cells.SetCellValue("您所查找的数据不存在！");
                }
                else
                {
                    for (int i = 0; i < dataList.Count; i++)
                    {
                        HSSFRow hssfRow = sheet.CreateRow(row + i) as HSSFRow;
                        hssfRow.Height = 600;
                        HSSFCell cells = null;
                        if (serialFlag)
                        {
                            // 设置序列号
                            cells = hssfRow.CreateCell(0) as HSSFCell;
                            cells.CellStyle = style;
                            cells.SetCellValue(i + 1);
                        }
                        //cells.SetCellValue(i + 1);
                        //object obj = Activator.CreateInstance(ObjectType);
                        T obj = (T)dataList[i];
                        Type objectType = obj.GetType();
                        for (int j = 0; j < fields.Length; j++)
                        {
                            if (serialFlag)
                            {
                                cells = hssfRow.CreateCell(j + 1) as HSSFCell;
                            }
                            else
                            {
                                cells = hssfRow.CreateCell(j) as HSSFCell;
                            }
                            String fieldName = fields[j];
                            Object value = null;
                            //String textValue = "";
                            if (null != fieldName && !"".Equals(fieldName))
                            {
                                //获取实体类中的属性
                                PropertyInfo property = objectType.GetProperty(fieldName);
                                //获取该属性的值
                                value = property.GetValue(obj, null);

                                if (null != value)
                                {
                                    cells.SetAsActiveCell();
                                    cells.CellStyle = style;
                                    Type propertyType = value.GetType();
                                    cells.SetCellValue(value.ToString());
                                    string propertyName = propertyType.Name;
                                    switch (propertyName)
                                    {
                                        case "String":
                                            cells.SetCellValue(new HSSFRichTextString(value.ToString()));
                                            break;
                                        case "DateTime":
                                            cells.SetCellValue(DateTime.Parse(value.ToString()).ToString("yyyy/MM/dd HH:mm:ss"));
                                            break;
                                        case "Int16":
                                        case "Int32":
                                        case "Int64":
                                        case "Byte":
                                            cells.SetCellValue(Int64.Parse(value.ToString()));
                                            break;
                                        case "Decimal":
                                        case "Double":
                                            cells.SetCellValue(double.Parse(value.ToString()));
                                            break;
                                        case "System.DBNull"://空值处理
                                            cells.SetCellValue("");
                                            break;
                                        default:
                                            cells.SetCellValue("");
                                            break;
                                    }
                                }
                                else
                                {
                                    cells.SetAsActiveCell();
                                    cells.CellStyle = style;
                                    cells.SetCellValue("");
                                }
                            }
                        }
                    }

                }


            }
            catch (Exception e)
            {
                string ErrorMessege = e.Message;
            }
        }


        //冻结窗口
        public static void freezePane(HSSFSheet sheet, int cloIndex, int rowIndex)
        {
            sheet.CreateFreezePane(cloIndex, rowIndex);
        }

    }
}
