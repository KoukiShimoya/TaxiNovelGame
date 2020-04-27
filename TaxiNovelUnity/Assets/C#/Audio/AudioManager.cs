using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ConstValues;
using UnityEngine.Audio;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    [SerializeField] private AudioSource[] audioSources = new AudioSource[9];
    private float bgmValue;
    private float seValue;
    [SerializeField] private AudioMixer audioMixer;

    public AudioSource[] GetAudioSource
    {
        get { return audioSources; }
    }
    
    private void Awake()
    {
        //InitializedSceneで発火
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void Start()
    {
        float[] audioValueData = SaveLoadCsvFile.LoadAudioVolumeData();
        bgmValue = audioValueData[0];
        SetBgmValue(bgmValue);
        seValue = audioValueData[1];
        SetSeValue(seValue);
    }

    private void SceneLoaded(Scene loadedScene, LoadSceneMode mode)
    {
        if (loadedScene.name == SceneName.StartScene.ToString())
        {
            StopAllAudioSources();
            audioSources[0].Play();
            PlayStartSceneMusic();
        }
        else if (loadedScene.name == SceneName.JK_North_Scene.ToString())
        {
            StopAllAudioSources();
            audioSources[0].Play();
        }
        else if (loadedScene.name == SceneName.Element_BeforeThugs_Scene.ToString())
        {
            StopAllAudioSources();
            audioSources[0].Play();
            audioSources[1].Play();
        }
        else if (loadedScene.name == SceneName.OL_Central_Scene.ToString())
        {
            StopAllAudioSources();
            audioSources[0].Play();
            audioSources[1].Play();
            audioSources[2].Play();
        }
        else if (loadedScene.name == SceneName.Thugs_Central_Scene.ToString())
        {
            StopAllAudioSources();
            audioSources[0].Play();
            audioSources[1].Play();
            audioSources[2].Play();
            audioSources[3].Play();
        }
        else if (loadedScene.name == SceneName.Clerk_Central_Scene.ToString())
        {
            StopAllAudioSources();
            audioSources[0].Play();
            audioSources[1].Play();
            audioSources[2].Play();
            audioSources[3].Play();
            
            List<ChoiceData> choiceDataList = ChoiceDataHolder.Instance.choiceDataList;
            foreach (var choiceData in choiceDataList)
            {
                if (choiceData.key == ChoiceKey.NoMeetThugs_MeetThugs)
                {
                    if (choiceData.choiceNumber == 1)
                    {
                        audioSources[4].Play();
                    }
                }
            }
        }
        else if (loadedScene.name == SceneName.Worker_South_Scene.ToString())
        {
            StopAllAudioSources();
            audioSources[0].Play();
            audioSources[1].Play();
            audioSources[2].Play();
            audioSources[3].Play();
            
            List<ChoiceData> choiceDataList = ChoiceDataHolder.Instance.choiceDataList;
            foreach (var choiceData in choiceDataList)
            {
                if (choiceData.key == ChoiceKey.NoMeetThugs_MeetThugs)
                {
                    if (choiceData.choiceNumber == 1)
                    {
                        audioSources[4].Play();
                    }
                }
            }
            
            audioSources[5].Play();
        }
        else if (loadedScene.name == SceneName.Worker_Central_Scene.ToString())
        {
            audioSources[0].Play();
            audioSources[1].Play();
            audioSources[2].Play();
            audioSources[3].Play();
            
            List<ChoiceData> choiceDataList = ChoiceDataHolder.Instance.choiceDataList;
            foreach (var choiceData in choiceDataList)
            {
                if (choiceData.key == ChoiceKey.NoMeetThugs_MeetThugs)
                {
                    if (choiceData.choiceNumber == 1)
                    {
                        audioSources[4].Play();
                    }
                }
            }
            
            audioSources[5].Play();
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
            audioSources[8].Play();
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


    private void PlayStartSceneMusic()
    {
        List<QuestData> questDataList = QuestDataHolder.Instance.questDataList;
        bool progressPoint = false;

        //リーマン
        foreach (var questData in questDataList)
        {
            if (questData.key == QuestKey.Worker)
            {
                if (questData.progress == 0)
                {
                    audioSources[1].Play();
                    audioSources[2].Play();
                    audioSources[3].Play();
            
                    List<ChoiceData> choiceDataList = ChoiceDataHolder.Instance.choiceDataList;
                    foreach (var choiceData in choiceDataList)
                    {
                        if (choiceData.key == ChoiceKey.NoMeetThugs_MeetThugs)
                        {
                            if (choiceData.choiceNumber == 1)
                            {
                                audioSources[4].Play();
                            }
                        }
                    }
            
                    audioSources[5].Play();
                    
                    break;
                }
            }
            else if (questData.key == QuestKey.Clerk)
            {
                if (questData.progress == 0)
                {
                    audioSources[1].Play();
                    audioSources[2].Play();
                    audioSources[3].Play();
            
                    List<ChoiceData> choiceDataList = ChoiceDataHolder.Instance.choiceDataList;
                    foreach (var choiceData in choiceDataList)
                    {
                        if (choiceData.key == ChoiceKey.NoMeetThugs_MeetThugs)
                        {
                            if (choiceData.choiceNumber == 1)
                            {
                                audioSources[4].Play();
                            }
                        }
                    }

                    break;
                }
            }
            else if (questData.key == QuestKey.Thugs)
            {
                if (questData.progress == 0)
                {
                    audioSources[1].Play();
                    audioSources[2].Play();
                    audioSources[3].Play();

                    break;
                }
            }
            else if (questData.key == QuestKey.OL)
            {
                if (questData.progress == 0)
                {
                    audioSources[1].Play();
                    audioSources[2].Play();

                    break;
                }
            }
            else if (questData.key == QuestKey.Element)
            {
                if (questData.progress == 0)
                {
                    audioSources[1].Play();

                    break;
                }
            }
        }

        /*
        EditorDebug.Log(audioSources[0].isPlaying.ToString() + audioSources[1].isPlaying.ToString() +
                        audioSources[2].isPlaying.ToString() + audioSources[3].isPlaying.ToString() +
                        audioSources[4].isPlaying.ToString() + audioSources[5].isPlaying.ToString());
                        */
    }

    public float GetBgmValue()
    {
        return bgmValue;
    }

    public float GetSeValue()
    {
        return seValue;
    }

    public void SetBgmValue(float value)
    {
        bgmValue = value;
        float mixerValue = LinearVolumeTDecibel(value, -12);
        audioMixer.SetFloat(AudioTag.BGM, mixerValue);
    }

    public void SetSeValue(float value)
    {
        seValue = value;
        float mixerValue = LinearVolumeTDecibel(value, 4);
        audioMixer.SetFloat(AudioTag.SE, mixerValue);
    }
    
    private float LinearVolumeTDecibel(float linearVolume, int thresould)
    {
        float decibel = 20.0f * Mathf.Log10(linearVolume);

        decibel += thresould;

        if (float.IsNegativeInfinity(decibel))
        {
            decibel = -96f;
        }

        return decibel;
    }
}
