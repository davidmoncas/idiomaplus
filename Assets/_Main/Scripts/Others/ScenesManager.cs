using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



/// <summary>
/// Controls the scene flow
/// </summary>
public class ScenesManager : MonoBehaviour
{

    public void GotoScene(int sceneNumber) {
        SceneManager.LoadScene(sceneNumber);
        Time.timeScale = 1;
    }

    IEnumerator GotoSceneIn2Seconds(int sceneNumber) {
        yield return new WaitForSeconds(2);
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneNumber);
    }

    public void GotoSceneInTime(int sceneNumber) {
        StartCoroutine(GotoSceneIn2Seconds(sceneNumber));
    }
}
