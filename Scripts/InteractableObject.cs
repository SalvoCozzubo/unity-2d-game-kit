using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class InteractableObject : MonoBehaviour
{
    private bool inInteractZone = false;
    [SerializeField]
    private BaseDialogue dialog;

    private float nextInteraction;
    private float interactionCooldown = .25f;
    private bool interacted = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!DialogManager.instance.dialogActive &&
            interacted)
        {
            nextInteraction = interactionCooldown;
            interacted = false;
        }

        if (InputManager.instance.GetActionButton() &&
            inInteractZone && nextInteraction <= 0 &&
            !GameManager.instance.IsGamePause())
        {
            interacted = true;
            DialogManager.instance.ShowMessage(dialog);
        }

        nextInteraction -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            inInteractZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            inInteractZone = false;
        }
    }
}
