using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemaforosControl : MonoBehaviour
{
    [SerializeField] private GameObject GreenLights1;
    [SerializeField] private GameObject GreenLights2;
    [SerializeField] private GameObject YellowLights1;
    [SerializeField] private GameObject YellowLights2;
    [SerializeField] private GameObject RedLights1;
    [SerializeField] private GameObject RedLights2;
    [SerializeField] private GameObject SemaforosTriggers1;
    [SerializeField] private GameObject SemaforosTriggers2;
    [SerializeField] private float semaforo_counter = 0;
    [SerializeField] private float semaforo_counter_stage1 = 15;
    [SerializeField] private float semaforo_counter_stage2 = 18;
    [SerializeField] private float semaforo_counter_stage3 = 33;
    [SerializeField] private float semaforo_counter_stage4 = 36;

    private IEnumerator EsperaSegundos(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    public void Semaforo_Pt1()
    {
        YellowLights1.SetActive(false);
        RedLights1.SetActive(true);
        SemaforosTriggers1.SetActive(true);
        RedLights2.SetActive(false);
        GreenLights2.SetActive(true);
        SemaforosTriggers2.SetActive(false);
    }

    public void Semaforo_Pt2()
    {
        GreenLights2.SetActive(false);
        YellowLights2.SetActive(true);
    }

    public void Semaforo_Pt3()
    {
        YellowLights2.SetActive(false);
        RedLights2.SetActive(true);
        SemaforosTriggers2.SetActive(true);
        RedLights1.SetActive(false);
        GreenLights1.SetActive(true);
        SemaforosTriggers1.SetActive(false);
    }

    public void Semaforo_Pt4()
    {
        GreenLights1.SetActive(false);
        YellowLights1.SetActive(true);
    }

    public void Start()
    {
        RedLights1.SetActive(false);
        RedLights2.SetActive(false);
        GreenLights1.SetActive(false);
        GreenLights2.SetActive(false);
        YellowLights1.SetActive(false);
        YellowLights2.SetActive(false);
        SemaforosTriggers1.SetActive(false);
        SemaforosTriggers2.SetActive(false);
    }

    public void Update()
    {
        semaforo_counter += 1 * Time.deltaTime;
        if (semaforo_counter <= semaforo_counter_stage1)
        {
            Semaforo_Pt1();
        }
        else if (semaforo_counter_stage1 < semaforo_counter && semaforo_counter <= semaforo_counter_stage2)
        {
            Semaforo_Pt2();
        }
        else if (semaforo_counter_stage2 < semaforo_counter && semaforo_counter <= semaforo_counter_stage3)
        {
            Semaforo_Pt3();
        }
        else if (semaforo_counter_stage3 < semaforo_counter && semaforo_counter <= semaforo_counter_stage4)
        {
            Semaforo_Pt4();
        }
        else if (semaforo_counter > semaforo_counter_stage4)
        {
            semaforo_counter = 0;
        }
    }
}