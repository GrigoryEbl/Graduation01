using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CollectedItem : MonoBehaviour
{
    //[SerializeField] private Transform _firstPositionY;
    //[SerializeField] private Transform _secondPositionY;
    //[SerializeField] private float _speed;

    //private Transform _target;

    //private void Start()
    //{
    //    _target = _firstPositionY;
    //}
   
    //private void FixedUpdate()
    //{
    //    transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

    //    if (transform.position == _secondPositionY.position)
    //        _target = _firstPositionY;
    //    else if (transform.position == _firstPositionY.position)
    //        _target = _secondPositionY;
    //}

    public void Collect()
    {
        Destroy(gameObject);
    }
}
