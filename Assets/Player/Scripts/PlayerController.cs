using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{



    [Header("Input Settings")]
    [SerializeField] private DefaultInput playerInput;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float movementSpeed; 
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Transform GroundCheck;



    [SerializeField] private Transform StartPosition;
    [SerializeField] private Transform handPosition;

    [SerializeField] private GameObject camera;

    [SerializeField] private Animator animatorController;

   private Transform GrabbedObject;



     

    // Start is called before the first frame update
    void Start()
    {
        playerInput = new DefaultInput();
        playerInput.Player.Enable();
        playerInput.Player.Jump.started += Jump;
        playerInput.Player.Grab.started += Grab;
        playerInput.Player.Grab.canceled += Throw;

        //playerInput.Player.Movement.performed += OnMovement;
    }



    void FixedUpdate()

    {
        float inputMovement = playerInput.Player.Movement.ReadValue<float>();
        if (transform.position.y < -3f)
        {
            transform.position = StartPosition.position;
           
        }
        else Movement(inputMovement, movementSpeed);
            

    }
    
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(handPosition.position, 0.3f);

    }

    void Update()
    {
        
        camera.transform.position = new Vector3( transform.position.x, transform.position.y + 4f, camera.transform.position.z);

    }


    public void Grab(InputAction.CallbackContext context)
    {
         if(Physics.SphereCast(handPosition.position, 0.3f, Vector3.forward, out RaycastHit hit))
        {
            Debug.Log(hit);
            GrabbedObject = hit.collider.transform;
            GrabbedObject.SetParent(transform);
        }

    }

     public void Throw(InputAction.CallbackContext context)
    {
        if (GrabbedObject) GrabbedObject.SetParent(null);
    }

    public void OnMovement (InputAction.CallbackContext context)
    {

        animatorController.SetFloat("MovementSpeed", Mathf.Abs(context.ReadValue<float>()));
        
        if (context.ReadValue<float>() != 0) 
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * context.ReadValue<float>(), transform.localScale.y, transform.localScale.z);
        }

    }

        public void Movement (float moveDirection, float velocity)
    {

        Vector2 dir = rigidbody.position + new Vector3(moveDirection, 0,0) * (Time.fixedDeltaTime * velocity);
        rigidbody.transform.position = new Vector3(dir.x, rigidbody.transform.position.y, rigidbody.transform.position.z) ;

    }

    public void Jump (InputAction.CallbackContext context)
    {

        if(IsGrounded(GroundCheck.position)) rigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);

    }


    public bool IsGrounded(Vector3 position)
    {
        float distance = 0.1f;

        if(Physics.Raycast(position, Vector3.down, out RaycastHit hit, distance))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}
