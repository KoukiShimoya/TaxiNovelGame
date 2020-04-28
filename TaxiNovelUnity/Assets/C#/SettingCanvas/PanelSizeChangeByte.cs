using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PanelSizeChangeByte : MonoBehaviour
{
    [SerializeField] private Text backPanelText;
    private int preByteCount = 0;
    private RectTransform rectTransform;
    [SerializeField] private int oneWordSize;
    [SerializeField] private int defaultSize;
    
    private void Start()
    {
        preByteCount = CheckByte();
        rectTransform = this.gameObject.GetComponent<RectTransform>();
        SizeChange(preByteCount);
    }
    
    private void Update()
    {
        int nowByte = CheckByte();

        if (nowByte != preByteCount)
        {
            SizeChange(nowByte);
        }
        
        preByteCount = nowByte;
    }

    private void SizeChange(int byteCount)
    {
        int width = byteCount * oneWordSize + defaultSize;
        if (byteCount == 0)
        {
            width = 0;
        }
        rectTransform.sizeDelta = new Vector2(width, rectTransform.sizeDelta.y);
    }

    private int CheckByte()
    {
        if (NowActiveLanguage.GetSetLanguageCode == NowActiveLanguage.LanguageCode.JA)
        {
           return backPanelText.text.Length * 2;
        }
        else if (NowActiveLanguage.GetSetLanguageCode == NowActiveLanguage.LanguageCode.EN)
        {
            return backPanelText.text.Length;
        }
        else
        {
            return 0;
        }
    }
}
