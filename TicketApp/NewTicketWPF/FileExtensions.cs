using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NewTicketWPF
{

    public static class FileExtensions
    {

        public static List<Profile> LoadAllProfile(this List<Profile> profiles)
        {
            try
            {
                profiles = new List<Profile>();
                TicketManagement tm = new TicketManagement();
                if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Profiles"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Profiles");
                }
                string[] allProfiles = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Profiles");
                string readFile = null;
                string[] streamLine = null;
                string[] rows = null;
                string name = null;
                for (int i = 0; i < allProfiles.Length; i++)
                {
                    if (allProfiles[i].Contains(".csv"))
                    {
                        tm = new TicketManagement();
                        readFile = File.ReadAllText(allProfiles[i]);
                        name = readFile.Substring(0, readFile.IndexOf(':'));
                        readFile = readFile.Substring(readFile.IndexOf(':') + 1);
                        streamLine = readFile.Split('\n');
                        foreach (var prop in streamLine)
                        {
                            if (prop == "")
                            {
                                break;
                            }
                            rows = prop.Split(',');
                            tm.tickets.Add(new Ticket(int.Parse(rows[0]), rows[1], bool.Parse(rows[2]), bool.Parse(rows[3]),int.Parse(rows[4])));
                        }
                        profiles.Add(new Profile(tm, name));
                    }
                }
                return profiles;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return new List<Profile>();
            }
        }

        public static Profile LoadFirstProfile(this Profile profile)
        {
            try
            {
                profile = new Profile();
                TicketManagement tm = new TicketManagement();
                if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Profiles"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Profiles");
                }
                string[] allProfile = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Profiles");
                string readFile = null;
                string[] streamLine = null;
                string[] rows = null;
                string name = null;
                if (allProfile[0].Contains(".csv"))
                {
                    readFile = File.ReadAllText(allProfile[0]);
                    name = readFile.Substring(0, readFile.IndexOf(':'));
                    readFile = readFile.Substring(readFile.IndexOf(':') + 1);
                    streamLine = readFile.Split('\n');
                    foreach (var elements in streamLine)
                    {
                        if (elements == "")
                        {
                            break;
                        }
                        rows = elements.Split(',');
                        tm.tickets.Add(new Ticket(int.Parse(rows[0]), rows[1], bool.Parse(rows[2]), bool.Parse(rows[3]), int.Parse(rows[4])));
                    }
                    profile = new Profile(tm, name);
                    return profile;
                }
                return new Profile();
            }
            catch (Exception)
            {
                MessageBox.Show("The \"Tickets\" folder is empty or the containing files is not readable.\n Try runing the program as administrator.", "File Reading Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public static Profile LoadSelectedProfile(this Profile profile, PData pData)
        {
            try
            {
                TicketManagement tm = new TicketManagement();
                profile = new Profile();
                string reader = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Profiles\\" + pData.PName + ".csv");
                string[] lines = reader.Split('\n');
                string[] pr = null;
                foreach (var prop in lines)
                {
                    if (prop == "")
                    {
                        break;
                    }
                    pr = prop.Split(',');
                    pr[0] = pr[0].Substring(pr[0].IndexOf(':') + 1);
                    tm.tickets.Add(new Ticket(int.Parse(pr[0]), pr[1], bool.Parse(pr[2]), bool.Parse(pr[3]), int.Parse(pr[4])));
                }
                profile = new Profile(tm, pData.PName);
                return profile;
            }
            catch (Exception e)
            {
                return profile.LoadFirstProfile();
            }
        }

        public static void SaveAllTickets(this List<Profile> profiles)
        {
            try
            {
                foreach (var profile in profiles)
                {
                    profile.SaveProfile();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void SavePData(this Profile profile, int value)
        {
            string fileContains = value.ToString() + "," + profile.ProfileName;
            File.WriteAllText(Directory.GetCurrentDirectory() + "\\PData.csv", fileContains);
        }

        public static PData LoadPData(this PData pData)
        {
            try
            {
                string file = File.ReadAllText(Directory.GetCurrentDirectory() + "\\PData.csv");
                string[] data = file.Split(',');
                pData = new PData(int.Parse(data[0]), data[1]);
                return pData;
            }
            catch (Exception e)
            {
                MessageBox.Show("Missing file \"PData.csv\".", "Load Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public static bool Savable(this string myString)
        {
            char[] format = { ' ', ',', '.', ':', '/', '\\', '*', '?', '\"', '|' };
            for (int i = 0; i < format.Length; i++)
            {
                if (myString.Contains(format[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ProfileExists(this string pName)
        {
            List<Profile> pf = new List<Profile>();
            pf = pf.LoadAllProfile();
            foreach (var p in pf)
            {
                if (p.ProfileName.Equals(pName))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ProfileExists(this bool checker)
        {
            try
            {
                string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Profiles");
                if (files.Length == 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public static void MakeRootDirectory(this Profile profile)
        {
            string directory = Directory.GetCurrentDirectory() + "\\Profiles";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
        }

        public static Profile LoadProfileWithPData(this Profile profile)
        {
            try
            {
                PData data = new PData();
                data = data.LoadPData();
                if (data == null)
                {
                    profile = profile.LoadFirstProfile();
                }
                profile = profile.LoadSelectedProfile(data);
                if (profile == null)
                {
                    return new Profile();
                }
                return profile;
            }
            catch(Exception e)
            {
                return new Profile();
            }
        }

        public static bool EmptyCheck(this Profile profile)
        {
            try
            {
                string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Profiles");
                if (files.Length == 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Profile LoadCurrentProfile(this Profile profile)
        {
            try
            {

                return profile;
            }
            catch(Exception)
            {
                return new Profile();
            }
        }

        public static bool CheckPDataExists(this bool exist)
        {
            try
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "PData.csv"))
                {
                    return true;
                }
                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }


    }
}
