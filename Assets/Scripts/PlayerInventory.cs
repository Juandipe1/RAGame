using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfGem { get; private set; }

    public UnityEvent<PlayerInventory> OnGemCollected;

    public void GemCollected()
    {
        NumberOfGem++;
        OnGemCollected.Invoke(this);
    }
}
