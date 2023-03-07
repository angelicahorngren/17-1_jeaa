using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : StateMachineBehaviour
{
    private Transform target; 
    public float speed = 2f;

    private Vector3 direction;  

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerPos = player.transform.position;
        Vector3 direction = playerPos - animator.transform.position;
        float distance = direction.magnitude;

        float range = 5f;
        if (distance > range)
        {
            direction = direction.normalized;
            animator.transform.position += direction * speed * Time.deltaTime;
            animator.transform.rotation = Quaternion.LookRotation(-direction);
        }
        else{
            animator.SetTrigger("Attack");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        animator.ResetTrigger("Attack");
    }

}
