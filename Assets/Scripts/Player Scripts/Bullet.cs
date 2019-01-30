using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ScreenShake screenshake;
    [SerializeField] private float Bullet_speed = 4f;
    private float TimeTillDeactiveateTimer = 0f;
    [SerializeField] private float DeactivationNumber = 2.5f;

    private Rigidbody2D rigid2D;

    [SerializeField] private float damage = 1f;

    [SerializeField] private bool IsPlayer_1;
    [SerializeField] private bool IsPlayer_2;

    private AudioSource Hit;

    public void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        rigid2D.velocity = MathUtility.DegreeToVector2(transform.eulerAngles.z) * Bullet_speed;
    }

    private void Update()
    {
        // Debug.Log("DeactiveTimer = " + TimeTillDeactiveateTimer);

        if (TimeTillDeactiveateTimer >= DeactivationNumber)
        {
            TimeTillDeactiveateTimer = 0f;
            Deactivate();
        }

        TimeTillDeactiveateTimer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (IsPlayer_1 == true)
        {
            if (col.gameObject.tag != "Player_2")
            {
                if (col.GetComponent<AudioSource>() != null)
                {
                    Hit = col.GetComponent<AudioSource>();
                    Hit.Play();
                }
            }

            if (col.gameObject.tag == "Player_2")
            {
                Hit = col.GetComponent<AudioSource>();
                Hit.Play();

                if (col.GetComponentInChildren<Healthbar>() != null)
                {
                    screenshake.SetShakeActive(true);
                    col.GetComponentInChildren<Healthbar>().CurrentHealth -= damage;
                    col.GetComponentInChildren<Healthbar>().FadeTimerIsActive = true;
                }

                Deactivate();
            }
        }

        if (IsPlayer_2 == true)
        {
            if (col.gameObject.tag != "Player_1")
            {
                if (col.GetComponent<AudioSource>() != null)
                {
                    Hit = col.GetComponent<AudioSource>();
                    Hit.Play();
                }
            }

            if (col.gameObject.tag == "Player_1")
            {
                Hit = col.GetComponent<AudioSource>();
                Hit.Play();

                if (col.GetComponentInChildren<Healthbar>() != null)
                {
                    screenshake.SetShakeActive(true);
                    col.GetComponentInChildren<Healthbar>().CurrentHealth -= damage;
                    col.GetComponentInChildren<Healthbar>().FadeTimerIsActive = true;
                }

                Deactivate();
            }
        }

        if (col.gameObject.tag == "Mine")
        {
            Hit = col.GetComponent<AudioSource>();
            Hit.Play();
            //ik moet zorgen dat hier de sound effect van de mine explosion wordt uitgevoerd
            col.gameObject.SetActive(false);
            Deactivate();
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