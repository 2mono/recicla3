using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] private AudioClip footsteps;
    RaycastHit hitInfo = new RaycastHit();
    NavMeshAgent agent;
    AudioSource audioSource;
    bool isMoving;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
                agent.destination = hitInfo.point;

        }
        
        if(agent.velocity != Vector3.zero) isMoving = true;
            else isMoving = false;

        if (isMoving && !audioSource.isPlaying) audioSource.PlayOneShot(footsteps, 0.1f);
        if (!isMoving) audioSource.Stop();


    }
}
