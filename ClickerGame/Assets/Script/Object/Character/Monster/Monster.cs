using UnityEngine;
using UnityEngine.UI;

public class Monster : Character
{
    protected Inventory inventoryManager;
    protected MonsterManager monsterManager;
    protected GlobalManager globalManager;
    public Text FloatingTextPrefab;
    public GameObject GoldParticPrefab;
    public GameObject EquipmentGetCtrPrefab;
    [SerializeField] protected float hp;
    [SerializeField] protected float maxHp;
    protected float basicHp;
    protected float maxCoolDown;
    protected float coolDown;

    protected float goldDrop = 10;

    protected virtual void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        monsterManager = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
        globalManager = GameObject.Find("GlobalManager").GetComponent<GlobalManager>();
    }

    protected virtual void Update()
    {
        if (!monsterManager.isBossStage) return;

        coolDown -= Time.deltaTime * 1.5f;
        PassiveSkill();
        if (coolDown <= 0)
        {
            ActiveSkill();
            coolDown = maxCoolDown;
        }
    }

    public void Init()
    {
        if (globalManager.stage % 10 == 0 && globalManager.stage != 0)
        {
            //  Boss stage
            EnhanceToBeBoss();
        }
        else
        {
            //  Normal stage
            maxHp = basicHp * monsterManager.normalHpRate;
            hp = maxHp;
        }
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

    public void Death()
    {
        DropGold();
        // Test:
        // Drop equipment to player
        // Automatically collected into inventory
        inventoryManager.GetComponent<Inventory>().EquipmentPrefab.GetComponent<Equipment>().CreateEquip();
        inventoryManager.GetComponent<Inventory>().AddEquipment(inventoryManager.GetComponent<Inventory>().EquipmentPrefab);
        // Gold brust out 
        Instantiate(GoldParticPrefab, gameObject.transform.position, Quaternion.identity);
        // "Equipment Get" textbox
        Instantiate(EquipmentGetCtrPrefab, transform.parent.parent);

    }

    private void EnhanceToBeBoss()
    {
        maxHp *= monsterManager.bossHpRate;
        hp = maxHp;
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

    protected virtual void ActiveSkill()
    {
        //  Only for Boss
    }

    protected virtual void PassiveSkill()
    {
        //  Only for Boss
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
