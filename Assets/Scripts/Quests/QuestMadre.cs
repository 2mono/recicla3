using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class QuestMadre : MonoBehaviour
{
    public SphereCollider sphereCollider;
    public GameObject flecha;


    private void Start()
    {
        flecha.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.Instance.inQuestNene) flecha.SetActive(true);
        if (GameManager.Instance.inQuestNeneFinished) flecha.SetActive(false);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            GameManager.Instance.MessageUI("Que miras? te debo algo?");
        }
        
        if(other.CompareTag("NenePerdido") && GameManager.Instance.inQuestNene)
        {
            GameManager.Instance.MessageUI("MI HIJO! DONDE ESTABA! GRACIAS!");
            GameManager.Instance.inQuestNeneFinished = true;
            other.GetComponent<NavMeshAgent>().destination = transform.position;
            sphereCollider.enabled = false;
            flecha.SetActive(false);
        }
    }
}
