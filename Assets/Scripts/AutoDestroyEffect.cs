using UnityEngine;

public class AutoDestroyEffect : MonoBehaviour
{
    ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!particle.isPlaying) Destroy(this.gameObject);
    }
}
