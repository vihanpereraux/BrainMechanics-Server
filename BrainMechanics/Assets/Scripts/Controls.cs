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

    public GameObject testPointLight;

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
        RenderSettings.fogMode = FogMode.Exponential;
        StartCoroutine(RunFogControlFunc());
    }

    void Update(){
    }

    private IEnumerator RunFunc2SInterval(){
        while (true){
            ControlLightRowOne();
            yield return new WaitForSeconds(.16f);
        }
    }
    private IEnumerator RunFogControlFunc(){
        while (true){
            ControlFog();
            yield return new WaitForSeconds(.1f);
        }
    }

    private void ControlLightRowOne(){
        float testLightStarterPosition = -13f;
        int lowerIndex = 0;
        int upperIndex = 6;
        int randomIndex = UnityEngine.Random.Range(lowerIndex, upperIndex);

        // setting intensity for 0
        for (int i = 0; i < lightRowOneLights.Count; i++){
            lightRowOneLights[i].GetComponent<Light>().intensity = 0;
        }        

        lightRowOneLights[randomIndex].GetComponent<Light>().intensity = 100;
        switch (randomIndex){
            case 0:
                testPointLight.transform.position = new Vector3(testLightStarterPosition + (5 * randomIndex), 3, 0);
            break;
            case 1:
                testPointLight.transform.position = new Vector3(testLightStarterPosition + (5 * randomIndex), 3, 0);
            break;
            case 2:
                testPointLight.transform.position = new Vector3(testLightStarterPosition + (5 * randomIndex), 3, 0);
            break;
            case 3:
                testPointLight.transform.position = new Vector3(testLightStarterPosition + (5 * randomIndex), 3, 0);
            break;
            case 4:
                testPointLight.transform.position = new Vector3(testLightStarterPosition + (5 * randomIndex), 3, 0);
            break;
            case 5:
                testPointLight.transform.position = new Vector3(testLightStarterPosition + (5 * randomIndex), 3, 0);
            break;
        }
        Debug.Log(randomIndex);
    }

    private void ControlFog(){
        RenderSettings.fogDensity = UnityEngine.Random.Range(0.0f, 0.015f);
    }
}
