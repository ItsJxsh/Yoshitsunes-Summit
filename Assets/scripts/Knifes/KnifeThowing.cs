using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class KnifeThowing : MonoBehaviour
{
    public GameObject knife;
    public AudioSource myFx;
    public AudioClip KnifeThrow;

    public ChangeStamina staminaController;
    private int currentStamina = 0;


    private void Start()
    {
        currentStamina = 0; 
        UpdateStaminaVisuals();
        StartCoroutine(IncreaseStaminaOverTime(5f));

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && currentStamina > 0)
        
        {
            ThrowKnife();
            DecreaseStamina();
            UpdateStaminaVisuals();

        }

    }

    void ThrowKnife()
    {
        Vector3 knifeDirection = new Vector3(transform.localScale.x, 0f, 0f);

        GameObject knifeClone = GameObject.Instantiate(knife, transform.position + knifeDirection / 2, Quaternion.identity);
        knifeClone.GetComponent<Rigidbody2D>().velocity = knifeDirection * 18.0f;
        myFx.PlayOneShot(KnifeThrow);
        Destroy(knifeClone, 1f);
    }

    void DecreaseStamina()
    {
        currentStamina--; 
    }

    void UpdateStaminaVisuals()
    {
        if (staminaController != null)
        {
            staminaController.UpdateStaminaVisuals(currentStamina);
        }
    }

    IEnumerator IncreaseStaminaOverTime(float interval)
    {
        int targetStamina = 3;

        while (currentStamina < targetStamina)
        {
            yield return new WaitForSeconds(interval);

            IncreaseStamina(1);
        }
    }

    public void IncreaseStamina(int amount)
    {
        currentStamina += amount;
        if (currentStamina > 3)
        {
            currentStamina = 3;
        }
        UpdateStaminaVisuals();
    }
}
