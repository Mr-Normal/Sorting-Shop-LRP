using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationApply : MonoBehaviour
{
    public AnimationClip applyAnimation;

    public void AddAndPlayAnimation(GameObject go)
    {
        Animation animation = go.GetComponent<Animation>();
        animation.clip = applyAnimation;
        animation.AddClip(applyAnimation, applyAnimation.name);
        animation.Play();
    }
}
