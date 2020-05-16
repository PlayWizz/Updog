using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updogScript : MonoBehaviour 
{
	public KMAudio Audio;
	public KMBombInfo Bomb;
	public KMBombModule Module;

	public KMSelectable Doge;
	public KMSelectable[] Dogs;
	public KMSelectable[] Regs;
	public Material[] COL14;
	public Material[] COL23;
	public Renderer DogeColor;
	private int DogeColorIndex = 1;

	//Logging
	static int moduleIdCounter = 1;
	int moduleId;
	private bool moduleSolved;

	void Awake()
	{
		moduleId = moduleIdCounter++;
		foreach (KMSelectable Dog in Dogs)
		{
			KMSelectable pressedDog = Dog;
			Dog.OnInteract += delegate () { DogsPress(pressedDog); return false; };
		} 

		foreach (KMSelectable Reg in Regs)
		{
			KMSelectable pressedReg = Reg;
			Reg.OnInteract += delegate () { RegsPress(pressedReg); return false; };
		} 

		Doge.OnInteract += delegate () {PressDoge(); return false; };
	}

	void Start () 
	{
		ColorCycle();
	}

	void ColorCycle()
	{
		DogeColorIndex = UnityEngine.Random.Range(0,6);
		DogeColor.material = COL14[DogeColorIndex];
	}
	
	void DogsPress(KMSelectable Dog)
	{
		Debug.Log("A dog has been pressed.");
	}

	void RegsPress(KMSelectable Reg)
	{
		Debug.Log("A reg has been pressed.");
	}

	void PressDoge()
	{
		Debug.Log("The Doge is happy to see he is being noticed!");
	}
}
