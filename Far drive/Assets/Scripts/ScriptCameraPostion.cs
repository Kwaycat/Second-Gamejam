using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCameraPostion : MonoBehaviour
{
    public Camera camera;
    public GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = car.transform.position;
    }
}
