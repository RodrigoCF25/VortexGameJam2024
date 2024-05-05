using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystemUI : MonoBehaviour
{
    [SerializeField] Sprite fullHeart;
    public CharacterHealth _playerHealth;
    [SerializeField] CharacterHealth _characterHealth;
    
    public GameObject[] hearts;


    void Start()
    {
        _characterHealth = GameObject.Find("Player").GetComponent<CharacterHealth>();
        CharacterHealth.OnHealthChangedEvent += UpdateHealthUI;
        _playerHealth = GameObject.Find("Player").GetComponent<CharacterHealth>();

        for(byte i = 0; i < hearts.Length; i++)
        {
            Image heartRenderer = hearts[i].GetComponent<Image>();
            heartRenderer.sprite = fullHeart;
        }
    }

    void UpdateHealthUI(byte currentHealth)
    {
        if(_characterHealth)
        {
            for(byte i = 0; i < hearts.Length; i++)
            {
                hearts[i].SetActive(i < currentHealth);
            }
        }
    }
}
