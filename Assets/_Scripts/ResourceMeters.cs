using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** 
 * ResourceMeters
 * 
 * A Unity class that updates the resource Slider objects on the UI canvas.
 * Sliders values represent percentage values of how optimal the fusion plant is running.
 * 
 * Example Usage:
 * 1. Attach this script to a GameObject such as the canvas in your Unity scene.
 * 2. Provide a reference to the levels to be displayed by the Sliders.
 * 3. Drag the corresponding Slider objects from the hierarchy to the inspector.
**/

public class ResourceMeters : MonoBehaviour
{
    //public var levels;

    public Slider UraniumSlider;
    public Slider WoodSlider;
    public Slider WaterSlider;

    // Update is called once per frame
    void Update()
    {
        UraniumSlider.value = GameState.UraniumMeter / 100f;
        WoodSlider.value = GameState.WoodMeter / 100;
        WaterSlider.value = GameState.WaterMeter / 100;
    }
}
