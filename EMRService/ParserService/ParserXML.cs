using EMRCoreService.ApiJsonSchemaModel;
using Newtonsoft.Json;
//using Pather.CSharp;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace EMRService
{

    public class ParseXMLService
    {
        /// <summary>
        /// Read all files in sub folders one by one
        /// </summary>
        public static void ReadAll()
        {
            DirectoryInfo d = new DirectoryInfo(ConfgService.config.GetAppSettings(AppConstants.UploadPath));
            FileInfo[] Files = d.GetFiles("*.XML");
            foreach (FileInfo file in Files)
            {
                ReadXMLAndPostJsonToApi(file.Name);
            }
        }

        /// <summary>
        /// Three operations will take place
        /// 1.Read XML to Object
        /// 2.Move XML to Arceive
        /// 3.Post data to API
        /// </summary>
        /// <param name="fileName"></param>
        public static void ReadXMLAndPostJsonToApi(string fileName)
        {
            string filePath = ConfgService.config.GetAppSettings(AppConstants.UploadPath) + "\\" + fileName;

          
            var cda_DocumentObject = ReadXML<POCD_MT000040ClinicalDocument>(filePath);
           
            MoveXmlFileToArchieve(fileName);
          
            var _json = JsonConvert.SerializeObject(cda_DocumentObject);
          
       //     PostToApi(_json);
            //System.IO.File.WriteAllText(Outputfile, _json);

            //Console.WriteLine(GetPropertyVal(cda_DocumentObject, "author[0].assignedAuthor.addr[0].Items[1].Text[0]"));
        }
        /// <summary>
        /// Generic way to read XML and return T object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        private static T ReadXML<T>(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StreamReader reader = new StreamReader(path);
            
            T doc;
            using (reader)
            {
                doc = (T)serializer.Deserialize(reader);
                reader.Close();
            }
            return doc;
        }

        /// <summary>
        /// Posting data to Web Api through HttpClient
        /// </summary>
        /// <param name="parsedXMLToJsonString"></param>
        public static async void PostToApi(string parsedXMLToJsonString)
        {
            string URI = ConfgService.config.GetAppSettings(AppConstants.GoAPiUrl);


            using (var wc = new HttpClient())
            {
               // wc.Headers[HttpRequestHeader.ContentType] = "application/json";

                var data = new StringContent(GetCCDDetailsInString(parsedXMLToJsonString), Encoding.UTF8, "application/json");

                var response = await wc.PostAsync(URI, data);
                var s = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(s);
                
            }
        }
        /// <summary>
        /// WebApi Json Schema input field information
        /// </summary>
        /// <param name="parsedXMLToJsonString"></param>
        /// <returns></returns>
        private static string GetCCDDetailsInString(string parsedXMLToJsonString)
        {
            var d = new CCD();


            d.AffiliationID = "Test";
            d.ChartType = "Test";
            d.DocumentData = new Int32[1];
            d.DocumentData[0] = 0;
            d.DocumentName = "Test";
            d.FileType = "string";
            d.FormatReceivedFromVendor = "ccda-pdf";
            d.MedicalCodes =new Medicalcodes() {
                CodeType = "ICD10Dx",
                DateOfService= "12152019",
               Value= "E785"
             };
            d.MemberDOB = "10102010";
            d.MemberFirstName = "charlotteFN3";
            d.MemberKey = "123";
            d.MemberKeyType = "Medicare";
            d.MemberLastName = "charlotteLN3";
            d.NPI = "";
            d.OriginalFileName = "Test";
            d.ProviderFirstName = "Test";
            d.ProviderKey = "Test";
            d.ProviderLastName = "Test";
            d.ProviderMiddleName = "Test";
            d.TIN = "Test";
            d.TemporaryFileName = "Test";
            d.UUID = "Test";
            d.VendorKey = "123";
            d.VendorName = "charlotteVendor";


            return JsonConvert.SerializeObject(d);

        }
        /// <summary>
        /// Move XML file to Archieve folder after reading the document to Object
        /// </summary>
        /// <param name="fileName"></param>
        public static void MoveXmlFileToArchieve(string fileName)
        {
            //string fileName = "test.txt";
            string uploadPath = ConfgService.config.GetAppSettings(AppConstants.UploadPath);
            string archievePath = ConfgService.config.GetAppSettings(AppConstants.ArchievePath);

            string sourceFile = Path.Combine(uploadPath, fileName);
            string destFile = Path.Combine(archievePath, fileName + "_Archieve_" + DateTime.Now.ToFileTimeUtc() + ".xml");

            if (!Directory.Exists(archievePath))
            {
                Directory.CreateDirectory(archievePath);
            }

            File.Move(sourceFile, destFile);
        }
        /// <summary>
        /// Get Values based on Property name passed as  string
        /// </summary>
        /// <param name="src"></param>
        /// <param name="propName"></param>
        /// <returns></returns>
        //public static object GetPropertyVal(object src, string propName)
        //{
        //    var resolver = new Resolver();
        //    object result = resolver.Resolve(src, propName);
        //    return result;
        //}

    }
}