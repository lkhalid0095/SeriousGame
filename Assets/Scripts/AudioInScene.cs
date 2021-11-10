using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInScene : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audio;
 
    void Start ()
     {
       if(audio == null){
           audio = GetComponent<AudioSource> ();

         }
      audio.Play();
     }
}
