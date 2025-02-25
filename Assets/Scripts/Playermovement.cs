using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


// This Code was from a tutorial on Youtube however I have no idea where the video has gone 
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 1f;
    public float runSpeed = 2f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public float defaultHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchSpeed = 3f;
    public GameObject PauseMenuUI;
    public GameObject SettingMenuUi;
    public GameObject ControlsMenuUI;
    public GameObject OptionsMenuUi;
    public TMP_Text StaminaUI;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;


    public bool canMove = true;



    [Header("Player Input Variables")]
    private PlayerInputSystem playerInputSystem;
    public Vector2 MoveInput;
    public Vector2 CameraInput;
    public bool IsInteractPressed;
    public bool IsFlashlightPressed;
    public bool IsJumpPressed;
    public bool IsReloadPressed;
    public bool Sprinting;
    public bool Crouching;
    public bool IsMenuPressed;
    public bool IsUnlockdoorPressed;
    public float Stamina;
    public float MaxStamina = 100;
    public float StaminaDrop;
    public float StaminaIncrease;
    private bool CanSprint = true;





    void Start()
    {

        Stamina = MaxStamina;
        StaminaUI.text = $"Stamina: {Stamina}";
        StaminaUI.color = Color.green;
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        PauseMenuUI.SetActive(false);
        SettingMenuUi.SetActive(false);
        ControlsMenuUI.SetActive(false);
        OptionsMenuUi.SetActive(false);
    }

    void Update()
    {
        if (canMove)
        {
            CheckJump();
            ApplyMovement();
            CheckCrouch();
            ApplyCamera();
            
        }
    }

    private void ApplyMovement()
    {
        float moveDirectionY = moveDirection.y;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeedX = (Sprinting && Stamina > 0 && CanSprint ? runSpeed : walkSpeed) * MoveInput.y;
        float curSpeedY = (Sprinting && Stamina > 0 && CanSprint ? runSpeed : walkSpeed) * MoveInput.x;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        if (!characterController.isGrounded)
        {
            moveDirectionY -= gravity * Time.deltaTime;
        }
        moveDirection.y = moveDirectionY;
        characterController.Move(moveDirection * Time.deltaTime);

        if (Sprinting)
        {
            Stamina -= StaminaDrop * Time.deltaTime;
            if (Stamina <= 0)
            {
                StaminaUI.color = Color.red;
                Stamina = 0;
                CanSprint = false;
                StartCoroutine(StaminaCoolDown());
            }

            StaminaUI.text = Stamina > 0 ? $"Stamina : {Mathf.Floor(Stamina)}" : $"Stamina : 0";
        }

        if (!Sprinting && Stamina >= 1)
        {
            Stamina += StaminaIncrease * Time.deltaTime;
            if(Stamina >= 50)
            {
                Stamina = 50;
                CanSprint = true;
            }
            StaminaUI.text = Stamina < 50 ? $"Stamina : {Mathf.Floor(Stamina)}" : $"Stamina : 50";
        }
    }

    IEnumerator StaminaCoolDown()
    {
        yield return new WaitForSeconds(5f);
        CanSprint = true;
        Stamina = MaxStamina;
        StaminaUI.text = $"Stamina : {Stamina}";
        StaminaUI.color = Color.green;
    }

    private void CheckCrouch()
    {
        Debug.Log(Crouching);
        if (Crouching)
        {
            characterController.height = crouchHeight;
            walkSpeed = crouchSpeed;
            runSpeed = crouchSpeed;

        }
        else
        {
            characterController.height = defaultHeight;
            walkSpeed = 2f;
            runSpeed = 4f;
        }
    }

    private void CheckJump()
    {
        Debug.Log(IsJumpPressed);
        if (characterController.isGrounded && IsJumpPressed)
        {
            moveDirection.y = jumpPower;
        }
    }

    private void ApplyCamera()
    {
        rotationX += -CameraInput.y * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, CameraInput.x * lookSpeed, 0);
    }



    private void OnEnable()
    {
        playerInputSystem = new();
        playerInputSystem.Enable();
        playerInputSystem.Main.Move.performed += OnMove;
        playerInputSystem.Main.Move.canceled += OnMove;
        playerInputSystem.Main.Look.performed += OnLook;
        playerInputSystem.Main.Look.canceled += OnLook;
        playerInputSystem.Main.Sprint.performed += OnSprint;
        playerInputSystem.Main.Sprint.canceled += OnSprint;
        playerInputSystem.Main.Crouch.performed += OnCrouch;
        playerInputSystem.Main.Crouch.canceled += OnCrouch;
        playerInputSystem.Main.Interact.performed += OnInteract;
        playerInputSystem.Main.Flashlight.performed += OnFlashlight;
        playerInputSystem.Main.Jump.performed += OnJump;
        playerInputSystem.Main.Jump.canceled += OnJump;
        playerInputSystem.Main.Reload.performed += OnReload;
        playerInputSystem.Main.MenuOpenClose.performed += OnMenu;
        playerInputSystem.Main.UnlockDoor.performed += OnDoorUnlocked;
        playerInputSystem.Main.UnlockDoor.canceled += OnDoorUnlocked;

    }

    private void OnDisable()
    {
        playerInputSystem = new();
        playerInputSystem.Disable();
        playerInputSystem.Main.Move.performed -= OnMove;
        playerInputSystem.Main.Move.canceled -= OnMove;
        playerInputSystem.Main.Look.performed -= OnLook;
        playerInputSystem.Main.Look.canceled -= OnLook;
        playerInputSystem.Main.Sprint.performed -= OnSprint;
        playerInputSystem.Main.Sprint.canceled -= OnSprint;
        playerInputSystem.Main.Crouch.performed -= OnCrouch;
        playerInputSystem.Main.Crouch.canceled -= OnCrouch;
        playerInputSystem.Main.Interact.performed -= OnInteract;
        playerInputSystem.Main.Flashlight.performed -= OnFlashlight;
        playerInputSystem.Main.Jump.performed -= OnJump;
        playerInputSystem.Main.Jump.canceled -= OnJump;
        playerInputSystem.Main.Reload.performed -= OnReload;
        playerInputSystem.Main.MenuOpenClose.performed -= OnMenu;
        playerInputSystem.Main.UnlockDoor.performed -= OnDoorUnlocked;
        playerInputSystem.Main.UnlockDoor.canceled -= OnDoorUnlocked;
    }
    private void LateUpdate()
    {
        IsInteractPressed = false;
    }
    private void OnMove(InputAction.CallbackContext action)
    {
        MoveInput = action.ReadValue<Vector2>();
    }
    private void OnLook(InputAction.CallbackContext action)
    {
        CameraInput = action.ReadValue<Vector2>();
    }

    private void OnSprint(InputAction.CallbackContext action)
    {
        Sprinting = action.ReadValueAsButton();
    }
    private void OnCrouch(InputAction.CallbackContext action)
    {
        Crouching = action.ReadValueAsButton();
    }

    private void OnInteract(InputAction.CallbackContext action)
    {
        IsInteractPressed = action.ReadValueAsButton();
    }

    private void OnFlashlight(InputAction.CallbackContext action)
    {
        IsFlashlightPressed = !IsFlashlightPressed;
    }

    private void OnJump(InputAction.CallbackContext action)
    {
        IsJumpPressed = action.ReadValueAsButton();
    }

    private void OnReload(InputAction.CallbackContext action)
    {
        IsReloadPressed = action.ReadValueAsButton();
    }

    private void OnMenu(InputAction.CallbackContext action)
    {
        IsMenuPressed = action.ReadValueAsButton();
    }
    private void OnDoorUnlocked(InputAction.CallbackContext action)
    {
        IsUnlockdoorPressed = action.ReadValueAsButton();

    }
}