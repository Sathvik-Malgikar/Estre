using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEditor.SceneManagement;
// using UnityEngine.SceneManagement;

public class loadARScene : MonoBehaviour
{
    public static String modelName="";

        public static void goToSceneChoice (String screenName ){

        modelName = screenName;
            SceneManager.LoadScene("paramPage",LoadSceneMode.Single);
            // SceneManager.UnloadSceneAsync("UIWelcome");

        }
        // public void goToScene1 (){

        //     modelName = "Whitmor";
        //     SceneManager.LoadScene("paramPage",LoadSceneMode.Single);
        //     // SceneManager.UnloadSceneAsync("UIWelcome");

        // }
        public static void goBack (){

        paramSession.stuffing = "";
        paramSession.seats = "";
        paramSession.group = "g1";
            // SceneManager.UnloadSceneAsync("trialAR");
            modelName = "";
    

        SceneManager.LoadScene("UIWelcome",LoadSceneMode.Single);
            // SceneManager.UnloadSceneAsync("paramPage");

        }

        
}
