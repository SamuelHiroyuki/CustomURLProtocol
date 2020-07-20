using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace CustomURLProtocol
{
    class Program
    {
        static void Main(string[] args)
        {
            string appName = "CustomURLProtocol";
            string appPath = @"C:\Users\Samuel Hiroyuki\source\repos\CustomURLProtocol\CustomURLProtocol\bin\Debug\netcoreapp3.1\CustomURLProtocol.exe";

            RegistryKey key = Registry.ClassesRoot.OpenSubKey(appName);  //open myApp protocol's subkey

            if (key == null)  //if the protocol is not registered yet...we register it
            {
                key = Registry.ClassesRoot.CreateSubKey(appName);
                key.SetValue(string.Empty, "URL: " + appName + " Protocol");
                key.SetValue("URL Protocol", string.Empty);

                key = key.CreateSubKey(@"shell\open\command");
                key.SetValue(string.Empty, appPath + " " + "%1");
                //%1 represents the argument - this tells windows to open this program with an argument / parameter
            }

            key.Close();
        }
    }
}
