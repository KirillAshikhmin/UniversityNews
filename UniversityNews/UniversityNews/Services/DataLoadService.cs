using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UniversityNews.DataObjects;

namespace UniversityNews.Services
{
    class DataLoad
    {

        static DataLoad()
        {
            LoadData();
        }

        public static List<NewDataObject> News { get; set; } 
    

        private static ManualResetEvent allDone = new ManualResetEvent(false);

        private static void LoadData()
        {
            try
            {
                HttpWebRequest request =
                    (HttpWebRequest)
                        WebRequest.Create(@"http://192.168.1.2/api/News");

                request.ContentType = "application /json";

                request.Method = "Post";
                request.Accept = "*/*";
                request.BeginGetRequestStream(GetRequestStreamCallback, request);
                allDone.WaitOne();
                //Task.Delay(20000);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Ошибка: " + e.Message);
            }
        }

        private static void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest) asynchronousResult.AsyncState;
                request.Method = "Post";
                // End the operation
                Stream postStream = request.EndGetRequestStream(asynchronousResult);

                Debug.WriteLine(postStream.Length);

                // Start the asynchronous operation to get the response
                request.BeginGetResponse(GetResponseCallback, request);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ошибка " + ex.Message);
            }
        }


        private static void GetResponseCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
                Stream streamResponse = response.GetResponseStream();
                StreamReader streamRead = new StreamReader(streamResponse);

                News.AddRange(JsonConvert.DeserializeObject<List<NewDataObject>>(streamRead.ReadToEnd()));
                allDone.Set();
                response.Dispose();
                streamRead.Dispose();
                streamResponse.Dispose();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Ошибка  : " + e.Message);
            }
        }
    }
}
