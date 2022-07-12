using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public float DistanceToInteract;
    public Camera FPScamera;

    public LayerMask InteractableMask;

    private void Update()
    {
        Debug.DrawRay(FPScamera.transform.position, FPScamera.transform.forward * DistanceToInteract);
        if (Input.GetKeyDown(KeyCode.E))
        {
            SeekInteraction();
        }
    }

    public void SeekInteraction()
    {
        RaycastHit hit;

        if (Physics.Raycast(FPScamera.transform.position, FPScamera.transform.forward, out hit, DistanceToInteract, InteractableMask))
        {
            Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}