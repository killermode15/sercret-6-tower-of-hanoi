using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public int RingOrder => ringOrder;
    [SerializeField] private int ringOrder = 0;

    public void SetRing(int order)
    {
        ringOrder = order;
    }
}
