﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RobotFadeIn : MonoBehaviour
{
    Material[] mats;
    public float fadeSpeed = 0.1f;
    float lerpAmount;
    Renderer[] r;

    void Start()
    {
        r = GetComponentsInChildren<Renderer>();
        mats = new Material[r.Length];
        for (int i = 0; i < r.Length; i++)
        {
            mats[i] = r[i].material;
        }

        StartCoroutine("FadeIn", mats);
    }

    public void BeginFadeout()
    {
        StartCoroutine("FadeOut", mats);
    }

    //makes robot turn from transparent to opaque
    IEnumerator FadeIn(Material[] materialsToFadeIn)
    {
        lerpAmount = 0;

        while (lerpAmount < 1)
        {
            for (int i = 1; i < materialsToFadeIn.Length; i++)
            {
                Color c = materialsToFadeIn[i].color;
                c.a = Mathf.Lerp(0, 1, lerpAmount);
                materialsToFadeIn[i].color = c;
                lerpAmount += fadeSpeed;
            }
            yield return null;
        }

        if (lerpAmount >= 1) {
            GetComponent<ShootLaser>().SetHasFinishedSpawning(true);
        }
    }


    //makes robot turn from opaque to transparent
    IEnumerator FadeOut(Material[] materialsToFadeOut)
    {
        lerpAmount = 0;

        while (lerpAmount < 1)
        {
            for (int i = 1; i < materialsToFadeOut.Length; i++)
            {
                Color c = materialsToFadeOut[i].color;
                c.a = Mathf.InverseLerp(1, 0, lerpAmount);
                materialsToFadeOut[i].color = c;
                lerpAmount += fadeSpeed;
            }
            yield return null;
        }

        if (lerpAmount >= 1)
        {
            GetComponent<LaserCollision>().LaserDodged();
        }
    }
}

