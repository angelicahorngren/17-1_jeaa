using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


namespace SG
{
    public class PlayerLocmotion : MonoBehaviour
    {
        Transform cameraObject;
        ControlsMac inputHandler;
        public Vector3 moveDirection;

        PlayerManager playerManager;


        [HideInInspector]
        public Transform mytransform;
        [HideInInspector]
        public AnimaterHandler animaterHandler;




        public new Rigidbody rigidbody;
        public GameObject normalCamera;

        [Header("Ground & Air Detection Stats")]
        [SerializeField]
        float groundDetectionRayStartPoint = 0.5f;
        [SerializeField]
        float minimumdistanceNeededToBeginFall = 1f;
        [SerializeField]
        float groundDetectionRayDistance = 0.2f;
        LayerMask ignoreForGroundCheck;
        public float inAirTimer;


        [Header("Movement Stats")]
        [SerializeField]
        float movementSpeed = 5;
        [SerializeField]
        float walkingspeed = 1;
        [SerializeField]
        float sprintSpeed = 7;
        [SerializeField]
        float rotationalSpeed = 10;
        [SerializeField]
        float fallingSpeed = 45;


        void Start()
        {
            playerManager = GetComponent<PlayerManager>();
            rigidbody = GetComponent<Rigidbody>();
            inputHandler = GetComponent<ControlsMac>();
            animaterHandler = GetComponentInChildren<AnimaterHandler>();
            cameraObject = Camera.main.transform;
            mytransform = transform;
            animaterHandler.Initialize();

            playerManager.isGrounded = true;
            //ignoreForGroundCheck = (1 << 8 | 1 << 11);



        }

      


        #region Movement
        Vector3 normalVerctor;
        Vector3 targetPosition;

        private void HandelRotation(float delta)
        {
            Vector3 targetDir = Vector3.zero;
            float moveOverride = inputHandler.moveAmount;

            targetDir = cameraObject.forward * inputHandler.vertical;
            targetDir += cameraObject.right * inputHandler.horizontal;

            targetDir.Normalize();
            targetDir.y = 0;

            if (targetDir == Vector3.zero)
                targetDir = mytransform.forward;

            float rs = rotationalSpeed;

            Quaternion tr = Quaternion.LookRotation(targetDir);
            Quaternion targetRotation = Quaternion.Slerp(mytransform.rotation, tr, rs * delta);
            mytransform.rotation = targetRotation;
        }


        public void HandleMovement(float delta)
        {
            if (inputHandler.lockMovement)
                return;


            if (playerManager.isInteracting)
                return;


            moveDirection = cameraObject.forward * inputHandler.vertical;
            moveDirection += cameraObject.right * inputHandler.horizontal;
            moveDirection.Normalize();
            moveDirection.y = 0;

            float speed = movementSpeed;

            if (inputHandler.getsprintFlag())
            {
                speed = sprintSpeed;
                playerManager.isSprinting = true;
                moveDirection *= speed;
            }
            else
            {
                moveDirection *= speed;
            }


            Vector3 projectVelocity = Vector3.ProjectOnPlane(moveDirection, normalVerctor);
            rigidbody.velocity = projectVelocity;

            animaterHandler.UpdateAnimatorValues(inputHandler.moveAmount, 0, playerManager.isSprinting);

            if (animaterHandler.canRotate)
            {
                HandelRotation(delta);
            }



        }


        public void HandleRollingAndSprinting(float delta)
        {
            if (animaterHandler.anim.GetBool("isInteracting"))
                return;
            
            if (inputHandler.rollFlag)
            {
                moveDirection = cameraObject.forward * inputHandler.vertical;
                moveDirection += cameraObject.right * inputHandler.horizontal;
                if (inputHandler.moveAmount > .1f)
                {
                    animaterHandler.PlayTargetAnimation("Rolling", true);
                    moveDirection.y = 0;
                    Quaternion rollRotation = Quaternion.LookRotation(moveDirection);
                    mytransform.rotation = rollRotation;
                    rigidbody.AddForce(transform.forward * 7, ForceMode.VelocityChange);


                }
                else
                {
                    animaterHandler.PlayTargetAnimation("Backstep", true);
                    rigidbody.AddForce(-transform.forward * 7, ForceMode.VelocityChange);
                    
                }
                inputHandler.rollFlag = false;

            }
        }


        public void HandleFalling(float delta, Vector3 moveDirection)
        {
            playerManager.isGrounded = false;
            RaycastHit hit;
            Vector3 origin = mytransform.position;
            origin.y += groundDetectionRayStartPoint;

            if(Physics.Raycast(origin, mytransform.forward, out hit, 0.4f))
            {
                moveDirection = Vector3.zero;

            }

            if (playerManager.isInAir)
            {
                rigidbody.AddForce(-Vector3.up * fallingSpeed);
                rigidbody.AddForce(moveDirection * fallingSpeed / 10f);
            }

            Vector3 dir = moveDirection;
            dir.Normalize();
            origin = origin + dir * groundDetectionRayDistance;

            targetPosition = mytransform.position;

            Debug.DrawRay(origin, -Vector3.up * minimumdistanceNeededToBeginFall, Color.red, 0.1f, false);
            Physics.Raycast(origin, -Vector3.up, out hit, minimumdistanceNeededToBeginFall);

            if (hit.collider != null)
            {
                normalVerctor = hit.normal;
                Vector3 tp = hit.point;
                playerManager.isGrounded = true;
                targetPosition.y = tp.y;

                if (playerManager.isInAir)
                {
                    Debug.Log("you were in the air for " + inAirTimer);
                    animaterHandler.PlayTargetAnimation("Land", true);
                    inAirTimer = 0;

                }
                else
                {
                    animaterHandler.PlayTargetAnimation("Blend Tree", false);
                    inAirTimer = 0;
                }


                playerManager.isInAir = false;


            }

            else
            {
                if (playerManager.isGrounded)
                {
                    playerManager.isGrounded = false;
                }

                if (playerManager.isInAir == false)
                {
                    if(playerManager.isInteracting == false)
                    {
                        animaterHandler.PlayTargetAnimation("Falling", true);
                    }
                    Vector3 vel = rigidbody.velocity;
                    vel.Normalize();
                    rigidbody.velocity = vel * (movementSpeed / 2);
                    playerManager.isInAir = true;

                }

            }

            if (playerManager.isGrounded)
            {
                if(playerManager.isInteracting || inputHandler.moveAmount > 0)
                {
                    mytransform.position = Vector3.Lerp(mytransform.position, targetPosition, Time.deltaTime);
                }
                else
                {
                    mytransform.position = targetPosition;
                }
            }



        }







        #endregion
    }

    

}