using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerNumberController : MonoBehaviour
{
    public TextMeshPro overhead;
    private PlayerController playerController;
    private int playerNumber;

    public PlayerNumberController(int playerNumber)
    {
        this.playerNumber = playerNumber;
    }

    // Start is called before the first frame update
    void Start()
    {
        overhead = new TextMeshPro()
        {
            text = "P" + playerNumber,
            fontSize = 8
        };
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(playerController.transform.position.x, playerController.transform.position.y + 1);
    }

    public void SetPlayerNumber(int number)
    {
        this.playerNumber = number;
        overhead.SetText($"P{playerNumber}");
    }

    public void SetPlayerController(PlayerController controller)
    {
        this.playerController = controller;
    }
}