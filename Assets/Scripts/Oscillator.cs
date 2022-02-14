using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{   
    [SerializeField][Range(0,20)]
    private float period = 0f; 
    [SerializeField]
    private Vector3 movementVector;

    private Vector3 startingPosition; 
    

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period > 0) 
        {
            float cycles  = Time.time / period; // continually growing over time

            const float tau = Mathf.PI * 2; // constant value of 6.283...
            float rawSinWave = Mathf.Sin(cycles * tau); //going from -1 to 1

            float movementFactor = (rawSinWave + 1f) / 2f; // recalculated to go from 0 to 1 so its clearner.

            Vector3 offset = movementVector * movementFactor;
            transform.position =  startingPosition + offset;
        }
    }
}
