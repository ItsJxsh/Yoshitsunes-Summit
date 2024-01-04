using UnityEngine;
using UnityEngine.SceneManagement;

public class isGrounded : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Scene currentScene = SceneManager.GetActiveScene(); // Temp fix for level drafting.  

        if (currentScene.name == "TutorialStage")
        {
            if (col.name == ("Permanent Tiles"))
            {
                player.GetComponent<Player>().jumpsremaining = 2;
            }
        }

        else if (currentScene.name == "TutorialStage2")
        {
            player.GetComponent<Player>().jumpsremaining = 2;
        }
    }
}
