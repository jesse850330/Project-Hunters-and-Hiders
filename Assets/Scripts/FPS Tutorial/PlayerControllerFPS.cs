using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerControllerFPS : NetworkBehaviour
{
    [SerializeField] private float PlayerSpeed;
    [SerializeField] private float PlayerMaxSpeed = 30f;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Vector3 cameraOffset;

    Rigidbody _rb;

    private void Start()
    {
        if (isLocalPlayer)
        {
            _rb = GetComponent<Rigidbody>();

            Camera.main.transform.SetParent(transform);
            Camera.main.transform.localPosition = cameraOffset;
            Camera.main.transform.rotation = transform.rotation;

        }
        else 
        {
            
        }
    }

    private void Update()
    {
        if (!isLocalPlayer)
            return;

        if (Input.GetAxis("Horizontal") != Mathf.Epsilon || Input.GetAxis("Vertical") != Mathf.Epsilon)
        {
            Vector3 movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (_rb.velocity.magnitude < PlayerMaxSpeed)
                _rb.AddForce(movementDirection * PlayerSpeed * Time.deltaTime * 100);
        }
    }
}
