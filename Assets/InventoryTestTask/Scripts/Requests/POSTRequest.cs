using System.Collections;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

namespace Requests
{
    public class POSTRequest : MonoBehaviour
    {
        private HttpClient _httpClient;
        private string _url;
        private string _bearerToken;

        private void Awake()
        {
            _url = "https://wadahub.manerai.com/api/inventory/status";
            _bearerToken = "kPERnYcWAY46xaSy8CEzanosAgsWM84Nx7SKM4QBSqPq6c7StWfGxzhxPfDh8MaP";
            _httpClient = new HttpClient();
        }

        public void SendRequest(PostStruct postStruct)
        {
            string json = JsonUtility.ToJson(postStruct);
            Task<string> kdkd = PostDataWithBearerToken(_url, _bearerToken, json);
        }

        public async Task<string> PostDataWithBearerToken(string apiUrl, string bearerToken, string requestData)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);

            var content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(apiUrl, content);

            return await response.Content.ReadAsStringAsync();
        }
    }
}