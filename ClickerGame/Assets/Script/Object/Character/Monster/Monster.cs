using UnityEngine;
using UnityEngine.UI;
using Skills;

public class Monster : Character
{
    //  Objects
    public Text FloatingTextPrefab;
    public Text CriticalTextPrefab;
    public GameObject GoldParticPrefab;
    public GameObject EquipmentGetCtrPrefab;
    public GameObject DamagePanel;
    private Inventory inventoryManager;
    private MonsterManager monsterManager;
    private GlobalManager globalManager;
    private SkillManager skillManager;

    //
    private string skill;
    private int clickShieldCount;
    private float hp;
    private float maxHp;
    private float basicHp;
    private float maxCoolDown;
    private float coolDown;
    private float dodgeChance;
    private float goldDrop;



    void Start()
    {
        SetManager();
        clickShieldCount = 0;
        dodgeChance = 0;
        goldDrop = 10;

        maxHp = basicHp * monsterManager.normalHpRate;
        hp = maxHp;
    }

    void Update()
    {
        if (!monsterManager.isBossStage) return;

        if (skillManager.EnemySkills[skill].skillType == ActiveSkill.SkillType.Multiple)
        {
            coolDown -= Time.deltaTime * 1.5f;
            if (coolDown <= 0)
            {
                UseSkill();
                coolDown = maxCoolDown;
            }
        }

    }

    public void Init()
    {
        SetManager();
        if (globalManager.stage % 10 == 0 && globalManager.stage != 0)
        {
            //  Boss stage
            EnhanceToBeBoss();
            if (skillManager.EnemySkills[skill].skillType == ActiveSkill.SkillType.Single)
                UseSkill();
        }
        else
        {
            //  Normal stage
            maxHp = basicHp * monsterManager.normalHpRate;
            hp = maxHp;
        }
    }

    public void BeingAttacked(float result, bool isCritical)
    {
        // Deduct hp
        if (clickShieldCount <= 0)
        {
            //  Dodge chance
            int randValue = Random.Range(1, 100);
            if (randValue > dodgeChance)
                hp -= (int)result;
        }

        else
        {
            clickShieldCount--;
        }

        // Show floating text
        ShowFloatingText((int)result, isCritical);
        // Animation
        transform.GetComponent<Animator>().SetTrigger("IsBeingAttacked");
    }

    public void Death()
    {
        DropGold();
        // Test:
        // Drop equipment to player
        // Automatically collected into inventory
        inventoryManager.GetComponent<Inventory>().AddEquipment();
        // Gold brust out 
        Instantiate(GoldParticPrefab, gameObject.transform.position, Quaternion.identity);
        // "Equipment Get" textbox
        Instantiate(EquipmentGetCtrPrefab, transform.parent.parent);

    }

    void EnhanceToBeBoss()
    {
        maxHp *= monsterManager.bossHpRate;
        hp = maxHp;
    }

    void DropGold()
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

    void UseSkill()
    {
        skillManager.TurnOnMonsterSkill(skill, 0);
    }

    void ShowFloatingText(float power, bool isCritical)
    {
        Text damageText;
        if (isCritical)
            damageText = Instantiate(CriticalTextPrefab, transform.parent.position, Quaternion.identity, DamagePanel.transform);
        else
            damageText = Instantiate(FloatingTextPrefab, transform.parent.position, Quaternion.identity, transform);

        damageText.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        damageText.text = GlobalManager.NumberConverter((int)power);

    }

    void SetManager()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        monsterManager = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
        globalManager = GameObject.Find("GlobalManager").GetComponent<GlobalManager>();
        skillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();

        DamagePanel = GameObject.Find("DamagePanel");
    }

    //  Getter
    public string getSkill()
    {
        return skill;
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

    public float getMaxCoolDown()
    {
        return maxCoolDown;
    }

    public float getCoolDown()
    {
        return coolDown;
    }

    public int getClickShieldCount()
    {
        return clickShieldCount;
    }

    //  Setter
    public void setSkill(string skill)
    {
        this.skill = skill;
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

    public void setMaxCoolDown(float maxCoolDown)
    {
        this.maxCoolDown = maxCoolDown;
    }

    public void setCoolDown(float coolDown)
    {
        this.coolDown = coolDown;
    }

    public void setClickShieldCount(int clickShieldCount)
    {
        this.clickShieldCount = clickShieldCount;
    }

    public void setDodgeChance(float dodgeChance)
    {
        this.dodgeChance = dodgeChance;
    }




}
