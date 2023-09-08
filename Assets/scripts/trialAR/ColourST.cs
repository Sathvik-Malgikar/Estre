using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using TMPro;

public class ColourST : MonoBehaviour
{
    [SerializeField]
    Material beigeClR;
    [SerializeField]
    Material brownClR;
    [SerializeField]
    Material lightgreyClR;

    // [SerializeField]
    // Color white;
    // [SerializeField]
    // Color Yellow;

    

    public static String currentColor ;
    public static Material currentMat;

    public void Awake(){

        currentColor="BEIGE";
        currentMat=beigeClR;
        
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("CLRBTN"))
        {
            if (go.name != currentColor)
                go.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
            else
                go.GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;

        }
    }

    public void setMaterial(String clr)
    {
        currentColor = clr;

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("CLRBTN"))
        {
            if (go.name != clr)
                go.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
            else
                go.GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;

        }

        if (clr == "BEIGE")
            currentMat = beigeClR;
        else if (clr == "LIGHTGREY")
            currentMat = lightgreyClR;
        else
        {
            currentMat = brownClR;
        }
        
        GameObject couchObj = GameObject.FindGameObjectWithTag("COUCH");
        if  (couchObj != null){
            Debug.Log("couch material change! for "+couchObj.name  );

            wallCollisionCheck wref= couchObj.GetComponent<wallCollisionCheck>();
            if (wref != null)
            {

            Debug.Log(wref.name+"wall collision is attached!", this);
            }
            else
            {
                Debug.Log( "wall collision is null!", this);
            }
            wref.repaint();
 
        

            
        

        // material = currentMat;
        }
    else
    Debug.LogError("couch object not found!");


    }
}
