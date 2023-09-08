using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideAnnounce : MonoBehaviour
{
    
    public void OnTriggerEnter(Collider other)
    {
       
            Debug.Log("ANNOUNCE trigger entered " + other.gameObject.name);
       
    }

    public void OnTriggerExit(Collider other)
    {
        
            Debug.Log("ANNOUNCE trigger exited " + other.gameObject.name);
       
    }

}
