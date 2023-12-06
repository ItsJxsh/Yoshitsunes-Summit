using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public int coins = 0; // The variable to display
    public TMP_Text Text; // The TextMeshPro object to display
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        coins = player.GetComponent<Player>().coinCounter;
        Text.SetText("" + coins);
    }
}
