using Newtonsoft.Json;
using System.Net;

namespace PNRAnalysisSystem.Service
{
    public class ServiceHttp
    {
        public string Domain { get; set; }
        public string Route { get; set; }

        public dynamic HttpPost(List<KeyValuePair<string, string>> parameters, Dictionary<string, string> headerContent)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Domain);

                    var content = new FormUrlEncodedContent(parameters);

                    HttpResponseMessage res = client.PostAsync(Route, content).Result;

                    var resContent = res.Content.ReadAsStringAsync().Result;

                    dynamic obj = JsonConvert.DeserializeObject(resContent);

                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        return obj;
                    }
                }
            }
            catch (Exception e)
            {
                string errMsg = $"Fail- Exception :{e.Message}";
            }

            return null;
        }

        public dynamic HttpGet(KeyValuePair<string, string> param, Dictionary<string, string> headerContent)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Domain);

                    if(headerContent != null)
                    {
                        foreach (var item in headerContent)
                        {
                            client.DefaultRequestHeaders.Add(item.Key, item.Value);
                        }
                    }                  

                    HttpResponseMessage res = client.GetAsync(Route).Result;

                    var resContent = res.Content.ReadAsStringAsync().Result;

                    dynamic obj = JsonConvert.DeserializeObject(resContent);

                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        return obj;
                    }
                }
            }
            catch (Exception e)
            {
                string errMsg = $"Fail- Exception :{e.Message}";
            }


            return null;
        }
    }
}
