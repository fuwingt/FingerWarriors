using UnityEngine;

public class Monster : Character
{
    [SerializeField] private float hp;
    [SerializeField] private float maxHp;
    [SerializeField] private float basicHp;

    public void BeingAttacked(float result)
    {
        // Deduct hp
        hp -= result;
        // Animation
        transform.GetComponent<Animator>().SetTrigger("IsBeingAttacked");
    }
    public void Reborn()
    {
        hp = maxHp;
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
