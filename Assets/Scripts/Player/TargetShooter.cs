using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float forceBullet = 900;
    [SerializeField] ParticleSystem particlesGun;
    


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            CameraShake.Shake(0.1f, 0.002f);
            particlesGun.Play();
            AudioManager.instance.PlayShoot();

            if (Physics.Raycast(ray,out RaycastHit hit))
            {
                Target target = hit.collider.gameObject.GetComponent<Target>();
                
                if(target != null)
                {
                   target.Hit();
                    AudioManager.instance.PlayHit();
                    
                }
            }
        }
    }


}
