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
    }

    private void fingHandler(et.Finger fing)
    {
        if (fing.index != 0)
        {
            // Debug LogError()
            Debug.Log("skipped finger due to multiple touch :" + fing.index);
            return;
        }
        Vector3 normalisedTouch = new Vector3(fing.currentTouch.screenPosition.x / Screen.width, fing.currentTouch.screenPosition.y / Screen.height, 0);

        if (ARM.Raycast(fing.currentTouch.screenPosition, hits, tr.PlaneWithinPolygon))
        {
            Debug.Log("registering plane as object");
            //Pose pose = hits[0].pose;

            GameObject temp = ARP.GetPlane(hits[0].trackableId).GameObject();
            temp.transform.SetParent(obstructions.transform, true);
            

        }
        }

    void OnEnable()
    {

        Debug.Log("TOUCH ENABLED FROM PHASE 1");

        et.TouchSimulation.Enable();
        et.EnhancedTouchSupport.Enable();
        et.Touch.onFingerDown += fingHandler;

    }

    void OnDisable()
    {

        Debug.Log("TOUCH DISABLED FROM PHASE 1");
        et.TouchSimulation.Disable();
        et.EnhancedTouchSupport.Disable();
        et.Touch.onFingerDown -= fingHandler;

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
