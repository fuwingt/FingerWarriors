using UnityEngine;

public class Monster : Character
{
    public GameObject _inventoryManager;
    [SerializeField] private float hp;
    [SerializeField] private float maxHp;
    [SerializeField] private float basicHp;

    void Start()
    {
        _inventoryManager = GameObject.Find("InventoryManager");
    }

    public void BeingAttacked(float result)
    {
        // Deduct hp
        hp -= result;
        // Animation
        transform.GetComponent<Animator>().SetTrigger("IsBeingAttacked");
    }
    public void Reborn()
    {
        // This function will be chnaged to "Death" 
        hp = maxHp;
        // Test:
        // Drop equipment to player
        // Automatically collected into inventory
        _inventoryManager.GetComponent<Inventory>().EquipmentPrefab.GetComponent<Equipment>().CreateEquip();
        _inventoryManager.GetComponent<Inventory>().AddEquipment(_inventoryManager.GetComponent<Inventory>().EquipmentPrefab);
    }

    public float getHp()
    {
        return hp;
    }

    public float getMaxHp()
    {
        return maxHp;
    }

    public float getBasicHp()
    {
        return basicHp;
    }
    public void setHp(float hp)
    {
        this.hp = hp;
    }

    public void setMaxHp(float maxHp)
    {
        this.maxHp = maxHp;
    }

    public void setBasicHp(float basicHp)
    {
        this.basicHp = basicHp;
    }


}
