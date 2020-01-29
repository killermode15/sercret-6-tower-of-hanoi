using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RodHandler : MonoBehaviour
{
    public int RingCount => ringsHeld.Count;

    private Stack<Ring> ringsHeld = new Stack<Ring>();
    private Transform startPoint = null;

    // Start is called before the first frame update
    private void Start()
    {
        startPoint = transform.GetChild(0);
    }

    public bool CanAddRingToRod(Ring ring)
    {
        if (ringsHeld.Count > 0)
        {
            if (ringsHeld.Peek().RingOrder < ring.RingOrder)
            {
                return false;
            }
        }
        return true;
    }


    public void AddRingToRod(Ring ring)
    {
        if (!ring)
            return;

        if (!CanAddRingToRod(ring))
            return;

        ringsHeld.Push(ring);

        ring.transform.position = startPoint.position;
        ring.transform.parent = startPoint;
        ring.transform.position += new Vector3(0, 0.5f * (ringsHeld.Count - 1), 0);
    }

    public Ring CheckTopRing()
    {
        return ringsHeld.Count <= 0 ? null : ringsHeld.Peek();
    }

    public Ring GetTopRing()
    {
        return ringsHeld.Count <= 0 ? null : ringsHeld.Pop();
    }
}
