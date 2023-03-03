using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SG {
    public class PlayerManager : MonoBehaviour
    {
        ControlsMac inputHandler;
        Animator anim;
        CameraHandler cameraHandler;
        PlayerLocmotion playerLocmotion;
        DancesHandler dancesHandler;

        public bool isInteracting;

        [Header ("Player Flags")]
        public bool isSprinting;
        public bool isInAir;
        public bool isGrounded;
        public bool CanDoCombo;
        public bool isTwerking;
        public bool isHiphopDancing;
        public bool isPowerUP;


        private void Awake()
        {
        }


        void Start()
        {
            Debug.Log("Heeyy");
            cameraHandler = FindObjectOfType<CameraHandler>();
            inputHandler = GetComponent<ControlsMac>();
            dancesHandler = GetComponent < DancesHandler>();
            anim = GetComponentInChildren<Animator>();
            playerLocmotion = GetComponent<PlayerLocmotion>();
        }



        // Update is called once per frame
        void Update()
        {

            float delta = Time.deltaTime;

            isInteracting = anim.GetBool("isInteracting");
            CanDoCombo = anim.GetBool("CanDoCombo");

            dancesHandler.TickInput(delta);
            inputHandler.TickInput(delta);
            playerLocmotion.HandleMovement(delta);
            playerLocmotion.HandleRollingAndSprinting(delta);
            playerLocmotion.HandleFalling(delta, playerLocmotion.moveDirection);
            playerLocmotion.HandleTwerk(delta);
            playerLocmotion.HandleWaveHipHop(delta);
            playerLocmotion.HandleSprintingAttack(delta);
            playerLocmotion.HandlePowerUp(delta);



        }



        private void FixedUpdate()
        {
            float delta = Time.fixedDeltaTime;
            if (cameraHandler != null)
            {
                cameraHandler.FollowTarget(delta);
                cameraHandler.HandleCameraRotation(delta, inputHandler.mouseX, inputHandler.mouseY);
            }
        }


        private void LateUpdate()
        {
            //inputHandler.rollFlag = false;
            //inputHandler. = false;

            isSprinting = inputHandler.getb_Input();
            inputHandler.rb_Input = false;
            inputHandler.rt_Input = false;
            inputHandler.d_pad_up = false;
            inputHandler.d_pad_down = false;
            inputHandler.d_pad_right = false;
            inputHandler.d_pad_left = false;



            isTwerking = dancesHandler.getTwerk_Input();
            isHiphopDancing = dancesHandler.getHipHop_Input();

            if (isInAir)
            {
                playerLocmotion.inAirTimer = playerLocmotion.inAirTimer + Time.deltaTime;
            }




        }

    }
}