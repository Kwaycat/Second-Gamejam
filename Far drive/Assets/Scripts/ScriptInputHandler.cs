using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptInputHandler : MonoBehaviour
{
    ScriptCarMovement carMovement;

    void Awake() {
        carMovement = GetComponent<ScriptCarMovement>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        carMovement.SetInputVector(inputVector);

        
    }
}
