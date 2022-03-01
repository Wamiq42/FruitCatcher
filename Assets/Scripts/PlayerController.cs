using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private Vector3 direction;
    private Vector3 moveDirection;
    private float targetAngle;
    private float smoothAngle;
    private float smoothTime = 0.1f;
    private float currentVelocity;
    private int score;


    public GameManager gameManager;
    public float speed;
    public float rotationAngle;
    public Transform cameraTransform;
    public Animator playerAnimator;
    public CharacterController playerCharacterController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerMovement();
        MovementwithCharacterController();
       
    }





    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Fruit"))
        {
            Debug.Log("Collided with Fruits");
            other.GetComponent<Fruits>().fruitScore();
            gameManager.setScore(gameManager.getScore() + other.GetComponent<Fruits>().getScore());
            Destroy(other.gameObject);
        }
        
    }

    void MovementwithCharacterController()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
       

        if(direction.magnitude > 0.1)
        {
            targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);


            moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            playerCharacterController.Move(moveDirection.normalized * speed * Time.deltaTime);
            playerAnimator.SetBool("AmyWalkForward", true);
        }
        else
        {
            playerAnimator.SetBool("AmyWalkForward", false);
           
        }
    }
   

    //Code but not using Character Controller;
    void PlayerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (verticalInput > 0)
        {
            transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
            playerAnimator.SetBool("AmyWalkForward", true);
            playerAnimator.SetBool("AmyWalkBackward", false);
        }
        else if (verticalInput < 0)
        {
            transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
            playerAnimator.SetBool("AmyWalkBackward", true);
            playerAnimator.SetBool("AmyWalkForward", false);
        }
        else if (verticalInput == 0)
        {
            playerAnimator.SetBool("AmyWalkForward", false);
            playerAnimator.SetBool("AmyWalkBackward", false);
        }
        if (horizontalInput > 0)
        {
            transform.Rotate(Vector3.up, rotationAngle * Time.deltaTime);
            
        }
        if (horizontalInput < 0)
        {
            transform.Rotate(Vector3.down, rotationAngle * Time.deltaTime);
         
        }
    }
}
