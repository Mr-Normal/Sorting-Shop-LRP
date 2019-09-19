using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationApply : MonoBehaviour
{
    public AnimationClip applyAnimation;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Chest")
        {
            AddAndPlayAnimation(other.gameObject);
        }
    }

    void AddAndPlayAnimation(GameObject go)
    {
        Animation animation = go.GetComponent<Animation>();
        animation.clip = applyAnimation;
        animation.AddClip(applyAnimation, applyAnimation.name);
        animation.Play();
    }
}
