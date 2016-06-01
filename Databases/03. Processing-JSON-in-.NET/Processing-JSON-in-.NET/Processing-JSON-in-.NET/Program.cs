using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.IO;

namespace Processing_JSON_in_.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            var webClient = new WebClient();
            var url = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
            var data = webClient.DownloadData(url);
            var contentAsXML = Encoding.UTF8.GetString(data);

            var doc = new XmlDocument();
            doc.LoadXml(contentAsXML);
            var contentAsJson = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
            var jObj = JObject.Parse(contentAsJson);

            var videos = jObj["feed"]["entry"]
                .Select(entry => JsonConvert.DeserializeObject<Video>(entry.ToString())).ToList();

            foreach (var video in videos)
            {
                Console.WriteLine(video.Title);
            }

            var linksToVideos = jObj["feed"]["entry"]
                                .Select(entry => entry["link"])
                                .Select(link => JsonConvert.DeserializeObject<Link>(link.ToString()))
                                .ToList();

            StringBuilder builder = new StringBuilder();
            var htmlStartLines = "<!DOCTYPE html><html></head><body>";
            var htmlEndLine = "</html>";
            builder.AppendLine(htmlStartLines);

            for (int i = 0, len = videos.Count; i < len; i++)
            {
                var currentVideo = videos[i];
                //var currentLink = linksToVideos[i];
                //builder.AppendFormat("<div><a href='{0}'><h2>{1}</h2></a><hr><iframe width='920' height='680' src='http://www.youtube.com/embed/{2}?enablejsapi=1&amp;version=3'  enablejsapi='1' allowfullscreen =''></iframe></div>",
                //        currentLink.Path, currentVideo.Title, currentVideo.Id);
                builder.AppendFormat("<iframe width='920' height='680' src='https://www.youtube.com/embed/{0}'></iframe><hr>",
                    currentVideo.Id);
            }

            builder.AppendLine(htmlEndLine);
            var resultHTML = builder.ToString();

            var pathToHTML = "../../index.html";
            using (StreamWriter writer = new StreamWriter(pathToHTML, false))
            {
                writer.WriteLine(resultHTML);
            }

            Console.WriteLine("====================");
            Console.WriteLine("File is ready!");
            Console.WriteLine("====================");
        }
    }
}
