using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFPS : MonoBehaviour
{

    [SerializeField] Transform cameraHolder;
    float verticalLookRotation;

    private void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X"));
        
        verticalLookRotation -= Input.GetAxisRaw("Mouse Y");
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90, 90f);
        cameraHolder.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);
    }

}
