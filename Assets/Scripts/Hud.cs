using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
	public Sprite[] HeartSprites;

	public Image HeartsUI;

	private NPC npc;

	int vida = 0;

	void Start()
	{
		npc = GameObject.FindGameObjectWithTag("alexia").GetComponent<NPC>();
		Debug.Log(npc.getVida());
	}

	void Update()
	{
		if (npc.getVida() >  50)
		{
			vida = 5;
		}

		else if (npc.getVida() < 50 && npc.getVida() > 40)
		{
			vida = 4;
		}
		else if(npc.getVida() < 40 && npc.getVida() > 30 )
		{
			vida = 3;
		}
		else if(npc.getVida() < 30 && npc.getVida() > 20)
		{
			vida = 2;
		}
		else if(npc.getVida() < 20 && npc.getVida() > 10)
		{
			vida = 1;
		}
		else if(npc.getVida() < 20 && npc.getVida() > 10)
		{
			vida = 0;
		}

		HeartsUI.sprite = HeartSprites[vida];
		Debug.Log(npc.getVida());
	}
}
