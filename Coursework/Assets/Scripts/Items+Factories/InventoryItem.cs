using System;

public enum ItemTypes { Eye, Pinky, Cerebellum };

[Serializable]

public struct InventoryItem
{
    public ItemTypes type;
    public int quant;
}