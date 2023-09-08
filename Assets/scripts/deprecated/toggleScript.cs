using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    // Reference to the toggle component
    public Toggle toggle;

    private void Start()
    {
        // Subscribe to the toggle's OnValueChanged event
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    // This method will be called when the toggle's value changes

    
    // Reference to the Mesh Renderer component
    public GameObject sofameshGO;

    // The new material you want to assign
    public Material gooMat;
    public Material blueMat;

   
    private void OnToggleValueChanged(bool isOn)
    {
       // Get the Mesh Renderer component
        MeshRenderer sofamesh = sofameshGO.GetComponent<MeshRenderer>();

        if (sofamesh != null && gooMat != null && isOn)
        {
            // Change the material of the Mesh Renderer
            sofamesh.material = gooMat;
        Debug.Log("goo set");
        }
        else if (sofamesh != null && blueMat != null && ! isOn)
        {
            sofamesh.material = blueMat;
        Debug.Log("blue set");
            // Debug.LogWarning("Mesh Renderer or new Material not set!");
        }
        else{

        Debug.Log("outside");
        }
    }
}
