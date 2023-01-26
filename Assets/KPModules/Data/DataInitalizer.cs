using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace KPModules.Data
{
    public class DataInitalizer<T> where T : Data
    {
        private string key;
        private string fileName;
        private string dataPath;
        private T data;
        public T Data { get { return data; } }

        public DataInitalizer(string encryptKey, string fileName)
        {
            this.key = encryptKey;
            this.fileName = fileName;
            dataPath = System.IO.Path.Combine(Application.persistentDataPath, fileName);
        }

        public void LoadData()
        {
            if (File.Exists(dataPath))
            {
                try
                {
                    string dataString = File.ReadAllText(dataPath);
                    string decrypted = XOROperator(dataString, key);
                    data = JsonUtility.FromJson<T>(decrypted);
                }
                catch (System.Exception e)
                {
                    Debug.Log(e.Message);
                    ResetData();
                }
            }
            else
                ResetData();
        }

        public void SaveData()
        {
            string origin = JsonUtility.ToJson(data);
            string encrypted = XOROperator(origin, key);
            File.WriteAllText(dataPath, encrypted);
        }

        public void ResetData()
        {
            data.Reset();
        }

        private static string XOROperator(string input, string key)
        {
            char[] output = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
                output[i] = (char)(input[i] ^ key[i % key.Length]);

            return new string(output);
        }
    }
}
