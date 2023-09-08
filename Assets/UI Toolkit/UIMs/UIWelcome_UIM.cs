using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using UnityEngine.SceneManagement;

public class UIIni : MonoBehaviour
{

    public UIDocument uid;

    public VisualTreeAsset Home;
    public VisualTreeAsset Sofa;
    public VisualTreeAsset ParamPage;

    // Start is called before the first frame update
    void Start()
    {
        VisualElement rootvis = uid.rootVisualElement;
        VisualElement cat3 =  rootvis.Q<VisualElement>("cat3");
        ScrollView lv = cat3.Q<ScrollView>("HorizScroll");

        GroupBox GB = cat3.Q<GroupBox>("dataBox");

        List<GroupBox> lgb = new List<GroupBox>();


        foreach (GroupBox grp in GB.Children())
        {
          lgb.Add(grp);
        }

        foreach (GroupBox grp in lgb) {
            grp.RegisterCallback<ClickEvent>(delegate (ClickEvent e)
            {

                Debug.Log("switching to  " + grp.name);
                setVisTree(grp.name);

            });
            lv.Add(grp);
        }

        //VisualElement C2 = cat3.Q<VisualElement>("C2");
        //lv.Add(C1);
        //lv.Add(C2);
    }

    public void setVisTree(String name) {
        if (name == "Home")
        {
            uid.visualTreeAsset = Home;
        }
        else if (name == "Sofa")
        {
            uid.visualTreeAsset= Sofa;
            InitSofaPage();
        }
        else if (name == "ParamPage")
        {
            uid.visualTreeAsset = ParamPage;
            InitParamPage();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitSofaPage()
    {
        VisualElement rootvis = uid.rootVisualElement;
        VisualElement Main = rootvis.Q<VisualElement>("Main");
        VisualElement Body = rootvis.Q<VisualElement>("Body");
        ScrollView lv = Body.Q<ScrollView>("scrollRect");

        VisualTreeAsset vta = Resources.Load<VisualTreeAsset>("dataBoxSofa");
        VisualElement dataroot = vta.CloneTree();
        GroupBox GB = dataroot.Q<GroupBox>("dataBox");


        List<GroupBox> lgb = new List<GroupBox>();


        foreach (GroupBox grp in GB.Children())
        {
            lgb.Add(grp);
        }

        foreach (GroupBox grp in lgb)
        {
            grp.RegisterCallback<ClickEvent>(delegate (ClickEvent e)
            {

                Debug.Log("clicked sofa  " + grp.name);
                loadARScene.modelName = grp.name;
                setVisTree("ParamPage");

            });
            lv.Add(grp);
        }

    }
    public void InitParamPage()
    {
        VisualElement rootvis = uid.rootVisualElement;
        GroupBox btngrp = rootvis.Q<VisualElement>("Main").Q<GroupBox>("Body").Q<GroupBox>("ButtonGroup");

        VisualTreeAsset radtemp = Resources.Load<VisualTreeAsset>("radiotemplate");
        StyleSheet st = Resources.Load<StyleSheet>("radiobutton");
        VisualElement modelChoice = radtemp.CloneTree();
        VisualElement stuffingChoice = radtemp.CloneTree();
        //visele.styleSheets.Add(st);

        RadioButtonGroup rbg = modelChoice.Q<RadioButtonGroup>("RadioButtonGroup");
        RadioButtonGroup rbg2 = stuffingChoice.Q<RadioButtonGroup>("RadioButtonGroup");



        List<String> stuffChoices = new List<String>();
        stuffChoices = new List<String> { "Feather","Coir","Leather" };
        rbg2.choices = stuffChoices;

        List<String> seatChoices = new List<String>();

        if (loadARScene.modelName == "Duke")
        {

            seatChoices = new List<String> { "LHS","RHS" };
        }
        else
        {
            seatChoices = new List<String> { "1S", "2S", "3S" };
        }

        rbg.choices = seatChoices;

        //Debug.Log(visele.styleSheets[0]);

        rootvis.styleSheets.Add(st);

        btngrp.Add(rbg);
        btngrp.Add(rbg2);

        rootvis.Q<Button>("Launch").RegisterCallback<ClickEvent>(delegate (ClickEvent e)
        {
            paramSession.seats = seatChoices[rbg.value];
            paramSession.stuffing= stuffChoices[rbg2.value];

            SceneManager.LoadScene("trialAR", LoadSceneMode.Single);


        });


    }
}
