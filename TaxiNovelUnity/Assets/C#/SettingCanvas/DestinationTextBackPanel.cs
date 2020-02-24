using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class DestinationTextBackPanel : MonoBehaviour
{
    [SerializeField] private Text backPanelText;
    private int preByteCount = 0;
    private const string encodingType = "Shift_JIS";
    private RectTransform rectTransform;
    
    private void Start()
    {
        preByteCount = Encoding.GetEncoding(encodingType).GetByteCount(backPanelText.text);
        rectTransform = this.gameObject.GetComponent<RectTransform>();
        SizeChange(preByteCount);
    }
    
    private void Update()
    {
        int byteCount = Encoding.GetEncoding(encodingType).GetByteCount(backPanelText.text);

        if (byteCount != preByteCount)
        {
            SizeChange(byteCount);
        }
        
        preByteCount = Encoding.GetEncoding(encodingType).GetByteCount(backPanelText.text);
    }

    private void SizeChange(int byteCount)
    {
        int width = byteCount * 25 + 50;
        if (byteCount == 0)
        {
            width = 0;
        }
        rectTransform.sizeDelta = new Vector2(width, rectTransform.sizeDelta.y);
    }
}
