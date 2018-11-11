using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareController : MonoBehaviour
{
	public enum ColorsEnum
	{
		Red, Green, Blue
	}

	public ColorsEnum color;
	private Color flareColor = Color.red;

	// Use this for initialization
	void Start () {
		switch (color)
		{
				case ColorsEnum.Red:
					flareColor = Color.red;
					break;
				case ColorsEnum.Green:
					flareColor = Color.green;
					break;
				case ColorsEnum.Blue:
					flareColor = Color.blue;
					break;
				default:
					flareColor = Color.red;
					break;
		}
		
		foreach (Transform child in transform)
		{
			child.GetComponent<ParticleSystem>().startColor = flareColor;
		}
	}
	
}
