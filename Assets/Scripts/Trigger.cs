﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour {
    //general
    public bool hasActivated, newOrOld;

    //camera shift
    public bool cameraTrigger;
    public Transform cammy, player;
    public Vector3 camPosNew, camAngleNew, camPosOld, camAngleOld,
        newPlayerPos, oldPlayerPos;
    //could also have a public transform that the camera Transform.LookAt()

        
    //OTHER STUFF YOU DONT NEED
    //objects
    //public bool hasObjects;
    //public GameObject[] objects;
    //public GameObject[] objectsToTurnOff;

    ////animation
    //public bool hasAnimation;
    //public Animator[] myAnimators;
    //public string stateName;

    ////dialogue
    //public bool hasDialogue;
    //public DialogueText[] myDialogues;

    ////audio snap
    //public bool hasAudioSnap;
    //public AudioMixerSnapshot nextSnapshot;

    ////audio to play
    //public bool hasAudioToPlay;
    //public AudioSource[] sources;

    ////scene transition
    //public bool transitionScene;
    //public int sceneIndex;

    void Start()
    {
        cammy = Camera.main.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        newOrOld = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!hasActivated)
            {
                //set to new position when you first pass through
                if (newOrOld)
                {
                    if (cameraTrigger)
                    {
                        cammy.position = camPosNew;
                        cammy.localEulerAngles = camAngleNew;
                        player.position = newPlayerPos;
                    }
                }

                //return to old position when you walk back through
                else
                {
                    if (cameraTrigger)
                    {
                        cammy.position = camPosOld;
                        cammy.localEulerAngles = camAngleOld;
                        player.position = oldPlayerPos;
                    }
                    
                }

                newOrOld = !newOrOld;
                hasActivated = true;
                StartCoroutine(SetBackToUnactive());
            }
            
        }

        
    }

    //so we can activate this trigger multiple times
    IEnumerator SetBackToUnactive()
    {
        yield return new WaitForSeconds(0.1f);
        hasActivated = false;
    }
    // OTHER STUFF YOU DONT NEED 
    //    if (hasObjects)
    //                {
    //                    //if greater than 1
    //                    if (objects.Length > 1)
    //                    {
    //                        for (int i = 0; i<objects.Length; i++)
    //                        {
    //                            objects[i].SetActive(true);
    //}
    //                    }
    //                    else
    //                    {
    //                        objects[0].SetActive(true);
    //                    }

    //                    //turn em off!!!
    //                    if(objectsToTurnOff.Length > 1)
    //                    {
    //                        for (int i = 0; i<objectsToTurnOff.Length; i++)
    //                        {
    //                            objectsToTurnOff[i].SetActive(false);
    //                        }
    //                    }
    //                    else
    //                    {
    //                        objectsToTurnOff[0].SetActive(false);
    //                    }
    //                }

    ////dialogue trigger
    //if (hasDialogue)
    //{
    //    //if greater than 1
    //    if (myDialogues.Length > 1)
    //    {
    //        for (int i = 0; i < myDialogues.Length; i++)
    //        {
    //            myDialogues[i].EnableDialogue();
    //        }
    //    }
    //    else
    //    {
    //        myDialogues[0].EnableDialogue();
    //    }
    //}

    ////animation trigger
    //if (hasAnimation)
    //{
    //    //if greater than 1
    //    if (myAnimators.Length > 1)
    //    {
    //        for (int i = 0; i < myAnimators.Length; i++)
    //        {
    //            myAnimators[i].SetTrigger(stateName);
    //        }
    //    }
    //    else
    //    {
    //        myAnimators[0].SetTrigger(stateName);
    //    }
    //}

    ////audiomixersnap
    //if (hasAudioSnap)
    //{
    //    nextSnapshot.TransitionTo(3f);
    //}

    ////audio to play
    //if (hasAudioToPlay)
    //{
    //    if (sources.Length > 1)
    //    {
    //        for (int i = 0; i < sources.Length; i++)
    //        {
    //            sources[i].Play();
    //        }
    //    }
    //    else
    //    {
    //        sources[0].Play();
    //    }
    //}

    //if (transitionScene)
    //{
    //    SceneManager.LoadScene(sceneIndex);
    //}
}
