using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseDialogue", menuName = "Dialog/Simple Dialog")]
public class BaseDialogue : ScriptableObject
{
    [SerializeField]
    [TextArea(2, 10)]
    private string[] sentences;

    public string[] GetSentences()
    {
        return sentences;
    }
}
