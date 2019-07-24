using System;
using System.Management;
using System.Security.Cryptography;
using System.Security;
using System.Collections;
using System.Text;

namespace MusicScalesPractice
{
    /// <summary>
    /// Generates a 8 byte Unique Identification code of a computer
    /// Example: 4876-8DB5-EE85-69D3-FE52-8CF7-395D-2EA9
    /// </summary>
    public class FingerPrint
    {
        private static string fingerPrint = string.Empty;
        private static string sequence = "L28HDK5UIPCSW3YXFT6RABZ01NO7EMJQ9V4G";
        private static int step = 7;
        public static string Value()
        {
            if (string.IsNullOrEmpty(fingerPrint))
            {
                fingerPrint = GetHash("CPU >> " + cpuId() + "\nBIOS >> " + biosId() + "\nBASE >> " + baseId() + videoId());
            }
            return fingerPrint.Substring(0, 9);
        }

        //Returns true if the code is correct
        public static bool Decrypt(string code)
        {
            if (code.Length != 8) { return false; }
            string challengeCode = Value().Replace("-", "");
            string needToReturn = "";
            foreach (char ch in code)
            {
                if (ch != '-')
                {
                    needToReturn += GetPrevChar(ch);
                }
            }
            return challengeCode.Equals(needToReturn);
        }

        //To Decrypt we need to go to the forward of the sequence
        private static char GetPrevChar(char ch)
        {
            int currIndexInSeq = sequence.IndexOf(ch);
            for (int i=0; i<step; i++)
            {
                if (currIndexInSeq+1 == sequence.Length)
                {
                    currIndexInSeq = 0;
                }
                else
                {
                    currIndexInSeq++;
                }
            }
            return sequence[currIndexInSeq];
        }

        /// <summary>
        /// Returns hash of string s
        /// </summary>
        private static string GetHash(string s)
        {
            MD5 sec = new MD5CryptoServiceProvider();
            ASCIIEncoding enc = new ASCIIEncoding();
            byte[] bt = enc.GetBytes(s);
            return GetHexString(sec.ComputeHash(bt));
        }
        private static string GetHexString(byte[] bt)
        {
            string s = string.Empty;
            for (int i = 0; i < bt.Length; i++)
            {
                byte b = bt[i];
                int n, n1, n2;
                n = (int)b;
                n1 = n & 15;
                n2 = (n >> 4) & 15;
                if (n2 > 9)
                    s += ((char)(n2 - 10 + (int)'A')).ToString();
                else
                    s += n2.ToString();
                if (n1 > 9)
                    s += ((char)(n1 - 10 + (int)'A')).ToString();
                else
                    s += n1.ToString();
                if ((i + 1) != bt.Length && (i + 1) % 2 == 0) s += "-";
            }
            return s;
        }
        #region Original Device ID Getting Code

        //private static string Identifier(string wmiClass, string wmiProperty, string wmiMustBeTrue)
        //{
        //    string result = "";
        //    ManagementClass mc = new ManagementClass(wmiClass);
        //    ManagementObjectCollection moc = mc.GetInstances();
        //    foreach (ManagementObject mo in moc)
        //    {
        //        if (mo[wmiMustBeTrue].ToString() == "True")
        //        {
        //            //Only get the first one
        //            if (result == "")
        //            {
        //                try
        //                {
        //                    result = mo[wmiProperty].ToString();
        //                    break;
        //                }
        //                catch
        //                {
        //                    //do nothing
        //                }
        //            }
        //        }
        //    }
        //    return result;
        //}


        /// <summary>
        /// Returns a hardware identifier
        /// </summary>
        private static string Identifier(string wmiClass, string wmiProperty)
        {
            string result = "";
            ManagementClass mc = new ManagementClass(wmiClass);
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                //Only get the first one
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Returns the cpu identifier string
        /// </summary>
        /// <returns></returns>
        private static string cpuId()
        {
            //Uses first CPU identifier available in order of preference
            //Don't get all identifiers, as it is very time consuming
            string retVal = Identifier("Win32_Processor", "UniqueId");
            if (retVal == "") //If no UniqueID, use ProcessorID
            {
                retVal = Identifier("Win32_Processor", "ProcessorId");
                if (retVal == "") //If no ProcessorId, use Name
                {
                    retVal = Identifier("Win32_Processor", "Name");
                    if (retVal == "") //If no Name, use Manufacturer
                    {
                        retVal = Identifier("Win32_Processor", "Manufacturer");
                    }
                    //Add clock speed for extra security
                    retVal += Identifier("Win32_Processor", "MaxClockSpeed");
                }
            }
            return retVal;
        }

        //BIOS Identifier
        private static string biosId()
        {
            return Identifier("Win32_BIOS", "Manufacturer")
            + Identifier("Win32_BIOS", "SMBIOSBIOSVersion")
            + Identifier("Win32_BIOS", "IdentificationCode")
            + Identifier("Win32_BIOS", "SerialNumber")
            + Identifier("Win32_BIOS", "ReleaseDate")
            + Identifier("Win32_BIOS", "Version");
        }

        //Main physical hard drive ID
        private static string diskId()
        {
            return Identifier("Win32_DiskDrive", "Model")
            + Identifier("Win32_DiskDrive", "Manufacturer")
            + Identifier("Win32_DiskDrive", "Signature")
            + Identifier("Win32_DiskDrive", "TotalHeads");
        }

        //Motherboard ID
        private static string baseId()
        {
            return Identifier("Win32_BaseBoard", "Model")
            + Identifier("Win32_BaseBoard", "Manufacturer")
            + Identifier("Win32_BaseBoard", "Name")
            + Identifier("Win32_BaseBoard", "SerialNumber");
        }

        //Primary video controller ID
        private static string videoId()
        {
            return Identifier("Win32_VideoController", "DriverVersion")
            + Identifier("Win32_VideoController", "Name");
        }

        //First enabled network card ID
        //private static string macId()
        //{
        //    return Identifier("Win32_NetworkAdapterConfiguration",
        //        "MACAddress", "IPEnabled");
        //}
        #endregion
    }
}
