using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_control : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("TutorialStage");
    }
}
