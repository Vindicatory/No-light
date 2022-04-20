using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [Header("Input Settings")]
    [SerializeField] private DefaultInput playerInput;
    [SerializeField] private float movementSmoothingSpeed = 1f;
    private Vector3 correctedInputMovement;
    private Vector3 smoothInputMovement;
    
    [SerializeField] private Animator animatorController;

    [SerializeField] private float movementSpeed; 
    [SerializeField] private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = new DefaultInput();
        playerInput.Player.Movement.performed += context => OnMovement();
    }

    public GameObject camera;

    void Update()
    {
      //  float inputX = Input.GetAxis("Horizontal");
        //this.transform.Translate(new Vector3(5f * inputX, 0, 0) * Time.deltaTime);
        camera.transform.position = new Vector3(this.transform.position.x, camera.transform.position.y, camera.transform.position.z);
       // Debug.Log(inputX);
        if (transform.position.y < -3f)
            transform.position = new Vector3(-5f,0.5f,0f);
            
        //if (inputX != 0)
        //    animatorController.SetBool("bIsMoving", true);
       // else 
        //    animatorController.SetBool("bIsMoving", false);


    }

    public void OnMovement ()
        {

        Debug.Log("OnMovement");
        float inputMovement = playerInput.Player.Movement.ReadValue<float>();
        rigidbody.transform.position = new Vector3(inputMovement * movementSpeed,  rigidbody.transform.position.y, rigidbody.transform.position.z) ;

        }
    




    
}
