using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Crestron.SimplSharp;
using Crestron.SimplSharp.CrestronIO;
using Newtonsoft.Json;

namespace jsFetch
{



#region Build json object

    public class Key
    {
        public ushort Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Command { get; set; }
        public string Test { get; set; }
    }

    public class jsonObject
    {
       public List<Key> Config { get; set; }
    }


#endregion

#region Event arguments for returnItemValue

    public class itemValue : EventArgs
    {
        public ushort Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Command { get; set; }
    }
#endregion

    public class jsonReadWrite
    {
        jsonObject data = new jsonObject();
        
        string fileData = "{\"Config\":[{\"Number\":1,\"Name\":\"None\",\"Command\":\"None\",\"Description\":\"Please check file path.\"}]}"; //Put somthing in fileData for default output
        string filePath = "";

#region Read json config file
        public void Initialize( string fileLocation)
        {
             filePath = fileLocation;

            CrestronConsole.PrintLine("[jsonReadWrite] Attempting to access configuration file. \r\n");
            if (File.Exists(filePath))
            {
                fileData = File.ReadToEnd(filePath, Encoding.ASCII);
                CrestronConsole.PrintLine("[jsonReadWrite] Config file Found, Reading... \r\n");
            }
            else
                CrestronConsole.PrintLine("[jsonReadWrite] Config file not found, loading default. Check your file path. \r\n");

            DeserializeJson();
        }

        public void DeserializeJson()
        {
            try
            {
                if (fileData != "" && fileData != null)
                {
                    data = JsonConvert.DeserializeObject<jsonObject>(fileData);
                    CrestronConsole.PrintLine("File Read... \r\n");
                }
                else
                {
                    ErrorLog.Error("Nothing to deserialize");
                    CrestronConsole.PrintLine("File is Empty... \r\n");
                }
            }
            catch (Exception e)
            {
                ErrorLog.Error("Error Converting file contents of jsonObject = {0}", e.Message);
            }

        }

        public ushort GetNumberOfNames()
        {
            ushort number = (ushort)data.Config.Count;
            return number;
        }
#endregion

#region Fetch json item values

        public event EventHandler<itemValue> returnItemValue;

        public void fetchName(string searchName)
        {
            itemValue value = new itemValue();

            if (data.Config != null)
            {
                foreach (Key item in data.Config)
                {
                    value.Number = item.Number;
                    value.Name = item.Name;
                    value.Description = item.Description;
                    value.Command = item.Command;
                    if (value.Name == searchName)
                    {
                        if (returnItemValue != null)
                        {
                            returnItemValue(this, value);
                        }
                    }
                }
            }
        }
#endregion

#region Add a name to json config file

        public void AddName(string _Name, string _Command, string _Description)
        {
            ushort count = GetNumberOfNames();

            if (count + 1 <= 150)
            {
                data.Config.Add(new Key()
                {
                    Number = (ushort)(count + 1),
                    Name = _Name,
                    Description = _Description,
                    Command = _Command,
                });
                UpdateJSON();
            }
            else
                ErrorLog.Error("JSON file to large");
        }

#endregion

#region Remove a name from json config file

        public void RemoveName()
        {
            ushort count = GetNumberOfNames();

            if (count - 1 >= 0)
            {
                data.Config.RemoveAt(count - 1);
                UpdateJSON();
            }
            else
                CrestronConsole.PrintLine("[jsonReadWrite] JSON file empty. \r\n");
        }
#endregion
     
#region Save json file

        public void UpdateJSON()
        {
            string jsonToSave;
            FileStream saveToFile;

            saveToFile = new FileStream(filePath, FileMode.Create);

            try
            {
                jsonToSave = JsonConvert.SerializeObject(data);

                saveToFile.Write(jsonToSave, Encoding.ASCII);
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("Error saving Contacts to File, Reason: {0}", e.Message);
            }
            finally
            {
                saveToFile.Close();
            }
        }
#endregion
    
    }

}