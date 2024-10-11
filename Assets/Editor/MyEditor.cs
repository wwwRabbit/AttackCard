using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;//文件流
using Excel;
using System.Data;

//编辑器脚本
public class MyEditor 
{
    [MenuItem("我的工具/excel转成txt")]
    public static void ExportExcelTotxt()
    {
        //_Excel文件夹路径
        string assetPath = Application.dataPath + "/_Excel";
       // Debug.Log("222222222222222");

        //Debug.Log(assetPath);

        //获得文件夹中的excel文件
        string[] files = Directory.GetFiles(assetPath, "*.xlsx");

        for (int i = 0; i < files.Length; i++)
        {
            
            files[i] = files[i].Replace('\\', '/');//斜杠替换
            //  Debug.Log(files[i]);

            //文件流读取文件
            using(FileStream fs=File.Open(files[i],FileMode.Open,FileAccess.Read))
            {
                //文件流转换成excel对象
                var excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                //获得excel数据
                DataSet dataSet = excelDataReader.AsDataSet();

                //读取excel第一张表
                DataTable table = dataSet.Tables[0];

                //表中内容读取后存到txt文档中
                readTableToTxt(files[i], table);

            }
        }

        //刷新编辑器
        AssetDatabase.Refresh();



    }
    private static void readTableToTxt(string filePath,DataTable table)
    {
        //获得文件名（不要文件后缀，生成同名txt文件）
        string fileName = Path.GetFileNameWithoutExtension(filePath);

       // Debug.Log(fileName);
        //txt文件的存储路径
        string path = Application.dataPath + "/Resources/Data/" + fileName + ".txt";

        //判断Resources/Data文件夹中是否已经存在对应的txt文件，如果是，则删除
        if (File.Exists(path))
        {
            File.Delete(path);
        }

        //文件流创造txt文件
        using(FileStream fs=new FileStream(path,FileMode.Create))
        {
            //文件流转写入流，方便写入字符串
            using(StreamWriter sw=new StreamWriter(fs))
            {
                //遍历table
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    DataRow dataRow = table.Rows[row];

                    string str = " ";
                    //遍历列
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        string val = dataRow[col].ToString();

                        str = str + val + "\t";//每一项tab分割
                    }

                    //写入
                    sw.Write(str);

                    //不是最后一行的话，换行
                    if (row!=table.Rows.Count-1)
                    {
                          sw.WriteLine();
                    }

                }
            }
        }

    }



}
