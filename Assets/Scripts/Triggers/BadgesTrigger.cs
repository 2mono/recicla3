using System;
using System.Threading.Tasks;
using TMPro;

using UnityEngine;

public class BadgesTrigger : MonoBehaviour
{
    [SerializeField] private GameObject goodBoyUI;
    [SerializeField] private GameObject shootUI;
    [SerializeField] private GameObject recollectUI;
    [SerializeField] private AudioClip fanfare;

    void Start()
    {
        Eventos.shootBadgeEvent += ShootBadge;
        Eventos.goodBoyBadgeEvent += GoodBoyBadge;
        Eventos.recollectBadgeEvent += RecollectBadge;

        goodBoyUI.SetActive(false);
        shootUI.SetActive(false);
        recollectUI.SetActive(false);
    }

    
    void GoodBoyBadge()
    {
        AudioSource.PlayClipAtPoint(fanfare,transform.position);
    }
    void ShootBadge()
    {
        AudioSource.PlayClipAtPoint(fanfare, transform.position);
    }

    async void RecollectBadge() 
    {
        AudioSource.PlayClipAtPoint(fanfare, transform.position);
        await Task.Delay(3000);
        recollectUI.SetActive(true);
        
    }
    
    
    
    
    
    
    
    void Change()
    {
        transform.localScale = new Vector3(3, 3, 3);
        Debug.Log("Change Size...");
    }

    void GrabObject()
    {
        Destroy(gameObject);
        Debug.Log("Agarre el objeto..");
    }

    void TouchObject()
    {
        Debug.Log("Algo me toco...");
    }

    private void OnDisable()
    {
        
    }


}
