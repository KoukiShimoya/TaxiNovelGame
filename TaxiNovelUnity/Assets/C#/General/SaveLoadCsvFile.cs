using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstValues;
using System.Text;
using System.IO;
using System;
using ConstValues;

public static class SaveLoadCsvFile
{
    public static string[] LoadCsvData(string path)
    {
        var fileInfo = new FileInfo(path);

        string readText = "";
        
        try {
            using (StreamReader sr = new StreamReader(fileInfo.OpenRead(), Encoding.UTF8)) {
                readText = sr.ReadToEnd();
            }
        } catch (Exception e) {
            EditorDebug.Log(e);
        }
        
        var rowData = readText.Split(General.crlf);
        return rowData;
    }

    public static void WriteCsvData(string path, string text)
    {
        var fileInfo = new FileInfo(path);
        using (StreamWriter sw = fileInfo.CreateText()) {
            sw.Write(text);
        }
    }

    public static List<ChoiceData> LoadChoiceData()
    {
        var loadPath = MultiPathCombine.Combine(PathData.TextDataPath, PathData.ResourcesFolder.TextData, PathData.TextFolder.ChoiceData + General.csv);
        
        var rowData = LoadCsvData(loadPath);
        
        var csvChoiceDataList = new List<ChoiceData>();

        foreach (var oneRow in rowData)
        {
            var csvChoiceData = oneRow.Split(General.comma);
            
            var oneRowChoiceData = new ChoiceData((ChoiceKey) Enum.Parse(typeof(ChoiceKey), csvChoiceData[0]), int.Parse(csvChoiceData[1]));
            
            csvChoiceDataList.Add(oneRowChoiceData);
        }

        return csvChoiceDataList;
    }

    public static List<QuestData> LoadQuestData()
    {
        var loadPath = MultiPathCombine.Combine(PathData.TextDataPath, PathData.ResourcesFolder.TextData, PathData.TextFolder.QuestData + General.csv);

        var rowData = LoadCsvData(loadPath);

        var csvQuestDataList = new List<QuestData>();

        foreach (var oneRow in rowData)
        {
            var csvQuestData = oneRow.Split(General.comma);
            
            var oneRowQuestData = new QuestData((QuestKey) Enum.Parse(typeof(QuestKey), csvQuestData[0]), int.Parse(csvQuestData[1]));
            
            csvQuestDataList.Add(oneRowQuestData);
        }

        return csvQuestDataList;
    }

    public static int[] LoadTimeData()
    {
        var loadPath = MultiPathCombine.Combine(PathData.TextDataPath, PathData.ResourcesFolder.TextData, PathData.TextFolder.PlayTime + General.csv);
        var timeStrings = LoadCsvData(loadPath)[0].Split(General.comma);
        return new int[] {int.Parse(timeStrings[0]), int.Parse(timeStrings[1]), int.Parse(timeStrings[2])};
    }
    
    public static void SaveTime()
    {
        var encoding = Encoding.UTF8;
        
        var savePath = MultiPathCombine.Combine(PathData.TextDataPath, PathData.ResourcesFolder.TextData,
            PathData.TextFolder.PlayTime + General.csv);
        
        var playTime = PlayTime.Instance;
        var hourString = playTime.GetHour.ToString();
        var minuteString = playTime.GetMinute.ToString();
        var secondString = playTime.GetSecond.ToString();
        
        WriteCsvData(savePath, hourString + General.comma + minuteString + General.comma + secondString);
        EditorDebug.Log("プレイ時間を保存しました");
    }

    public static void SaveChoice(ChoiceData choiceData)
    {
        var encoding = Encoding.UTF8;
        
        var savePath = MultiPathCombine.Combine(PathData.TextDataPath, PathData.ResourcesFolder.TextData,
            PathData.TextFolder.ChoiceData + General.csv);

        var choiceDataHolder = ChoiceDataHolder.Instance;

        var choiceDataHolderChoiceDataList = new List<ChoiceData>(choiceDataHolder.choiceDataList);

        var debugLogKey = "";
        var debugLogValue = "";

        foreach (var choiceDataHolderChoiceData in choiceDataHolderChoiceDataList)
        {
            if (choiceData.key == choiceDataHolderChoiceData.key)
            {
                choiceDataHolderChoiceData.choiceNumber = choiceData.choiceNumber;
                debugLogKey = choiceData.key.ToString();
                debugLogValue = choiceData.choiceNumber.ToString();
                break;
            }
        }

        choiceDataHolder.choiceDataList = choiceDataHolderChoiceDataList;

        var saveStr = "";
        
        foreach (var choiceDataHolderChoiceData in choiceDataHolderChoiceDataList)
        {
            saveStr += choiceDataHolderChoiceData.key.ToString() + General.comma + choiceDataHolderChoiceData.choiceNumber;
            saveStr += General.crlf;
        }

        saveStr = saveStr.Trim(General.crlf);
        
        WriteCsvData(savePath, saveStr);
        EditorDebug.Log("選択肢を保存しました。Key：" + debugLogKey +", Value：" + debugLogValue);
    }

    public static void SaveQuest(QuestData questData)
    {
        var encoding = Encoding.UTF8;
        
        var savePath = MultiPathCombine.Combine(PathData.TextDataPath, PathData.ResourcesFolder.TextData,
            PathData.TextFolder.QuestData + General.csv);

        var questDataHolder = QuestDataHolder.Instance;

        var questDataHolderQuestDataList = new List<QuestData>(questDataHolder.questDataList);
        
        var debugLogKey = "";
        var debugLogValue = "";

        foreach (var questDataHolderQuestData in questDataHolderQuestDataList)
        {
            if (questDataHolderQuestData.key == questData.key)
            {
                questDataHolderQuestData.progress = questData.progress;
                debugLogKey = questData.key.ToString();
                debugLogValue = questData.progress.ToString();
                break;
            }
        }

        questDataHolder.questDataList = questDataHolderQuestDataList;

        var saveStr = "";

        foreach (var questDataHolderQuestData in questDataHolderQuestDataList)
        {
            saveStr += questDataHolderQuestData.key.ToString() + General.comma + questDataHolderQuestData.progress;
            saveStr += General.crlf;
        }

        saveStr = saveStr.Trim(General.crlf);
        
        WriteCsvData(savePath, saveStr);
        EditorDebug.Log("クエストを保存しました。Key：" + debugLogKey +", Value：" + debugLogValue);
    }
}

[System.Serializable]
public class ChoiceData
{
    public ChoiceKey key;
    public int choiceNumber;

    public ChoiceData(ChoiceKey key, int choiceNumber)
    {
        this.key = key;
        this.choiceNumber = choiceNumber;
    }
}

[System.Serializable]
public class QuestData
{
    public QuestKey key;
    public int progress;

    public QuestData(QuestKey key, int progress)
    {
        this.key = key;
        this.progress = progress;
    }
}

[System.Serializable]
public enum QuestKey
{
    None,
    JK,
    Elementary,
    OL,
    Thugs,
    Clerk,
    Worker
}

[System.Serializable]
public enum ChoiceKey
{
    None,
    Something_Book,
    FindThugs
}
