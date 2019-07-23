using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Unity Editor
    public int playerNumber;
    public Text text;

    // Private
    private int controller = -1;
    private PlayerInput input;
    private bool ready = false;
    private bool canReady = true;
    private CharacterScript character;


    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
        character = GetComponent<CharacterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller != -1 && Input.GetButtonDown("ButtonA_P" + controller))
        {
            if (!canReady) return;

            ready = true;
            character.ToggleReady(ready);
        }

        if (controller != -1 && Input.GetButtonDown("ButtonB_P" + controller))
        {
            if (!canReady) return;

            ready = false;
            character.ToggleReady(ready);
        }

        if (controller != -1 && Input.GetButtonDown("ButtonY_P" + controller))
        {
            ready = false;
            character.ToggleReady(ready);

            canReady = !character.ToggleLore();
        }
    }

    public CharacterScript GetCharacter()
    {
        return character;
    }


    public void SetController(int controller)
    {
        this.controller = controller;
        input.SetInputNumber(controller);
        UpdateText();
    }

    public int GetController()
    {
        return this.controller;
    }

    void UpdateText()
    {
        CharacterScript script = GetComponent<CharacterScript>();
        script.Init();
    }

    public bool IsReady()
    {
        return ready;
    }

    public bool PressedStart()
    {
        if(Input.GetButtonDown("Start_P" + controller))
        {
            return true;
        }

        return false;
    }
}
