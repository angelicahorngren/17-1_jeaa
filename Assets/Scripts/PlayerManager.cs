using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG {
    public class PlayerManager : MonoBehaviour
    {
        ControlsMac inputHandeler;
        Animator anim;

        void Start()
        {
            inputHandeler = GetComponent<ControlsMac>();
            anim = GetComponentInChildren<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            inputHandeler.isInteracting = anim.GetBool("isInteracting");
            inputHandeler.rollFlag = false;
            inputHandeler.sprintFlag = false;
        }


    }
}