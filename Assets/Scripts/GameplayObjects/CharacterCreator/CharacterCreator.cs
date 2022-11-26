using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CharacterCreator : MonoBehaviour
{
    private string[] nicknames;
    private string[] prefixNames;

    private string nicknameFilePath;
    private string preftixNamesFilePath;

    void Awake()
    {
        nicknameFilePath = Application.dataPath + "/Scripts/GameplayObjects/CharacterCreator/CharacterNames.txt";
        preftixNamesFilePath = Application.dataPath + "/Scripts/GameplayObjects/CharacterCreator/CharacterNamesPrefixes.txt";

        nicknames = parseNameFile(nicknameFilePath);
        prefixNames = parseNameFile(preftixNamesFilePath);
    }

    public Character CreateCharacter() 
    {
        string newCharName = getRandomNickname();

        Character createdCharacter = new Character(newCharName);

        return createdCharacter;
    }

    private string getRandomNickname()
    {
        string nickname = "";

        nickname += prefixNames[Random.Range(0, prefixNames.Length)];
        nickname += " ";
        nickname += nicknames[Random.Range(0, nicknames.Length)];

        return nickname;
    }

    private string[] parseNameFile(string filePath) 
    {
        string text = File.ReadAllText(filePath);

        char separator = '\n';
        string[] strValues = text.Split(separator);
        for (int i = 0; i < strValues.Length; i++) 
        {
            strValues[i] = strValues[i].Remove(strValues[i].Length-1);
        }

        return strValues;
    }
}
