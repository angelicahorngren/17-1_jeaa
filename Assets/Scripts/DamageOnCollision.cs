using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class DamageOnCollision : MonoBehaviour
    {
        public int damage = 25;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("friend"))
            {
                friend friendStats = collision.gameObject.GetComponent<friend>();

                if (friendStats != null)
                {
                    friendStats.TakeDamage(damage);
                }
            }
        }
    }
}
