using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsGrounded()
    {
        //RaycastHit hit;
        float distance = 1f;

        if(Physics.Raycast(transform.position, Vector2.down, out RaycastHit hit, distance))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
