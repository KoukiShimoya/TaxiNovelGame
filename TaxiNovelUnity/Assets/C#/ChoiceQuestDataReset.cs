using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceQuestDataReset : MonoBehaviour
{
    public void OnClick()
    {
        SaveLoadCsvFile.SaveChoice(new ChoiceData(ChoiceKey.Something_Book, -1));
        SaveLoadCsvFile.SaveChoice(new ChoiceData(ChoiceKey.NoMeetThugs_MeetThugs, -1));
        SaveLoadCsvFile.SaveChoice(new ChoiceData(ChoiceKey.Letter_Courage, -1));
        SaveLoadCsvFile.SaveChoice(new ChoiceData(ChoiceKey.JapaneseSweets_Cake, -1));
        SaveLoadCsvFile.SaveChoice(new ChoiceData(ChoiceKey.TastyCandy_SaveCandy, -1));
        SaveLoadCsvFile.SaveChoice(new ChoiceData(ChoiceKey.Cute_LowRisk, -1));
        
        SaveLoadCsvFile.SaveQuest(new QuestData(QuestKey.JK, -1));
        SaveLoadCsvFile.SaveQuest(new QuestData(QuestKey.Element, -1));
        SaveLoadCsvFile.SaveQuest(new QuestData(QuestKey.OL, -1));
        SaveLoadCsvFile.SaveQuest(new QuestData(QuestKey.Thugs, -1));
        SaveLoadCsvFile.SaveQuest(new QuestData(QuestKey.Clerk, -1));
        SaveLoadCsvFile.SaveQuest(new QuestData(QuestKey.Worker, -1));
    }
}
