using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstValues;
using System.Text;
using System.IO;
using System;
using ConstValues;
using Fungus;

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
            if (oneRow == "")
            {
                continue;
            }
            
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
            if (oneRow == "")
            {
                continue;
            }
            
            var csvQuestData = oneRow.Split(General.comma);
            
            var oneRowQuestData = new QuestData((QuestKey) Enum.Parse(typeof(QuestKey), csvQuestData[0]), int.Parse(csvQuestData[1]));
            
            csvQuestDataList.Add(oneRowQuestData);
        }

        return csvQuestDataList;
    }

    public static List<EndingData> LoadEndingData()
    {
        var loadPath = MultiPathCombine.Combine(PathData.TextDataPath, PathData.ResourcesFolder.TextData, PathData.TextFolder.EndingData + General.csv);

        var rowData = LoadCsvData(loadPath);

        var csvEndingDataList = new List<EndingData>();

        foreach (var oneRow in rowData)
        {
            if (oneRow == "")
            {
                continue;
            }

            var csvEndingData = oneRow.Split(General.comma);
            
            var oneRowEndingData = new EndingData((EndingKey)Enum.Parse(typeof(EndingKey), csvEndingData[0]), int.Parse(csvEndingData[1]));
            
            csvEndingDataList.Add(oneRowEndingData);
        }

        return csvEndingDataList;
    }

    public static int[] LoadTimeData()
    {
        var loadPath = MultiPathCombine.Combine(PathData.TextDataPath, PathData.ResourcesFolder.TextData, PathData.TextFolder.PlayTime + General.csv);
        var timeStrings = LoadCsvData(loadPath)[0].Split(General.comma);
        return new int[] {int.Parse(timeStrings[0]), int.Parse(timeStrings[1]), int.Parse(timeStrings[2])};
    }
    
    public static void SaveTime()
    {
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
        
        //セーブアイコン表示時のコード
        /*
        if (IsGameSceneCheck.GameSceneCheck.Check())
        {
            SaveIcon.Instance.StartIconCoroutine();
        }
        */
        
        EditorDebug.Log("選択肢を保存しました。Key：" + debugLogKey +", Value：" + debugLogValue);
    }

    public static void SaveQuest(QuestData questData)
    {
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
        
        //セーブアイコン表示時のコード
        /*
        if (IsGameSceneCheck.GameSceneCheck.Check())
        {
            SaveIcon.Instance.StartIconCoroutine();
        }
        */
        
        EditorDebug.Log("クエストを保存しました。Key：" + debugLogKey +", Value：" + debugLogValue);
    }

    public static void SaveEnding(EndingData endingData)
    {
        var savePath = MultiPathCombine.Combine(PathData.TextDataPath, PathData.ResourcesFolder.TextData,
            PathData.TextFolder.EndingData + General.csv);

        var endingDataHolder = EndingDataHolder.Instance;

        var endingDataHolderEndingDataList = new List<EndingData>(endingDataHolder.endingDataList);
        
        var debugLogKey = "";
        var debugLogValue = "";

        foreach (var endingDataHolderEndingData in endingDataHolderEndingDataList)
        {
            if (endingDataHolderEndingData.key == endingData.key)
            {
                endingDataHolderEndingData.progress = endingData.progress;
                debugLogKey = endingData.key.ToString();
                debugLogValue = endingData.progress.ToString();
                break;
            }
        }

        endingDataHolder.endingDataList = endingDataHolderEndingDataList;

        var saveStr = "";

        foreach (var endingDataHolderEndingData in endingDataHolderEndingDataList)
        {
            saveStr += endingDataHolderEndingData.key.ToString() + General.comma + endingDataHolderEndingData.progress;
            saveStr += General.crlf;
        }

        saveStr = saveStr.Trim(General.crlf);
        
        WriteCsvData(savePath, saveStr);

        EditorDebug.Log("エンディングデータを保存しました・Key：" + debugLogKey + ", Value：" + debugLogValue);
    }
}