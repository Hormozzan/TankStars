using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictorySceneSwitcher : MonoBehaviour
{
    public int sceneID;

    public void SceneSwitcher(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
