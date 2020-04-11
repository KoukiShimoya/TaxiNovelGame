using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Text text;
    [SerializeField] private AudioType audioType;
    private AudioManager audioManager;
    
    private void Start()
    {
        audioManager = AudioManager.Instance;
        
        switch (audioType)
        {
            case AudioType.BGM:
                slider.value = audioManager.GetBgmValue();
                text.text = Math.Round(slider.value, 1).ToString();
                break;
            
            case AudioType.SE:
                slider.value = audioManager.GetSeValue();
                text.text = Math.Round(slider.value, 1).ToString();
                break;
            
            default:
                EditorDebug.LogError("そのAudioTypeは存在しません");
                break;
        }
    }
    
    public void OnValueChanged()
    {
        text.text = Math.Round(slider.value, 1).ToString();

        switch (audioType)
        {
            case AudioType.BGM:
                audioManager.SetBgmValue(slider.value);
                break;
            
            case AudioType.SE:
                audioManager.SetSeValue(slider.value);
                break;
            
            default:
                EditorDebug.LogError("そのAudioTypeは存在しません");
                break;
        }
    }

    public void OnPointerUp()
    {
        SaveLoadCsvFile.SaveAudioVolume(); 
    }

    public enum AudioType
    {
        BGM,
        SE
    }
}
