using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destination : SingletonMonoBehaviour<Destination>
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float speed;
    private float time;

    private void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        spriteRenderer.color = GetAlphaColor(spriteRenderer.color);
    }
    
    private Color GetAlphaColor(Color color) {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.4f + 0.5f;
        color.a += 0.2f;
        if (color.a > 1f)
        {
            color.a = 1f;
        }

        return color;
    }
    
    
}
