using UnityEngine;

public class ESCBackDetect : MonoBehaviour
{
    void Update()
    {
        // Check if the Android back button (KeyCode.Escape) is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Do something when the back button is pressed
            Debug.Log("Android back button pressed!");
            //paramSession.stuffing="";
            //paramSession.seats="";
            Debug.LogWarning("faulty back navigation using escape/back arrow alert!");
            //paramSession.group="g1";
            loadARScene.goBack();
            
            // You can implement your desired behavior here, such as pausing the game, showing a confirmation dialog, etc.
        }
    }
}
