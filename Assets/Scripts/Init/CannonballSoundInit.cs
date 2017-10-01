using UnityEngine;

public class CannonballSoundInit : MonoBehaviour {
    private static string[] soundNames = new string[] { "Cannon1", "Cannon2", "Cannon3", "Cannon4", "Cannon5" };

	void Start ()
    {
        AudioSource audio = this.GetComponent<AudioSource>();
        string name = GetRandomSoundFile();
        audio.PlayOneShot(Resources.Load<AudioClip>("Sounds/" + name));
    }

    private static string GetRandomSoundFile()
    {
        return soundNames[(int)Mathf.Min(soundNames.Length - 1, Mathf.Floor(Random.Range(0, soundNames.Length)))];
    }
}
