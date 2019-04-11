﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController_Play : MonoBehaviour
{

    public GameObject SoundOnButton;
    public GameObject SoundOffButton;
    public GameObject AllChangeModeButton;
    public GameObject RotateChangeModeButton;
    public GameObject SlideChangeModeButton;
    public GameObject RankingButton;
    public GameObject RankPage;
    public GameObject EC;
    public GameObject RectangleBiscuitBackground, Rec2SquareBackground, SimilarityBackground;
    private EventController ec;

    public void Awake()
    {
        SoundOnButton.SetActive(false);
        SoundOffButton.SetActive(true);
        AllChangeModeButton.SetActive(true);
        RotateChangeModeButton.SetActive(false);
        SlideChangeModeButton.SetActive(false);
        RankPage.SetActive(false);
        ec = EC.GetComponent<EventController>();

        int currentMode = PlayerPrefs.GetInt("Mode");

        if(currentMode == 0 || currentMode == 1)
        {
            RectangleBiscuitBackground.SetActive(true);
        }
        else if(currentMode == 2)
        {
            Rec2SquareBackground.SetActive(true);
        }
        else
        {
            SimilarityBackground.SetActive(true);
        }
    }

    public void Totitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void RestartChallenge()
    {
        SceneManager.LoadScene("Play");
    }

    public void GameClose()
    {
        Application.Quit();
    }

    public void SoundOn()
    {
        PlayerPrefs.SetFloat("isSoundOn", 1f);
        AudioListener.volume = 1f;
    }

    public void SoundOff()
    {
        PlayerPrefs.SetFloat("isSoundOn", 0f);
        AudioListener.volume = 0f;
    }

    public void ToRank()
    {
        RankPage.SetActive(true);
    }

    public void ImmediateWin()
    {
        ec.GameManager(2);
    }



}
