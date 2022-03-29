using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject camera;

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        this.transform.Translate(new Vector3(5f * inputX, 0, 0) * Time.deltaTime);
        camera.transform.position = new Vector3(this.transform.position.x, camera.transform.position.y, camera.transform.position.z);

        if (transform.position.y < -3f)
            transform.position = new Vector3(-5f,0.5f,0f);
    }

    
}
