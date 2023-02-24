using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SG
{
    public class WeaponSlotManager : MonoBehaviour
    {
        WeaponHolderSlot leftHandSlot;
        WeaponHolderSlot rightHandSlot;

        DamageCollider rightHandDamageCollider;
        DamageCollider leftHandDamageCollider;

        Animator animator;

        public void Awake()
        {
            animator = GetComponent<Animator>();
            WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();

            foreach(WeaponHolderSlot weaponSlot in weaponHolderSlots)
            {
                if (weaponSlot.isLeftHandSlot)
                {
                    leftHandSlot = weaponSlot;
                }
                else if (weaponSlot.isRightHandSlot) 
                {
                    rightHandSlot = weaponSlot;
                }


            }

        }

        public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
        {
            if (isLeft)
            {
                leftHandSlot.LoadWeaponItem(weaponItem);
                LoadLeftHandDamageCollider();

                #region Handle Left Weapon Item Animations
                if (weaponItem != null)
                {
                    animator.CrossFade(weaponItem.left_hand_idle, 0.2f);
                }
                else
                {
                    animator.CrossFade("left arm empty", 0.2f);
                }
                #endregion
            }
            else
            {
                rightHandSlot.LoadWeaponItem(weaponItem);
                LoadrightHandDamageCollider();

                #region Handle Right Weapon Item Animations
                if (weaponItem != null)
                {
                    animator.CrossFade(weaponItem.right_hand_idle, 0.2f);
                }
                else
                {
                    animator.CrossFade("right arm empty", 0.2f);
                }
                #endregion
            }
        }

        #region Handle Weapon's Damage Collider

        public void LoadLeftHandDamageCollider()
        {
            leftHandDamageCollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        }


        public void LoadrightHandDamageCollider()
        {
            rightHandDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();

        }


        public void OpenLeftHandDamageCollider()
        {
            leftHandDamageCollider.EnableDamageCollider();

        }


        public void OpenRightHandDamageCollider()
        {
            rightHandDamageCollider.EnableDamageCollider();
        }

        public void CloseLeftHandDamageCollider()
        {
            leftHandDamageCollider.DisableDamageCollider();

        }


        public void CloseRightHandDamageCollider()
        {
            rightHandDamageCollider.DisableDamageCollider();
        }



        #endregion

    }
}
