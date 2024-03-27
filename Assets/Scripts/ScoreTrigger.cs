using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour{
    [SerializeField] private int score_decrease;
    [SerializeField] private string codeword;

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            Debug.Log("Collision, caused by " + codeword);
            Score.total_score-=score_decrease;
        }
    }
}