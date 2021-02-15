using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Cs : MonoBehaviour
{
    public float Health = 50;
    public GameObject Playerview;
    public GameObject LightDetection;   

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Flashlight")
        {
            LightDetection.SetActive(true);
            Playerview.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Flashlight")
        {
            LightDetection.SetActive(true);
            Playerview.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Flashlight")
        {
            LightDetection.SetActive(false);
            Playerview.SetActive(true);
        }
    }
}
