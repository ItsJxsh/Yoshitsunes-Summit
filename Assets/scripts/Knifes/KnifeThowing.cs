using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class KnifeThowing : MonoBehaviour
{
    public GameObject knife;
    public AudioSource myFx;
    public AudioClip KnifeThrow;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        
        {

            Vector3 knifeDirection = new Vector3(transform.localScale.x, 0f, 0f);

            GameObject knifeClone = GameObject.Instantiate(knife, transform.position + knifeDirection / 2, Quaternion.identity);
            knifeClone.GetComponent<Rigidbody2D>().velocity = knifeDirection * 18.0f;
            myFx.PlayOneShot(KnifeThrow);
            Destroy(knifeClone, 1.5f);
        }

    }
}
