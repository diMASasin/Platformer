using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool Grounded { get; private set; }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Grounded = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Grounded = true;
    }

}
