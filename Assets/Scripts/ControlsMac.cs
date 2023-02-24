using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace SG
{
    public class ControlsMac : MonoBehaviour
    {
        public float horizontal;
        public float vertical;
        public float moveAmount;
        public float mouseX;
        public float mouseY;

        [SerializeField]
        bool b_Input;
        public bool rb_Input;
        public bool rt_Input;
        public bool PowerUp_Input;
        public bool d_pad_up;
        public bool d_pad_down;
        public bool d_pad_left;
        public bool d_pad_right;


        public bool rollFlag;
        public bool lockMovement;
        public bool stopanimation;

        [SerializeField]
        bool sprintFlag;
        public bool comboFlag;
        public bool PowerUpFlag;
        public float rollInputTimer;


        PlayerControls inputActions;
        PlayerAttacker playerAttacker;
        PlayerInventory playerInventory;
        PlayerManager playerManager;
        

        Vector2 movementInput;
        Vector2 cameraInput;



        public void Awake()
        {
            playerAttacker = GetComponent<PlayerAttacker>();
            playerInventory = GetComponent<PlayerInventory>();
            playerManager = GetComponent<PlayerManager>();
        }

        public bool getb_Input()
        {
            return b_Input;
        }

        

        public bool getsprintFlag()
        {
            return sprintFlag;
        }


        private void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new PlayerControls();
                inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
                inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            }

            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        public void TickInput(float delta)
        {
            MoveInput(delta);
            HandleRollInput(delta);
            HandleAttackInput(delta);
            HandleQuickslotsInput();
            HandlePowerUpInput(delta);
        }


        public void MoveInput(float delta)
        {
            horizontal = movementInput.x;
            vertical = movementInput.y;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
            mouseX = cameraInput.x;
            mouseY = cameraInput.y;

        }

        private void HandleRollInput(float delta)
        {
            if (lockMovement)
            {
                return;
            }


            b_Input = inputActions.PlayerActions.Roll.IsPressed();
            if (b_Input)
            {
                rollInputTimer += delta;
                sprintFlag = true;
            }
            else
            {
                sprintFlag = false;
                if (rollInputTimer > 0 && rollInputTimer < 0.3f)
                {
                    rollFlag = true;

                }
                rollInputTimer = 0;

            }

        }


        private void HandleAttackInput(float delta)
        {
            if (lockMovement)
            {
                return;
            }

            inputActions.PlayerActions.RB.performed += i => rb_Input = true;
            inputActions.PlayerActions.RT.performed += i => rt_Input = true;


            //RB Input Handles the Right Hand weapon's light attack
            if (rb_Input)
            {
                if (playerManager.CanDoCombo)
                {
                    comboFlag = true;
                    playerAttacker.HandleWeaponCombo(playerInventory.rightWeapon);
                    comboFlag = false;
                }
                else
                {
                    if (lockMovement)
                    {
                        return;
                    }
                    if (playerManager.CanDoCombo)
                    {
                        return;
                    }
                    playerAttacker.HandleLightAttack(playerInventory.rightWeapon);

                }
            }

            if (rt_Input)
            {
                playerAttacker.HandleHeavyAttack(playerInventory.rightWeapon);

            }

        }


        private void HandleQuickslotsInput()
        {
            inputActions.PlayerQuickSlots.DPadRight.performed += i => d_pad_right = true;
            inputActions.PlayerQuickSlots.DPadLeft.performed += i => d_pad_left = true;


            if (d_pad_right)
            {
                playerInventory.ChangeRightWeapon();
            }


            else if (d_pad_left)
            {
                playerInventory.ChangeLeftWeapon();
            }
                
        }


        private void HandlePowerUpInput(float delta)
        {

            if (lockMovement)
            {
                return;
            }
            PowerUp_Input = inputActions.PlayerQuickSlots.DPadUp.IsPressed();

            if (PowerUp_Input)
            {
                PowerUpFlag  = true;
            }

            else
            {
                PowerUpFlag = false;
            }
        }



        


    }



}