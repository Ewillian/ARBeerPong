﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    private GameObject MainMenu;

    private GameObject GamemodeMenu;

    private GameObject RuleMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenu = GameObject.FindGameObjectWithTag("Main Menu");
        GamemodeMenu = GameObject.FindGameObjectWithTag("GameModeMenu");
        RuleMenu = GameObject.FindGameObjectWithTag("Rule menu");
    }

   void ShowMainMenu()
    {
        MainMenu.GetComponent<Animator>().SetBool("Called", true);
    }

    public void ShowGamemode()
    {
        MainMenu.GetComponent<Animator>().SetTrigger("EventOut");
        GamemodeMenu.GetComponent<Animator>().SetTrigger("EventIn");
    }

    public void LeaveGamemode()
    {
        GamemodeMenu.GetComponent<Animator>().SetTrigger("EventOut");
        MainMenu.GetComponent<Animator>().SetTrigger("EventIn");
    }

    public void LoadNoMoreCup()
    {
        SceneManager.LoadScene("BasicGamemodeScene");
    }

    public void ShowRulesMenu()
    {
        MainMenu.GetComponent<Animator>().SetTrigger("EventOut");
        RuleMenu.GetComponent<Animator>().SetTrigger("EventIn");
    }

    public void LeaveRulesMenu()
    {
        RuleMenu.GetComponent<Animator>().SetTrigger("EventOut");
        MainMenu.GetComponent<Animator>().SetTrigger("EventIn");
    }
}
