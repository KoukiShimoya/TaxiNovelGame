using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ConstValues;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] audioSources = new AudioSource[7];

    public AudioSource[] GetAudioSource
    {
        get { return audioSources; }
    }
    
    private void Start()
    {
        audioSources[0].Play();
        List<QuestData> questDataList = QuestDataHolder.Instance.questDataList;
        foreach (var questData in questDataList)
        {
            if (SceneManager.GetActiveScene().name == SceneName.Ending_1.ToString())
            {
                audioSources[1].Play();
                break;
            }
            else if (SceneManager.GetActiveScene().name == SceneName.Ending_2.ToString())
            {
                audioSources[1].Play();
                break;
            }
            else if (SceneManager.GetActiveScene().name == SceneName.Ending_3.ToString())
            {
                audioSources[1].Play();
                break;
            }
            else if (SceneManager.GetActiveScene().name == SceneName.Ending_4.ToString())
            {
                audioSources[1].Play();
                break;
            }
            else if (SceneManager.GetActiveScene().name == SceneName.Ending_5.ToString())
            {
                audioSources[1].Play();
                break;
            }
            else if (SceneManager.GetActiveScene().name == SceneName.Ending_6_1.ToString())
            {
                audioSources[1].Play();
                break;
            }
            else if (SceneManager.GetActiveScene().name == SceneName.Ending_6_2.ToString())
            {
                audioSources[1].Play();
                break;
            }
            else if (SceneManager.GetActiveScene().name == SceneName.Ending_6_3.ToString())
            {
                audioSources[1].Play();
                break;
            }
            
            
            if (questData.key == QuestKey.JK)
            {
                if (questData.progress == 1)
                {
                    audioSources[1].Play();
                }
            }
            else if (questData.key == QuestKey.Elementary)
            {
                if (questData.progress == 1)
                {
                    audioSources[2].Play();
                }
            }
            else if (questData.key == QuestKey.OL)
            {
                if (questData.progress == 1)
                {
                    audioSources[3].Play();
                }
            }
            else if (questData.key == QuestKey.Thugs)
            {
                if (questData.progress == 1)
                {
                    audioSources[4].Play();
                }
            }
            else if (questData.key == QuestKey.Clerk)
            {
                if (questData.progress == 1)
                {
                    audioSources[5].Play();
                }
            }
        }

        if (SceneManager.GetActiveScene().name == SceneName.Worker_Central_Scene.ToString())
        {
            audioSources[6].Play();
        }
    }
}
