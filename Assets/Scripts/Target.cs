using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float speed;
    private void Update()
    {
        transform.Rotate(Time.deltaTime * speed, 1, 2);
    }
    public void Hit()
    {
        transform.position = TargetBounds.Instance.GetRandomPosition();
        TargetBounds.Instance.TargetCount();
    }

}


