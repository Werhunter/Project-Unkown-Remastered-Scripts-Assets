using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{

    private float timer = 0f;
    [SerializeField] float shaketime = 0.5f;
    [SerializeField] float shakeammount = 0.05f;

    private bool activatetimer = false;


    void Update ()
    {
        //print(timer);

        if (activatetimer == true)
        {
            timer += Time.deltaTime;
        }

        if (timer > 0f)
        {
            Vector3 random = Random.insideUnitCircle * shakeammount;
            random.z = -10f;
            transform.position = random;

            if (timer > shaketime)
            {
                SetShakeActive(false);
                activatetimer = false;
                timer = 0f;
            }                 
        }
        
    }

    public void SetShakeActive(bool setActive)
    {
        if (setActive == true)
        {
            activatetimer = true;
        }
    }
}
