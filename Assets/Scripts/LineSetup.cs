using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSetup : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private LineController lineController;


    private void Start()
    {
        lineController.SetupLine(points);
    }
}
