using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skills;

public class GameController : MonoBehaviour
{
    public ObjectGenerator objectGenerator;
    public SkillManager skillManager;

    void Start()
    {
        skillManager.createSkills();
        objectGenerator.generateHeroes();
        objectGenerator.generateMonster();
        objectGenerator.generatePet();


        GlobalManager.currentEnemy = MonsterManager.monsterList[0];
    }

    void Update()
    {

    }


}
