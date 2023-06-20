using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour
{

    private bool canInteract;

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    public abstract void Interact();

    public bool CanInteract()
    {
        return canInteract;
    }

    public void SetCanInteract(bool canInteract)
    {
        this.canInteract = canInteract;
    }

}
