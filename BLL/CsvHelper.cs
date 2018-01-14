using System.Data;
using System.IO;

namespace Topicsys.BLL
{
    /// <summary>
    /// CSV文件转换类
    /// </summary>
    public static class CsvHelper
    {
        /// <summary>
        /// 导出报表为Csv
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="strFilePath">物理路径</param>
        public static bool dt2csv(string strFilePath, DataTable dt)
        {
            try
            {
                string strBufferLine = "";
                StreamWriter strmWriterObj = new StreamWriter(strFilePath, false, System.Text.Encoding.UTF8);
                /// 写入列名
                string strColumns = "";
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (i < dt.Columns.Count - 1)
                    {
                        strColumns += dt.Columns[i].ColumnName + ",";
                    }
                    else
                    {
                        strColumns += dt.Columns[i].ColumnName;
                    }
                }

                strmWriterObj.WriteLine(strColumns);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strBufferLine = "";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j > 0)
                            strBufferLine += ",";
                        strBufferLine += dt.Rows[i][j].ToString();
                    }
                    strmWriterObj.WriteLine(strBufferLine);
                }
                strmWriterObj.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 将Csv读入DataTable
        /// </summary>
        /// <param name="filePath">csv文件路径</param>
        /// <param name="n">表示第n行是字段title,第n+1行是记录开始</param>
        public static DataTable csv2dt(string filePath, int n, DataTable dt)
        {
            StreamReader reader = new StreamReader(filePath, System.Text.Encoding.UTF8, false);
            int i = 0, m = 0;
            reader.Peek();
            while (reader.Peek() > 0)
            {
                m = m + 1;
                string str = reader.ReadLine();
                if (m >= n + 1)
                {
                    string[] split = str.Split(',');

                    System.Data.DataRow dr = dt.NewRow();
                    try
                    {
                        for (i = 0; i < split.Length; i++)
                        {
                            dr[i] = split[i].Replace("\"", "");
                        }
                        dt.Rows.Add(dr);
                    }
                    catch (System.Exception)
                    {
                        continue;
                    }
                }
            }
            return dt;
        }
    }
}