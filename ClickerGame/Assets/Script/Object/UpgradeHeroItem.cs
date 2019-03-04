using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeHeroItem : MonoBehaviour {

	
    public Text NameText;   
	public Text LevelText;
	public Text PowerText;
	public Text LevelUpText;

	public Text status;

	private GlobalManager _globalManager;
    private GameObject hero;
    private string heroName;
    private float heroPrice;
    private float heroPower;
	private float heroSkillPower;
	private float heroLevel;
	private bool isSelectingField = false;

	// Use this for initialization
	void Start () {
		_globalManager = GameObject.Find("GlobalManager").gameObject.GetComponent<GlobalManager>();
		InfoUpdate();
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		if(isSelectingField == true)
		{
			SwitchHero();
		}
	}

	public void Purchase()
    {
		if(hero == null)	return;

        if(_globalManager.getGold() >= heroPrice)
        {
           _globalManager.setGold(_globalManager.getGold() - heroPrice);
            hero.GetComponent<Hero>().setUpgradeCount(hero.GetComponent<Hero>().getUpgradeCount() + 1);
            hero.GetComponent<Hero>().setPower(Mathf.Round(hero.GetComponent<Hero>().getPower() * 1.3f));
            hero.GetComponent<Hero>().setSkillPower_1(Mathf.Round(hero.GetComponent<Hero>().getSkillPower_1() * 1.1f));
            hero.GetComponent<Hero>().setPrice(Mathf.Round(hero.GetComponent<Hero>().getPrice() * 1.15f));
			hero.GetComponent<Hero>().setLevel(hero.GetComponent<Hero>().getLevel() + 1);
        }
		InfoUpdate();
    }

	public void SwitchStatus()
	{
		if(hero == null)	return;

		status.text = "Selecting...";
		isSelectingField = true;
		// call function "show arrow sign"
		
	}

	private void SwitchHero()
	{
		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if(hit.collider != null)
			{
				if(hit.collider.gameObject.tag == "Field")
				{
					if(hit.collider.transform.childCount == 0)
					{
						hero.transform.SetParent(hit.collider.gameObject.transform);
						
					}
					else
					{
						// Switch
					}
				}
				else
				{
					// Hide the arrow and then return
				}
			}
			status.text = "Select";
			isSelectingField = false;
		}
	}

	private void InfoUpdate()
	{
		if(hero != null)
		{
			heroName = hero.GetComponent<Hero>().getName();
        	heroPrice = hero.GetComponent<Hero>().getPrice();
        	heroPower = hero.GetComponent<Hero>().getPower();
			heroSkillPower = hero.GetComponent<Hero>().getSkillPower_1();
			heroLevel = hero.GetComponent<Hero>().getLevel();
        
        	NameText.text = heroName;
			LevelText.text = "Lv. " + heroLevel;
			PowerText.text = "DPS: " + heroPower
								+ "\nSkill Power: " + heroSkillPower;

			LevelUpText.text = "$" + heroPrice + " Level Up"
								+ "\n+ DPS: "
								+ "\n+ Skill Power: ";
		}
	}



	public void setHero(GameObject hero)
	{
		this.hero = hero;
	}
}
