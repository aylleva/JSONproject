using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace jsontask1
{
  
    internal class Program
    {
        public static string Pathname;
       
      


        static void Main(string[] args)
        {

            Pathname = Path.GetFullPath(Path.Combine("..", "..", "..", "Files", "names.json"));


            List<string> Names = new List<string> { "Samurai", "Ayla", "Nurane", "Kubra", "Mehin" };

            //Addname("Nezrin");
            //Addname("Zerife");
            //Console.WriteLine(Search("Nezrin", n => n == "FalseMan"));

            Delete(4);


            string result = JsonConvert.SerializeObject(Names);

            using (StreamWriter sw = new StreamWriter(Pathname, true))
            {
                sw.WriteLine(result);
            }




        }
     


        static void Addname(string name)
        {

            List<string> names = new List<string>();
            string result;
            using (StreamReader sr = new StreamReader(Pathname))
            {
                result = sr.ReadToEnd();
            }

            names = JsonConvert.DeserializeObject<List<string>>(result);

            names = JsonConvert.DeserializeObject<List<string>>(result);

            names.Add(name);

            string result2 = JsonConvert.SerializeObject(names);

            using (StreamWriter sw = new StreamWriter(Pathname))
            {
                sw.Write(result2);
            }

        }

        static bool Search(string name,Predicate<string> func)
        {
            List<string>names=new List<string>();
            string result;
            using(StreamReader sr=new StreamReader(Pathname))
            {
                result=sr.ReadToEnd();
            }

           names=JsonConvert.DeserializeObject<List<string>>(result);

         for(int i=0;i<names.Count; i++)
            {
                if (func(names[i]))
                {
                    return true;
                }
            }
            return false;

        }

        static void Delete(int index)
        {
            List<string> names = new List<string>();
            string result;
            using (StreamReader sr = new StreamReader(Pathname))
            {
                result = sr.ReadToEnd();
            }

            names = JsonConvert.DeserializeObject<List<string>>(result);

            for(int i = 0; i < names.Count; i++)
            {
                if (i == index)
                {
                    names.Remove(names[i]);
                }
            }
          

           string result2 = JsonConvert.SerializeObject(names);
            using(StreamWriter sw = new StreamWriter(Pathname))
            {
                sw.Write(result2);
            }
        }
    }
}