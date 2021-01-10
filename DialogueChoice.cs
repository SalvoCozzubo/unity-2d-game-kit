using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueChoice", menuName = "Dialog/Dialog Choice")]
public class DialogueChoice : BaseDialogue
{
    [Header("Choice")]
    [SerializeField]
    private string[] ChoicesText;

    [Header("Choice Tag")]
    [SerializeField]
    private string[] ChoicesTag;

    public string[] GetChoicesText()
    {
        return ChoicesText;
    }

    public string[] GetChoicesTag()
    {
        return ChoicesTag;
    }
}