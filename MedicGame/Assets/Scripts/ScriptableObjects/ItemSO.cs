using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ItemSO")]
public class ItemSO : ScriptableObject
{

    public string itemName;
    public Sprite sprite;
    public Vector3 uiOffset;
    public float uiWidth = 100;
    public float uiHeight = 100;
    public Transform prefab;

}
