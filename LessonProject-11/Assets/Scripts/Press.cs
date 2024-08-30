using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Press : MonoBehaviour
{
    [SerializeField] private OnTriggered portal;

    private void OnCollisionEnter(Collision collision)
    {      
        if(collision.gameObject.tag == "Respawn")
        {
            portal.presses += 1;
            portal.ChekPress();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            portal.presses -= 1;
            portal.ChekPress();
        }
    }
}
