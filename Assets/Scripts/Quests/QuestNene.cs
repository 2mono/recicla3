using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics.Internal;
using UnityEngine;
using UnityEngine.AI;

public class QuestNene : MonoBehaviour
{
    [SerializeField] private GameObject flecha;
    GameObject player;
    private GameObject character;
    Animator anim;

    float moveSpeed = 3.0f;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        character = GetComponent<GameObject>();
    }

    private void Update()
    {
        if (GameManager.Instance.inQuestNene)
        {
            float speed = moveSpeed;
            anim.SetFloat("Speed", speed, 0.1f, Time.deltaTime);
            //code for looking to player
            character.transform.rotation = Quaternion.Slerp(character.transform.rotation,
            Quaternion.LookRotation(player.transform.position - character.transform.position), 3 * Time.deltaTime);

            //code for following the player
            character.transform.position += character.transform.forward * moveSpeed * Time.deltaTime;
        }
        if (GameManager.Instance.inQuestNeneFinished)  character.transform.position = transform.position;

        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !GameManager.Instance.inQuestNene)
        {
            GameManager.Instance.inQuestNene = true;
            GameManager.Instance.MessageUI("Ayudame a encontrar a mi Mama!");
            flecha.SetActive(false);
        }
    }

}
