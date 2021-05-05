using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mainCam;

    public bool runOnce = true;

    public GameObject shockwave;

    public GameObject egoShip;

    public GameObject milano;

    public GameObject fleet1;

    public GameObject fleet2;

    public GameObject fleet3;

    public GameObject fleet4;

    public GameObject fleet5;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFleet());

    }

    void Update()
    {
        if(milano.transform.position.z < -640)
        {
            if(runOnce == true)
            {
                GameObject shockwaveObj = Instantiate(shockwave, egoShip.transform.position, egoShip.transform.rotation);
                Destroy(shockwaveObj.gameObject, 3);
                runOnce = false;
            }

        }

    }


    System.Collections.IEnumerator SpawnFleet()
    {
        yield return new WaitForSeconds(3.0f);
        fleet1.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        fleet2.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        fleet3.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        fleet4.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        fleet5.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        mainCam.GetComponent<CameraFollow>().enabled = true;

        

    }


}
