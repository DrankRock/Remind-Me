using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindMeApp
{
    using System;
    using System.Collections.Generic;

    public static class LanguageManager
    {
        // Dictionary to store language texts with keys as "identifier_language"
        private static readonly Dictionary<string, string> languageTexts = new Dictionary<string, string>();

        // Method to add or update a text for a specific language
        public static void AddText(string identifier, string language, string text)
        {
            string key = GenerateKey(identifier, language);
            languageTexts[key] = text;
        }

        // Method to get a text by its identifier and language
        public static string GetText(string identifier, string language)
        {
            string key = GenerateKey(identifier, language);

            if (languageTexts.TryGetValue(key, out string text))
            {
                return text;
            }
            else
            {
                // Return a default or fallback text if not found
                return $"[{identifier}]";
            }
        }

        // Helper method to generate dictionary keys
        private static string GenerateKey(string identifier, string language)
        {
            return $"{identifier}_{language}".ToLower();
        }

        // Method to load default texts for demonstration purposes
        public static void LoadDefaultTexts()
        {
            AddText("ev1", "English", "Events Happening !");
            AddText("del1", "English", "Deleting an event is permanent, do you wish to delete this event ?");
            AddText("conf1", "English", "Please Confirm");
            AddText("name", "English", "Remind Me!");
            AddText("exit", "English", "Exit");
            AddText("open", "English", "Open");
            AddText("fol1", "English", "The following event(s) are happening today : \n");
            AddText("in", "English", "in ");
            AddText("days", "English", " days");
            AddText("cancel", "English", "Cancel");
            AddText("continue", "English", "Continue");
            AddText("name2", "English", "Name");
            AddText("noEmpty", "English", "Name can't be empty !");
            AddText("lang", "English", "Language");
            AddText("settings", "English", "Settings");
            AddText("about", "English", "About");

            AddText("ev1", "German", "Ereignisse geschehen!");
            AddText("del1", "German", "Das Löschen eines Ereignisses ist dauerhaft, möchten Sie dieses Ereignis löschen?");
            AddText("conf1", "German", "Bitte bestätigen");
            AddText("name", "German", "Erinnere mich!");
            AddText("exit", "German", "Beenden");
            AddText("open", "German", "Öffnen");
            AddText("fol1", "German", "Die folgenden Ereignisse finden heute statt:\n");
            AddText("in", "German", "in ");
            AddText("days", "German", " Tage");
            AddText("cancel", "German", "Abbrechen");
            AddText("continue", "German", "Fortfahren");
            AddText("name2", "German", "Name");
            AddText("noEmpty", "German", "Name darf nicht leer sein!");
            AddText("lang", "German", "Sprache");
            AddText("settings", "German", "Einstellungen");
            AddText("about", "German", "Über");


            AddText("ev1", "French", "Événements en cours !");
            AddText("del1", "French", "La suppression d'un événement est permanente, souhaitez-vous supprimer cet événement ?");
            AddText("conf1", "French", "Veuillez confirmer");
            AddText("name", "French", "Rappelle-moi!");
            AddText("exit", "French", "Quitter");
            AddText("open", "French", "Ouvrir");
            AddText("fol1", "French", "Les événements suivants se produisent aujourd'hui :\n");
            AddText("in", "French", "dans ");
            AddText("days", "French", " jours");
            AddText("cancel", "French", "Annuler");
            AddText("continue", "French", "Continuer");
            AddText("name2", "French", "Nom");
            AddText("noEmpty", "French", "Le nom ne peut pas être vide !");
            AddText("lang", "French", "Langue");
            AddText("settings", "French", "Paramètres");
            AddText("about", "French", "À propos");


        }
    }

}
