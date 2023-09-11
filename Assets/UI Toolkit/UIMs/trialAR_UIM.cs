using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using et = UnityEngine.InputSystem.EnhancedTouch;


public class trialAR_UIM : MonoBehaviour
{

    public VisualTreeAsset obstructionTree;
    public VisualTreeAsset placementTree;
    public UIDocument uid;
    
    public GameObject planePrefab;
    public GameObject OriginRef;
    public GameObject obstructionPrefab;
    private ARPlaneManager arp ;

    // Start is called before the first frame update
    void Start()
    {
        setVisTree("Obs");
        //FindAnyObjectByType<ARPlaneManager>().planePrefab = obstructionPrefab;

    }
    void Awake()
    {


        et.TouchSimulation.Enable();
        et.EnhancedTouchSupport.Enable();
        Debug.Log("TOUCH ENABLED FROM TRIALAR");
        //et.Touch.onFingerDown += fingHandler;

    }



    void OnDisable()
    {

        et.TouchSimulation.Disable();
        et.EnhancedTouchSupport.Disable();
        Debug.Log("TOUCH DISABLED FROM TRIALAR");
        //et.Touch.onFingerDown -= fingHandler;


    }
    public void setVisTree(String name)
    {
        if (name == "Obs")
        {
            uid.visualTreeAsset = obstructionTree;
            initObstructionTree();
        }
        else if (name == "Placement")
        {
            uid.visualTreeAsset = placementTree;
            initPlacementTree();
        }
        else
        {
            Debug.Log("screen not found!!");
        }
        
    }
    public void initPlacementTree( )
    {

        OriginRef.GetComponent<ARPlaneManager>().planePrefab = planePrefab;
        OriginRef.GetComponent<ARPlaneManager>().requestedDetectionMode = PlaneDetectionMode.Horizontal;
    
        OriginRef.GetComponent<AddObstruction>().enabled = false;
        OriginRef.GetComponent<AddObstruction>().Cleanup();
        OriginRef.GetComponent<PlaceSeat>().enabled = true;
        

        uid.rootVisualElement.Q<VisualElement>("Float").RegisterCallback<ClickEvent>(delegate (ClickEvent eve)
        {
            setVisTree("CONFIRM");
          

        }); 
        
        uid.rootVisualElement.Q<Button>("DeleteInstance").RegisterCallback<ClickEvent>(delegate (ClickEvent eve)
        {
            PlaceSeat.deleteInstance();

          

        }); 
        uid.rootVisualElement.Q<Button>("BackBtn").RegisterCallback<ClickEvent>(delegate (ClickEvent eve)
        {
           loadARScene.goBack();
          

        });
        uid.rootVisualElement.Q<Label>("ModelName").text = "Model Name :"+loadARScene.modelName+" "+paramSession.seats;

        RadioButtonGroup rbg = uid.rootVisualElement.Q<RadioButtonGroup>();

        var  qr = uid.rootVisualElement.Query<RadioButton>().ToList();

        List<String> colours = new List<String> { "BEIGE","BROWN","LIGHTGREY"} ;

        foreach (RadioButton radio in qr) {

            radio.RegisterCallback<ClickEvent>(delegate (ClickEvent eve) {
                Debug.Log(colours[rbg.value]+"is the chosen radio btn");
                ColourST cst = FindAnyObjectByType<ColourST>();
                cst.setMaterial(colours[rbg.value]);  
                
            });

        }

        

    }
    
    public void initObstructionTree( )
    {
        OriginRef.GetComponent<ARPlaneManager>().requestedDetectionMode = PlaneDetectionMode.Vertical;
        OriginRef.GetComponent<ARPlaneManager>().planePrefab = obstructionPrefab;
        OriginRef.GetComponent<AddObstruction>().enabled = true;
        OriginRef.GetComponent<PlaceSeat>().enabled = false;
        OriginRef.GetComponent<PlaceSeat>().Cleanup();


        uid.rootVisualElement.Q<VisualElement>("Float").RegisterCallback<ClickEvent>(delegate (ClickEvent eve)
        {
            setVisTree("Placement");
            // TODO: do the scripting to save state and change plane mode to just horizontal and also clear the existing planes and restart
            //change the tag type maybe have a different prefab plane one called object one the default

        } );

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
