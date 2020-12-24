using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool Grounded;

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if(collision.otherCollider)
    //        Grounded = false;
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.otherCollider)
    //        Grounded = true;
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        Grounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Grounded = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Grounded = true;
    }

}
