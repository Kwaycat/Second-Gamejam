using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptWheelTrailRendererHandler : MonoBehaviour
{
    //Components
    ScriptCarMovement carMovement;
    TrailRenderer trailRenderer;
    void Awake()
    {
        //Get the car movement script
        carMovement = GetComponentInParent<ScriptCarMovement>();

        //Get the trail renderer component
        trailRenderer = GetComponent<TrailRenderer>();

        //Set the trail renderer to not emit in the start
        trailRenderer.emitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (carMovement.IsTireScreeching(out float lateralVelocity, out bool isBreaking))
            trailRenderer.emitting = true;
        else trailRenderer.emitting = false;
    }
}
