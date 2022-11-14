using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjercicioTDA : MonoBehaviour
{
    List<string> simpsons = new List<string>();
    

    void Start()
    {
        simpsons.Add("Bart");
        simpsons.Add("Homero");
        simpsons.Add("Maggie");
        simpsons.Add("Marge");
        simpsons.Add("Lisa");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            foreach (string simpson in simpsons)
            {
                Debug.Log(simpson);
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            simpsons.Reverse();
            foreach (string simpson in simpsons)
            {
                Debug.Log(simpson);
            }
        }

    }
}
