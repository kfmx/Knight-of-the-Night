using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour {

    public AudioSource mushroomSource;

    // AudioSource audioSource;

    void Start() {
        mushroomSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log(col);
        mushroomSource.Play();
        
    }
}
