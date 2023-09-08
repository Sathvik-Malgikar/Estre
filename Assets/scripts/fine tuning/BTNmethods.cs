using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BTNmethods : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backTOAR()
    {
    



    SceneManager.LoadScene("trialAR", LoadSceneMode.Single);
    // SceneManager.UnloadSceneAsync("paramPage");

      
    }
}
