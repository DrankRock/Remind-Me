using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

// Made by the bro gpt. Modified by him too

namespace RemindMeApp
{
    public static class UserDataManager
    {
        private static readonly string xmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "userData.xml");

        // Method to ensure the XML file exists; if not, create it
        private static void EnsureXmlFileExists()
        {
            if (!File.Exists(xmlFilePath))
            {
                using (XmlWriter writer = XmlWriter.Create(xmlFilePath))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("AppData"); // Root element for app data
                    writer.WriteStartElement("Events"); // Events sub-root element
                    writer.WriteEndElement();
                    writer.WriteElementString("Language", "English"); // Default language
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }

        // Method to add a new event data entry
        public static void WriteData(string eventName, DateTime eventDate)
        {
            EnsureXmlFileExists();

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath);

            // Find the Events element
            XmlNode eventsNode = doc.SelectSingleNode("/AppData/Events");

            // Create a new event element
            XmlElement eventElement = doc.CreateElement("Event");

            // Create and append the event name element
            XmlElement nameElement = doc.CreateElement("Name");
            nameElement.InnerText = eventName;
            eventElement.AppendChild(nameElement);

            // Create and append the event date element
            XmlElement dateElement = doc.CreateElement("Date");
            dateElement.InnerText = eventDate.ToString("yyyy-MM-dd HH:mm");
            eventElement.AppendChild(dateElement);

            // Append the event element to the Events node
            eventsNode.AppendChild(eventElement);

            // Save the changes to the XML file
            doc.Save(xmlFilePath);
        }

        // Method to read all event data entries
        public static Dictionary<string, DateTime> ReadData()
        {
            EnsureXmlFileExists();

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath);

            Dictionary<string, DateTime> eventData = new Dictionary<string, DateTime>();

            // Iterate through all event elements under Events
            foreach (XmlNode eventNode in doc.SelectNodes("/AppData/Events/Event"))
            {
                string eventName = eventNode["Name"].InnerText;
                DateTime eventDate = DateTime.ParseExact(eventNode["Date"].InnerText, "yyyy-MM-dd HH:mm", null);

                eventData[eventName] = eventDate;
            }

            return eventData;
        }

        // Method to remove an event data entry
        public static void RemoveData(string eventName, DateTime eventDate)
        {
            EnsureXmlFileExists();

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath);

            XmlNode eventToRemove = null;

            // Search for the event node to remove
            foreach (XmlNode eventNode in doc.SelectNodes("/AppData/Events/Event"))
            {
                string name = eventNode["Name"].InnerText;
                DateTime date = DateTime.ParseExact(eventNode["Date"].InnerText, "yyyy-MM-dd HH:mm", null);

                if (name == eventName && date == eventDate)
                {
                    eventToRemove = eventNode;
                    break;
                }
            }

            if (eventToRemove != null)
            {
                eventToRemove.ParentNode.RemoveChild(eventToRemove);
                doc.Save(xmlFilePath);
            }
            else
            {
                throw new ArgumentException("Event not found.");
            }
        }

        // Method to modify an existing event data entry
        public static void ModifyData(string oldName, DateTime oldDate, string newName, DateTime newDate)
        {
            EnsureXmlFileExists();

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath);

            XmlNode eventToModify = null;

            // Search for the event node to modify
            foreach (XmlNode eventNode in doc.SelectNodes("/AppData/Events/Event"))
            {
                string name = eventNode["Name"].InnerText;
                DateTime date = DateTime.ParseExact(eventNode["Date"].InnerText, "yyyy-MM-dd HH:mm", null);

                if (name == oldName && date == oldDate)
                {
                    eventToModify = eventNode;
                    break;
                }
            }

            if (eventToModify != null)
            {
                // Modify the event name and date
                eventToModify["Name"].InnerText = newName;
                eventToModify["Date"].InnerText = newDate.ToString("yyyy-MM-dd HH:mm");

                // Save the changes to the XML file
                doc.Save(xmlFilePath);
            }
            else
            {
                throw new ArgumentException("Event not found.");
            }
        }

        // Method to set the application's language
        public static void SetLanguage(string language)
        {
            // Validate the language input
            if (language != "English" && language != "German" && language != "French")
            {
                throw new ArgumentException("Invalid language. Choose from: English, German, French.");
            }

            EnsureXmlFileExists();

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath);

            XmlNode languageNode = doc.SelectSingleNode("/AppData/Language");

            // Update the language if it exists, otherwise create it
            if (languageNode != null)
            {
                languageNode.InnerText = language;
            }
            else
            {
                XmlElement newLanguageElement = doc.CreateElement("Language");
                newLanguageElement.InnerText = language;
                doc.DocumentElement.AppendChild(newLanguageElement);
            }

            // Save the changes to the XML file
            doc.Save(xmlFilePath);
        }

        // Method to get the application's current language
        public static string GetLanguage()
        {
            EnsureXmlFileExists();

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath);

            XmlNode languageNode = doc.SelectSingleNode("/AppData/Language");

            // Return the language if it exists, otherwise return default
            return languageNode != null ? languageNode.InnerText : "English";
        }
    }
}