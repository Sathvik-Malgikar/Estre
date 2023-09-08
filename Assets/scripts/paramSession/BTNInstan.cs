using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class BTNInstan : MonoBehaviour
{

    public GameObject baseGO;
    
    // Start is called before the first frame update
    void Awake()
    {
        name = loadARScene.modelName;

        String[] bvals= { };


        if (name== "Whitmor" || name== "ChesterField")
        {
            bvals = new String[3] {"1S","2S","3S" } ;


        }
        else if   ( name== "Duke")
        {
            bvals = new String[2] { "LHS", "RHS" };

        }else{

            Debug.LogError("MISMATCHING NAME! :"+name );
        }

        foreach(String st in bvals)
        {
            GameObject newGO =  Instantiate(baseGO);
            newGO.SetActive(true);
            newGO.transform.SetParent(gameObject.transform);
            newGO.name = st;
            newGO.GetComponentInChildren<TextMeshProUGUI>().text= st;
            newGO.transform.position = gameObject.transform.position;
            newGO.transform.rotation = gameObject.transform.rotation;
            newGO.transform.localScale = gameObject.transform.localScale;            

        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
