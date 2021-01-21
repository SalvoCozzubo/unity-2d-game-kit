using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogText : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text tmpText;
    private string currentSentences;
    private bool show = false;
    [SerializeField]
    private int letterPerSeconds = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TypeDialog(string sentences)
    {
        tmpText.text = "";  // clean
        foreach (var letter in sentences.ToCharArray())
        {
            tmpText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSeconds);
        }
    }

    void Render()
    {

    }

    public void ShowSentence(string sentence)
    {
        StartCoroutine(TypeDialog(sentence));
    }
}
