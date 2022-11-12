using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : MonoBehaviour
{
    public static PlayerAnimator Instance { get; private set; }

    NavMeshAgent agent;
    public Animator anim;
    float motionSmoothTime = .1f;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        RunAnim();
    }

    public void RunAnim()
    {
        float speed = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("Speed", speed, motionSmoothTime, Time.deltaTime);
    }

    public async void PickAnim()
    {
        agent.enabled = false;
        anim.SetTrigger("Pickup");
        await Task.Delay(1500);
        agent.enabled = true;
    }

}
