using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstValues;

public class StartSceneToGameScene : MonoBehaviour
{
    public void SceneChangeToGameScene()
    {
        SceneChange.Instance.FadeTextureAndSceneChange(SceneChange.FadeType.None, SceneName.TutorialScene);
    }
}
