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

        public bool isInteracting;

        [Header ("Player Flags")]
        public bool isSprinting;
        public bool isInAir;
        public bool isGrounded;


        private void Awake()
        {
        }


        void Start()
        {
            cameraHandler = CameraHandler.singleton;
            inputHandler = GetComponent<ControlsMac>();
            anim = GetComponentInChildren<Animator>();
            playerLocmotion = GetComponent<PlayerLocmotion>();
        }



        // Update is called once per frame
        void Update()
        {

            float delta = Time.deltaTime;

            isInteracting = anim.GetBool("isInteracting");
            

            inputHandler.TickInput(delta);
            playerLocmotion.HandleMovement(delta);
            playerLocmotion.HandleRollingAndSprinting(delta);
            playerLocmotion.HandleFalling(delta, playerLocmotion.moveDirection);






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

            if (isInAir)
            {
                playerLocmotion.inAirTimer = playerLocmotion.inAirTimer + Time.deltaTime;
            }




        }

    }
}