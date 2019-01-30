using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public ScreenShake screenshake;
    private float TimeTillDeactiveateTimer = 0f;
    [SerializeField] private int damage = 1;

    [SerializeField] private bool IsPlayer_1 = false;  //player playing on the left side of the keyboard
    [SerializeField] private bool IsPlayer_2 = false; //player playing on the right side of the keyboard

    [SerializeField] private AudioSource MineExplosionSoundAudioSource;
    [SerializeField] private AudioClip MineExplosionSound_Clip;

    private void Start()
    {
        screenshake = Camera.main.GetComponent<ScreenShake>();
        MineExplosionSoundAudioSource.clip = MineExplosionSound_Clip;
    }

    private void Update()
    {
        // Debug.Log("DeactiveTimer = " + TimeTillDeactiveateTimer);

        if (TimeTillDeactiveateTimer >= 5f)
        {
            TimeTillDeactiveateTimer = 0f;
            Deactivate();
        }

        TimeTillDeactiveateTimer += Time.deltaTime;

        if (IsPlayer_1 == false && IsPlayer_2 == false)
        {
            Debug.LogError("De Mines weten niet van welke player ze zijn maak IsPlayer1 of 2 true");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (IsPlayer_1 == true)
        {
            if (col.gameObject.tag == "Player_2")
            {
                if (col.GetComponentInChildren<Healthbar>() != null)
                {
                    screenshake.SetShakeActive(true);
                    col.GetComponentInChildren<Healthbar>().CurrentHealth -= damage;
                    col.GetComponentInChildren<Healthbar>().FadeTimerIsActive = true;
                }
                MineExplosionSoundAudioSource.Play();
                Deactivate();
            }
        }

        if (IsPlayer_2 == true)
        {
            if (col.gameObject.tag == "Player_1")
            {
                if (col.GetComponentInChildren<Healthbar>() != null)
                {
                    screenshake.SetShakeActive(true);
                    col.GetComponentInChildren<Healthbar>().CurrentHealth -= damage;
                    col.GetComponentInChildren<Healthbar>().FadeTimerIsActive = true;
                }
                MineExplosionSoundAudioSource.Play();
                Deactivate();
            }
        }
    }

    private void Active()
    {
        this.gameObject.SetActive(true);
    }

    private void Deactivate()
    {
        TimeTillDeactiveateTimer = 0f;
        this.gameObject.SetActive(false);
    }
}