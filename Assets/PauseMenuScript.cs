using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    public Text resume;
    public Text exit;

    private int controller;
    private Text currentSelected;
    private string vertical = "Vertical_P"; 
    private Color32 avansRed = new Color32(198, 0, 42, 255);
    private Canvas menu;
    private string ButtonA = "ButtonA_P";
    private string start = "Start_P";
    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = Assets.SceneTransfer.players[0].GetController();
        vertical += controller;
        ButtonA += controller;
        start += controller;

        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Canvas>();
        menu.enabled = false;
        currentSelected = resume;
        currentSelected.color = avansRed;
    }

    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            if (Input.GetButtonDown(start))
            {
                Resume();
            }
            else if (Input.GetAxis(vertical) > 0)
            {
                currentSelected = resume;
                exit.color = Color.white;
                resume.color = avansRed;
            }
            else if (Input.GetAxis(vertical) < 0)
            {
                currentSelected = exit;
                resume.color = Color.white;
                exit.color = avansRed;
            }
            else if (Input.GetButtonDown(ButtonA))
            {
                if(currentSelected == resume)
                {
                    Resume();
                }
                else if(currentSelected == exit)
                {
                    Exit();
                }
            }
        }
        else
        {
            if (Input.GetButtonDown(start) && Time.timeScale > 0)
            {
                Pause();
            }
        }
    }

    private void Resume()
    {
        paused = false;
        Time.timeScale = 1f;
        menu.enabled = false;
    }

    private void Pause()
    {
        paused = true;
        Time.timeScale = 0f;
        menu.enabled = true;
    }

    private void Exit()
    {
        Resume();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
