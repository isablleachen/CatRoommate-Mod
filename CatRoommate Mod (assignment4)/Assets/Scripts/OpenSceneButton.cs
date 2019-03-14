using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSceneButton : MonoBehaviour
{
    public void SelectionScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); 
    }

    public void InstructionScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
