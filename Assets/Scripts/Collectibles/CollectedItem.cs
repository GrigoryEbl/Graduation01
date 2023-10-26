using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CollectedItem : MonoBehaviour
{
    public void Collect()
    {
        Destroy(gameObject);
    }
}
