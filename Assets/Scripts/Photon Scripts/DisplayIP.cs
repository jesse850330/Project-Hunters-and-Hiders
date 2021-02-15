using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayIP : MonoBehaviour
{
    public Text IP4Address;
    public Text IP6Address;
    void Start()
    {
        string ipv4 = IPManager.GetIP(ADDRESSFAM.IPv4);
        string ipv6 = IPManager.GetIP(ADDRESSFAM.IPv6);
        IP4Address.text = ipv4;
        IP6Address.text = ipv6;
    }

}
