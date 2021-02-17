using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Scripts_Host : MonoBehaviour
{
    public Toggle Map1;
    public Toggle Map2;
    public Toggle RandomMaps;
    private int maps;
    public Button back;
    public Button next;
    public Button backHost;
    public Button startHost;
    public GameObject Map;
    public GameObject Host;

    void Start()
    {
        maps = 0;
        back.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        });
        next.onClick.AddListener(() =>
        {
            HostNext();
        });
        backHost.onClick.AddListener(() =>
        {
            HostBack();
        });
        startHost.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        });
    }

    void Update()
    {
        if (Map1.isOn == true)
        {
            maps = 1;
        }
        if (Map2.isOn == true)
        {
            maps = 2;
        }
        if (RandomMaps.isOn == true)
        {
            random();
        }
    }

    void random()
    {
        maps = Random.Range(1, 3);
    }

    void HostNext()
    {
        Map.SetActive(false);
        Host.SetActive(true);
    }

    void HostBack()
    {
        Host.SetActive(false);
        Map.SetActive(true);
    }
}
