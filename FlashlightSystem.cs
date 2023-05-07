using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class FlashlightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 40f;

    Light myLight;

    private void Start()
    {
        myLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntesity();

    }

    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle = restoreAngle;
    }

    public void AddLightIntesity(float intenstyAmout)
    {
        myLight.intensity += intenstyAmout;
    }

    void DecreaseLightAngle()
    {
        if(myLight.spotAngle <= minimumAngle) return; // return bo osiadamy poziom minimum jaki zalozylismy
        else
        {
            myLight.spotAngle -= angleDecay * Time.deltaTime;  // -= bo redukujemy z czegos
        }
        
    }

    void DecreaseLightIntesity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
         
    }
}
