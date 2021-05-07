using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource songClip;

    public AudioSource voiceClip;

    public AudioSource voiceClip2;

    private bool runOnce = true;
    private bool runOnce1 = true;
    private bool runOnce2 = true;
    private bool runOnce3 = true;


    public GameObject cameraEndPos;
    public GameObject mainCam;
    public GameObject moveCam;
    public GameObject videoPlayer;
    public GameObject videoPlayer2;
    public GameObject rawimage1;
    public GameObject rawimage2;


    public GameObject egoShip;
    public GameObject milano;
    public GameObject fleet1;
    public GameObject fleet2;
    public GameObject fleet3;
    public GameObject fleet4;
    public GameObject fleet5;
    public GameObject fleet6;
    public GameObject fleet7;
    public GameObject fleet8;
    public GameObject fleet9;


    public GameObject shockwave;
    public GameObject miniShockwave;



    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(StartScene());

    }

    void Update()
    {
        if(milano.transform.position.z < 795 && milano.transform.position.z > 450)
        {
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, moveCam.transform.position, Time.deltaTime * 0.1f);
            mainCam.transform.rotation = Quaternion.Lerp(mainCam.transform.rotation, moveCam.transform.rotation, Time.deltaTime * 0.1f);
        }
        

        if(milano.transform.position.z < 600)
        {
            if(runOnce1 == true)
            {
                StartCoroutine(StartAction());
                runOnce1 = false;
            }
        }

        if(milano.transform.position.z < 560)
        {
            if(runOnce2 == true)
            {
                
                voiceClip.Play();
                runOnce2 = false;
            }
        }

        if(milano.transform.position.z < 260)
        {
            if(runOnce3 == true)
            {
                
                voiceClip2.Play();
                runOnce3 = false;
            }
        }

        if(milano.transform.position.z < -550)
        {
            mainCam.GetComponent<CameraFollow>().enabled = false;
            mainCam.transform.position = cameraEndPos.transform.position;
            mainCam.transform.rotation = cameraEndPos.transform.rotation;
        }

        if(milano.transform.position.z < -640)
        {
            if(runOnce == true)
            {
                GameObject shockwaveObj = Instantiate(shockwave, egoShip.transform.position, egoShip.transform.rotation);
                Destroy(shockwaveObj.gameObject, 3);
                StartCoroutine(EndScene());
                runOnce = false;
            }

        }

    }


    System.Collections.IEnumerator StartScene()
    {
        
        yield return new WaitForSeconds(98.5f);
        songClip.Play();
        
        yield return new WaitForSeconds(0.5f);
        videoPlayer.SetActive(false);


    }

    System.Collections.IEnumerator StartAction()
    {

        
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

        yield return new WaitForSeconds(0.2f);
        GameObject shockwaveObj4 = Instantiate(miniShockwave, fleet4.transform.position, fleet4.transform.rotation);
        Destroy(shockwaveObj4.gameObject, 3);
        fleet4.SetActive(true);

        yield return new WaitForSeconds(0.2f);
        GameObject shockwaveObj5 = Instantiate(miniShockwave, fleet5.transform.position, fleet5.transform.rotation);
        Destroy(shockwaveObj5.gameObject, 3);
        fleet5.SetActive(true);

        yield return new WaitForSeconds(0.2f);
        GameObject shockwaveObj6 = Instantiate(miniShockwave, fleet6.transform.position, fleet6.transform.rotation);
        Destroy(shockwaveObj6.gameObject, 3);
        fleet6.SetActive(true);

        yield return new WaitForSeconds(0.2f);
        GameObject shockwaveObj7 = Instantiate(miniShockwave, fleet7.transform.position, fleet7.transform.rotation);
        Destroy(shockwaveObj7.gameObject, 3);
        fleet7.SetActive(true);

        yield return new WaitForSeconds(0.2f);
        GameObject shockwaveObj8 = Instantiate(miniShockwave, fleet8.transform.position, fleet8.transform.rotation);
        Destroy(shockwaveObj8.gameObject, 3);
        fleet8.SetActive(true);

        yield return new WaitForSeconds(0.2f);
        GameObject shockwaveObj9 = Instantiate(miniShockwave, fleet9.transform.position, fleet9.transform.rotation);
        Destroy(shockwaveObj9.gameObject, 3);
        fleet9.SetActive(true);
        

        yield return new WaitForSeconds(15.5f);
        mainCam.transform.parent = null;
        mainCam.GetComponent<CameraFollow>().enabled = true;


    }

    System.Collections.IEnumerator EndScene()
    {
        
        yield return new WaitForSeconds(0.8f);
        AudioSource audio = this.GetComponent<AudioSource>();
        audio.Stop();
        rawimage1.SetActive(false);
        videoPlayer2.SetActive(true);
        videoPlayer.SetActive(true);
        
        yield return new WaitForSeconds(0.1f);
        rawimage2.SetActive(true);

    }


}
