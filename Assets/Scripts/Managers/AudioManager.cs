using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public static AudioManager instance;

    [SerializeField] AudioClip disparo, hit, warp, gameOver;
    AudioSource audioSource;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(warp);
    }
    public void PlayShoot()
    {
        audioSource.PlayOneShot(disparo, 0.3f);
    }

    public void PlayHit()
    {
        audioSource.PlayOneShot(hit, 0.6f);
    }

    public void PlayGameOver()
    {
        audioSource.PlayOneShot(gameOver);
    }
    
    
    void Update()
    {
        
    }
}
