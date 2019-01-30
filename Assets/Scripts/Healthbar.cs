using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private GameObject Background;
    [SerializeField] private Image HealthBar;           //IMAGE TYPE MUST STAY ON FILLED & FILL METHOD OP HORIZONTAL
    [SerializeField] private Text RatioText;

    public float CurrentHealth = 100f; //hitpoint
    public float MaxHealth = 100f; //maxhitpoint

    private float FadeTimer = 3f;
    public bool FadeTimerIsActive = false;

    [SerializeField] private GameObject BattleThemeGameObject;
    [SerializeField] private GameObject DeathSoundPrefab;
    [SerializeField] private List<GameObject> Broken_Ship_Pieces;

    private void Start()
    {
        CurrentHealth = MaxHealth;
        UpdateHealthBar();
    }

    private void Update()
    {
        transform.parent.eulerAngles = Vector3.zero;
        //Debug.Log("Player Health = " + CurrentPlayerHealth);

        UpdateHealthBar();

        //als de player all zijn health kwijt is of onder de null is
        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
            UpdateHealthBar();
            Destroy(BattleThemeGameObject);
            Instantiate(DeathSoundPrefab, transform.position, transform.rotation);
            Instantiate(Broken_Ship_Pieces[Random.Range(0, 4)], transform.position, transform.rotation);
            Instantiate(Broken_Ship_Pieces[Random.Range(0, 4)], transform.position, transform.rotation);
            Instantiate(Broken_Ship_Pieces[Random.Range(0, 4)], transform.position, transform.rotation);
            Destroy(this.gameObject.transform.root.gameObject);
        }

        if (FadeTimer <= 0f)
        {
            FadeTimerIsActive = false;
            FadeTimer = 3f;
            // Background.SetActive(false);
        }

        if (FadeTimerIsActive == true)
        {
            FadeTimer -= Time.deltaTime;
            Background.SetActive(true);
        }
    }

    private void UpdateHealthBar() //dit checkt hoeveel health de speler echt heeft
    {
        float ratio = CurrentHealth / MaxHealth;

        //PlayerHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);

        HealthBar.fillAmount = CurrentHealth / MaxHealth; //IMAGE TYPE MUST STAY ON FILLED & FILL METHOD OP HORIZONTAL
        RatioText.text = (ratio * 100).ToString("0");
    }
}