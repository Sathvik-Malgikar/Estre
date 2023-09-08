using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class getModelName : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = loadARScene.modelName + "-" + paramSession.seats;    
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
