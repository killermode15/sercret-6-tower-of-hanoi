using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class RodHandler : MonoBehaviour
{
    public int RingCount => ringsHeld.Count;
    public Vector3 TopPosition => topPoint.position;
    public Vector3 StartPosition => startPoint.position;

    [Header("Animation Properties")]
    [Space(10)]
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private Transform startPoint = null;
    [SerializeField] private Transform topPoint = null;

    private Stack<Ring> ringsHeld = new Stack<Ring>();

    public List<Ring> ringTest = new List<Ring>();

    private void Update()
    {
        ringTest = ringsHeld.ToList();
    }

    public bool CanAddRingToRod(Ring ring)
    {
        if (ringsHeld.Count <= 0) return true;

        return ringsHeld.Peek().RingOrder >= ring.RingOrder;
    }


    public void AddRingToRod(Ring ring, bool addDelay = false)
    {
        if (!ring)
            return;

        if (!CanAddRingToRod(ring))
            return;
        
        ringsHeld.Push(ring);

        ring.transform.position = startPoint.position + Vector3.up * 6.5f;
        ring.transform.parent = startPoint;

        Vector3 targetPos = startPoint.position + new Vector3(0, 0.5f * (ringsHeld.Count - 1), 0);

        if (addDelay)
        {
            StartCoroutine(AnimateRing_CR(ring, targetPos, 0.35f, (ringsHeld.Count - 1) * 0.2f));
        }
        else
        {
            StartCoroutine(AnimateRing_CR(ring, targetPos, 0.35f));
        }
    }

    public Ring CheckTopRing()
    {
        return ringsHeld.Count <= 0 ? null : ringsHeld.Peek();
    }

    public Ring GetTopRing()
    {
        return ringsHeld.Count <= 0 ? null : ringsHeld.Pop();
    }

    public void ClearRod()
    {
        ringsHeld.Clear();
        //for (int i = ringsHeld.Count - 1; i > 0 ; i--)
        //{
        //    Destroy(ringsHeld.Pop().gameObject);
        //}
    }

    private IEnumerator AnimateRing_CR(Ring ring, Vector3 targetPos, float duration, float delay = 0)
    {
        ring.gameObject.SetActive(false);
        yield return new WaitForSeconds(delay);
        ring.gameObject.SetActive(true);

        float currTime = 0;
        float perc = 0;
        Vector3 startPos = startPoint.position + Vector3.up * 6.5f;

        Vector3 startingPos = ring.transform.position;

        while (perc < 1)
        {
            currTime += Time.deltaTime;
            perc = currTime / duration;

            float easedPerc = gameSettings.RingEaseCurve.Evaluate(perc);
            ring.transform.position = Vector3.Lerp(startPos, targetPos, easedPerc);

            yield return new WaitForEndOfFrame();
        }
    }

}
