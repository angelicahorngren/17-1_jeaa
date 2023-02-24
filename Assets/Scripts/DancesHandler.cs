using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

namespace SG
{
    public class DancesHandler : MonoBehaviour
    {

        ControlsMac inputHandler;

        [SerializeField]
        bool Twerk_Input;
        bool HipHop_Input;
        public bool TwerkFlag;
        public bool HipHopFlag;



        PlayerControls inputActions;


        void Start()
        {
            inputHandler = GetComponent<ControlsMac>();
        }



        public bool getTwerk_Input()
        {
            return Twerk_Input;
        }

        public bool getHipHop_Input()
        {
            return HipHop_Input;
        }



        private void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new PlayerControls();
            }

            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }


        public void TickInput(float delta)
        {
            handleTwerkInput(delta);
            handleHipHopInput(delta);
        }



        private void handleTwerkInput(float delta)
        {

            if (inputHandler.lockMovement)
            {
                return;
            }
            Twerk_Input = inputActions.Dances.Twerk.IsPressed();

            if (Twerk_Input)
            {
                TwerkFlag = true;
            }

            else
            {
                TwerkFlag = false;
            }
        }

            



        private void handleHipHopInput(float delta)
        {
            if (inputHandler.lockMovement)
            {
                return;
            }
            HipHop_Input = inputActions.Dances.WaveHipHop.IsPressed();

            if (HipHop_Input)
            {
                HipHopFlag = true;
            }

            else
            {
                HipHopFlag = false;
            }

        }

    }
}