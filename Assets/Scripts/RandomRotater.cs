using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotater : MonoBehaviour
{
    private Rigidbody2D rBody;

    public float tumble;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        rBody.angularVelocity = Random.value * tumble;
    }

    
}
