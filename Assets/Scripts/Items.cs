using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField]
    private ItemTypes type;
    public ItemTypes Type => type;
}

public enum ItemTypes
{
    potion,
    coin,
    trap
}
