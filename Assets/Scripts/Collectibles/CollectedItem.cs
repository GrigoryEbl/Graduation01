using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CollectedItem : Sounds
{
    public void Collect()
    {
        PlaySound(sounds[0], volume: 1, isDestroyed: true);
        Destroy(gameObject);
    }
}
