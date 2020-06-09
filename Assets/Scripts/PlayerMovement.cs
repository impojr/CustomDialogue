using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Velocity = 10f;
    [Space]

    private Animator anim;
    private Camera cam;
    private CharacterController controller;

    [Header("Player Rotation")]
    public float desiredRotationSpeed = 0.1f;
    public float allowPlayerRotation = 0.1f;

    [Header("Animation Smoothing")]
    [Range(0, 1f)]
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.15f;

    public float InputX;
    public float InputZ;
    public Vector3 desiredMoveDirection;

    public float Speed;
    public bool canMove = true;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        cam = Camera.main;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate Input Vectors
        if (canMove)
        {
            InputX = Input.GetAxis("Horizontal");
            InputZ = Input.GetAxis("Vertical");
            ProcessInputs();
        } 
    }

    void ProcessInputs()
    {
        //Calculate the Input Magnitude
        Speed = new Vector2(InputX, InputZ).sqrMagnitude;

        //Only move the character if the speed is greater than the threshold
        if (Speed > allowPlayerRotation)
        {
            anim.SetFloat("Blend", Speed, StartAnimTime, Time.deltaTime);
            PlayerMoveAndRotation();
        }
        else if (Speed < allowPlayerRotation)
        {
            anim.SetFloat("Blend", Speed, StopAnimTime, Time.deltaTime);
        }
    }

    void PlayerMoveAndRotation()
    {
        var cam = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        desiredMoveDirection = forward * InputZ + right * InputX;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
        controller.Move(desiredMoveDirection * Time.deltaTime * Velocity);
    }

    public void DisablePlayerMovement()
    {
        canMove = false;
        Speed = 0;
        anim.SetFloat("Blend", Speed);
    }

    public void EnablePlayerMovement()
    {
        canMove = true;
    }

    public void StartWalkingAnim()
    {
        anim.SetFloat("Blend", Velocity);
    }

    public void StopWalkingAnim()
    {
        anim.SetFloat("Blend", 0);
    }
}
