using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private float DashSpeed = 500;
    [SerializeField] private float DashActivationNumber = 5f;
    //private float DashTimer = 5f;

    private Rigidbody2D rigid2d;

    [SerializeField] private AbilityCooldownBar AbilityBar;

    [SerializeField] private GameObject Abbilitie_CoolDownbar;
    private AbilityCooldownBar abilitiecooldownscript;

    //private bool Abbilitie_IsActive = false;
    private AbilityTimer abilityTimer;

    [SerializeField] private AudioSource DashSoundAudioSource;
    [SerializeField] private AudioClip DashSound_Clip;

    private void Start()
    {
        DashSoundAudioSource.clip = DashSound_Clip;
        abilityTimer = GetComponent<AbilityTimer>();
        rigid2d = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //DashTimer = Mathf.Clamp(DashTimer + Time.fixedDeltaTime, 0f, DashActivationNumber);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (abilityTimer.isReady)
            {
                DashSoundAudioSource.Play();
                rigid2d.AddRelativeForce(Vector2.right * DashSpeed);
                abilityTimer.SetCooldown(DashActivationNumber);
                ActivateAbilitieCooldownBar();
            }
        }

        // Debug.Log(DashTimer);
    }

    public void ActivateAbilitieCooldownBar()
    {
        //AbilityBar.gameObject.SetActive(true);
        AbilityBar.SetTimer(abilityTimer);
    }
}