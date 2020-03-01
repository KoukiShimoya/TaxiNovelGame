using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Kirurobo;
using UnityEditor;
using UnityEngine;

public static class ResolutionStateHolder
{
    public enum ResolutionState
    {
        FullScreen,
        FullScreen_Windowed,
        R3840_2160,
        R2560_1440,
        R1920_1080,
        R1600_900,
        R1366_768,
        R1280_720
    }

    private static ResolutionState resolutionState;

    public static void ResolutionStateChange(ResolutionState state)
    {
        resolutionState = state;
        
        Screen.fullScreen = false;
        Screen.fullScreenMode = FullScreenMode.Windowed;
        
        switch (state)
        {
            case ResolutionState.FullScreen:
                Screen.fullScreen = true;
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
                
            case ResolutionState.FullScreen_Windowed:
                UniWinApi uniWin = new UniWinApi();
                var window = UniWinApi.FindWindow();
                uniWin.SetWindow(window);
                uniWin.Maximize();
                uniWin.Dispose();
                break;
            
            case ResolutionState.R3840_2160:
                Screen.SetResolution(3840, 2160, false);
                break;
            
            case ResolutionState.R2560_1440:
                Screen.SetResolution(2560, 1440, false);
                break;
                
            case ResolutionStateHolder.ResolutionState.R1920_1080:
                Screen.SetResolution(1920, 1080, false);
                break;
            
            case ResolutionState.R1600_900:
                Screen.SetResolution(1600, 900, false);
                break;
            
            case ResolutionState.R1366_768:
                Screen.SetResolution(1366, 768, false);
                break;
            
            case ResolutionState.R1280_720:
                Screen.SetResolution(1280, 720, false);
                break;
            
            default:
                break;
        }
    }

    public static void Initialize()
    {
        ResolutionStateChange(resolutionState);
    }
}
