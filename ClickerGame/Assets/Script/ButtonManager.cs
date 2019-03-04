using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

	public GameObject menu;
	
	public void PopUpMenu()
	{
		if(menu!=null)
		{
			Animator animator = menu.GetComponent<Animator>();
			if(animator!=null)
			{
				bool isPopUp = animator.GetBool("popUp");
				animator.SetBool("popUp", !isPopUp);
			}
		}
	}

	
}
