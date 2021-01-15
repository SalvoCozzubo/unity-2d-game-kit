using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [Header("References: Dialog")]
    [SerializeField]
    private GameObject dialogImage;
    [SerializeField]
    private TMPro.TMP_Text dialogText;

    [Header("References: Popup")]
    [SerializeField]
    private GameObject popupImage;
    [SerializeField]
    private DialogPopupChoiceItem[] items;
    
    public static DialogManager instance;
    public bool dialogActive { get; private set; }
    private int currentTextIndex;
    private int currentItemSelected;
    private BaseDialogue currentDialog;
    [Header("General")]
    [SerializeField]
    private float cooldown = .5f;
    private float next = 0;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        dialogActive = false;
        currentTextIndex = 0;
        currentItemSelected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (next < 0 && dialogActive &&
            InputManager.instance.GetActionButton() &&
            GameManager.instance.IsGamePause())
        {
            next = cooldown;
            currentTextIndex += 1;
            Render();
        }

        float verticalAxis = InputManager.instance.GetVerticalAxis();
        if (next < 0 && dialogActive &&
            GameManager.instance.IsGamePause() &&
            verticalAxis != 0 &&
            currentDialog is DialogueChoice)
        {
            next = cooldown;
            items[currentItemSelected].UnselectItem();

            currentItemSelected = verticalAxis < 0 ?
                currentItemSelected += 1 : currentItemSelected -= 1;
            
            if (currentItemSelected < 0) currentItemSelected = 1;
            else if (currentItemSelected > 1) currentItemSelected = 0;

            items[currentItemSelected].SelectItem();
        }

        next -= Time.deltaTime;
    }

    void Render() {
        string[] text = currentDialog.GetSentences();
        if (currentTextIndex < text.Length)
        {
            if (currentDialog is DialogueChoice)
            {
                items[0].SetupItem(
                    ((DialogueChoice)currentDialog).GetChoicesText()[0]);
                items[1].SetupItem(
                    ((DialogueChoice)currentDialog).GetChoicesText()[1]);
                items[0].SelectItem();
                items[1].UnselectItem();
            }
            dialogText.text = text[currentTextIndex];
        }
        else
        {
            dialogActive = false;
            dialogImage.SetActive(false);
            popupImage.SetActive(false);
            GameManager.instance.Resume();
        }
    }

    public void ShowMessage(BaseDialogue dialog)
    {
        GameManager.instance.Pause();

        currentTextIndex = 0;
        dialogActive = true;
        currentDialog = dialog;
        dialogImage.SetActive(true);
        if (dialog is DialogueChoice) {
            popupImage.SetActive(true);
            currentItemSelected = 0;
        }
        next = cooldown;
        Render();
    }
}
