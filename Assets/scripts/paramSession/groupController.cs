using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class groupController : MonoBehaviour
{
    public List<GameObject> lg = new List<GameObject>();
    // public GameObject g2;

    // Start is called before the first frame update
    void Start()
    {
        // myname = gameObject.name;

        // gameObject.SetActive(myname == paramSession.group);

    }
    void Awake()
    {
        if (lg.Contains(null))
        {
            Debug.Log("null groups found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var group in lg){

        group.SetActive(group.name == paramSession.group);
        }

    }
}
