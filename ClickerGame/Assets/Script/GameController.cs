using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject _globalManager;
    public ObjectGenerator objectGenerator;
    public GameObject timeCountdownBar;

    void Start()
    {
        objectGenerator.generateHeroes();
        objectGenerator.generateMonster();
        objectGenerator.generatePet();


        GlobalManager.currentEnemy = MonsterManager.monsterList[0];
    }

    void Update()
    {

    }


}
