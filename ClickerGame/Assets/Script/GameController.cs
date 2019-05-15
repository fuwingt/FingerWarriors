using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skills;

public class GameController : MonoBehaviour
{
    public ObjectGenerator _objectGenerator;
    public SkillManager _skillManager;
    public AchievementManager _achievementManager;

    void Start()
    {
        _skillManager.createSkills();
        _objectGenerator.generateHeroes();
        _objectGenerator.generateMonster();
        _objectGenerator.generatePet();
        _achievementManager.Init();

        GlobalManager.currentEnemy = MonsterManager.monsterList[0];


        GlobalManager.FieldArray[0].transform.GetChild(0).GetComponent<Hero>().isOnField = true;
    }



}
