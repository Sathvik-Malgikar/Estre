using System;
using System.Collections;
using System.Collections.Generic;
// using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class paramSession : MonoBehaviour
{
    

    public static String stuffing="";
    public static String seats="";
    public static String group="g1";
    // // [SerializeField]
    // [SerializeField]
    // public static GameObject g1;

    public void setStuffing  (String val ) {

        stuffing = val;
        Debug.Log( "inside after setstuffing"+ stuffing ); 
        group="g2";
        // GameObject.Find("g1").SetActive( false );
        // GameObject.Find("g2").SetActive( true );
        
    }
    public void setSeats( ) {

        seats = gameObject.name;
        Debug.Log( "inside after setseats"+ seats );
        group="g3"; 
        SceneManager.LoadScene("trialAR",LoadSceneMode.Single);
        // SceneManager.UnloadSceneAsync("paramSession");

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("paramses called");
        // Debug.Log(group);
    }
    // void Awake()
    // {

    //     if (g1==null){
    //         Debug.Log( "g1 not assigned" );
    //     }

    //     // if (g2==null){
    //     //     Debug.Log( "g1 not assigned" );
    //     // }
    // }
}
