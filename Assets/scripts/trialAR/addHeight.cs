using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class addHeight : MonoBehaviour
{
    [SerializeField]
    public static float currentHeight;
    // Start is called before the first frame update
    public void addHeightFactor(float height)
    {
        currentHeight += (height);
        Debug.Log("current height inside addHeight after increment" + currentHeight);
    }
    private void Start()
    {
        currentHeight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
