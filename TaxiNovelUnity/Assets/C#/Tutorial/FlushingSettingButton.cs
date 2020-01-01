using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ConstValues;

public class FlushingSettingButton : MonoBehaviour
{
    [SerializeField] private float speed;
    private float time;
    [SerializeField] private List<Text> textList;
    [SerializeField] private List<Image> imageList;
    private bool isPlayerExit = false;
    [HideInInspector] public bool doTutorial = false;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(TagName.Player))
        {
            isPlayerExit = true;
            if (!doTutorial)
            {
                doTutorial = true;
                StartCoroutine(FlashingButton());
            }
        }
    }

    /*
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag(TagName.Player))
        {
            isPlayerExit = false;
        }
    }
    */

    private IEnumerator FlashingButton()
    {
        while (true)
        {
            foreach (var text in textList)
            {
                text.color = GetAlphaColor(text.color);
            }

            foreach (var image in imageList)
            {
                image.color = GetAlphaColor(image.color);
            }


            if (!doTutorial)
            {
                foreach (var text in textList)
                {
                    text.color = SetDefaultAlpha(text.color);
                }

                foreach (var image in imageList)
                {
                    image.color = SetDefaultAlpha(image.color);
                }
                
                
                yield break;
            }
            
            yield return null;
        }
    }

    public void OnClick()
    {
        if (isPlayerExit)
        {
            doTutorial = false;
        }
    }
    
    private Color GetAlphaColor(Color color) {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }

    private Color SetDefaultAlpha(Color color)
    {
        color.a = 1f;
        return color;
    }
}
