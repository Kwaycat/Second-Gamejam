using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGuideArrow : MonoBehaviour
{
    public ScriptGameController gameController;
    public GameObject car;
    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = car.transform.position;

        Vector2 rotation = target.transform.position - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
