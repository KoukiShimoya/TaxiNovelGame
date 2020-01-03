using System.Collections;
using System.Collections.Generic;
using ConstValues;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayTime : SingletonMonoBehaviour<PlayTime>
{
    [SerializeField] private int hour;

    public int GetHour
    {
        get { return hour; }
    }

    [SerializeField] private int minute;
    public int GetMinute
    {
        get { return minute; }
    }

    [SerializeField] private int second;
    public int GetSecond
    {
        get { return second; }
    }

    private float decimalPoint;
    private void Start()
    {
        int[] timeData = SaveLoadCsvFile.LoadTimeData();
        hour = timeData[0];
        minute = timeData[1];
        second = timeData[2];
        decimalPoint = 0f;

        SceneManager.activeSceneChanged += ActiveSceneChanged;
    }

    private void Update()
    {
        decimalPoint += Time.deltaTime;
        if (decimalPoint > 1.0f)
        {
            second++;
            decimalPoint -= 1f;
            if (second >= 60)
            {
                minute++;
                second -= 60;
                if (minute >= 60)
                {
                    hour++;
                    minute -= 60;
                }
            }
        }
    }

    private void ActiveSceneChanged(Scene preScene, Scene nextScene)
    {
        SaveLoadCsvFile.SaveTime();
    }
}
