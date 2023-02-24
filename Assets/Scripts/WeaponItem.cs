using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    [CreateAssetMenu (menuName = "Item/Weapon Item")]
    public class WeaponItem : Item
    {
        public GameObject modelPrefab;
        private bool isUnarmed;


        [Header("Idle Animation")]
        public string right_hand_idle;
        public string left_hand_idle;



        [Header("One Handed Attack Animation")]
        public string OH_Light_Attack_1;
        public string OH_Light_Attack_2;
        public string OH_Heavy_Attack_1;


    }
}
