using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public playerCore thePlayer;

    public float moveSpeed;
    public float playerRange;

    public LayerMask playerLayer;
    public bool playerIsRanged;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<playerCore>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] playerOverlap = Physics.OverlapSphere(transform.position, playerRange, playerLayer);
        foreach(Collider player in playerOverlap){
            playerIsRanged = true;
        }
        if(playerIsRanged){
            transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);
            transform.LookAt(thePlayer.transform);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, playerRange);
    }
}
