using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class ScriptGameController : MonoBehaviour
{
    public TMP_Text uIText;
    public Scene victoryScene;

    public bool winScreen = false;

    public bool goGetMilk = false;
    public bool gotMilk = false;
    public bool gotHome = false;

    public void EditObjective() {
        if (goGetMilk == true)
            uIText.text = "Go get milk at the store";
        if (gotMilk == true)
            uIText.text = "Bring the milk home";
    }

    public void GoToEndScreen() {
        if (gotHome == true)
            SceneManager.LoadScene("Victory Scene", LoadSceneMode.Single);
    }
}
