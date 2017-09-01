﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalSOundCOntroller : MonoBehaviour {

    public AudioSource intro;
    private bool introState;
    public AudioSource mainBGM;
    public Image black;
    public Animator anim;

    // Use this for initialization
    void Start()
    {
        introState = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!intro.isPlaying && introState)
        {
            mainBGM.Play();
            introState = false;
        }

        if (!mainBGM.isPlaying && !introState)
        {
            SceneManager.LoadScene("Title_Menu");
        }

    }
}
