using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sink : BaseInteractable
{

    [SerializeField] private Image progressBar;
    [SerializeField] private Image progressBarBackground;
    [SerializeField] private Gradient progressBarGradient;

    private void Awake()
    {
        progressBar.gameObject.SetActive(false);
        progressBarBackground.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetCanInteract(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SetCanInteract(false);
    }

    public override void Interact()
    {
        if (CanInteract())
        {
            UsableItem usableItem = Player.Instance.GetCurrentUsableItemEquipped();
            if(usableItem != null)
            {
                if (usableItem is Bottle bottle)
                {
                    bottle.StartFilling(this);
                }
            }
        }
    }

    public void SetProgress(float progress)
    {
        if(progress > 0 && progress < 1)
        {
            progressBar.gameObject.SetActive(true);
            progressBarBackground.gameObject.SetActive(true);
        }
        else
        {
            progressBar.gameObject.SetActive(false);
            progressBarBackground.gameObject.SetActive(false);
        }

        progressBar.fillAmount = progress;
        progressBar.color = progressBarGradient.Evaluate(progress);
    }

}
