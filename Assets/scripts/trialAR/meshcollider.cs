using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshcollider : MonoBehaviour
{
     


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("inside Start of Mesh");
        MeshCollider collider = gameObject.GetComponent<MeshCollider>();
        if (collider != null)
        {
            Debug.Log("collider not null");
        }
        else
        {
            Debug.Log("collider is null");
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("inside colli enter in mesh!"+collision.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
