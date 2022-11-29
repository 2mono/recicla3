using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics.Internal;
using UnityEngine;
using UnityEngine.AI;

public class QuestNene : MonoBehaviour
{
    [SerializeField] private GameObject flecha;
    [SerializeField] private AudioClip enterZone;
    GameObject player;
    //private GameObject character;
    Animator anim;

    float moveSpeed = 3.0f;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (GameManager.Instance.inQuestNene)
        {
            
           transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(player.transform.position - transform.position), 3 * Time.deltaTime);
            
            
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            anim.SetFloat("Speed", 1f);
        }
        if (GameManager.Instance.inQuestNeneFinished)  transform.position = transform.position;

        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !GameManager.Instance.inQuestNene)
        {
            AudioSource.PlayClipAtPoint(enterZone, transform.position);
            GameManager.Instance.inQuestNene = true;
            GameManager.Instance.MessageUI("Ayudame a encontrar a mi Mama!");
            flecha.SetActive(false);
        }
    }

}
