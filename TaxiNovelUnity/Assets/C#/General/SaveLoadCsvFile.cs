using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstValues;
using System.Text;
using System.IO;
using ConstValues;

public static class SaveLoadCsvFile
{
    public static string[] LoadCsvData(string path)
    {
        var textAsset = Resources.Load<TextAsset>(path);
        var text = textAsset.text;
        var rowData = text.Split(General.crlf);
        return rowData;
    }

    private static List<ChoiceData> LoadChoiceData()
    {
        var loadPath = MultiPathCombine.Combine(PathData.ResourcesFolder.TextData, PathData.TextFolder.ChoiceData);
        
        var rowData = LoadCsvData(loadPath);
        
        var csvChoiceDataList = new List<ChoiceData>();

        foreach (var oneRow in rowData)
        {
            var csvChoiceData = oneRow.Split(General.comma);
            
            var oneRowChoiceData = new ChoiceData(csvChoiceData[0], int.Parse(csvChoiceData[1]));
            
            csvChoiceDataList.Add(oneRowChoiceData);
        }

        return csvChoiceDataList;
    }

    /// <param name="loadPath">パスのみ</param>
    /// <param name="savePath">末尾にGeneral.csvが必要</param>
    public static void SaveTime()
    {
        var encoding = Encoding.GetEncoding(General.EncodingType);
        
        var loadPath = MultiPathCombine.Combine(PathData.ResourcesFolder.TextData, PathData.TextFolder.PlayTime);
        var savePath = MultiPathCombine.Combine(PathData.ResourcesPath, PathData.ResourcesFolder.TextData,
            PathData.TextFolder.PlayTime + General.csv);
        
        var streamWriter = new StreamWriter(savePath, false, encoding);
        var rowData = LoadCsvData(loadPath);
        
        var playTime = PlayTime.Instance;
        var hourString = playTime.GetHour.ToString();
        var minuteString = playTime.GetMinute.ToString();
        var secondString = playTime.GetSecond.ToString();
        
        streamWriter.Write(hourString + General.comma + minuteString + General.comma + secondString);
        streamWriter.Flush();
        streamWriter.Close();
        EditorDebug.Log("プレイ時間を保存しました");
    }

    public static void SaveChoice(ChoiceData choiceData)
    {
        var encoding = Encoding.GetEncoding(General.EncodingType);
        
        var loadPath = MultiPathCombine.Combine(PathData.ResourcesFolder.TextData, PathData.TextFolder.ChoiceData);
        var savePath = MultiPathCombine.Combine(PathData.ResourcesPath, PathData.ResourcesFolder.TextData,
            PathData.TextFolder.ChoiceData + General.csv);
        
        var streamWriter = new StreamWriter(savePath, false, encoding);

        var csvChoiceDataList = LoadChoiceData();

        foreach (var csvChoiceData in csvChoiceDataList)
        {
            if (csvChoiceData.key == choiceData.key)
            {
                csvChoiceData.choiceNumber = choiceData.choiceNumber;
                break;
            }
        }

        var saveStr = "";
        
        foreach (var csvChoiceData in csvChoiceDataList)
        {
            saveStr += choiceData.key + General.comma + choiceData.choiceNumber;
            saveStr += General.crlf;
        }

        saveStr = saveStr.Trim(General.crlf);
        
        streamWriter.Write(saveStr);
        streamWriter.Flush();
        streamWriter.Close();
        EditorDebug.Log("選択肢を保存しました");
    }
}

[System.Serializable]
public class ChoiceData
{
    public string key;
    public int choiceNumber;

    public ChoiceData(string key, int choiceNumber)
    {
        this.key = key;
        this.choiceNumber = choiceNumber;
    }
}
