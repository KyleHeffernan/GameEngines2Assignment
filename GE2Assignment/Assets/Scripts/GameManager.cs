using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Audio Clips
    public AudioSource songClip;

    public AudioSource voiceClip;

    public AudioSource voiceClip2;

    public AudioSource voiceClip3;

    //Booleans used to make sure certain items are only run once
    private bool runOnce = true;
    private bool runOnce1 = true;
    private bool runOnce2 = true;
    private bool runOnce3 = true;
    private bool runOnce4 = true;

    //Camera objects and videoplayer objects
    public GameObject cameraEndPos;
    public GameObject mainCam;
    public GameObject moveCam;
    public GameObject videoPlayer;
    public GameObject videoPlayer2;
    public GameObject rawimage1;
    public GameObject rawimage2;

    //Ship objects
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
    public GameObject sentrySquad1;

    //Positions and objects for effects
    public Transform egoShot1;
    public Transform egoShot2;
    public Transform egoShot3;
    public Transform egoShot4;
    public Transform egoShot5;
    public Transform egoShot6;
    public GameObject shockwave;
    public GameObject miniShockwave;
    public GameObject egoShot;



    // Start is called before the first frame update
    void Start()
    {
        //Starts coroutine handling starting cutscene
        StartCoroutine(StartScene());
    }

    void Update()
    {
        //Once the milano starts moving, the camera lerps from the roof to the front
        if(milano.transform.position.z < 795 && milano.transform.position.z > 450)
        {
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, moveCam.transform.position, Time.deltaTime * 0.1f);
            mainCam.transform.rotation = Quaternion.Lerp(mainCam.transform.rotation, moveCam.transform.rotation, Time.deltaTime * 0.1f);
        }
        
        //Once the milano gets to this position, run the coroutine to spawn the fleet of ships in
        if(milano.transform.position.z < 600)
        {
            if(runOnce1 == true)
            {
                StartCoroutine(StartAction());
                runOnce1 = false;
            }
        }

        //Once the milano gets to this position, play voiceclip1
        if(milano.transform.position.z < 560)
        {
            if(runOnce2 == true)
            {
                
                voiceClip.Play();
                runOnce2 = false;
            }
        }

        //Once the milano gets to this position, play voiceclip2
        if(milano.transform.position.z < 260)
        {
            if(runOnce3 == true)
            {
                
                voiceClip2.Play();
                runOnce3 = false;
            }
        }

        //Once the milano gets to this postion, the sentry spawning coroutine is started, voiceclip3 is played and the camera is moved
        if(milano.transform.position.z < -400)
        {
            if(runOnce4 == true)
            {
                StartCoroutine(SpawnSentries());
                
                voiceClip3.Play();
                runOnce4 = false;
            }
            mainCam.GetComponent<CameraFollow>().enabled = false;
            mainCam.transform.position = cameraEndPos.transform.position;
            mainCam.transform.rotation = cameraEndPos.transform.rotation;
        }

        //Once the milano gets to this position, Egos ship unleashes a torrent of effects and the endscene coroutine is started
        if(milano.transform.position.z < -640)
        {
            if(runOnce == true)
            {
                GameObject shockwaveObj = Instantiate(shockwave, egoShip.transform.position, egoShip.transform.rotation);
                Destroy(shockwaveObj.gameObject, 3);

                GameObject egoShotEffect1 = Instantiate(egoShot, egoShot1.transform.position, egoShot1.transform.rotation);
                Destroy(egoShotEffect1.gameObject, 3);
                GameObject egoShotEffect2 = Instantiate(egoShot, egoShot2.transform.position, egoShot2.transform.rotation);
                Destroy(egoShotEffect2.gameObject, 3);
                GameObject egoShotEffect3 = Instantiate(egoShot, egoShot3.transform.position, egoShot3.transform.rotation);
                Destroy(egoShotEffect3.gameObject, 3);
                GameObject egoShotEffect4 = Instantiate(egoShot, egoShot4.transform.position, egoShot4.transform.rotation);
                Destroy(egoShotEffect4.gameObject, 3);
                GameObject egoShotEffect5 = Instantiate(egoShot, egoShot5.transform.position, egoShot5.transform.rotation);
                Destroy(egoShotEffect5.gameObject, 3);
                GameObject egoShotEffect6 = Instantiate(egoShot, egoShot6.transform.position, egoShot6.transform.rotation);
                Destroy(egoShotEffect6.gameObject, 3);


                StartCoroutine(EndScene());
                runOnce = false;
            }

        }

    }


    System.Collections.IEnumerator StartScene()
    {
        //Once the clip ends, the audio clip starts and carries the song on
        yield return new WaitForSeconds(98.5f);
        songClip.Play();
        //Video player turns off once cutscene ends
        yield return new WaitForSeconds(0.5f);
        videoPlayer.SetActive(false);


    }

    System.Collections.IEnumerator StartAction()
    {
        //Spawning the fleets of the drones in with a shockwave effect
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
        
        //After the ships have all spawned and some time has passed, switch the camera to use the following script
        yield return new WaitForSeconds(15.5f);
        mainCam.transform.parent = null;
        mainCam.GetComponent<CameraFollow>().enabled = true;


    }

    System.Collections.IEnumerator SpawnSentries()
    {
        //Spawns the fleet of sentries with a shockwave and stops the music
        yield return new WaitForSeconds(1.0f);
        GameObject shockwaveObj10 = Instantiate(miniShockwave, sentrySquad1.transform.position, sentrySquad1.transform.rotation);
        Destroy(shockwaveObj10.gameObject, 3);
        sentrySquad1.SetActive(true);
        songClip.Stop();
    }

    System.Collections.IEnumerator EndScene()
    {
        //Once the unity scene ends play the ending cutscene
        yield return new WaitForSeconds(1.85f);
        rawimage1.SetActive(false);
        videoPlayer2.SetActive(true);
        videoPlayer.SetActive(true);
        
        yield return new WaitForSeconds(0.1f);
        rawimage2.SetActive(true);

    }


}
