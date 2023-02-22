using UnityEngine;

public class friend : MonoBehaviour
{
    public GameObject player;  
    public float followDistance = 5f;  //boss follows the player at this distance
    public float stopDistance = 0.5f;  //boss stops following the player at this distance
    public float startFollowDistance = 10f; //boss sees and starts to follow player at this distance
    public float speed = 0.1f;  //movement speed
    public float hoverHeight = 10f;  //placement above the ground

    void Update()
    {
        //gets distance to player
        float distance = Vector3.Distance(player.transform.position, transform.position);

        //if the player is within startFollowDistance and the distance to player is greater than followDistance
        if (distance <= startFollowDistance && distance > followDistance)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.LookAt(player.transform);

            //hover above ground
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.up, out hit))
            {
                transform.position = new Vector3(transform.position.x, hit.point.y + hoverHeight, transform.position.z);
            }
        }
        
        else if (distance <= stopDistance)
        {
            //do nothing
        }
        //stay still but look at player
        else
        {
            transform.LookAt(player.transform);

            //hover above ground
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.up, out hit))
            {
                transform.position = new Vector3(transform.position.x, hit.point.y + hoverHeight, transform.position.z);
            }
        }
    }
}
