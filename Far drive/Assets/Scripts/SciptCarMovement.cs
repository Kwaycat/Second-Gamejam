using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SciptCarMovement : MonoBehaviour
{
    //components
    Rigidbody2D rb;
    

    //floats
    public float acc = 0.8f; //acceleration
    public float speed;

    //Ints
    int angle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");
        if (vInput != 0) {
            //ratate angle variable
        }

        Vector2 moveDirection = new Vector2(hInput, vInput);
        moveDirection.Normalize();

        transform.Translate(moveDirection * speed * Time.deltaTime); //change y input to angle
    }
}
