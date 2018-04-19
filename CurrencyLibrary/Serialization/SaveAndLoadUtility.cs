using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLibrary.Serialization
{
    public class SaveAndLoadUtility
    {
        public static bool DirectoryExists(string path, bool createDirectory = true)
        {
            if(!Directory.Exists(path))
            {
                if(createDirectory)
                {
                    Directory.CreateDirectory(path);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public static bool FileExists(string path)
        {
            return (path != null && File.Exists(path));
        }

        public static void Save<T>(T itemToSave, string path)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path,
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, itemToSave);
        }

        public static T Load<T>(string path)
        {
            if(FileExists(path))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path,
                                          FileMode.Open,
                                          FileAccess.Read,
                                          FileShare.Read);
                T loadedObject = (T)formatter.Deserialize(stream);
                stream.Close();
                return loadedObject;
            }
            else
            {
                Console.Error.WriteLine($"File does not exist as path {path}!");
                return default(T);
            }
        }
    }
}
