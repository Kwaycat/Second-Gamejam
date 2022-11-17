using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGotMilkTrigger : MonoBehaviour
{
    public ScriptGameController gameController;
    public GameObject playerCar;
    BoxCollider2D playerCollider;
    // Start is called before the first frame update
    void Start() {
        playerCollider = playerCar.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        if (gameController.goGetMilk == true) {
            gameController.gotMilk = true;
            gameController.EditObjective();
        }
            
        
    }
}
