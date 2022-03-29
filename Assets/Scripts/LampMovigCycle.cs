using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampMovigCycle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private float cycleRange = 10f;

    void Update()
    {
        transform.position = new Vector3(2f*Mathf.PingPong(Time.time*2f, cycleRange), transform.position.y, transform.position.z);


    }

}
