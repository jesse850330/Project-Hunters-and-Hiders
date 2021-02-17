using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Scripts_Start : MonoBehaviour
{
    public Button back;
    public Button next;
    public Button backStart;
    public GameObject Character;
    public GameObject Team;

    void Start()
    {
        back.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
        next.onClick.AddListener(() =>
        {
            Next();
        });
        backStart.onClick.AddListener(() =>
        {
            StartBack();
        });
    }

    void Next()
    {
        Character.SetActive(false);
        Team.SetActive(true);
    }
    void StartBack()
    {
        Team.SetActive(false);
        Character.SetActive(true);
    }
}
