using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeHP : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite threehp;
    public Sprite twohp;
    public Sprite onehp;
    public Sprite zerohp;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Player>().health == 3)
        {
            spriteRenderer.sprite = threehp;
        }
        if (player.GetComponent<Player>().health == 2)
        {
            spriteRenderer.sprite = twohp;
        }
        if (player.GetComponent<Player>().health == 1)
        {
            spriteRenderer.sprite = onehp;
        }
        if (player.GetComponent<Player>().health <= 0)
        {
            spriteRenderer.sprite = zerohp;
        }
    }
}
