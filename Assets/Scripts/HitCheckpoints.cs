using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class HitCheckpoints : MonoBehaviour
{
	public int WrongCheckpoints;
	public int GoodCheckpoints;
	public Text QuestionText;
	public Text AnswerR;
	public Text AnswerG;
	public Text AnswerB;
	public GameObject FinishedText;
	public Text ExtraTimeText;
	public Stopwatch RoundTime;
	public GameObject finish;
	public int level;

	public int AmountOfQuestions = 3;
	private int RightAnswerIndex;
	private bool finished = false;
	private QuestionObj[] Questions;

	private void Start()
	{
		RoundTime = new Stopwatch();
		
		FinishedText.gameObject.SetActive(false);
		finish.transform.GetChild(0).gameObject.SetActive(false);

		switch (level)
		{
			case 1:
				Questions = new[]
				{
					new QuestionObj("Wat is de hoodstad van Marokko", "Rabat", "Caïro", "Istanbull"),
					new QuestionObj("Wat is de hoofdstad van België?", "Brussel", "Antwerpen", "Gent"),
					new QuestionObj("Welke stad heeft de meeste inwoners?", "Luxemburg (land)", "Antwerpen", "Den Haag"),
					new QuestionObj("Welk land heeft de grootste oppervlakte?", "Canada", "Verenigde Staten", "Australië"),
					new QuestionObj("Hoeveel provincies zijn er in NL?", "12", "10", "11")
				};
				break;
			case 2:
				Questions = new[]
				{
					new QuestionObj("2 + 9", "11", "10", "13"),
					new QuestionObj("23 + 44", "67", "77", "69"),
					new QuestionObj("4,2 * 3", "12,6", "12,9", "12,2"),
					new QuestionObj("Wat is de wortel van 25", "5", "2", "4.26"),
					new QuestionObj("2 tot de macht 4 is...?", "16", "32", "10")
				};
				break;
			default:
				Debug.LogError("Could not find the selected level. Please change this asap.");
				break;
		}

		GenerateQuestion(0);
	}
	
	//When a checkpoint gets hit
	private void OnTriggerEnter(Collider collidedObject)
	{
		// Should only trigger when a checkpoint or finished gets hit
		if (!collidedObject.gameObject.CompareTag("Checkpoint")) return;
		
		// When the finish gets hit
		if (collidedObject.name == "Finish" && !finished)
		{
			finished = true;
			RoundTime.Stop();
			collidedObject.transform.GetChild(0).gameObject.SetActive(true);
			Camera.main.gameObject.SetActive(false);
			collidedObject.GetComponent<BoxCollider>().enabled = false;
			finish.transform.GetChild(0).gameObject.SetActive(true);
			QuestionText.transform.parent.gameObject.SetActive(false);
			FinishedText.gameObject.SetActive(true);
			GetComponent<HighscoreController>().AddScore(level, VariableManager.Username, RoundTime.Elapsed.Add(TimeSpan.FromSeconds(5 * WrongCheckpoints)));
			Debug.Log(RoundTime.Elapsed.ToString());
		}
		else   // Disable checkpoints as soon as they get hit
		{
			collidedObject.transform.parent.gameObject.SetActive(false);
			if (collidedObject.GetComponent<FlareController>().color == (FlareController.ColorsEnum)RightAnswerIndex)
			{
				GoodCheckpoints++;
			}
			else
			{
				WrongCheckpoints++;
				ExtraTimeText.text = "+ " + WrongCheckpoints * 5 + ".00";
			}
		}
		
		if (GoodCheckpoints + WrongCheckpoints < AmountOfQuestions)
		{
			GenerateQuestion(GoodCheckpoints + WrongCheckpoints);
		}
		else
		{
			QuestionText.transform.parent.gameObject.SetActive(false);
		}
	}

	private void GenerateQuestion(int count)
	{
		int rando = Random.Range(1, 4);
		QuestionText.text = Questions[count].Question;
		AnswerR.text = Questions[count].Answers[(rando + 0) % 3];
		AnswerG.text = Questions[count].Answers[(rando + 1) % 3];
		AnswerB.text = Questions[count].Answers[(rando + 2) % 3];
		RightAnswerIndex = 3 - rando;
	}
}

public class QuestionObj
{
	public string Question { get; private set; }
	public string[] Answers { get; private set; }

	public QuestionObj(string question, string goodAnswer, string badAnswer1, string badAnswer2)
	{
		Question = question;
		Answers = new[] {goodAnswer, badAnswer1, badAnswer2};
	}
}
