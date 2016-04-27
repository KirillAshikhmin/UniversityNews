using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Xml;
using UniversityNews.DataObjects;

namespace UniversityNews.Helpers
{
    public class NewsHelper
    {
        public static bool IsReadingXml { get; set; }
        public static List<NewDataObject> ItemList { get; set; }

        static NewsHelper()
        {
            LoadData();
        }
        //public static void BeginReadXmlStream(string currFileName)
        //{
        //    try
        //    {
        //        IsReadingXml = true;
        //        currFileName = "192.168.1.2/api/News/";
        //        HttpWebRequest httpRequest = (HttpWebRequest) WebRequest.Create(currFileName);
        //        httpRequest.BeginGetResponse(FinishWebRequest, httpRequest);
        //    }
        //    catch
        //    {
        //        //
        //    }
        //}
        private static void LoadData()
        {
            try
            {
                HttpWebRequest request =
                    (HttpWebRequest)
                        WebRequest.Create(@"http://192.168.1.2/api/News/");

                request.ContentType = "application/xml";

                request.Method = "POST";
                request.Accept = "*/*";
                request.BeginGetRequestStream(GetRequestStreamCallback, request);
                allDone.WaitOne();
            }
            catch (Exception e)
            {
                Debug.WriteLine("FirstMethod Exrption: " + e.Message);
            }
        }

        private static void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
            request.Method = "POST";
            // End the operation
            Stream postStream = request.EndGetRequestStream(asynchronousResult);


            // Start the asynchronous operation to get the response
            request.BeginGetResponse(GetResponseCallback, request);
        }
        private static ManualResetEvent allDone = new ManualResetEvent(false);

        private static void GetResponseCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
                Stream streamResponse = response.GetResponseStream();
                StreamReader streamRead = new StreamReader(streamResponse);

               

                allDone.Set();
                response.Dispose();
                streamRead.Dispose();
                streamResponse.Dispose();
            }
            catch (Exception e)
            {
                Debug.WriteLine("GetResponseCallback Exeption : " + e.Message);
            }
        }
        //private static void FinishWebRequest(IAsyncResult result)
        //{
        //    IsReadingXml = true;

        //    var httpWebRequest = result.AsyncState as HttpWebRequest;
        //    HttpWebResponse httpResponse = httpWebRequest?.EndGetResponse(result) as HttpWebResponse;
        //    if (httpResponse != null && httpResponse.StatusCode == HttpStatusCode.OK)
        //    {
        //        Stream httpResponseStream = httpResponse.GetResponseStream();
        //        BuildItemList(httpResponseStream);
        //    }
        //}

        public static void BuildItemList(Stream xmlStream)
        {
            List<NewDataObject> returnValue = new List<NewDataObject>();

            try
            {
                using (XmlReader myXmlReader = XmlReader.Create((xmlStream)))
                {
                    while (myXmlReader.Read())
                    {
                        if (myXmlReader.Name == "News")
                        {
                                returnValue.Add(new NewDataObject(
                                myXmlReader.GetAttribute("Title"),
                                myXmlReader.GetAttribute("ImageUrl"),
                                myXmlReader.GetAttribute("Details"),
                                DateTime.Parse(myXmlReader.GetAttribute("Date")),
                                int.Parse(myXmlReader.GetAttribute("NewType")),
                                myXmlReader.GetAttribute("Owner")
                                ));
                        }
                    }
                }
            }
            catch
            {
                // ignored
            }

            //Done
            ItemList = returnValue;
            IsReadingXml = false;
        }
    }
}