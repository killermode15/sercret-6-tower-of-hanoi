using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionHandler : MonoBehaviour
{
    private RodHandler selectedRod;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f);

            if (!hit)
                return;
            
            if (!hit.collider.CompareTag("Rod"))
                return;

            RodHandler detectedRod = hit.collider.GetComponent<RodHandler>();
            selectedRod = hit.collider.GetComponent<RodHandler>();

            Debug.Log("hit a rod");
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f);

            if (!hit)
                return;

            if (!hit.collider.CompareTag("Rod"))
                return;

            RodHandler detectedRod = hit.collider.GetComponent<RodHandler>();

            if(!detectedRod.CanAddRingToRod(selectedRod.CheckTopRing()))
            {
                return;
            }
            detectedRod.AddRingToRod(selectedRod.GetTopRing());

            Debug.Log("detected a rod");
        }
    }
}
