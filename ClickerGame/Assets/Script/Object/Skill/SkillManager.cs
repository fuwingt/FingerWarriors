using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    public class SkillManager : MonoBehaviour
    {

        public GameObject SkillObjectPrefab;
        public GameObject monsterPanel;
        public TimeCountdownBar timeCountdownBar;
        public GlobalManager globalManager;
        public MonsterManager monsterManager;
        private Dictionary<string, ActiveSkill> ActiveSkills = new Dictionary<string, ActiveSkill>();
        private Dictionary<string, PassiveSkill> PassiveSkills = new Dictionary<string, PassiveSkill>();

        void Start()
        {
            //	ActiveSkills (Id: 0 - 99)
            ActiveSkills.Add("FireSlash", new ActiveSkill("FireSlash", "Make fire damage to enemy", 30, 0, 0, ActiveSkill.SkillType.ActiveDamage));
            ActiveSkills.Add("Freeze", new ActiveSkill("Freeze", "Make water damage to enemy", 70, 1, 0, ActiveSkill.SkillType.ActiveDamage));

            //	PassiveSkills (Id: 100 - 199)
            PassiveSkills.Add("AttackBuffFront", new PassiveSkill("AttackBuffFront", "", 100, 0, PassiveSkill.SkillType.FieldBuff));
            PassiveSkills.Add("AttackBuffBack", new PassiveSkill("AttackBuffBack", "", 101, 0, PassiveSkill.SkillType.FieldBuff));
        }

        public void TurnOnActiveSkill(string name, float result)
        {
            int _id = ActiveSkills[name].getId();
            int _requiredEnergy = ActiveSkills[name].requiredEnergy;
            ActiveSkill.SkillType _skilltType = ActiveSkills[name].skillType;

            if (_skilltType == ActiveSkill.SkillType.ActiveDamage)
            {
                if (monsterManager.GetCurrentMonster() != null)
                {
                    if (globalManager.getEnergy() >= _requiredEnergy)
                    {
                        globalManager.setEnergy(globalManager.getEnergy() - _requiredEnergy);
                        // Skill object
                        GameObject SkillObject = Instantiate(SkillObjectPrefab, monsterPanel.transform);
                        SkillObject.GetComponent<Animator>().SetInteger("SkillID", _id);
                        SkillObject.GetComponent<SkillObject>().setResult(result);
                        ActiveSkillEffect(name);
                    }
                    else
                    {
                        // Not enough energy
                    }
                }
            }


        }

        public void TurnOnPassiveSkill(string name, float buffRate, bool isActivated)
        {
            PassiveSkill.SkillType _skillType = PassiveSkills[name].skillType;

            if (_skillType == PassiveSkill.SkillType.FieldBuff)
            {
                string target = "";
                switch (name)
                {
                    case "AttackBuffFront":
                        target = "FrontField";
                        break;

                    case "AttackBuffBack":
                        target = "BackField";
                        break;

                }

                for (int i = 0; i < GlobalManager.FieldArray.Length; i++)
                {
                    Field f = GlobalManager.FieldArray[i].GetComponent<Field>();

                    if (f.tag != target) continue;

                    if (isActivated)
                        f.fieldBuff *= buffRate;
                    else
                        f.fieldBuff /= buffRate;
                }
            }
            else if (_skillType == PassiveSkill.SkillType.GoldBuff)
            { }
            else if (_skillType == PassiveSkill.SkillType.TimeBuff)
            { }


        }

        private void ActiveSkillEffect(string name)
        {
            switch (name)
            {
                case "Freeze":
                    if (monsterManager.isBossStage)
                    {
                        if (timeCountdownBar == null)
                            timeCountdownBar = GameObject.Find("TimeCountdownBar").GetComponent<TimeCountdownBar>();

                        timeCountdownBar.StopCounting(2);
                    }
                    break;
                default:
                    //	There is no skill effect
                    break;
            }
        }


    }
}


