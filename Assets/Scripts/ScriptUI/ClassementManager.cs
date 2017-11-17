using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassementManager : MonoBehaviour {


	private int scoreJ1;
	private int scoreJ2;
	private int scoreJ3;
	private int scoreJ4;

	public Text firstPlayer;
	public Text secondPlayer;
	public Text thirdPlayer;
	public Text fourthPlayer;

	public GameObject uiManagerIG;

	public enum Scores {
		Joueur1,
		Joueur2,
		Joueur3,
		Joueur4,
		numEntries
	}

	public int[] score;

	void Awake(){
		score = new int[(int)Scores.numEntries];
		score[(int)Scores.Joueur1]= uiManagerIG.GetComponent<UIManagerIG>().DisplayScore(1);
		score[(int)Scores.Joueur2]= uiManagerIG.GetComponent<UIManagerIG>().DisplayScore(2);
		score[(int)Scores.Joueur3]= uiManagerIG.GetComponent<UIManagerIG>().DisplayScore(3);
		score[(int)Scores.Joueur4]= uiManagerIG.GetComponent<UIManagerIG>().DisplayScore(4);
		int maxIndex=-1;
		int maxValue = 0;
		for(int i=0;i<(int)Scores.numEntries;i++){
			if(score[i]>maxValue){
				maxValue=score[i];
				maxIndex=i;
			}
		}

		if(maxIndex >=0){
			Debug.Log((Scores)maxIndex + "   " + maxValue);
			firstPlayer.text = (Scores)maxIndex + " : "+ maxValue+" points ";
		}
		int secondIndex=-1;
		int secondValue = 0;
		for(int i=0;i<(int)Scores.numEntries;i++){
			if (score[i] == maxValue){
				i++;
			}
			if(score[i]>secondValue){
				secondValue=score[i];
				secondIndex=i;
			}
		}
		if(secondIndex >=0){
			Debug.Log((Scores)secondIndex + "   " + secondValue);
			secondPlayer.text = (Scores)secondIndex + " : " + secondValue + " points ";
		}
		int thirdIndex=-1;
		int thirdValue = 0;
		for(int i=0;i<(int)Scores.numEntries;i++){
			if (score[i] == maxValue || score[i] == secondValue){
				i++;
			}
			if(score[i]>thirdValue){
				thirdValue=score[i];
				thirdIndex=i;
			}
		}
		if(thirdIndex >=0){
			Debug.Log((Scores)thirdIndex + "   " + thirdValue);
			thirdPlayer.text = (Scores)thirdIndex + " : " + thirdValue + " points ";
		}
		int fourthIndex=-1;
		int fourthValue = 0;
		for(int i=0;i<(int)Scores.numEntries;i++){
			if (score[i] == maxValue || score[i] == secondValue || score[i] == thirdValue){
				i++;
			}
			if(score[i]>fourthValue){
				fourthValue=score[i];
				fourthIndex=i;
			}
		}
		if(fourthIndex >=0){
			Debug.Log((Scores)fourthIndex + "   " + fourthValue);
			fourthPlayer.text = (Scores)fourthIndex + " : " + fourthValue + " points ";
		}
	}
}