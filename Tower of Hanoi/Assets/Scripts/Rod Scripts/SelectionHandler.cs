using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectionHandler : MonoBehaviour
{
    [Header("Selection Events")]
    [SerializeField] private UnityEvent onRingMove;

    private RodHandler selectedRod = null;
    private Ring ring = null;
    private Vector3 ringTargetPosition = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnRodSelected();
        }
        else if (ring != null)
        {
            OnRodHover();
            if (Input.GetMouseButtonUp(0))
            {
                OnRodDown();
            }
        }
    }

    // Is called when a rod is clicked on
    private void OnRodSelected()
    {
        // Cast a ray to check if an object is clicked
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f);

        // Do nothing if there was nothing hit or the object hit is not a rod
        if (!hit)
            return;

        if (!hit.collider.CompareTag("Rod"))
            return;

        // Set the detected rod as the selected rod
        selectedRod = hit.collider.GetComponent<RodHandler>();
        // Get a reference to the top ring of the rod
        ring = selectedRod.CheckTopRing();
    }

    // Is called when a rod with a ring is selected and the left mouse button is held
    private void OnRodHover()
    {
        // Cast a ray to check if an object is detected
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f);

        // If an object is detected and it's a rod, set the rod's top position as the target position
        if (hit)
        {
            if (hit.collider.CompareTag("Rod"))
            {
                RodHandler hoveredRod = hit.collider.GetComponent<RodHandler>();
                ringTargetPosition = hoveredRod.TopPosition;
            }
        }

        ring.transform.position = Vector3.Lerp(ring.transform.position, ringTargetPosition, Time.deltaTime * 10);
    }

    private void OnRodDown()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f);

        if(hit)
        {
            if(!hit.collider.CompareTag("Rod") && ring != null)
            {
                ring = null;
                selectedRod.AddRingToRod(selectedRod.GetTopRing());
            }

            RodHandler detectedRod = hit.collider.GetComponent<RodHandler>();

            if (!detectedRod.CanAddRingToRod(selectedRod.CheckTopRing()))
            {
                if (ring)
                {
                    ring = null;
                    selectedRod.AddRingToRod(selectedRod.GetTopRing());
                }
                return;
            }
            detectedRod.AddRingToRod(selectedRod.GetTopRing());
            ring = null;
        }
    }
}
