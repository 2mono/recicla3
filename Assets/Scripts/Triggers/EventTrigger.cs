using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent events;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            events.Invoke();
            Debug.Log("Invoco Unity Event");
        }
    }
}
