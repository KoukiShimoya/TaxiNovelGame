using ConstValues;
using UnityEngine;

public class InitializeDontDestroyOnLoad : SingletonMonoBehaviour<InitializeDontDestroyOnLoad>
{
    private bool loadNextScene = false;
    private void Start()
    {
        var ddolObject = Resources.LoadAll<GameObject>(Path.ResourcesFolder.DontDestroyOnLoad);
        GameObject ddolRoot = null;
        foreach (var obj in ddolObject)
        {
            if (obj.name.Contains(ObjectName.DDOLRoot))
            {
                ddolRoot = Instantiate(obj);
                DontDestroyOnLoad(ddolRoot);
                break;
            }
        }

        foreach (var obj in ddolObject)
        {
            if (obj.name.Contains(ObjectName.DDOLRoot))
            {
                continue;
            }

            var instantiatedObj = Instantiate(obj);
            instantiatedObj.transform.SetParent(ddolRoot.transform);
        }

        loadNextScene = true;
    }

    private void Update()
    {
        if (loadNextScene)
        {
            loadNextScene = false;
            SceneChange.Instance.NoPostEffectSceneChange(SceneName.StartScene);
        }
    }
}