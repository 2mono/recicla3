using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    [SerializeField] private float radius;
    GameObject player;
    Animator anim;
    
    private bool inRange = false;
    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
    }

    private async void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeColorIn();
            if (Input.GetKeyDown(KeyCode.E) && inRange)
            {
                GameManager.Instance.CountItem();
                player.GetComponent<PlayerMovement>().enabled = false;
                anim.SetTrigger("Pickup");
                Destroy(gameObject, 0.1f);
                await Task.Delay(2000);
                player.GetComponent<PlayerMovement>().enabled = true;
            }
            inRange = true; 
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ChangeColorOut();
        inRange = false; 
    }

    void ChangeColorIn()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = Color.red;
    }

    void ChangeColorOut()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = Color.white;
    }
}
