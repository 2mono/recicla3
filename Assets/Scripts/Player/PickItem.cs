using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    [SerializeField] private float radius;
    GameObject recollectPoint;
    private bool inRange = false;
    private Light lit;

    private void Start()
    {
        lit = GetComponent<Light>();
        recollectPoint = GameObject.FindGameObjectWithTag("Recolector");
        print(recollectPoint);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //other.transform.LookAt(transform.position);
            if (Input.GetKeyDown(KeyCode.E) && inRange)
            {
                GameManager.Instance.CountItem();
                PlayerAnimator.Instance.PickAnim();
                Destroy(gameObject, 0.1f);
            }
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
