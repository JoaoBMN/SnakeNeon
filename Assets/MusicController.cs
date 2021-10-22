using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicController : MonoBehaviour
{

    AudioSource audioSource;
    public Slider slider;
    public GameObject textObject;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void UpdateVolume()
    {
        audioSource.volume = slider.value;

        int volume = (int)Mathf.Round(100*slider.value);

        textObject.GetComponent<TMP_Text>().text = volume.ToString();


    }
    

}