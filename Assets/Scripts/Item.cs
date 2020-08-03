using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "TypeMan/Item", order = 0)]
public class Item : ScriptableObject {
    // Fields
    private string itemName;
    private Vector3 itemLocation;
    private Mesh itemMesh;

    // Properties
    public string ItemName { get => itemName; set => itemName = value; }
    public Vector3 ItemLocation { get => itemLocation; set => itemLocation = value; }
    public Mesh ItemMesh { get => itemMesh; set => itemMesh = value; }

    // Methods
    public void SetItem()
    {

    }

    public void RemoveSimilarItems()
    {
        
    }
}

