﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerJoinTextHandler : MonoBehaviour
{

    public GameObject Player1Text;
    public GameObject Player2Text;

    public bool Player1 = false;
    public bool Player2 = false;

    public GameObject[] PlayerObj = new GameObject[2];

    private void Start()
    {
        GetPlayer();
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Lilly_Menu")
        {
            if(Player1 == true)
            {
                Player1 = false;
            }
            if (Player2 == true)
            {
                Player2 = false;
            }
        }
        //PLAYER 1 TEXT
        if(Player1)
        {
            if (Player1Text)
            {
                Player1Text.gameObject.SetActive(false);
            }
        }
        else
        {
            if (!Player1Text.activeInHierarchy)
            {
                Player1Text.gameObject.SetActive(true);
            }
        }
        //PLAYER 2 TEXT
        if (Player2)
        {
            if (Player2Text)
            {
                Player2Text.gameObject.SetActive(false);
            }
        }
        else
        {
            if (!Player2Text.activeInHierarchy)
            {
                Player2Text.gameObject.SetActive(true);
            }
        }
    }

    public void HandlePlayer1Text()
    {
        Player1 = !Player1;
    }

    public void HandlePlayer2Text()
    {
        Player2 = !Player2;
    }

    public void GetPlayer()
    {
        PlayerObj = GameObject.FindGameObjectsWithTag("Player");
        if(PlayerObj.Length > 0)
        {
            if(PlayerObj[0])
            {
                if(PlayerObj[0].GetComponent<Player_Movement>().PlayerString == "Player1")
                {
                    HandlePlayer1Text();
                }
                else if (PlayerObj[0].GetComponent<Player_Movement>().PlayerString == "Player2")
                {
                    HandlePlayer2Text();
                }
            }
            if (PlayerObj.Length > 1)
            {
                if (PlayerObj[1].GetComponent<Player_Movement>().PlayerString == "Player1")
                {
                    HandlePlayer1Text();
                }
                else if (PlayerObj[1].GetComponent<Player_Movement>().PlayerString == "Player2")
                {
                    HandlePlayer2Text();
                }
            }
        }
    }

}