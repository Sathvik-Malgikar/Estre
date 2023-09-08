using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using et = UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using tr = UnityEngine.XR.ARSubsystems.TrackableType;
using Unity.XR.CoreUtils;

public class PlaceSeat : MonoBehaviour
{

    public GameObject loadedPrefab;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private ARRaycastManager ARM = null;
    private ARPlaneManager ARP = null;
    public GameObject gotemp = null;
    public Material ghostref;

    public Rect spawnArea;


    void Awake()
    {
        spawnArea = new Rect(0f, 0.2f, 1f, 0.48f);

        Debug.Log("INSIDE AWAKE RES LOADED!"+ "models/" + loadARScene.modelName + "/prefabs/" + paramSession.seats);

        loadedPrefab = Resources.Load<GameObject>("models/"+loadARScene.modelName+"/prefabs/"+ paramSession.seats);//paramPage.seats

        if (loadedPrefab==null)
        Debug.LogError("prefab NULL"+"tried to load "+"models/"+loadARScene.modelName+"/prefabs/"+ paramSession.seats);
        else
        Debug.Log("loaded prefab from disk :"+loadedPrefab.name);

        // Debug.Log("Chosen model: " + loadARScene.modelName);
        // if (loadARScene.modelName == "ModelOne")
        // {
        //     Debug.Log("m1 successful read! ");

        // }
        // else
        // {
        //     Debug.Log("m3 ");
        // }

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
    void OnEnable()
    {

        Debug.Log("TOUCH ENABLED FROM PHASE 2");

        et.TouchSimulation.Enable();
        et.EnhancedTouchSupport.Enable();
        et.Touch.onFingerDown += fingHandler;

    }

  

    void OnDisable()
    {

        Debug.Log("TOUCH DISABLED FROM PHASE 2");
        et.TouchSimulation.Disable();
        et.EnhancedTouchSupport.Disable();
        et.Touch.onFingerDown -= fingHandler;

    }


    void fingHandler(et.Finger fing)
    {

       

        if (fing.index != 0)
        {
            // Debug LogError()
            Debug.Log("skipped finger due to multiple touch :" + fing.index);
            return;
        }

        Vector3 normalisedTouch = new Vector3(fing.currentTouch.screenPosition.x / Screen.width, fing.currentTouch.screenPosition.y / Screen.height, 0); 

        if (!spawnArea.Contains(normalisedTouch))
        {
         
            Debug.Log("finger out of area");
            return;
        }
            if (ARM.Raycast(fing.currentTouch.screenPosition, hits, tr.PlaneWithinPolygon))
        {

           

            if (ARP.GetPlane(hits[0].trackableId).alignment == UnityEngine.XR.ARSubsystems.PlaneAlignment.HorizontalUp)
            {
           

                Debug.Log("hit recorded on plane !! ");


                Pose pose = hits[0].pose;
                deleteInstance();
                gotemp = Instantiate(loadedPrefab, pose.position, pose.rotation);

                GameObject defGO = gotemp.GetNamedChild("default");


                defGO.AddComponent<wallCollisionCheck>();
                defGO.GetComponent<wallCollisionCheck>().setghost(ghostref);

                MeshRenderer mr=  defGO.GetComponent<MeshRenderer>();

                int n = mr.materials.Length;
                Material[] mtrs = new Material[n];
                if (!wallCollisionCheck.invalidPos)
                {
                    Debug.Log("painting colour " + ColourST.currentColor, this);
                    for (int i = 0; i < n; i++)
                    {
                        mtrs[i] = ColourST.currentMat;
                    }
                    mr.materials = mtrs;
                }
                else
                {
                    // MeshRenderer mr = GameObject.FindGameObjectWithTag("COUCH").GetComponent<MeshRenderer>();

                    // int n = mr.materials.Length;
                    // Material[] mtrs = new Material[n];
                    Debug.Log("painting colour ghost ", this);
                    for (int i = 0; i < n; i++)
                    {
                        mtrs[i] = ghostref;
                    }
                    mr.materials = mtrs;
                }

                Vector3 pos = gotemp.transform.position;
                pos.y = 0;
                Vector3 cpos = Camera.main.transform.position;
                cpos.y = 0;
                Vector3 dir = cpos - pos;

                Quaternion targetRot = Quaternion.LookRotation(dir);

                gotemp.transform.rotation = targetRot;
               

                Debug.Log("Instantiated" + pose.ToString());
            }



        }else{
            Debug.Log("missed plane ",this);
        }


    }
    public void deleteInstance(){
         if (gotemp != null)
                {
                    Destroy(gotemp);
                    gotemp = null;
                }
    }

}
