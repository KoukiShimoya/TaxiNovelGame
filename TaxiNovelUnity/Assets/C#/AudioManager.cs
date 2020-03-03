using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ConstValues;
using UnityEngine.SceneManagement;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    [SerializeField] private AudioSource[] audioSources = new AudioSource[8];

    public AudioSource[] GetAudioSource
    {
        get { return audioSources; }
    }
    
    private void Awake()
    {
        //InitializedSceneで発火
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void SceneLoaded(Scene loadedScene, LoadSceneMode mode)
    {
        if (
            loadedScene.name == SceneName.StartScene.ToString() ||
            loadedScene.name == SceneName.JK_North_Scene.ToString() ||
            loadedScene.name == SceneName.Element_BeforeThugs_Scene.ToString() ||
            loadedScene.name == SceneName.OL_Central_Scene.ToString() ||
            loadedScene.name == SceneName.Thugs_Central_Scene.ToString() ||
            loadedScene.name == SceneName.Clerk_Central_Scene.ToString() ||
            loadedScene.name == SceneName.Worker_South_Scene.ToString()
            )
        {
            StopAllAudioSources();
            audioSources[0].Play();
            PlayMusicByQuestKey();
        }
        else if (loadedScene.name == SceneName.Worker_Central_Scene.ToString())
        {
            StopAllAudioSources();
            audioSources[0].Play();
            PlayMusicByQuestKey();
            audioSources[6].Play();
        }
        else if (
            loadedScene.name == SceneName.Ending_1.ToString() ||
            loadedScene.name == SceneName.Ending_2.ToString() ||
            loadedScene.name == SceneName.Ending_3.ToString() ||
            loadedScene.name == SceneName.Ending_4.ToString() ||
            loadedScene.name == SceneName.Ending_5.ToString() ||
            loadedScene.name == SceneName.Ending_6_1.ToString() ||
            loadedScene.name == SceneName.Ending_6_2.ToString()
        )
        {
            StopAllAudioSources();
            audioSources[0].Play();
            audioSources[1].Play();
        }
        else if (loadedScene.name == SceneName.Ending_6_3.ToString())
        {
            StopAllAudioSources();
            audioSources[7].Play();
        }
    }

    private void StopAllAudioSources()
    {
        foreach (var audioSource in audioSources)
        {
            audioSource.Stop();
        }
    }


    private void PlayMusicByQuestKey()
    {
        List<QuestData> questDataList = QuestDataHolder.Instance.questDataList;
        foreach (var questData in questDataList)
        {
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
    }
}
