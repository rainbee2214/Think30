using UnityEngine;
using System.Collections;

public class FunctionButton : TouchButtonController 
{
	public GameObject sinWave;

	void Update () 
	{
		CheckForTouches();
	}

	public override void OnTouchEnded()
	{
		if ((this.name == "A+") || (this.name == "A-"))
			ChangeA();
		if ((this.name == "B+") || (this.name == "B-"))
			ChangeB();
		if ((this.name == "C+") || (this.name == "C-"))
			ChangeC();

	}

	void ChangeA()
	{
		if(this.name == "A+") sinWave.GetComponent<BonusController>().a += 0.25f;
		if(this.name == "A-") sinWave.GetComponent<BonusController>().a -= 0.25f;
	}

	void ChangeB()
	{
		if(this.name == "B+") sinWave.GetComponent<BonusController>().b += 0.25f;;
		if(this.name == "B-") sinWave.GetComponent<BonusController>().b -= 0.25f;
	}

	void ChangeC()
	{
		if(this.name == "C+") sinWave.GetComponent<BonusController>().c += 1f;
		if(this.name == "C-") sinWave.GetComponent<BonusController>().c -= 1f;
	}


}
