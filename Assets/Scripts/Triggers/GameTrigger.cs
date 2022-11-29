using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip enterZone;
    public enum GameNumber
    {
        Game00, Game01, Game02, Game03
    }
    public GameNumber gameNumber;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            AudioSource.PlayClipAtPoint(enterZone, transform.position,1f);
            switch (gameNumber)
            {
                case GameNumber.Game00:
                    if (!GameManager.Instance.winGame00) GameManager.Instance.StartGameRecollect();
                    else GameManager.Instance.MessageUI("Intentalo nuevamente mas tarde!");
                    break;
                case GameNumber.Game01:
                    if (!GameManager.Instance.winGame01) GameManager.Instance.StartSubmarineGame();
                    else GameManager.Instance.MessageUI("Intentalo nuevamente mas tarde!");
                    break;
                case GameNumber.Game02:
                    if (!GameManager.Instance.winGame02) GameManager.Instance.StartFPSGame();
                    else GameManager.Instance.MessageUI("Intentalo nuevamente mas tarde!");
                    break;
                case GameNumber.Game03:
                    //TODO
                    break;
                default:
                    break;
            }
        }
    }
}
