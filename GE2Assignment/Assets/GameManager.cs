using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mainCam;

    public GameObject fleet1;

    public GameObject fleet2;

    public GameObject fleet3;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFleet());

    }

    System.Collections.IEnumerator SpawnFleet()
    {
        yield return new WaitForSeconds(3.0f);
        fleet1.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        fleet2.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        fleet3.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        mainCam.GetComponent<CameraFollow>().enabled = true;

        

    }


}
