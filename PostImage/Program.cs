using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PostImage
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create a request using a URL that can receive a post.   
            WebRequest request = WebRequest.Create("http://localhost:8000/ImageAl");
            request.Credentials = CredentialCache.DefaultCredentials;
            // Set the Method property of the request to POST.  
            request.Method = "POST";

            // Create POST data and convert it to a byte array.  
            string fristData = "imageStr=";
            string file =  @"C:\Users\Salih\Desktop\sa.png";
            string postData = fristData + Convert.ToBase64String(File.ReadAllBytes(file));
            //Console.WriteLine(postData);
    

            byte[] byteArray = Encoding.ASCII.GetBytes(postData);


          
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

             
            WebResponse response = request.GetResponse();//419 hatası veriyor 
            using (dataStream = response.GetResponseStream())
            {
               
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                //Console.WriteLine(responseFromServer);
            }

           
            response.Close();
            //Console.ReadKey();



        }

    }

}

