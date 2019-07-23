using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectController : MonoBehaviour
{
    public Text startText;

    private Player[] players;
    private bool allReady
    {
        get
        {
            var connectedPlayers = players.Where(p => p.GetController() != -1).ToList();

            if (connectedPlayers.Count < 1)
            {
                return false;
            }

            return connectedPlayers.All(p => p.IsReady());
        }
    }
    
    void Start()
    {
        startText.enabled = false;
        players = FindObjectsOfType<Player>().OrderBy(p => p.playerNumber).ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (allReady)
        {
            startText.enabled = true;
            var connectedPlayers = players.Where(p => p.GetController() != -1).ToList();

            foreach (Player player in connectedPlayers)
            {
                if (player.PressedStart())
                {
                    GameObject.FindGameObjectWithTag("Music").GetComponent<MainMenuClickScript>().PlayMusic();
                    Assets.SceneTransfer.players = players;
                    UnityEngine.SceneManagement.SceneManager.LoadScene(1, UnityEngine.SceneManagement.LoadSceneMode.Single);
                }
            }
        }
        else
        {
            startText.enabled = false;
        }
    }
}
