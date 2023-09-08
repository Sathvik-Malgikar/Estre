using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class trialAR_UIM : MonoBehaviour
{

    public VisualTreeAsset obstructionTree;
    public VisualTreeAsset placementTree;
    public UIDocument uid;

    // Start is called before the first frame update
    void Start()
    {
        setVisTree("Obs");
        
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
        uid.rootVisualElement.Q<Label>("ModelName").text = loadARScene.modelName;

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

        

    } public void initObstructionTree( )
    {
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
