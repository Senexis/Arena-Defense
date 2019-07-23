using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float coolDownUntilNextSwitch = 0.2f;
    public float coolDownUntilNextScroll = 0.05f;

    private int inputNumber = -1;
    private Player player;
    private bool canSwitchCharacter = true;
    private double scrollPos = 1;

    // input strings


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(inputNumber);

        if (inputNumber == -1) return;
        if (Input.GetAxis("Horizontal_P" + inputNumber) > 0)
        {
            // right
            StartCoroutine(SwitchTargetRoutine(coolDownUntilNextSwitch, 1));
        }
        else if (Input.GetAxis("Horizontal_P" + inputNumber) < 0)
        {
            // left
            StartCoroutine(SwitchTargetRoutine(coolDownUntilNextSwitch, -1));
        }

        var verticalAxis = Input.GetAxis("VerticalRotation_P" + inputNumber);
        if (verticalAxis != 0)
        {
            StartCoroutine(ScrollRoutine(coolDownUntilNextScroll, verticalAxis));
        }
    }

    IEnumerator SwitchTargetRoutine(float duration, int direction)
    {
        if (canSwitchCharacter)
        {
            canSwitchCharacter = false;
            scrollPos = 1;

            if (direction > 0)
            {
                GetComponentInChildren<CharacterScript>().NextSlide();
            }
            else
            {
                GetComponentInChildren<CharacterScript>().PreviousSlide();
            }

            yield return new WaitForSeconds(duration);
            canSwitchCharacter = true;
        }
        else
        {
            yield return new WaitForSeconds(0f);
        }
    }

    IEnumerator ScrollRoutine(float duration, float direction)
    {
        if (direction > 0)
        {
            scrollPos += 0.015;
        }
        else
        {
            scrollPos -= 0.015;
        }

        if (scrollPos > 1)
        {
            scrollPos = 1;
        }

        if (scrollPos < 0)
        {
            scrollPos = 0;
        }

        GetComponentInChildren<CharacterScript>().ScrollLore(scrollPos);
        yield return new WaitForSeconds(duration);
    }

    public void SetInputNumber(int numb)
    {
        this.inputNumber = numb;
    }
}
