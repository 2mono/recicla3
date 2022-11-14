using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PajaroMovement : MonoBehaviour
{
    private float speed;
    public GameObject prefab;
    AudioSource audioSource;

    private void Start()
    {
        speed = Random.Range(3, 10);
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            var offsetDistance = hit.distance;
            Debug.DrawLine(transform.position, hit.point, Color.cyan);
            if (hit.collider.tag == "Player")
            {
                Debug.Log("Le pegue!");
                Instantiate(prefab,transform.position, transform.rotation);
            }
        }

        SeagullSound();
    }

    async void SeagullSound()
    {
        if (!audioSource.isPlaying) 
        { 
            audioSource.Play();
            await Task.Delay(6000);
            audioSource.Stop();
        }
    }


 }

