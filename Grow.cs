using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Grow : MonoBehaviour
{

    public GameObject GrowthStage1;
    public GameObject GrowthStage2;



    void Start()
    {
        StartCoroutine(StartGrowing());
    }


    IEnumerator StartGrowing()
    {
        yield return new WaitForSeconds(5);
        Destroy(GrowthStage1);
        Instantiate(GrowthStage2, gameObject.transform.position, Quaternion.identity, this.transform);
    }

    
}
