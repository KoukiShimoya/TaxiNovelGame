using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstValues;
using System.Text;
using System.IO;

public static class SaveLoadCsvFile
{
    public static string[] LoadCsvData(string path)
    {
        var textAsset = Resources.Load<TextAsset>(path);
        var text = textAsset.text;
        var rowData = text.Split(General.crlf);
        return rowData;
    }
    
    /// <param name="loadPath">パスのみ</param>
    /// <param name="savePath">末尾にGeneral.csvが必要</param>
    public static void SaveCsvFile(string loadPath, string savePath, SAVETYPE saveType)
    {
        var encoding = Encoding.GetEncoding(General.EncodingType);
        var streamWriter = new StreamWriter(savePath, false, encoding);
        var rowData = LoadCsvData(loadPath);
        var saveStr = "";
        switch (saveType)
        {
            case SAVETYPE.Time:
                saveStr = SaveTime();
                break;
            default:
                Debug.LogError("CSVにセーブができません");
                break;
        }
        
        streamWriter.Write(saveStr);
        streamWriter.Flush();
        streamWriter.Close();
        Debug.Log("Accurate! "+saveType.ToString() + " saved.");
    }

    private static string SaveTime()
    {
        var playTime = PlayTime.Instance;
        var hourString = playTime.GetHour.ToString();
        var minuteString = playTime.GetMinute.ToString();
        var secondString = playTime.GetSecond.ToString();
        return hourString + General.comma + minuteString + General.comma + secondString;
    }

    public enum SAVETYPE
    {
        Time,
        Flag
    }
}
