using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour, UsableItem
{

    [SerializeField] private Animator animator;
    [SerializeField] private ItemSO bottleEmptyItemSO;
    [SerializeField] private ItemSO bottleFullItemSO;

    private Sink sink;
    private bool fill;
    private float fillingTimerMax = 4f;
    private float fillingTimer;

    private void Update()
    {
        if (fill)
        {
            fillingTimer -= Time.deltaTime;
            sink.SetProgress(1 - fillingTimer / fillingTimerMax);
            if(fillingTimer <= 0)
            {
                OnFinishFilling();
            }
        }
    }

    public void Use()
    {
        
    }

    public void StartFilling(Sink sink)
    {
        this.sink = sink;
        fill = true;
        fillingTimer = fillingTimerMax;
        animator.SetBool("Fill", fill);
    }

    public void OnFinishFilling()
    {
        fill = false;
        animator.SetBool("Fill", fill);
        Inventory.Instance.RemoveItem(bottleEmptyItemSO);
        Inventory.Instance.AddItem(bottleFullItemSO);
        Player.Instance.EquipItem(bottleFullItemSO.prefab);
    }

}
