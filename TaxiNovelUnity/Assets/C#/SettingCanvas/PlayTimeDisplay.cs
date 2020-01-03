using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTimeDisplay : MonoBehaviour
{
    private Text text;
    private PlayTime playTime;
    
    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
        playTime = PlayTime.Instance;
    }

    void Update()
    {
        text.text = playTime.GetHour.ToString() + "h" + playTime.GetMinute.ToString() + "m" +
                    playTime.GetSecond.ToString() + "s";
    }
}
