using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SG
{
    public class PlayerAttacker : MonoBehaviour
    {

        AnimaterHandler animaterHandler;
        ControlsMac inputHandler;
        public string lastAttack;


        public void Awake()
        {
            animaterHandler = GetComponentInChildren<AnimaterHandler>();
            inputHandler = GetComponent<ControlsMac>();
        }


        public void HandleWeaponCombo(WeaponItem weapon)
        {
            if (inputHandler.comboFlag)
            {
                animaterHandler.anim.SetBool("CanDoCombo", false);
                if (lastAttack == weapon.OH_Light_Attack_1)
                {
                    animaterHandler.PlayTargetAnimation(weapon.OH_Light_Attack_2, true);
                }
            }

        }

        public void HandleLightAttack(WeaponItem weapon)
        {

            animaterHandler.PlayTargetAnimation(weapon.OH_Light_Attack_1, true);
            lastAttack = weapon.OH_Light_Attack_1;


        }


        public void HandleHeavyAttack(WeaponItem weapon)
        {

            animaterHandler.PlayTargetAnimation(weapon.OH_Heavy_Attack_1, true);
            lastAttack = weapon.OH_Heavy_Attack_1;



        }



    }
}
