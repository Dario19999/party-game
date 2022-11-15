using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCInteractable : Interactable //Hereda
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private string[] _dialogue;

    private DialogueController _dialogueController;
    private void Start()
    {
        _dialogueController = FindObjectOfType<DialogueController>();   //Sirve para 
        if (_dialogueController == null)
        {
            Debug.LogError("La escena no tiene un Dialogue Controller");
        }

    }

    public override void Interact(PlayerController player) 
    {
        //base.Interact(); llama a la funcion
        //Debug.Log("Interactuando con el NPC");
        _dialogueController.setDialogue(_name, _dialogue);
        //Debug.Log("El NPC " + _name + " dice " + _dialogue[0]);
    }
}
