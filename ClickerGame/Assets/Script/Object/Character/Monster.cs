using UnityEngine;
using UnityEngine.UI;

public class Monster : Character
{
    public GameObject _inventoryManager;
    public Text FloatingTextPrefab;
    public GameObject GoldParticPrefab;
    public GameObject EquipmentGetCtrPrefab;
    [SerializeField] private float hp;
    [SerializeField] private float maxHp;
    [SerializeField] private float basicHp;
    protected float goldDrop = 10;

    void Start()
    {
        _inventoryManager = GameObject.Find("InventoryManager");
    }

    public void BeingAttacked(float result)
    {
        // Deduct hp
        hp -= (int)result;
        // Show floating text
        ShowFloatingText((int)result);
        // Animation
        transform.GetComponent<Animator>().SetTrigger("IsBeingAttacked");
    }
    public void Reborn()
    {
        // This function will be chnaged to "Death" 
        hp = maxHp;
        // Drop gold
        DropGold();
        // Test:
        // Drop equipment to player
        // Automatically collected into inventory
        _inventoryManager.GetComponent<Inventory>().EquipmentPrefab.GetComponent<Equipment>().CreateEquip();
        _inventoryManager.GetComponent<Inventory>().AddEquipment(_inventoryManager.GetComponent<Inventory>().EquipmentPrefab);
        // Gold brust out 
        Instantiate(GoldParticPrefab, gameObject.transform.position, Quaternion.identity);
        // "Equipment Get" textbox
        Instantiate(EquipmentGetCtrPrefab, gameObject.transform.position, Quaternion.identity, transform.parent.parent);

    }

    private void DropGold()
    {
        float randValue = Random.Range(0, 100);
        if (randValue <= GlobalManager.gold10xChance)
        {
            GlobalManager.setGold(GlobalManager.getGold() + goldDrop * 10);
        }
        else
        {
            GlobalManager.setGold(GlobalManager.getGold() + goldDrop);
        }
    }

    private void EnhanceToBeBoss()
    {
        //maxHp = 
    }

    private void ShowFloatingText(float power)
    {
        Text damageText = Instantiate(FloatingTextPrefab, transform.parent.position, Quaternion.identity, transform);
        damageText.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        damageText.text = power.ToString();

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
