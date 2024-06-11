using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace _projeto01 {
    public class ExportToFile {

        private const string dir = @"C:\Users\386188\Desktop\Lucas Zanotto\teste01\";
        public static bool SaveToDelimitedTxt(string fileName, string fileContent) {
            string filePath = $@"{dir}\{fileName}";

            try
            {
                if(!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                using(StreamWriter sw = File.CreateText(filePath)) {
                    sw.Write(fileContent);
                }

                return true;         
            }
            catch (System.Exception)
            {
               return false; 
            }
        }
    }

}