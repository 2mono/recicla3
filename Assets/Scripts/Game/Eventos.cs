using UnityEngine;
using System;
using UnityEngine.Events;

public class Eventos : MonoBehaviour
{
    
    public static event Action goodBoyBadgeEvent;
    public static event Action recollectBadgeEvent;
    public static event Action shootBadgeEvent;


    private void Update()
    {
        if (GameManager.Instance.winGame00)
        {
            recollectBadgeEvent?.Invoke();
        }
        if (GameManager.Instance.winGame01)
        {
            goodBoyBadgeEvent?.Invoke();
        }
        if (GameManager.Instance.winGame02)
        {
            shootBadgeEvent?.Invoke();
        }
    }

}
