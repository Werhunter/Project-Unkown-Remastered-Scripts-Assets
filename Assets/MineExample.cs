using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExample : MonoBehaviour, ITriggerable
{
    public void HandleOnTriggerEnter(int player)
    {
        // player krijgt damage, mijn ontploft, en verdwijnt
    }
}

public class InfernoExample : MonoBehaviour, ITriggerable
{
    public void HandleOnTriggerEnter(int player)
    {
        // player player staat in de hens, maar inferno blijft staan
    }
}

public interface ITriggerable
{
    void HandleOnTriggerEnter(int player);
}

public class PlayerExample : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ITriggerable trigger = collider.GetComponent<ITriggerable>();
        if (trigger != null)
        {
            trigger.HandleOnTriggerEnter(id);
        }
    }
}

// wie krijgt de OnTriggerEnter?
// antwoord: degene die IN de trigger beweegt, NIET degene die stilstaat