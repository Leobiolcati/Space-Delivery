using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public static int total_score = 100;
    [SerializeField] private Text score_text;
    [SerializeField] private int score_check = total_score;

    private void Update(){
        if(score_check != total_score){
            OnVariableChange(total_score);
        }
    }

    private void OnVariableChange(int new_score){
        Debug.Log("Value change on score: was " + score_check + " now is " + new_score);
        score_check = new_score;
        score_text.text = new_score + " Pontos";
    }
}