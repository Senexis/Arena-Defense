using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TODO: Split this controller
public class CharSelectController : MonoBehaviour
{
    public string Player1Join = "ButtonA_P1";
    public string Player2Join = "ButtonA_P2";
    public string Player3Join = "ButtonA_P3";
    public string Player4Join = "ButtonA_P4";
    public string gameStart = "Start";

//Sidenote, should clean this up. Perhaps later

    //Text
    public Text Player1Text;
    public Text Player2Text;
    public Text Player3Text;
    public Text Player4Text;

    //Controllers
    private bool Controller1 = false;
    private bool Controller2 = false;
    private bool Controller3 = false;
    private bool Controller4 = false;

    //Player slots
    private bool Player1Slot = false;
    private bool Player2Slot = false;
    private bool Player3Slot = false;
    private bool Player4Slot = false;    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Start game
        if (Input.GetButtonDown(gameStart))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }

        //Controller check
        if(Input.GetButtonDown(Player1Join) && !Controller1)
        {
            JoinPlayer();
            Controller1 = true;
            //Debug.Log("Controller 1 Joined");
        } else if (Input.GetButton(Player2Join) && !Controller2)
        {
            JoinPlayer();
            Controller2 = true;
            //Debug.Log("Controller 2 Joined");
        }  else if (Input.GetButton(Player3Join) && !Controller3)
        {
            JoinPlayer();
            Controller3 = true;
            //Debug.Log("Controller 3 Joined");
        }  else if (Input.GetButton(Player3Join) && !Controller4)
        {
            JoinPlayer();
            Controller4 = true;
            //Debug.Log("Controller 4 Joined");
        }
        //Controller check ready
        //if(Input.GetButtonDown(Player1Join) && Controller1)
        //{
        //    Debug.Log("Controller 1 Ready");
        //} else if (Input.GetButton(Player2Join) && Controller2)
        //{
        //    Debug.Log("Controller 2 Ready");
        //}  else if (Input.GetButton(Player3Join) && Controller3)
        //{
        //    Debug.Log("Controller 3 Ready");
        //}  else if (Input.GetButton(Player3Join) && Controller4)
        //{
        //    Debug.Log("Controller 4 Ready");
        //}
    }

    //Players
    void JoinPlayer()
    {
        if (Player1Slot == false)
        {
            Debug.Log("Player 1 filled");
            Player1Slot = true;
            Player1Text.text = "Player 1 Joined!";
        } else if (Player2Slot == false)
        {
            Debug.Log("Player 2 filled");
            Player2Slot = true;
            Player2Text.text = "Player 2 Joined!";
        } else if (Player3Slot == false)
        {
            Debug.Log("Player 3 filled");
            Player3Slot = true;
            Player3Text.text = "Player 3 Joined!";
        } else if (Player4Slot == false)
        {
            Debug.Log("Player 4 filled");
            Player4Slot = true;
            Player4Text.text = "Player 4 Joined!";
        }
    }
}
