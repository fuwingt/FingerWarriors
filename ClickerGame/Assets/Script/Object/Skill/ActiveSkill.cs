using UnityEngine;

namespace Skills
{
    public class ActiveSkill : Skill
    {
        public enum SkillType
        {
            //  Heroes
            ActiveDamage,
            Buff,
            Debuff,
            //  Enemy
            Multiple,
            Single

        }

        public SkillType skillType;
        public int requiredEnergy;


        public ActiveSkill(string name, string description, int requiredEnergy, int id, float result, SkillType skillType) : base(name, description, id, result)
        {
            this.requiredEnergy = requiredEnergy;
            this.skillType = skillType;
        }


    }
}

