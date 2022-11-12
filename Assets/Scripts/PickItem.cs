using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    [SerializeField] private float radius;
    private bool inRange = false;
    private Light lit;

    private void Start()
    {
        lit = GetComponent<Light>();
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)&& inRange)
        {
            
            GameManager.Instance.CountItem();
            PlayerAnimator.Instance.PickAnim();
            Destroy(gameObject,0.1f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.LookAt(transform.position);
            inRange = true; 
            lit.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false; 
        lit.enabled = false;
    }
}
