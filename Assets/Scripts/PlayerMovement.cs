using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public Animator animator;
    public PlayerActions playerActions;

    public float moveSpeed, walkSpeed, runSpeed;

    public Vector2 moveInput;

    public bool isRunning, isJumping;
    private void OnEnable()
    {
        playerActions = new PlayerActions();
        playerActions.ActionMap.KeyboardAction.performed += OnMove;
        playerActions.ActionMap.KeyboardAction.canceled += OnMove;
        playerActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }

    private void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        moveInput = obj.ReadValue<Vector2>();
        Debug.Log("Move Input: " + moveInput);
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        moveSpeed = isRunning ? runSpeed : walkSpeed;
        animator.SetFloat("Speed", moveInput.magnitude);

        //MoveCharacter
        //Contcatenation
        Vector3 moveDir = new Vector3(moveInput.x,0,moveInput.y);
        moveDir = transform.TransformDirection(moveDir) * moveSpeed;
        characterController.Move(moveDir);
    }
}
