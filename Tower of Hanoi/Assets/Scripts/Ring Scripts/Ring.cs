using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public int RingOrder => ringOrder;

    [SerializeField] private int ringOrder = 0;
    [SerializeField] private TextMeshPro ringOrderText = null;
    [SerializeField] private SpriteRenderer spriteRenderer = null;

    private void Start()
    {
    }

    public void SetRing(int order, Color color, Vector3 scale)
    {
        name = "Ring [" + order +"]";
        ringOrder = order;
        ringOrderText.text = order.ToString();
        spriteRenderer.color = color;
        spriteRenderer.transform.localScale += scale;

    }
}
