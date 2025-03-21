using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Requests
{
    public class POSTRequest : MonoBehaviour
    {
        private string _url;
        private string _bearerToken;

        private void Awake()
        {
            _url = "https://wadahub.manerai.com/api/inventory/status";
            _bearerToken = "kPERnYcWAY46xaSy8CEzanosAgsWM84Nx7SKM4QBSqPq6c7StWfGxzhxPfDh8MaP";
        }

        public void SendRequest(PostStruct postStruct)
        {
            string jsonString = JsonUtility.ToJson(postStruct);
            StartCoroutine(SendPostRequestWithAuthentication(_url, jsonString, _bearerToken));
        }

        private IEnumerator SendPostRequestWithAuthentication(string url, string jsonData, string authToken)
        {
            using (UnityWebRequest request = UnityWebRequest.PostWwwForm(url, jsonData))
            {
                byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.SetRequestHeader("Authorization", authToken);
                request.SetRequestHeader("Content-Type", "application/json");
                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError(request.error);
                }
                else
                {
                    Debug.Log("POST request successful: " + request.downloadHandler.text);
                }
            }
        }        
    }
}