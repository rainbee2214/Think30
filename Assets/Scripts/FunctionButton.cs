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
		if(this.name == "A+") sinWave.GetComponent<MathFunctions>().a += 0.25f;
		if(this.name == "A-") sinWave.GetComponent<MathFunctions>().a -= 0.25f;

		//if(sinWave.GetComponent<MathFunctions>().a < -5) sinWave.GetComponent<MathFunctions>().a = -5;
		//if(sinWave.GetComponent<MathFunctions>().a > 5) sinWave.GetComponent<MathFunctions>().a = 5;
	}
	void ChangeB()
	{
		if(this.name == "B+") sinWave.GetComponent<MathFunctions>().b += 0.25f;;
		if(this.name == "B-") sinWave.GetComponent<MathFunctions>().b -= 0.25f;

		//if(sinWave.GetComponent<MathFunctions>().b < -5) sinWave.GetComponent<MathFunctions>().b = -5;
		//if(sinWave.GetComponent<MathFunctions>().b > 5) sinWave.GetComponent<MathFunctions>().b = 5;
	}
	void ChangeC()
	{
		if(this.name == "C+") sinWave.GetComponent<MathFunctions>().c += 1f;
		if(this.name == "C-") sinWave.GetComponent<MathFunctions>().c -= 1f;

		//if(sinWave.GetComponent<MathFunctions>().c < -3) sinWave.GetComponent<MathFunctions>().c = -3;
		//if(sinWave.GetComponent<MathFunctions>().c > 3) sinWave.GetComponent<MathFunctions>().c = 3;
	}


}
