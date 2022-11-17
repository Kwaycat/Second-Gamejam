using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptRestartAndEndGame : MonoBehaviour
{
    public ScriptGameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (gameController.winScreen == true)
                SceneManager.LoadScene("WorldTest", LoadSceneMode.Single);
            else {
                Scene gameScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(gameScene.name);

            }
        }
            

        if (Input.GetKey(KeyCode.Escape))
                Application.Quit();
    }
}
