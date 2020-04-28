using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveIcon : SingletonMonoBehaviour<SaveIcon>
{
    private Image image;
    
    private void Start()
    {
        image = GetComponent<Image>();
        Color color = image.color;
        color.a = 0;
        image.color = color;
    }

    public void StartIconCoroutine()
    {
        StartCoroutine(SaveIconDisplay());
    }
    
    private IEnumerator SaveIconDisplay()
    {
        bool up = true;
        int exitCount = 2;
        int count = 0;
        float speed = 0.04f;
        
        while (true)
        {
            Color color = image.color;
            
            if (up)
            {
                color.a += speed;
                image.color = color;
                if (color.a >= 1)
                {
                    up = false;
                }
            }
            else
            {
                color.a -= speed;
                image.color = color;
                if (color.a <= 0)
                {
                    up = true;
                    count++;
                }
            }

            if (count == exitCount)
            {
                yield break;
            }
            
            yield return null;
        }
    }
}
