using BeatThat.Service;
using UnityEngine;

public class Bug : MonoBehaviour
{
    public GameObject m_notPassing;
    public GameObject m_passing;

    // Start is called before the first frame update
    void Start()
    {
        m_passing.SetActive(false);
        m_notPassing.SetActive(true);
        Services.Init(() =>
        {
            m_passing.SetActive(true);
            m_notPassing.SetActive(false);
        });
    }

}
