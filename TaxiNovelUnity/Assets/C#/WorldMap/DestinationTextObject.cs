using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationTextObject : SingletonMonoBehaviour<DestinationTextObject>
{
    private UILanguageChange uiLanguageChange;
    private void Start()
    {
        uiLanguageChange = this.gameObject.GetComponent<UILanguageChange>();
    }

    public void ChangeDestinationText(string JP, string EN)
    {
        uiLanguageChange.ChangeText(JP, EN);
    }
}
