using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPopupChoiceItem : MonoBehaviour
{
    [SerializeField]
    private GameObject selectIcon;
    [SerializeField]
    private TMPro.TMP_Text selectText;
    // Start is called before the first frame update
    void Start()
    {
        selectIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupItem(string text)
    {
        selectText.text = text;
    }

    public void SelectItem()
    {
        selectIcon.SetActive(true);
    }

    public void UnselectItem()
    {
        selectIcon.SetActive(false);
    }
}
