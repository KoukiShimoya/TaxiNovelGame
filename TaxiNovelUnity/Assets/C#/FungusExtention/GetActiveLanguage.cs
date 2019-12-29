using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

[CommandInfo("Scripting", "Set Active Language To Variable", "StaticなActiveLanguageを変更する")]
public class SetActiveLanguageToVariable : Fungus.Command
{
    [Tooltip("String variable to store the tex file contents in")]
    [VariableProperty(typeof(StringVariable))]
    [SerializeField] protected StringVariable stringVariable;

    public override void OnEnter() 
    {
        stringVariable.Value = NowActiveLanguage.GetSetLanguageCode.ToString();

        Continue();
    }
    
    public override Color GetButtonColor()
    {
        return new Color32(235, 191, 217, 255);
    }
}