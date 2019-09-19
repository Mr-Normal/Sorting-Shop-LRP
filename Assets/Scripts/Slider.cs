using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public float progress;
    public Animator sliderAnimator;

    void Start()
    {/*
        MeshRenderer renderer;
        renderer = GetComponent<MeshRenderer>();
        sliderMaterial = renderer.sharedMaterial;*/
        
    }

    // Update is called once per frame
    void Update()
    {
        //sliderMaterial.SetFloat("Vector1_8D10CCC0", progress);
        sliderAnimator.PlayInFixedTime(0, 0, progress);
    }

    public float Progress
    {
        set
        {
            progress = value;
        }
    }
}
