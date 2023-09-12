using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using et = UnityEngine.InputSystem.EnhancedTouch;
using tr = UnityEngine.XR.ARSubsystems.TrackableType;


public class AddObstruction : MonoBehaviour
{
    private ARRaycastManager ARM = null;
    private ARPlaneManager ARP = null;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public GameObject obstructions;
    public Material solidObstruction;
    //public GameObject obstructionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        ARM = GetComponent<ARRaycastManager>();
        ARP = GetComponent<ARPlaneManager>();

        if (ARM == null)
        {
            Debug.LogWarning("ARM is null");
        }
        if (ARP == null)
        {
            Debug.LogWarning("ARP is null");

        }
        et.Touch.onFingerDown += fingHandler;
    }

    private void fingHandler(et.Finger fing)
    {
        if (fing.index != 0)
        {
            // Debug LogError()
            //Debug.Log("skipped finger due to multiple touch :" + fing.index);
            return;
        }
        Vector3 normalisedTouch = new Vector3(fing.currentTouch.screenPosition.x / Screen.width, fing.currentTouch.screenPosition.y / Screen.height, 0);

        if (ARM.Raycast(fing.currentTouch.screenPosition, hits, tr.PlaneWithinPolygon))
        {

            //Pose pose = hits[0].pose;

            GameObject temp = ARP.GetPlane(hits[0].trackableId).GameObject();
            temp.tag = "Obstruction";
            //temp.GetComponent<ARPlane>().enabled = false;
            //temp.GetComponent<ARPlaneMeshVisualizer>().enabled = false;
            temp.GetComponent<MeshRenderer>().material = solidObstruction;
            temp.transform.SetParent(obstructions.transform, true);
            
            Debug.Log("registered plane as object,current : "+obstructions.transform.childCount);

        }
     
        }
 

    public void Cleanup()
    {
         
        et.Touch.onFingerDown -= fingHandler;

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
