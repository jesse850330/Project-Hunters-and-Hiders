using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightRaycast_Cs : MonoBehaviour
{
    public GameObject objectHit;
    public Vector3 collision = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 50))
        {
            objectHit = hit.transform.gameObject;
            collision = hit.point;
            if (hit.transform.tag == "Hider")
            {
                hit.transform.gameObject.GetComponent<Health_Cs>().Health -= 0.01f; 
            }

        }
    }

    void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(collision, 1f);
    }
}
