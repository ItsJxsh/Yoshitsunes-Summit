using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpiritAI : MonoBehaviour
{
    public GameObject spirit;
    public GameObject target;
    float speed = 2.0f;
    bool seeking = false;
    public bool damageable = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                seeking = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                seeking = false;
                damageable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        if (seeking)
        {
            spirit.transform.position = Vector3.MoveTowards(spirit.transform.position, target.transform.position, speed * dt);
            damageable = true;
        }
    }
}
