using UnityEngine;
using System.ComponentModel;

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
    
    public static void DrawRay(Vector3 start, Vector3 dir)
    {
        bool depthTest = true;
        float duration = 0.0f;
        Color white = Color.white;
        EditorDebug.DrawRay(start, dir, white, duration, depthTest);
    }
    
    public static void DrawRay(Vector3 start, Vector3 dir, Color color)
    {
        bool depthTest = true;
        float duration = 0.0f;
        EditorDebug.DrawRay(start, dir, color, duration, depthTest);
    }
    
    public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration)
    {
        bool depthTest = true;
        EditorDebug.DrawRay(start, dir, color, duration, depthTest);
    }

    public static void DrawRay(
        Vector3 start,
        Vector3 dir,
        [DefaultValue("Color.white")] Color color,
        [DefaultValue("0.0f")] float duration,
        [DefaultValue("true")] bool depthTest)
    {
        Debug.DrawRay(start, dir, color, duration, depthTest);
    }
}
