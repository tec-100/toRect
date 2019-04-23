﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController_Title : MonoBehaviour {

    public GameObject[] HelpContentsBiscuit = new GameObject[1];
    public GameObject[] HelpContentsRec2Square = new GameObject[2];
    public GameObject[] HelpContentsSimilarity = new GameObject[1];
    private List<GameObject[]> HelpContents;
    public GameObject HelpWindow;
    public GameObject ModeSelect;
    public GameObject StoryModeSelect, StoryModeHelp;
    public GameObject RankPage;
    public GameObject LeftButton;
    public GameObject RightButton;
    public GameObject SoundOnButton;
    public GameObject SoundOffButton;
    private int page;
    private int helpGameModeIndex;
    private int helpLength;

    // Used to auto upload from PlayerPrefs
    public void Awake()
    {
        HelpContents = new List<GameObject[]>();
        HelpContents.Add(HelpContentsBiscuit);
        HelpContents.Add(HelpContentsRec2Square);
        HelpContents.Add(HelpContentsSimilarity);
        helpGameModeIndex = 0;

        ModeSelect.SetActive(false);
        RankPage.SetActive(false);
        StoryModeSelect.SetActive(false);
        //SoundOffButton.SetActive(true);
        //SoundOnButton.SetActive(false);

        PlayerPrefs.SetInt("isMonsterTypeOn", 1);
        if (!PlayerPrefs.HasKey("isSoundOn"))
            SoundOn();

        if (PlayerPrefs.GetFloat("isSoundOn") == 0f)
        {
            SoundOnButton.SetActive(true);
            SoundOffButton.SetActive(false);
        }
        else
        {
            SoundOnButton.SetActive(false);
            SoundOffButton.SetActive(true);
        }
    }

    public void toRectStoryModeStart()
    {
        PlayerPrefs.SetInt("Mode", 1);
        PlayerPrefs.SetInt("Game", 0);
        SceneManager.LoadScene("Play");
        return;
    }

    public void jiktojungStoryModeStart()
    {
        PlayerPrefs.SetInt("Mode", 2);
        PlayerPrefs.SetInt("Game", 10);
        SceneManager.LoadScene("Play");
        return;
    }

    public void pieStoryModeStart()
    {
        PlayerPrefs.SetInt("Mode", 3);
        PlayerPrefs.SetInt("Game", 12);
        SceneManager.LoadScene("Play");
        return;
    }

    public void ChallengeModeStart()
    {
        PlayerPrefs.SetInt("Mode", 0);
        PlayerPrefs.SetInt("Game", 0);
        SceneManager.LoadScene("Play");
        return;
    }

    public void SoundOn()
    {
        PlayerPrefs.SetFloat("isSoundOn", 1f);
        AudioListener.volume = 1f;
        return;
    }

    public void SoundOff()
    {
        PlayerPrefs.SetFloat("isSoundOn", 0f);
        AudioListener.volume = 0f;
        return;
    }

    private void clearAll()
    {
        StoryModeHelp.SetActive(false);
        for(int i = 0; i < HelpContents.Count; i++)
        {
            for(int j = 0; j < HelpContents[i].Length; j++)
            {
                HelpContents[i][j].SetActive(false);
            }
        }
        LeftButton.SetActive(false);
        RightButton.SetActive(false);
        return;
    }

    public void OpenPage(int gamemode)
    {
        helpGameModeIndex = gamemode;
        page = 0;
        clearAll();
        HelpWindow.SetActive(true);
        HelpContents[helpGameModeIndex][page].SetActive(true);
        if (HelpContents[helpGameModeIndex].Length != 1) RightButton.SetActive(true);
        else RightButton.SetActive(false);
        LeftButton.SetActive(false);
        return;
    }

    public void MoveRightPage()
    {
        clearAll();
        LeftButton.SetActive(true);
        if (page == HelpContents[helpGameModeIndex].Length - 2) RightButton.SetActive(false);
        else RightButton.SetActive(true);
        HelpContents[helpGameModeIndex][page].SetActive(false);
        page++;
        HelpContents[helpGameModeIndex][page].SetActive(true);
        return;
    }

    public void MoveLeftPage()
    {
        clearAll();
        RightButton.SetActive(true);
        if (page == 1) LeftButton.SetActive(false);
        else LeftButton.SetActive(true);
        HelpContents[helpGameModeIndex][page].SetActive(false);
        page--;
        HelpContents[helpGameModeIndex][page].SetActive(true);
        return;
    }
}
