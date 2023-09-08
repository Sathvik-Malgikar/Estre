using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCALER : MonoBehaviour
{
    // Start is called before the first frame update
    public float scaleX = 1.4f;
    private GameObject gotemp;
    public float scaleH = 1.2f;
    void Start()
    {
       
    }
    public void Scale()
    {
        gotemp = GameObject.FindGameObjectWithTag("COUCH");
        Vector3 vetemp = gotemp.transform.localScale;
        vetemp.x *= scaleX;
        vetemp.y *= scaleH;
        gotemp.transform.localScale = vetemp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
