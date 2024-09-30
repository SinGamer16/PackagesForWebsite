using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    GameSettings gameSettings;
    private int playerAsPlayer;

    [SerializeField] private GameObject Cam;

    private ThirdPersonSettings playerSettings;
    private float walkSpeed;
    private float runSpeed;
    private float jumpPower;
    private float stamina;
    private float drainSpeed;
    private float regenSpeed;
    private bool Running = false;
    private float speed;
    private bool Crounching = false;
    private float playerHeight;
    private float crouchHeight;
    private float currentHeight;

    private Rigidbody rb;
    private float distToGround;
    [SerializeField] private LayerMask GroundMask;

    void Start()
    {
        // Get GameSettings
        gameSettings = transform.root.Find("GameSettings").gameObject.GetComponent<GameSettings>();

        // playerSettings Script Link
        playerSettings = transform.parent.GetComponent<ThirdPersonSettings>();

        // Variable linked to PlayerSettings script
        walkSpeed = playerSettings.PlayerWalkSpeed;
        runSpeed = playerSettings.PlayerRunSpeed;
        jumpPower = playerSettings.PlayerJumpPower;
        stamina = playerSettings.PlayerStamina;
        drainSpeed = playerSettings.StaminaDrainSpeed;
        regenSpeed = playerSettings.StaminaRegenSpeed;
        playerHeight = playerSettings.PlayerHeight;
        crouchHeight = playerSettings.CrouchHeight;

        // Rigidbody Stuff
        rb = GetComponent<Rigidbody>();
        currentHeight = transform.localScale.y;
        distToGround = currentHeight; // Gets the players heights and halfs it because the position of the object is only half way up.
    }

    // Test if player is on the ground (Make sure to make a Ground mask and apply in inspecter)
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.15f, GroundMask);
    }

    void Update()
    {
        playerAsPlayer = gameSettings.playingAsPlayer;
        if (playerAsPlayer != playerSettings.playerID)
        {
            Cam.SetActive(false);
            return;
        }
        Cam.SetActive(true);

        currentHeight = transform.localScale.y;

        // Moving
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        Vector3 dir = transform.right * x + transform.forward * y;


        
        SortControls();

        //Stamina
        if (Running && stamina > 0)
        {
            playerSettings.PlayerStamina -= drainSpeed * Time.deltaTime;
            stamina = playerSettings.PlayerStamina;
        }
        if (!Running && stamina < playerSettings.MaxStamina)
        {
            playerSettings.PlayerStamina += regenSpeed * Time.deltaTime;
            stamina = playerSettings.PlayerStamina;
        }
        if (stamina < 0)
        {
            playerSettings.PlayerStamina = 0;
            stamina = playerSettings.PlayerStamina;
        }
        if (stamina > playerSettings.MaxStamina)
        {
            playerSettings.PlayerStamina = playerSettings.MaxStamina;
            stamina = playerSettings.PlayerStamina;
        }

        //Running
        if (!Running)
        {
            speed = Mathf.Lerp(speed, walkSpeed, 10f * Time.deltaTime);
        }
        else
        {
            speed = Mathf.Lerp(speed, runSpeed, 10f * Time.deltaTime);
        }

        //Crouching
        
        if (Crounching)
        {
            transform.localScale = new Vector3(0.8f, Mathf.Lerp(currentHeight, crouchHeight, Time.deltaTime * 10f), 0.8f);
        }
        else
        {
            transform.localScale = new Vector3(0.8f, Mathf.Lerp(currentHeight, playerHeight, Time.deltaTime * 10f), 0.8f);
        }

        // Jumping
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity += Vector3.up * jumpPower;
        }
        
        //Moving Player
        rb.MovePosition(transform.position + dir * speed);
    }

    void SortControls()
    {
        //Running
        if (Input.GetKeyDown(KeyCode.LeftControl) && stamina > 0)
        {
            Running = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Running = false;
        }
        if (stamina <= 0)
        {
            Running = false;
        }

        

        //Crouching
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Crounching = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)) 
        { 
            Crounching = false;
        }
    }
}
