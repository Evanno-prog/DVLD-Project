using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using DVLD_BussinessLayer;

namespace DVLD_WinForm_PresentationLayer.Global_Classes
{
    internal static class clsGlobal
    {
        public static clsUser CurrentUser;
   
        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            /////////////////////////[My Solution]/////////////////////////////////
            
            // Specify the Registry key and path
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
            try
            {
                // Write the UserName and Password to the Registry
                Registry.SetValue(keyPath, "UserName", Username, RegistryValueKind.String);
                Registry.SetValue(keyPath, "Password", Password, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

            //////////////////////////[Another Solution]///////////////////////////
            //try
            //{
            //    string KeyName = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
            //    string ValueName = "LastLogIn";
            //    string ValueData = Registry.GetValue(KeyName, ValueName, null) as string;
            //    if (Username == "" && !string.IsNullOrEmpty(ValueData))
            //    {
            //        ValueData = "";
            //        Registry.SetValue(KeyName, ValueName, ValueData, RegistryValueKind.String);
            //        return true;
            //    }
            //    ValueData = Username + "#//#" + Password;
            //    Registry.SetValue(KeyName, ValueName, ValueData, RegistryValueKind.String);
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"An error occurred: {ex.Message}");
            //    return false;
            //}

        }
        public static bool GetStoredCredential(ref string Username, ref string Password)
        {

            //////////////////////////[My Solution]///////////////////////////

            // Specify the Registry key and path
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
            try
            {
                // Read the value from the Registry
                 Username = Registry.GetValue(keyPath, "UserName", "") as string;
                 Password = Registry.GetValue(keyPath, "Password", "") as string;
                if (Username == "" || Password == "") 
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

            //////////////////////////[Another Solution]///////////////////////////

            //this will get the stored username and password and will return true if found and false if not found.
            //try
            //{
            //    string KeyName = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
            //    string ValueName = "LastLogIn";
            //    string Value = Registry.GetValue(KeyName, ValueName, null) as string;
            //    if (!string.IsNullOrEmpty(Value))
            //    {

            //        string[] result = Value.Split(new string[] { "#//#" }, StringSplitOptions.None);
            //        Username = result[0];
            //        Password = result[1];
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"An error occurred: {ex.Message}");
            //    return false;
            //}

        }
    }
}
