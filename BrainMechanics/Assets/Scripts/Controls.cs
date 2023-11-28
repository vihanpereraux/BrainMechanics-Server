using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public GameObject lightRowOne;
    public GameObject lightRowTwo;
    public GameObject lightRowThree;
    public GameObject lightRowFour;
    
    List<GameObject> lightRowOneLights = new List<GameObject>();
    List<GameObject> lightRowTwoLights = new List<GameObject>();
    List<GameObject> lightRowThreeLights = new List<GameObject>();
    List<GameObject> lightRowFourLights = new List<GameObject>();

    private float rotationSpeed = .8f;
    private float rotationMagnitude = 10f;
    

    void Start(){
        for (int i = 0; i < 6; i++){
            lightRowOneLights.Add(lightRowOne.transform.GetChild(i).gameObject);
            lightRowTwoLights.Add(lightRowTwo.transform.GetChild(i).gameObject);
            lightRowThreeLights.Add(lightRowThree.transform.GetChild(i).gameObject);
            lightRowFourLights.Add(lightRowFour.transform.GetChild(i).gameObject);
        }
        StartCoroutine(RunFunc2SInterval());
    }

    void Update(){
        // float rotationAngle = (Mathf.Sin(Time.time * rotationSpeed) * rotationMagnitude) + 90;
        // float rotationAngleInverse = (Mathf.Sin(Time.time * rotationSpeed) * (rotationMagnitude * -1)) + 90;
        // for (int i = 0; i < lightRowOneLights.Count; i++){
        //     lightRowOneLights[i].transform.rotation = Quaternion.Euler(rotationAngle, -90f, -90f);
        //     lightRowTwoLights[i].transform.rotation = Quaternion.Euler(rotationAngleInverse, -90f, -90f);
        //     lightRowThreeLights[i].transform.rotation = Quaternion.Euler(rotationAngle, -90f, -90f);
        //     lightRowFourLights[i].transform.rotation = Quaternion.Euler(rotationAngle, -90f, -90f);
        // }
    }

    private IEnumerator RunFunc2SInterval(){
        while (true){
            ControlLightRowOne();
            yield return new WaitForSeconds(.16f);
        }
    }
    private void ControlLightRowOne(){
        int lowerValue = 0;
        int upperValue = 100;

        for (int i = 0; i < 6; i++){
            int randomValue = UnityEngine.Random.Range(lowerValue, upperValue);
            int roundedValue = Mathf.RoundToInt(randomValue);

            lightRowOneLights[i].GetComponent<Light>().intensity = roundedValue;
            lightRowTwoLights[i].GetComponent<Light>().intensity = roundedValue;
            lightRowThreeLights[i].GetComponent<Light>().intensity = roundedValue;
            lightRowFourLights[i].GetComponent<Light>().intensity = roundedValue;
        }
    }
}
