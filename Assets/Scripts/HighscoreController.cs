using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour
{
	public Text[] Texts;

	public void UpdateHighscore(int level)
	{
		if (VariableManager.GetLevelHighscore(level).Count <= 0) return;
		
		var sortedList = VariableManager.GetLevelHighscore(level).OrderBy(x => x.Time).ToList();

		Debug.Log("Entries bij de highscore: " + sortedList.Count);
			
		Texts[0].text = "1. " + sortedList[0].Username.Substring(0, 3).ToUpper() + " " + sortedList[0].Time.TotalSeconds.ToString().Substring(0, 5);
		if (VariableManager.GetLevelHighscore(level).Count >= 2)
		{
			Texts[1].text = "2. " + sortedList[1].Username.Substring(0, 3).ToUpper() + " " + sortedList[1].Time.TotalSeconds.ToString().Substring(0, 5);
		}
		if (VariableManager.GetLevelHighscore(level).Count >= 3)
		{
			Texts[2].text = "3. " + sortedList[2].Username.Substring(0, 3).ToUpper() + " " + sortedList[2].Time.TotalSeconds.ToString().Substring(0, 5);
		}
	}

	public void AddScore(int level, string name, TimeSpan time)
	{
		VariableManager.AddLevelHighscore(level, name, time);
		UpdateHighscore(level);
	}
}