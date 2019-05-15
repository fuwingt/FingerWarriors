using UnityEngine;

namespace Skills
{
    public class PassiveSkill : Skill
    {

        public enum SkillType
        {
            FieldBuff,
            GoldBuff,
            TimeBuff,
            ElementBuff
        }

        public bool isActived;
        public SkillType skillType;

        public PassiveSkill(string name, string description, int id, float result, SkillType skillType) : base(name, description, id, result)
        {
            this.skillType = skillType;
        }


    }
}

