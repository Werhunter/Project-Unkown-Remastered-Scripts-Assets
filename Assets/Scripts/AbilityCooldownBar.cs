using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldownBar : MonoBehaviour
{
    [SerializeField] private GameObject AbbilitieCooldownBarBackground;
    [SerializeField] private Image AbbilitieCooldownBar;
    [SerializeField] private Text RatioText;
    [SerializeField] private GameObject background;

    public float CurrentAbbilitieTime = 5f; //hitpoint
    public float MaxAbbilitieTime = 5f; //maxhitpoint

    private AbilityTimer abilityTimer;

    public bool AbbilitieIsActive = false;

    private void Start()
    {
        Transform parent = transform.parent;
        //abilityTimer = parent.GetComponent<AbilityTimer>() ?? parent.gameObject.AddComponent<AbilityTimer>(); 

        CurrentAbbilitieTime = MaxAbbilitieTime;
        UpdateAbilityCooldownBar();
        MaxAbbilitieTime = CurrentAbbilitieTime;
    }

    public void SetTimer(AbilityTimer abilityTimer)
    {
        this.abilityTimer = abilityTimer;
    }

    void Update()
    {
        transform.parent.eulerAngles = Vector3.zero;
        //Debug.Log("Player Health = " + CurrentPlayerHealth);

        //deze regel zet hem gelijk uit!!!
       // AbbilitieCooldownBarBackground.SetActive(!abilityTimer.isReady);
        UpdateAbilityCooldownBar();


    }

    private void UpdateAbilityCooldownBar() //dit checkt hoeveel health de speler echt heeft
    {
        if (abilityTimer == null)
        {
            return;
        }
        float ratio = abilityTimer.abilityTimer / abilityTimer.abilityTimerMax;
        AbbilitieCooldownBar.fillAmount = ratio;
        RatioText.text = (ratio * 100f).ToString("0");
        background.SetActive(ratio != 0);
    }



}
