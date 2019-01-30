using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTimer : MonoBehaviour {

    private float m_abilityTimer;
    private float m_abilityTimerMax;

    public float abilityTimer { get { return m_abilityTimer; } }
    public float abilityTimerMax {  get { return m_abilityTimerMax; } }
    public bool isReady
    {
        get
        {
            return m_abilityTimer == 0f;
        }
    }

    private void Update()
    {
        m_abilityTimer = Mathf.Clamp(m_abilityTimer -= Time.deltaTime, 0f, float.MaxValue);
    }

    public void SetCooldown(float time)
    {
        m_abilityTimerMax = time;
        m_abilityTimer = time;
    }
}
