using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Vuforia;

public class ButtonEvent : MonoBehaviour, IVirtualButtonEventHandler
{
    public VirtualButtonBehaviour[] vbs;
    public GameObject cube;
    public GameObject button;
    public int index;
    public Color[] colors;

    void initColors()
    {
        colors = new Color[5];
        colors[0] = Color.gray;
        colors[1] = Color.red;
        colors[2] = Color.yellow;
        colors[3] = Color.blue;
        colors[4] = Color.green;
    }

    void Start()
    {
        vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; i++)
        {
            vbs[i].RegisterEventHandler(this);
        }
        initColors();
        index = 0;
    }


    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        index++;
        if (index == 4)
            index = 0;
        button.GetComponent<MeshRenderer>().material.color = Color.red;
        cube.GetComponent<Renderer>().material.color = colors[index];

    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        button.GetComponent<MeshRenderer>().material.color = Color.white;
    }

}

