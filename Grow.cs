using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Grow : MonoBehaviour
{

    public GameObject GrowthStage1;
    public GameObject GrowthStage2;



    void Start()
    {
        StartCoroutine(GrowToStage2());
    }


    IEnumerator GrowToStage2()
    {
        yield return new WaitForSeconds(Settings.GrowthTime);

        Destroy(GrowthStage1);
        Instantiate(GrowthStage2, gameObject.transform.position, Quaternion.identity, this.transform);
        // GrowToStage3();
    }

    IEnumerator GrowToStage3()
    {
        yield return new WaitForSeconds(Settings.GrowthTime);
        
        Destroy(GrowthStage2);
        Instantiate(GrowthStage3, gameObject.transform.position, Quaternion.identity, this.transform);
    }

    
}
