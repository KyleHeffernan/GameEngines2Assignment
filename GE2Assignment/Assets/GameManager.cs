using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cameraEndPos;
    public GameObject mainCam;

    public bool runOnce = true;
    public bool videoEnd = false;

    public GameObject shockwave;

    public GameObject miniShockwave;

    public GameObject videoPlayer;

    public GameObject egoShip;

    public GameObject milano;

    public GameObject fleet1;

    public GameObject fleet2;

    public GameObject fleet3;

    public GameObject fleet4;

    public GameObject fleet5;

    public GameObject fleet6;

    public GameObject fleet7;



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

        if(milano.transform.position.z < -550)
        {
            mainCam.GetComponent<CameraFollow>().enabled = false;
            mainCam.transform.position = cameraEndPos.transform.position;
            mainCam.transform.rotation = cameraEndPos.transform.rotation;
        }

    }


    System.Collections.IEnumerator SpawnFleet()
    {
        
        yield return new WaitForSeconds(98.5f);
        AudioSource audio = this.GetComponent<AudioSource>();
        audio.Play();
        videoEnd = true;
        yield return new WaitForSeconds(1.0f);
        videoPlayer.SetActive(false);
        
        yield return new WaitForSeconds(5.0f);
        GameObject shockwaveObj1 = Instantiate(miniShockwave, fleet1.transform.position, fleet1.transform.rotation);
        Destroy(shockwaveObj1.gameObject, 3);
        fleet1.SetActive(true);

        yield return new WaitForSeconds(0.3f);
        GameObject shockwaveObj2 = Instantiate(miniShockwave, fleet2.transform.position, fleet2.transform.rotation);
        Destroy(shockwaveObj2.gameObject, 3);
        fleet2.SetActive(true);

        yield return new WaitForSeconds(0.3f);
        GameObject shockwaveObj3 = Instantiate(miniShockwave, fleet3.transform.position, fleet3.transform.rotation);
        Destroy(shockwaveObj3.gameObject, 3);
        fleet3.SetActive(true);

        yield return new WaitForSeconds(0.3f);
        GameObject shockwaveObj4 = Instantiate(miniShockwave, fleet4.transform.position, fleet4.transform.rotation);
        Destroy(shockwaveObj4.gameObject, 3);
        fleet4.SetActive(true);

        yield return new WaitForSeconds(0.3f);
        GameObject shockwaveObj5 = Instantiate(miniShockwave, fleet5.transform.position, fleet5.transform.rotation);
        Destroy(shockwaveObj5.gameObject, 3);
        fleet5.SetActive(true);

        yield return new WaitForSeconds(0.3f);
        GameObject shockwaveObj6 = Instantiate(miniShockwave, fleet6.transform.position, fleet6.transform.rotation);
        Destroy(shockwaveObj6.gameObject, 3);
        fleet6.SetActive(true);

        yield return new WaitForSeconds(0.3f);
        GameObject shockwaveObj7 = Instantiate(miniShockwave, fleet7.transform.position, fleet7.transform.rotation);
        Destroy(shockwaveObj7.gameObject, 3);
        fleet7.SetActive(true);

        yield return new WaitForSeconds(3.0f);
        mainCam.GetComponent<CameraFollow>().enabled = true;

        

    }


}
