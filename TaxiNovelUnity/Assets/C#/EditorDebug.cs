using UnityEngine;

/// <summary>
/// ビルド時にDebug.Logを一括で消すためのクラス
/// </summary>
public static class EditorDebug
{
    public static void Log(object message)
    {
        Debug.Log(message);
    }
    
    public static void DrawLine(Vector3 start, Vector3 end, Color color)
    {
        Debug.DrawLine(start, end, color);
    }
}
