using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Scripts_Menu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Server;
    public GameObject Options;
    public GameObject Rule;
    public GameObject BackButton;
    public Button play;
    public Button option;
    public Button help;
    public Button exit;
    public Button back;

    void GamePlay()
    {
        Menu.SetActive(false);
        Server.SetActive(true);
        BackButton.SetActive(true);
    }
    void GameOption()
    {
        Menu.SetActive(false);
        Options.SetActive(true);
        BackButton.SetActive(true);
    }
    void GameHelp()
    {
        Menu.SetActive(false);
        Rule.SetActive(true);
        BackButton.SetActive(true);
    }
    void GameExit()
    {
        Application.Quit();
    }
    public void BackMenu()
    {
        Server.SetActive(false);
        Options.SetActive(false);
        Rule.SetActive(false);
        BackButton.SetActive(false);
        Host.SetActive(false);
        Join.SetActive(false);
        Menu.SetActive(true);
    }

    void Start()
    {
        play.onClick.AddListener(() =>
        {
            GamePlay();
        });
        option.onClick.AddListener(() =>
        {
            GameOption();
        });
        help.onClick.AddListener(() =>
        {
            GameHelp();
        });
        exit.onClick.AddListener(() =>
        {
            GameExit();
        });
        back.onClick.AddListener(() =>
        {
            BackMenu();
        });
    }
}
