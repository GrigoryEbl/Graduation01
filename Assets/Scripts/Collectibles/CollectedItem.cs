using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedItem : MonoBehaviour
{
    public void Collect()
    {
        Destroy(gameObject);
    }
}
