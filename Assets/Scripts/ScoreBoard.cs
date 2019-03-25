﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public ScoreScript scoreboardPlayer1;
    public ScoreScript scoreboardPlayer2;

    public ArmAnimationCode MonkeyArmP1;
    public ArmAnimationCode MonkeyArmP2;

    public List<Collectables> player1Icons;
    public List<Collectables> player2Icons;

    public PickUpSpawner pickupManager;

    public float pickUpPoints = 5;
    public float allPickUpPoints = 20;
    public GameObject musk;

    bool hasScored = true;
    float blinktime;
    float animationdelay1;
    float animationdelay2;
    public int PlayerScoar = 1;
    int roundWinP1 = 0;
    int roundWinP2 = 0;

    public List<Round> player1RoundWins;
    public List<Round> player2RoundWins;


    // Start is called before the first frame update
    void Start()
    {
        DoneScoring();
        blinktime = player1Icons[0].animationLenght;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BabyGotHit(float ballSpeed, int pickuptype)
    {
        
        if (ballSpeed > 0)
        {
            if (Time.fixedTime > animationdelay1 + blinktime)
            {
                if (HasColected(player1Icons))
                {
                     scoreboardPlayer1.NewScoreAdd(allPickUpPoints, 0.1f);
                     player1Icons[0].GetComponent<AudioSource>().Play();
                     StartBlinkingBoys(player1Icons);
                     animationdelay1 = Time.fixedTime;
                }
                else
                {
                    scoreboardPlayer1.NewScoreAdd(pickUpPoints, 0.1f);
                    player1Icons[pickuptype].TurnOn();
                }
            }
        }
        else
        {
            if (Time.fixedTime > animationdelay2 + blinktime)
            {
                if (HasColected(player2Icons))
                {
                    scoreboardPlayer2.NewScoreAdd(allPickUpPoints, 0.1f);
                    player2Icons[0].GetComponent<AudioSource>().Play();
                    StartBlinkingBoys(player2Icons);
                    animationdelay2 = Time.fixedTime;
                }
                else
                {
                    scoreboardPlayer2.NewScoreAdd(pickUpPoints, 0.1f);
                    player2Icons[pickuptype].TurnOn();
                }
            }
        }
    }
    public void TurnOfAll()
    {
        for (int i = 0; i < player1Icons.Count; i++)
        {
            player1Icons[i].TurnOf();
            player2Icons[i].TurnOf();
        }
    }
    bool HasColected (List<Collectables> icons)
    {
        for (int i = 0; i < icons.Count - 1; i++)
        {
            if (!icons[i].isOn)
            {
                return false;
            }
        }
        return true;
    }
    void TurnOfScoreSide(List<Collectables> icons)
    {
        for (int i = 0; i < icons.Count; i++)
        {
            icons[i].TurnOf();
        }
    }
    public void Scored (int playerGoal, float score) // score is standin
    {
        // musk.GetComponent<AudioSource>().Pause();
        musk.GetComponent<AudioSource>().volume = 0.3f;
        hasScored = true;
        PlayerScoar = playerGoal;
        if (PlayerScoar == 1)
        {
            roundWinP1++;
            roundwins(player1RoundWins, roundWinP1);
            scoreboardPlayer1.NewScoreAdd(score, 0.1f);
        }
        else
        {
            roundWinP2++;
            roundwins(player2RoundWins, roundWinP2);
            scoreboardPlayer2.NewScoreAdd(score, 0.1f);
        }
    }
    public void DoneScoring ()
    {
        if (hasScored)
        {
            hasScored = false;
            musk.GetComponent<AudioSource>().volume = 0.75f;
            if (PlayerScoar == 1)
            {            
                MonkeyArmP1.MoveArmAnimation();
            }
            else
            {
                MonkeyArmP2.MoveArmAnimation();
            }
            ResetTheBoard();
            
        }
    }
    void ResetTheBoard()
    {
        Debug.Log("GottoResetboard");
        pickupManager.TurnOfAll();
    }
    void roundwins (List<Round> givepoint, int score)
    {
        for (int i = 0; i < givepoint.Count; i++)
        {
            givepoint[i].setRoundNum(score);
        }
    }
    void StartBlinkingBoys(List<Collectables> icons)
    {
        for (int i = 0; i < icons.Count; i++)
        {
            icons[i].StartBlinking();
        }
    }
}
