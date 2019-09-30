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
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Chest")
        {
            AddAndPlayAnimation(other.gameObject);
        }
    }
}
