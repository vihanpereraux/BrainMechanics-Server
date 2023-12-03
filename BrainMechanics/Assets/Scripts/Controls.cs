using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;


public class Controls : MonoBehaviour
{
    // light controlls
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

    public GameObject testPointLight_1;
    public GameObject testPointLight_2;
    public GameObject testPointLight_3;
    public GameObject testPointLight_4;


    // fog controlls
    // public Color fogColor = Color.gray;
    // public float fogDensity = 0.015f;
    

    void Start(){
        // fetching all light game objects
        for (int i = 0; i < 6; i++){
            lightRowOneLights.Add(lightRowOne.transform.GetChild(i).gameObject);
            lightRowTwoLights.Add(lightRowTwo.transform.GetChild(i).gameObject);
            lightRowThreeLights.Add(lightRowThree.transform.GetChild(i).gameObject);
            lightRowFourLights.Add(lightRowFour.transform.GetChild(i).gameObject);
        }

        StartCoroutine(RunFunc2SInterval());
        RenderSettings.fogMode = FogMode.ExponentialSquared;
        StartCoroutine(RunFogControlFunc());
    }

    void Update(){
    }

    private IEnumerator RunFunc2SInterval(){
        while (true){
            ControlLights();
            yield return new WaitForSeconds(.16f);
        }
    }
    private IEnumerator RunFogControlFunc(){
        while (true){
            ControlFog();
            yield return new WaitForSeconds(.1f);
        }
    }

    private void ControlLights(){
        float testLightStarterPosition = -13f;
        int lowerIndex = 0;
        int upperIndex = 6;
        int randomIndex = UnityEngine.Random.Range(lowerIndex, upperIndex);

        // setting intensity for 0
        for (int i = 0; i < 6; i++){
            lightRowOneLights[i].GetComponent<Light>().intensity = 0;
            lightRowTwoLights[i].GetComponent<Light>().intensity = 0;
            lightRowThreeLights[i].GetComponent<Light>().intensity = 0;
            lightRowFourLights[i].GetComponent<Light>().intensity = 0;
        }        
        testPointLight_1.GetComponent<Light>().intensity = 0f;
        testPointLight_2.GetComponent<Light>().intensity = 0f;
        testPointLight_3.GetComponent<Light>().intensity = 0f;
        testPointLight_4.GetComponent<Light>().intensity = 0f;

        lightRowOneLights[randomIndex].GetComponent<Light>().intensity = 100;
        lightRowTwoLights[randomIndex].GetComponent<Light>().intensity = 100;
        lightRowThreeLights[randomIndex].GetComponent<Light>().intensity = 100;
        lightRowFourLights[randomIndex].GetComponent<Light>().intensity = 100;

        switch (randomIndex){
            case 0:
                getLightSettings(testLightStarterPosition, randomIndex);
            break;
            case 1:
                getLightSettings(testLightStarterPosition, randomIndex);
            break;
            case 2:
                getLightSettings(testLightStarterPosition, randomIndex);
            break;
            case 3:
                getLightSettings(testLightStarterPosition, randomIndex);
            break;
            case 4:
                getLightSettings(testLightStarterPosition, randomIndex);
            break;
            case 5:
                getLightSettings(testLightStarterPosition, randomIndex);
            break;
        }
        Debug.Log(randomIndex);
    }
    private void getLightSettings(float testLightStarterPosition, int randomIndex){
        testPointLight_1.transform.position = new Vector3(testLightStarterPosition + (5 * randomIndex), 3, 3);
        testPointLight_2.transform.position = new Vector3(testLightStarterPosition + (5 * randomIndex), 3, 7);
        testPointLight_3.transform.position = new Vector3(testLightStarterPosition + (5 * randomIndex), 3, 11);
        testPointLight_4.transform.position = new Vector3(testLightStarterPosition + (5 * randomIndex), 3, 15);
        testPointLight_1.GetComponent<Light>().intensity = 6.5f;
        testPointLight_2.GetComponent<Light>().intensity = 6.5f;
        testPointLight_3.GetComponent<Light>().intensity = 6.5f;
        testPointLight_4.GetComponent<Light>().intensity = 6.5f;
    }

    private void ControlFog(){
        RenderSettings.fogDensity = UnityEngine.Random.Range(0.0f, 0.035f);
    }
}
