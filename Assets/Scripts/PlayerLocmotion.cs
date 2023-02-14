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
        Vector3 moveDirection;

        [HideInInspector]
        public Transform mytransform;
        [HideInInspector]
        public AnimaterHandler animaterHandler;




        public new Rigidbody rigidbody;
        public GameObject normalCamera;


        [Header("Stats")]
        [SerializeField]
        float movementSpeed = 5;
        [SerializeField]
        float sprintSpeed = 9;
        [SerializeField]
        float rotationalSpeed = 10;

        public bool isSprinting;



        // Start is called before the first frame update
        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            inputHandler = GetComponent<ControlsMac>();
            animaterHandler = GetComponentInChildren<AnimaterHandler>();
            cameraObject = Camera.main.transform;
            mytransform = transform;
            animaterHandler.Initialize();




        }

        public void Update()
        {
            float delta = Time.deltaTime;

            isSprinting = inputHandler.b_Input; 
            inputHandler.TickInput(delta);

            HandleMovement(delta);
            HandleRollingAndSprinting(delta);





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
            if (inputHandler.rollFlag)
                return;
            
            moveDirection = cameraObject.forward * inputHandler.vertical;
            moveDirection += cameraObject.right * inputHandler.horizontal;
            moveDirection.Normalize();
            moveDirection.y = 0;

            float speed = movementSpeed;

            if (inputHandler.sprintFlag)
            {
                speed = sprintSpeed;
                isSprinting = true;
                moveDirection *= speed;
            }
            else
            {
                moveDirection *= speed;
            }


            Vector3 projectVelocity = Vector3.ProjectOnPlane(moveDirection, normalVerctor);
            rigidbody.velocity = projectVelocity;

            if (animaterHandler.canRotate)
            {
                HandelRotation(delta);
            }


            animaterHandler.UpdateAnimatorValues(inputHandler.moveAmount, 0, isSprinting);

        }


        public void HandleRollingAndSprinting(float delta)
        {
            if (animaterHandler.anim.GetBool("isInteracting"))
                return;
            
            if (inputHandler.rollFlag)
            {
                moveDirection = cameraObject.forward * inputHandler.vertical;
                moveDirection += cameraObject.right * inputHandler.horizontal;
                if (inputHandler.moveAmount > 0)
                {
                    animaterHandler.PlayTargetAnimation("Rolling", true);
                    moveDirection.y = 0;
                    Quaternion rollRotation = Quaternion.LookRotation(moveDirection);
                    mytransform.rotation = rollRotation;
                }
                else
                {
                    animaterHandler.PlayTargetAnimation("Backstep", true);
                }
            }
        }








        #endregion
    }

    

}