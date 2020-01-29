using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public int RingOrder => ringOrder;
    [SerializeField] private int ringOrder = 0;
    [SerializeField] private TextMeshPro ringOrderText;

    public void SetRing(int order)
    {
        name = "Ring [" + order +"]";
        ringOrder = order;
        ringOrderText.text = order.ToString();
        //ringOrderText.transform.SetParent(null);
        ringOrderText.transform.localScale = new Vector3(1, 1f, 1);
        ringOrderText.transform.SetParent(transform, true);
        ringOrderText.transform.position = transform.position;
    }
}
