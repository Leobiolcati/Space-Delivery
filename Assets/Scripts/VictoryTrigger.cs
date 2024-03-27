using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryTrigger : MonoBehaviour{
    public GameObject victoryUI;
    public float delay;
    [SerializeField] private GameObject truckHUD;

    void Start(){
        victoryUI.SetActive(false);
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            truckHUD.SetActive(false);
            victoryUI.SetActive(true);
            StartCoroutine(Countdown());
        }
    }

    IEnumerator Countdown(){
        yield return new WaitForSeconds (delay);
        SceneManager.LoadScene(0);
    }
}