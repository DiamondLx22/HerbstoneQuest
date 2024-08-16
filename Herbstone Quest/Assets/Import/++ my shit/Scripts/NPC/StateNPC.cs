using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateNPC : MonoBehaviour
{
    public Animator anim;

    public void SitUp()
    {
        anim.SetBool("SitUp", true);
    }
    public void SitDown()
    {
        anim.SetBool("SitUp", false);
    }
    
    public void SetExited() 
    {
        anim.SetBool("Exited", true);
    }
    
    public void SetCalm()
    {
        anim.SetBool("Exited", false);
    }
}

