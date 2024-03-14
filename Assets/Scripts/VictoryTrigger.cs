using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryTrigger : MonoBehaviour{

    [SerializeField] private string LevelName;
    public GameObject VictoryText;
    public float delay;

    void Start(){
        VictoryText.SetActive(false);
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            VictoryText.SetActive(true);
            StartCoroutine(Countdown());
        }
    }
    IEnumerator Countdown(){
        yield return new WaitForSeconds (delay);
        SceneManager.LoadScene(0);
    }
}